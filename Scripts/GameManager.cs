using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject playerHelicopter;
    [SerializeField] private GameObject finishLineHelicopter;
    [SerializeField] private NPC npc;
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private CreditManager creditManager;
    [SerializeField] private ShieldManager shieldManager;
    [SerializeField] private WeaponShopManager weaponShopManager;
    [SerializeField] private RankManager rankManager;
    [SerializeField] private HelicopterRankManager helicopterRankManager;
    [SerializeField] private PrizeManager prizeManager;
    [SerializeField] private CameraManager cameraManager;

    public int currentLevel = 1;
    public int levelToUnlock = 2;

    private int killCount;
    private int levelReached;
    private Checkpoint checkpoint;
    private string levelReachPlayerPrefsName = "levelReached";
    private int isPlayNewSong; // 0 is false.
    private string isPlayNewSongPlayerPrefsName = "isPlayNewSong";
    private AdsInitializer adsInitializer;
    private AdsManager adsManager;

    // Game States.
    public static bool isReadyToShoot;
    public static bool isGameOver;
    public static bool isLevelComplete;
    public static bool isPaused;
    public static bool isDoingEndOfLevelAnimation;
    public static bool isExitingLevel;

    private bool isOneStageLevel;
    private bool isTwoStageLevel;
    private bool isThreeStageLevel;

    // Analytics.
    private string levelStartedEventName = "levelStarted";
    private string levelCompleteEventName = "levelComplete";

    private void Awake()
    {
        //PlayerPrefs.DeleteKey(levelReachPlayerPrefsName);
        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        if (levelReached < currentLevel)
        {
            levelReached = currentLevel;
            PlayerPrefs.SetInt(levelReachPlayerPrefsName, levelReached);
        }

        isPlayNewSong = 0;
        PlayerPrefs.SetInt(isPlayNewSongPlayerPrefsName, isPlayNewSong);
        ResetGameStates();
        ScanForCheckpoint();
    }

    // Start is called before the first frame update
    void Start()
    {
        levelUI.SetLevelText(currentLevel);
        levelUI.SetCurrentCreditsCountText(creditManager.GetCreditCount());
        levelUI.SetKillCountText(GetKillCount());
        if (currentLevel == 1)
        {
            levelUI.SetShieldImageActive(false);
        } else
        {
            levelUI.SetCurrentShieldCountText(shieldManager.GetShieldCount());
        }
        itemManager.SetPlayerAsCaller();
        itemManager.EquipItems();
        creditManager.CheckForMultiplyCreditsLevel(currentLevel);
        if (levelReached >= 11)
        {
            levelUI.SetStartLevelMapVisuals(currentLevel);
            if (levelReached == 15 || levelReached == 25)
            {
                levelUI.ShowBossBanner();
            }
        }

        adsManager = FindObjectOfType<AdsManager>();
        if (adsManager != null)
        {
            //if (adsManager.GetHasCompletedFirstPurchase() == 0)
            {
                adsInitializer = FindObjectOfType<AdsInitializer>();
            }
        }

        if (PlayerPrefs.GetInt(levelStartedEventName + currentLevel, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "userLevel", currentLevel },
            };
            AnalyticsService.Instance.CustomData(levelStartedEventName, parameters);
            PlayerPrefs.SetInt(levelStartedEventName + currentLevel, 1);
        }
    }

    public void SlowTime()
    {
        if (!isPaused)
        {
            Time.timeScale = 0.3f;
        }
    }

    public void FreezeTime()
    {
        Time.timeScale = 0f;
    }

    public void ResumeTime()
    {
        if (!TutorialManager.isBridgeTutorialActive || !TutorialManager.isExplodeTutorialActive || !TutorialManager.isFallTutorialActive || !TutorialManager.isGlassTutorialActive || !TutorialManager.isShootingTutorialActive)
        if (!isPaused)
        {
            if (ZombieController.numberOfAlertedZombies <= 0 && !isDoingEndOfLevelAnimation || isGameOver)
            {
                Time.timeScale = 1;
            }
            else
            {
                SlowTime();
            }
        }
        else
        {
            if (isExitingLevel)
            {
                Time.timeScale = 1;
            }
        }
    }

    public void StartSlowMo(float duration)
    {
        StartCoroutine(SlowTimeWaitResumeTime(duration));
    }

    public IEnumerator SlowTimeWaitResumeTime(float delay)
    {
        SlowTime();

        yield return new WaitForSecondsRealtime(delay);

        if (!isGameOver && !isLevelComplete)
        {
            ResumeTime();
        }
    }

    public void LevelComplete()
    {
        if (!isGameOver)
        {
            RenderSettings.fog = false;

            isPlayNewSong = 1;
            PlayerPrefs.SetInt(isPlayNewSongPlayerPrefsName, isPlayNewSong);
            isLevelComplete = true;
            isDoingEndOfLevelAnimation = true;
            StartCoroutine(WaitEnableLevelCompleteUI(1.5f));
            cameraManager.EnableLevelCompleteCam();
            player.ClearAllPlayerBulletProjectiles();
            //player.ClearAllPlayerBulletTrails();
            player.gameObject.SetActive(false);
            playerHelicopter.gameObject.SetActive(false);
            finishLineHelicopter.gameObject.SetActive(true);
            npc.gameObject.SetActive(true);
            SlowTime();
            creditManager.AddCredits(30);
            creditManager.SaveCreditCount();
            creditManager.SetEndLevelCreditCount(creditManager.GetCreditCount());
            if (isOneStageLevel)
            {
                levelUI.SetStage_01_Passed();
            }
            else if (isTwoStageLevel)
            {
                levelUI.SetStage_02_Passed();
            }
            else if (isThreeStageLevel)
            {
                levelUI.SetStage_03_Passed();
            }
            if (currentLevel == 6 + levelUI.GetNumberOfLevelsSkipped())
            {
                rankManager.SetMale_01SkinAsOffered();
            }
            if (currentLevel == 11 + levelUI.GetNumberOfLevelsSkipped())
            {
                rankManager.SetHomelessSkinAsOffered();
            }
            if (currentLevel == 16 + levelUI.GetNumberOfLevelsSkipped())
            {
                helicopterRankManager.SetHelicopter_02SkinAsOffered();
            }
            if (currentLevel == 21 + levelUI.GetNumberOfLevelsSkipped())
            {
                rankManager.SetBikerSkinAsOffered();
            }
            //if (currentLevel == 23 + levelUI.GetNumberOfLevelsSkipped())
            //{
            //    int isSecondPackPurchased = PlayerPrefs.GetInt("secondPackPurchased", 0);
            //    int isSecondPackExpired = PlayerPrefs.GetInt("secondPackExpired", 0);
            //    int isThirdPackPurchased = PlayerPrefs.GetInt("thirdPackPurchased", 0);
            //    int isThirdPackExpired = PlayerPrefs.GetInt("thirdPackExpired", 0);
            //    if (isSecondPackPurchased == 0 && isSecondPackExpired == 1)
            //    {
            //        PlayerPrefs.SetInt("secondPackExpired", 0);
            //    } else if (isThirdPackPurchased == 0 && isThirdPackExpired == 1)
            //    {
            //        PlayerPrefs.SetInt("thirdPackExpired", 0);
            //    }
            //}
            if (currentLevel == 26 + levelUI.GetNumberOfLevelsSkipped())
            {
                rankManager.SetFemale_01SkinAsOffered();
            }
            //if (currentLevel == 30 + levelUI.GetNumberOfLevelsSkipped())
            //{
            //    int isSecondPackPurchased = PlayerPrefs.GetInt("secondPackPurchased", 0);
            //    int isSecondPackExpired = PlayerPrefs.GetInt("secondPackExpired", 0);
            //    int isThirdPackPurchased = PlayerPrefs.GetInt("thirdPackPurchased", 0);
            //    int isThirdPackExpired = PlayerPrefs.GetInt("thirdPackExpired", 0);
            //    if (isSecondPackPurchased == 0 && isSecondPackExpired == 1)
            //    {
            //        PlayerPrefs.SetInt("secondPackExpired", 0);
            //    }
            //    else if (isThirdPackPurchased == 0 && isThirdPackExpired == 1)
            //    {
            //        PlayerPrefs.SetInt("thirdPackExpired", 0);
            //    }
            //}
            if (currentLevel == 31 + levelUI.GetNumberOfLevelsSkipped())
            {
                helicopterRankManager.SetHelicopter_04SkinAsOffered();
            }
            ClearFoundCheckpoint();
            IncreaseLevelReached();
            LevelUI.wasReviveBtnClicked = false;

            if (PlayerPrefs.GetInt(levelCompleteEventName + currentLevel, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                        {  "userLevel", currentLevel },
                };
                AnalyticsService.Instance.CustomData(levelCompleteEventName, parameters);
                PlayerPrefs.SetInt(levelCompleteEventName + currentLevel, 1);
            }
        }
    }

    public void GameOver()
    {
        if (!isLevelComplete)
        {
            isGameOver = true;
            levelUI.SetGameOverPanelActive(true);
            levelUI.SetGameUIActive(false);
            if (currentLevel == 1)
            {
                levelUI.SetSkipLevelBtnActive(false);
            }
            player.ConstrainPlayer(false);
            FindObjectOfType<RunnerController>().SetHelpWordBubbleImageActive(false);
            cameraManager.ClearTargetGroup();
            if (AdsInitializer.isInitialized && BannerAd.isShowing)
            {
                adsInitializer.HideBannerAd();
            }
        }
    }

    public IEnumerator WaitEnableLevelCompleteUI(float delay)
    {
        yield return new WaitForSeconds(delay);

        isDoingEndOfLevelAnimation = false;
        if (AdsInitializer.isInitialized && BannerAd.isShowing)
        {
            adsInitializer.HideBannerAd();
        }

        if (currentLevel < 10)
        {
            rankManager.CheckForRankLevel(currentLevel);
            prizeManager.CheckIfPrizeLevel(currentLevel);
            if (!rankManager.GetIsRankLevel())
            {
                if (!prizeManager.GetIsPrizeLevel())
                {
                    weaponShopManager.CheckForWeaponShopOffer(currentLevel);
                }
                else
                {
                    levelUI.ShowPrizeMenu();
                    levelUI.SetContinueBtnActive(false);
                }
                levelUI.SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                if (!creditManager.GetIsMultiplyCreditsLevel())
                {
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                }
                else
                {
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                    levelUI.SetMultiplyCreditsEarnedBtnActive(true);
                    levelUI.SetMultiplyCreditsArrowImageActive(true);
                }
            }
        } else
        {
            levelUI.SetEndLevelMapVisuals(currentLevel);
        }
        levelUI.SetGameUIActive(false);
        levelUI.SetLevelCompletePanelActive(true);
        levelUI.SetLevelCompletedText(currentLevel);
        if (currentLevel == 1)
        {
            levelUI.SetShieldImageActive(true);
        }
        FreezeTime();
    }

    public void IncreaseKillCount()
    {
        killCount++;
        levelUI.SetKillCountText(GetKillCount());
        levelUI.IncreaseKillCountScale(.005f);
    }

    public void PauseGame()
    {
        isPaused = true;
        levelUI.SetPausePanelActive(true);
        FreezeTime();
    }

    public void UnpauseGame()
    {
        isPaused = false;
        levelUI.SetPausePanelActive(false);
        ResumeTime();
    }

    public void ResetGameStates()
    {
        isReadyToShoot = false;
        isGameOver = false;
        isLevelComplete = false;
        isPaused = false;
        killCount = 0;
        ZombieController.numberOfAlertedZombies = 0;
        isDoingEndOfLevelAnimation = false;
        ResumeTime();
    }

    private void ScanForCheckpoint()
    {
        bool checkpointFound = false;
        checkpoint = FindObjectOfType<Checkpoint>();
        RunnerController runner = FindObjectOfType<RunnerController>();

        if (checkpoint != null)
        {
            checkpointFound = true;
        }

        if (checkpointFound)
        {
            levelUI.SetTwoStageUIVisuals();
            isTwoStageLevel = true;
            //Debug.Log("Two Stage Level!");
            if (checkpoint.GetIsCheckpointReached() == 1)
            {
                levelUI.SetStage_01_Passed();
                runner.SetStartPosition(checkpoint.GetCheckpointStartTransform().position);
                cameraManager.HideStartTransitionTrack();
                cameraManager.HideCameraAssistNormalTrack();
                cameraManager.UseCameraAssistCheckpointTrack();
            }
            else
            {
                runner.SetStartPosition(runner.transform.position);
            }
        }
        else
        {
            levelUI.SetOneStageUIVisuals();
            isOneStageLevel = true;
            //Debug.Log("One Stage Level!");
            runner.SetStartPosition(runner.transform.position);
        }
    }

    public void ClearFoundCheckpoint()
    {
        if (checkpoint != null)
        {
            checkpoint.ClearCheckpoint();
        }
    }

    public void IncreaseLevelReached()
    {
        if (levelReached < levelToUnlock)
        {
            levelReached = levelToUnlock;
            PlayerPrefs.SetInt(levelReachPlayerPrefsName, levelReached);
        }
    }

    public int GetKillCount()
    {
        return killCount;
    }
}
