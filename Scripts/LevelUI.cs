using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Services.Analytics;
using Lofelt.NiceVibrations;
#if UNITY_IOS
       using UnityEngine.iOS;
#elif UNITY_ANDROID
       using Google.Play.Review;
#endif

public class LevelUI : MonoBehaviour
{
    //[SerializeField] private WeaponShopManager weaponShopManager;
    //[SerializeField] private CreditManager creditManager;
    //[SerializeField] private ItemManager itemManager;
    //[SerializeField] private RankManager rankManager;
    //[SerializeField] private HelicopterRankManager helicopterRankManager;
    //[SerializeField] private PrizeManager prizeManager;
    //[SerializeField] private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI versionNumberTM;
    private WeaponShopManager weaponShopManager;
    private CreditManager creditManager;
    private ItemManager itemManager;
    private RankManager rankManager;
    private HelicopterRankManager helicopterRankManager;
    private PrizeManager prizeManager;
    private GameManager gameManager;
    //[SerializeField] private IAPManager iAPManager;

    [Header("Main UI")]
    [SerializeField] private GameObject gameUI;
    [SerializeField] private TextMeshProUGUI levelTM;
    [SerializeField] private TextMeshProUGUI shieldCountTM;
    [SerializeField] private TextMeshProUGUI killCountTM;
    [SerializeField] private TextMeshProUGUI currentCreditCountTM;
    [SerializeField] private Image credits_image;
    [SerializeField] private Image shield_image;
    [SerializeField] private Image stage_01_image;
    [SerializeField] private Image stage_01_passed_image;
    [SerializeField] private Image stage_02_image;
    [SerializeField] private Image stage_02_passed_image;
    [SerializeField] private Image stage_03_image;
    [SerializeField] private Image stage_03_passed_image;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject continueBtn;
    [SerializeField] private GameObject skipLevelBtn;
    [SerializeField] private Image creditsEarned_image;
    [SerializeField] private TextMeshProUGUI creditsEarnedCountTM;
    [SerializeField] private TextMeshProUGUI levelCompletedTM;
    [SerializeField] private Button multiplyCreditsEarnedBtn;
    [SerializeField] private Image multiplyCreditsArrow_image;
    [SerializeField] private GameObject killCount;
    private int numberOfLevelsSkipped;
    private string numberOfLevelsSkippedPlayerPrefsName = "numberOfLevelsSkipped";

    [Header("Kill UI")]
    [SerializeField] private TextMeshProUGUI killtacularTM;
    [SerializeField] private TextMeshProUGUI killFrenzyTM;
    [SerializeField] private TextMeshProUGUI killtrocityTM;
    [SerializeField] private TextMeshProUGUI fallTM;
    [SerializeField] private TextMeshProUGUI squishTM;
    [SerializeField] private TextMeshProUGUI collideTM;
    [SerializeField] private TextMeshProUGUI launchedTM;
    [SerializeField] private TextMeshProUGUI buildingTM;
    private float killUIAnimationTime = 1f;
    private bool hasKilltacularStreak;
    private bool hasKillFrenzyStreak;
    private bool hasKilltrocityStreak;
    private bool hasFallStreak;
    private bool hasSquishStreak;
    private bool hasCollideStreak;
    private bool hasLaunchedStreak;
    private bool hasBuildingStreak;

    [Header("Weapon Shop UI")]
    [SerializeField] private GameObject weaponShopMenu_Single;
    [SerializeField] private GameObject weaponShopMenu_Double;
    [SerializeField] private Image assaultWeapon_Single_image;
    [SerializeField] private Image shotgunWeapon_Single_image;
    [SerializeField] private Image smgWeapon_Single_image;
    [SerializeField] private Image rifle_01Weapon_Single_image;
    [SerializeField] private Image smg_02Weapon_Single_image;
    [SerializeField] private Image shotgun_02Weapon_Single_image;
    [SerializeField] private Image assault_02Weapon_Single_image;
    [SerializeField] private Image smg_03Weapon_Single_image;
    [SerializeField] private Image assault_03Weapon_Single_image;
    [SerializeField] private Image rifle_02Weapon_Single_image;
    [SerializeField] private Image machineGun_01Weapon_Single_image;
    [SerializeField] private Image machineGun_02Weapon_Single_image;
    [SerializeField] private Image rocketLauncherWeapon_Single_image;
    [SerializeField] private Image shotgunWeapon_Slot_01_image;
    [SerializeField] private Image smgWeapon_Slot_01_image;
    [SerializeField] private Image rifle_01Weapon_Slot_01_image;
    [SerializeField] private Image smg_02Weapon_Slot_01_image;
    [SerializeField] private Image shotgun_02Weapon_Slot_01_image;
    [SerializeField] private Image assault_02Weapon_Slot_01_image;
    [SerializeField] private Image smg_03Weapon_Slot_01_image;
    [SerializeField] private Image assault_03Weapon_Slot_01_image;
    [SerializeField] private Image rifle_02Weapon_Slot_01_image;
    [SerializeField] private Image machineGun_01Weapon_Slot_01_image;
    [SerializeField] private Image machineGun_02Weapon_Slot_01_image;
    [SerializeField] private Image rocketLauncherWeapon_Slot_01_image;
    [SerializeField] private Image smgWeapon_Slot_02_image;
    [SerializeField] private Image rifle_01Weapon_Slot_02_image;
    [SerializeField] private Image smg_02Weapon_Slot_02_image;
    [SerializeField] private Image shotgun_02Weapon_Slot_02_image;
    [SerializeField] private Image assault_02Weapon_Slot_02_image;
    [SerializeField] private Image smg_03Weapon_Slot_02_image;
    [SerializeField] private Image assault_03Weapon_Slot_02_image;
    [SerializeField] private Image rifle_02Weapon_Slot_02_image;
    [SerializeField] private Image machineGun_01Weapon_Slot_02_image;
    [SerializeField] private Image machineGun_02Weapon_Slot_02_image;
    [SerializeField] private Image rocketLauncherWeapon_Slot_02_image;
    [SerializeField] private Image weapon_image_Single;
    [SerializeField] private Image weapon_image_Double;
    [SerializeField] private Image weapon_02_image_Double;
    [SerializeField] private Image weaponPrice_image_Single;
    [SerializeField] private Image weaponPrice_image_Double;
    [SerializeField] private Image weaponPrice_02_image_Double;
    [SerializeField] private TextMeshProUGUI weaponPriceTM_Single;
    [SerializeField] private TextMeshProUGUI weaponPriceTM_Double_01;
    [SerializeField] private TextMeshProUGUI weaponPriceTM_Double_02;
    [SerializeField] private TextMeshProUGUI weaponEquippedTM_Single;
    [SerializeField] private TextMeshProUGUI weaponEquippedTM_Double_01;
    [SerializeField] private TextMeshProUGUI weaponEquippedTM_Double_02;
    [SerializeField] private GameObject exitWeaponShopBtn_Single;
    [SerializeField] private GameObject exitWeaponShopBtn_Double;
    private Item.ItemType weaponOffered;
    private Item.ItemType secondWeaponOffered;
    private bool isFirstWeaponOfferSlotFilled;
    private bool wasFirstWeaponOfferPurchased;
    private bool wasSecondWeaponOfferPurchased;

    [Header("Bank UI")]
    [SerializeField] private GameObject bankMenu;
    [SerializeField] private TextMeshProUGUI smallCreditPackageValueTM;
    [SerializeField] private TextMeshProUGUI mediumCreditPackageValueTM;
    [SerializeField] private TextMeshProUGUI largeCreditPackageValueTM;
    [SerializeField] private TextMeshProUGUI creditsNeededTM;

    [Header("Rank UI")]
    [SerializeField] private Image rank_image;
    [SerializeField] private Image rankFill_image;
    [SerializeField] private TextMeshProUGUI rankFillPercentageTM;
    [SerializeField] private GameObject skinMenu;
    [SerializeField] private GameObject skin_Male_01;
    [SerializeField] private GameObject skin_Homeless;
    [SerializeField] private GameObject skin_Biker;
    [SerializeField] private GameObject skin_Female_01;
    [SerializeField] private TextMeshProUGUI skinEquippedTM;
    [SerializeField] private GameObject exitSkinBtn;
    //[SerializeField] private GameObject purchaseSkinBtn;
    [SerializeField] private GameObject newSkinBtn;
    private int roundedFillAmount;
    private int roundedTargetFillAmount;

    [Header("Helicopter Rank UI")]
    [SerializeField] private Image helicopterRank_image;
    [SerializeField] private Image helicopterRankFill_image;
    [SerializeField] private TextMeshProUGUI helicopterRankFillPercentageTM;
    [SerializeField] private GameObject helicopterMenu;
    [SerializeField] private GameObject skin_Helicopter_02;
    [SerializeField] private GameObject skin_Helicopter_04;
    [SerializeField] private TextMeshProUGUI helicopterSkinEquippedTM;
    [SerializeField] private GameObject exitHelicopterSkinBtn;
    //[SerializeField] private GameObject purchaseHelicopterSkinBtn;
    [SerializeField] private GameObject newHelicopterSkinBtn;
    private int roundedHelicopterFillAmount;
    private int roundedHelicopterTargetFillAmount;

    [Header("Prize UI")]
    [SerializeField] private GameObject prizeMenu;
    [SerializeField] private GameObject prizeCrate_01;
    [SerializeField] private GameObject prizeCrate_02;
    [SerializeField] private GameObject prizeCrate_03;
    [SerializeField] private Image prizeBtn_01_image;
    [SerializeField] private Image prizeBtn_02_image;
    [SerializeField] private Image prizeBtn_03_image;
    [SerializeField] private Image prize_01_image;
    [SerializeField] private Image prize_02_image;
    [SerializeField] private Image prize_03_image;
    [SerializeField] private Image priceBtn_01_image;
    [SerializeField] private Image priceBtn_02_image;
    [SerializeField] private Image priceBtn_03_image;
    [SerializeField] private Image adBtn_01_image;
    [SerializeField] private Image adBtn_02_image;
    [SerializeField] private Image adBtn_03_image;
    [SerializeField] private Image checkmark_01_image;
    [SerializeField] private Image checkmark_02_image;
    [SerializeField] private Image checkmark_03_image;
    [SerializeField] private TextMeshProUGUI prize_amount_01TM;
    [SerializeField] private TextMeshProUGUI prize_amount_02TM;
    [SerializeField] private TextMeshProUGUI prize_amount_03TM;
    [SerializeField] private GameObject exitPrizeMenuBtn;
    [SerializeField] private GameObject continuePrizeMenuBtn;
    private int bestPrize = 700;
    private bool hasPrize_01BeenReceived;
    private bool hasPrize_02BeenReceived;
    private bool hasPrize_03BeenReceived;
    private bool hasBestPrizeBeenReceived;

    [Header("Map UI")]
    [SerializeField] private GameObject mapUI;
    [SerializeField] private GameObject continueMapBtn;
    [SerializeField] private TextMeshProUGUI worldNumberText;
    [SerializeField] private TextMeshProUGUI mapSlot_01Text;
    [SerializeField] private TextMeshProUGUI mapSlot_02Text;
    [SerializeField] private TextMeshProUGUI mapSlot_03Text;
    [SerializeField] private TextMeshProUGUI mapSlot_04Text;
    [SerializeField] private TextMeshProUGUI mapSlot_05Text;
    [SerializeField] private TextMeshProUGUI mapSlot_05BossText;
    [SerializeField] private Image mapSlot_01CurrentImage;
    [SerializeField] private Image mapSlot_02CurrentImage;
    [SerializeField] private Image mapSlot_03CurrentImage;
    [SerializeField] private Image mapSlot_04CurrentImage;
    [SerializeField] private Image mapSlot_05CurrentImage;
    [SerializeField] private TextMeshProUGUI unlockMapText;
    [SerializeField] private Image mapSlot_01Background;
    [SerializeField] private Image mapSlot_02Background;
    [SerializeField] private Image mapSlot_03Background;
    [SerializeField] private Image mapSlot_04Background;
    [SerializeField] private Image mapSlot_05Background;
    [SerializeField] private Image mapSlot_05BossImage;
    [SerializeField] private Image bossBattleBanner;
    [SerializeField] private Image bossDestroyedBanner;

    [Header("Pause UI")]
    [SerializeField] private GameObject pauseBtn;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private Image toggleBloodOn_image;
    [SerializeField] private Image toggleBloodOff_image;
    [SerializeField] private Image toggleMusicOn_image;
    [SerializeField] private Image toggleMusicOff_image;
    [SerializeField] private Image toggleSoundEffectsOn_image;
    [SerializeField] private Image toggleSoundEffectsOff_image;
    [SerializeField] private Image toggleHapticssOn_image;
    [SerializeField] private Image toggleHapticsOff_image;
    private int isBloodOn;
    private int isMusicOn;
    private int isSoundEffectsOn;
    private int isHapticsOn;
    private string isBloodOnPlayerPrefsName = "isBloodOn";
    private string isMusicOnPlayerPrefsName = "isMusicOn";
    private string isSoundEffectsOnPlayerPrefsName = "isSoundEffectsOn";
    private string isHapticsOnPlayerPrefsName = "isHapticsOn";

    [Header("Social Btns")]
    //[SerializeField] private GameObject infoBtn;
    //[SerializeField] private GameObject infoMenu;
    [SerializeField] private GameObject instagramBtn;
    private int hasCollectedInstagramReward;
    private string hasCollectedInstagramRewardPlayerPrefsName = "hasCollectedInstagramReward";

    [Header("FX")]
    [SerializeField] private ParticleSystem creditFX;
    [SerializeField] private ParticleSystem newSkinFX;

    private int levelReached;
    private string levelReachPlayerPrefsName = "levelReached";
    public static bool offerGunTrialAgain;
    public static bool offerShieldPackageAgain;
    private AdsInitializer adsInitializer;
    private AdsManager adsManager;
    public static bool wasReviveBtnClicked;
    private bool readyToShowInGameInterstitialAd;
    public static bool hasShownBuildingUI;
    public static bool isReadyToShowOnDeathOffer;

    // Analytics.
    private string continueToNextLevelEventName = "continueToNextLevel"; // 0 means false, 1 means true

    private void Awake()
    {
        weaponShopManager = FindObjectOfType<WeaponShopManager>();
        creditManager = FindObjectOfType<CreditManager>();
        itemManager = FindObjectOfType<ItemManager>();
        rankManager = FindObjectOfType<RankManager>();
        helicopterRankManager = FindObjectOfType<HelicopterRankManager>();
        prizeManager = FindObjectOfType<PrizeManager>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Start()
    {
        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        adsManager = FindObjectOfType<AdsManager>();
        if (adsManager != null)
        {
            //if (adsManager.GetHasCompletedFirstPurchase() == 0)
            {
                adsInitializer = FindObjectOfType<AdsInitializer>();
            }
        }
        offerGunTrialAgain = false;
        offerShieldPackageAgain = false;
        PackManager.isViewingShieldPackAgain = false;
        SetVersionText();
        hasCollectedInstagramReward = PlayerPrefs.GetInt(hasCollectedInstagramRewardPlayerPrefsName);
        if (hasCollectedInstagramReward == 1)
        {
            SetInstagramBtnActive(false);
        }
    }

    public void Revive()
    {
        if (AdsInitializer.isInitialized)
        {
            if (levelReached >= AdsInitializer.levelToBeginInterstitialAds)
            {
                if (wasReviveBtnClicked)
                {
                    readyToShowInGameInterstitialAd = true;
                }
                wasReviveBtnClicked = true;
            }
        }
        if (levelReached != 2 && levelReached != 6 && levelReached != 9 && levelReached != 10 && levelReached < 11)
        {
            if (AdsInitializer.isInitialized)
            {
                if (adsManager != null)
                {
                    if (readyToShowInGameInterstitialAd && AdsInitializer.isInterstitialAdLoaded && adsManager.GetHasCompletedFirstPurchase() == 0)
                    {
                        adsInitializer.ShowInterstitialAd(); // Player has revived for a second time in the same level, during the same session.
                        readyToShowInGameInterstitialAd = false;
                    }
                    else
                    {
                        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                        if (AdsInitializer.isBannerAdLoaded)
                        {
                            adsInitializer.ShowBannerAd();
                        }
                    }
                } else
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            } else
            {
                AdsInitializer adsInitializer = FindObjectOfType<AdsInitializer>();
                if (adsInitializer != null)
                {
                    adsInitializer.InitializeAds();
                }
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        else
        {
            Home();
            if (levelReached == 2)
            {
                offerGunTrialAgain = true;
            }
            if (levelReached == 6)
            {
                PackManager.isViewingShieldPackAgain = true;
                offerShieldPackageAgain = true;
            }
            if (levelReached == 9)
            {
                if (itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0)
                {
                    offerGunTrialAgain = true;
                }
            }
            if (levelReached == 10)
            {
                PackManager.isViewingShieldPackAgain = true;
                offerShieldPackageAgain = true;
            }
            if (levelReached >= 11)
            {
                if (levelReached != 16)
                {
                    PackManager.isViewingShieldPackAgain = true;
                    offerShieldPackageAgain = true;
                }
                else
                {
                    if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0)
                    {
                        offerGunTrialAgain = true;
                    }
                    else
                    {
                        PackManager.isViewingShieldPackAgain = true;
                        offerShieldPackageAgain = true;
                    }
                }
            }
        }
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    private void Home()
    {
        gameManager.ResumeTime();
        Loader.Load(Loader.Scene.Home);
        if (AdsInitializer.isInitialized && BannerAd.isShowing)
        {
            adsInitializer.HideBannerAd();
        }
        if (AdsInitializer.isInitialized && AdsInitializer.isInterstitialAdLoaded)
        {
            if (wasReviveBtnClicked)
            {
                if (readyToShowInGameInterstitialAd)
                {
                    adsInitializer.ShowInterstitialAd();
                }
            }
            else
            {
                adsInitializer.ShowInterstitialAd();
            }
        } else
        {
            AdsInitializer adsInitializer = FindObjectOfType<AdsInitializer>();
            if (adsInitializer != null)
            {
                adsInitializer.InitializeAds();
            }
        }
    }

    public void HomeBtn()
    {
        GameManager.isExitingLevel = true;
        AudioManager.Instance.Play_sfx_ui_tap();
        Home();
    }

    public void ContinueBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Home();
        if (PlayerPrefs.GetInt(continueToNextLevelEventName + levelReached, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "nextLevel", levelReached },
            };
            AnalyticsService.Instance.CustomData(continueToNextLevelEventName, parameters);
            PlayerPrefs.SetInt(continueToNextLevelEventName + levelReached, 1);
        }
    }

    public void SkipLevelBtnClicked()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SkipLevel()
    {
        gameManager.IncreaseLevelReached();
        gameManager.ClearFoundCheckpoint();
        wasReviveBtnClicked = false;
        IncreaseNumberOfLevelsSkipped();
        Home();
        if (PlayerPrefs.GetInt(continueToNextLevelEventName + levelReached, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "nextLevel", levelReached },
            };
            AnalyticsService.Instance.CustomData(continueToNextLevelEventName, parameters);
            PlayerPrefs.SetInt(continueToNextLevelEventName + levelReached, 1);
        }
    }

    public void MultiplyCreditsEarnedBtnClicked()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void MultiplyCreditsEarnedBtn()
    {
        SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount() * 3);
        int additionalCreditsReceived = (creditManager.GetEarnedCreditCount() * 2);
        SetMultiplyCreditsEarnedBtnActive(false);
        SetMultiplyCreditsArrowImageActive(false);
        creditManager.SaveNewCreditCount(creditManager.GetCreditCount() + additionalCreditsReceived);
        creditManager.VisualLevelCreditChange(true, creditManager.GetEndLevelCreditCount(), creditManager.GetCreditCount());
    }

    public void WeaponBtn()
    {
        SetWasFirstWeaponOfferPurchased(true);
        SetWasSecondWeaponOfferPurchased(false);
        creditManager.AttemptWeaponPurchase(GetWeaponOffered());
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void WeaponBtn_02()
    {
        SetWasFirstWeaponOfferPurchased(false);
        SetWasSecondWeaponOfferPurchased(true);
        creditManager.AttemptWeaponPurchase(GetSecondWeaponOffered());
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void NewSkinBtnClicked()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void NewSkinBtn()
    {
        rankManager.ClaimRankUpSkin(levelReached - GetNumberOfLevelsSkipped());
        SetSkinEquippedTextActive(true);
        //SetNewSkinBtnInteractable(false);
        //SetPurchaseSkinBtnActive(false);
        SetNewSkinBtnActive(false);
        SetExitSkinBtnActive(false);
        StartCoroutine(WaitSetSkinMenuActive(false, 1.5f));
        StartCoroutine(WaitHideRank(1.5f));
    }

    public void NewHelicopterBtnClicked()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void NewHelicopterSkinBtn()
    {
        helicopterRankManager.ClaimHelicopterRankUpSkin(levelReached);
        SetHelicopterSkinEquippedTextActive(true);
        //SetNewHelicopterSkinBtnInteractable(false);
        //SetPurchaseHelicopterSkinBtnActive(false);
        SetNewHelicopterSkinBtnActive(false);
        SetExitHelicopterSkinBtnActive(false);
        StartCoroutine(WaitSetHelicopterMenuActive(false, 1.5f));
        StartCoroutine(WaitHideHelicopterRank(1.5f));
    }

    public void PrizeBtnClicked()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void PrizeBtn_01()
    {
        SetHasPrize_01BeenReceived(true);
        if (!hasPrize_02BeenReceived && !hasPrize_03BeenReceived)
        {
            prizeCrate_01.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(WaitAwardPrize_01(1f));
        }
        else
        {
            prizeCrate_01.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(WaitAwardAnotherPrize_01(1f));
        }
        if (!GetHasPrize_02BeenReceived())
        {
            SetAdBtnImage_02Active(true);
            SetPrice_Btn_02ImageActive(false);
            SetPrizeBtnImage_02RaycastTarget(false);
        }
        if (!GetHasPrize_03BeenReceived())
        {
            SetAdBtnImage_03Active(true);
            SetPrice_Btn_03ImageActive(false);
            SetPrizeBtnImage_03RaycastTarget(false);
        }
    }

    public void PrizeBtn_02()
    {
        SetHasPrize_02BeenReceived(true);
        if (!hasPrize_01BeenReceived && !hasPrize_03BeenReceived)
        {
            prizeCrate_02.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(WaitAwardPrize_02(1f));
        }
        else
        {
            prizeCrate_02.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(WaitAwardAnotherPrize_02(1f));
        }
        if (!GetHasPrize_01BeenReceived())
        {
            SetAdBtnImage_01Active(true);
            SetPrice_Btn_01ImageActive(false);
            SetPrizeBtnImage_01RaycastTarget(false);
        }
        if (!GetHasPrize_03BeenReceived())
        {
            SetAdBtnImage_03Active(true);
            SetPrice_Btn_03ImageActive(false);
            SetPrizeBtnImage_03RaycastTarget(false);
        }
    }

    public void PrizeBtn_03()
    {
        SetHasPrize_03BeenReceived(true);
        if (!hasPrize_01BeenReceived && !hasPrize_02BeenReceived)
        {
            prizeCrate_03.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(WaitAwardPrize_03(1f));
        }
        else
        {
            prizeCrate_03.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(WaitAwardAnotherPrize_03(1f));
        }
        if (!GetHasPrize_01BeenReceived())
        {
            SetAdBtnImage_01Active(true);
            SetPrice_Btn_01ImageActive(false);
            SetPrizeBtnImage_01RaycastTarget(false);
        }
        if (!GetHasPrize_02BeenReceived())
        {
            SetAdBtnImage_02Active(true);
            SetPrice_Btn_02ImageActive(false);
            SetPrizeBtnImage_02RaycastTarget(false);
        }
    }

    public IEnumerator WaitAwardPrize_01(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        AwardPrize_01();
    }

    private void AwardPrize_01()
    {
        SetPrizeCrate_01Active(false);
        SetPrize_01ImageActive(true);
        int randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
        SetPrize_Amount_01Text(randomPrize);
        creditManager.AddCredits(randomPrize);
        creditManager.VisualLevelCreditChange(true, creditManager.GetCreditCount() - randomPrize, creditManager.GetCreditCount());
        //Debug.Log(randomPrize + " Credits Added!");
        SetCheckmark_01ImageActive(true);
        SetPrice_Btn_01ImageActive(false);
        SetExitPrizeMenuBtnActive(true);
        SetPrizeBtnImage_01RaycastTarget(false);
    }

    public IEnumerator WaitAwardPrize_02(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        AwardPrize_02();
    }

    private void AwardPrize_02()
    {
        SetPrizeCrate_02Active(false);
        SetPrize_02ImageActive(true);
        int randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
        SetPrize_Amount_02Text(randomPrize);
        creditManager.AddCredits(randomPrize);
        creditManager.VisualLevelCreditChange(true, creditManager.GetCreditCount() - randomPrize, creditManager.GetCreditCount());
        //Debug.Log(randomPrize + " Credits Added!");
        SetCheckmark_02ImageActive(true);
        SetPrice_Btn_02ImageActive(false);
        SetExitPrizeMenuBtnActive(true);
        SetPrizeBtnImage_02RaycastTarget(false);
    }

    public IEnumerator WaitAwardPrize_03(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        AwardPrize_03();
    }

    private void AwardPrize_03()
    {
        SetPrizeCrate_03Active(false);
        SetPrize_03ImageActive(true);
        int randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
        SetPrize_Amount_03Text(randomPrize);
        creditManager.AddCredits(randomPrize);
        creditManager.VisualLevelCreditChange(true, creditManager.GetCreditCount() - randomPrize, creditManager.GetCreditCount());
        //Debug.Log(randomPrize + " Credits Added!");
        SetCheckmark_03ImageActive(true);
        SetPrice_Btn_03ImageActive(false);
        SetExitPrizeMenuBtnActive(true);
        SetPrizeBtnImage_03RaycastTarget(false);
    }

    public IEnumerator WaitAwardAnotherPrize_01(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        AwardAnotherPrize_01();
    }

    private void AwardAnotherPrize_01()
    {
        // Must Watch Ad
        SetPrizeCrate_01Active(false);
        SetPrize_01ImageActive(true);
        int randomPrize;
        if (GetHasPrize_02BeenReceived() && !GetHasPrize_03BeenReceived())
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
        }
        else if (!GetHasPrize_02BeenReceived() && GetHasPrize_03BeenReceived())
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
        }
        else
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = bestPrize;
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
            SetExitPrizeMenuBtnActive(false);
            SetContinuePrizeMenuBtnActive(true);
        }
        SetPrize_Amount_01Text(randomPrize);
        creditManager.AddCredits(randomPrize);
        creditManager.VisualLevelCreditChange(true, creditManager.GetCreditCount() - randomPrize, creditManager.GetCreditCount());
        //Debug.Log(randomPrize + " Credits Added!");
        SetCheckmark_01ImageActive(true);
        SetAdBtnImage_01Active(false);
    }

    public IEnumerator WaitAwardAnotherPrize_02(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        AwardAnotherPrize_02();
    }

    private void AwardAnotherPrize_02()
    {
        // Must Watch Ad
        SetPrizeCrate_02Active(false);
        SetPrize_02ImageActive(true);
        int randomPrize;
        if (GetHasPrize_01BeenReceived() && !GetHasPrize_03BeenReceived())
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
        }
        else if (!GetHasPrize_01BeenReceived() && GetHasPrize_03BeenReceived())
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
        }
        else
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = bestPrize;
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
            SetExitPrizeMenuBtnActive(false);
            SetContinuePrizeMenuBtnActive(true);
        }
        SetPrize_Amount_02Text(randomPrize);
        creditManager.AddCredits(randomPrize);
        creditManager.VisualLevelCreditChange(true, creditManager.GetCreditCount() - randomPrize, creditManager.GetCreditCount());
        //Debug.Log(randomPrize + " Credits Added!");
        SetCheckmark_02ImageActive(true);
        SetAdBtnImage_02Active(false);
    }

    public IEnumerator WaitAwardAnotherPrize_03(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        AwardAnotherPrize_03();
    }

    private void AwardAnotherPrize_03()
    {
        // Must Watch Ad
        SetPrizeCrate_03Active(false);
        SetPrize_03ImageActive(true);
        int randomPrize;
        if (GetHasPrize_01BeenReceived() && !GetHasPrize_02BeenReceived())
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
        }
        else if (!GetHasPrize_01BeenReceived() && GetHasPrize_02BeenReceived())
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = GetRandomPrizeAmount(GenerateRandomNumber());
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
        }
        else
        {
            if (!hasBestPrizeBeenReceived)
            {
                randomPrize = bestPrize;
            }
            else
            {
                randomPrize = GenerateRandomNumberNotBestPrize();
            }
            SetExitPrizeMenuBtnActive(false);
            SetContinuePrizeMenuBtnActive(true);
        }
        SetPrize_Amount_03Text(randomPrize);
        creditManager.AddCredits(randomPrize);
        creditManager.VisualLevelCreditChange(true, creditManager.GetCreditCount() - randomPrize, creditManager.GetCreditCount());
        //Debug.Log(randomPrize + " Credits Added!");
        SetCheckmark_03ImageActive(true);
        SetAdBtnImage_03Active(false);
    }

    public int GetRandomPrizeAmount(int randomNum)
    {
        switch (randomNum)
        {
            case 1:
                return 50;
            case 2:
                return 50;
            case 3:
                return 50;
            case 4:
                return 50;
            case 5:
                return 100;
            case 6:
                return 100;
            case 7:
                return 100;
            case 8:
                return 200;
            case 9:
                return 200;
            case 10:
                return 300;
            case 11:
                SetHasBestPrizeBeenReceived(true);
                return 700;
            default:
                Debug.Log("Random number received out of range...");
                return 100;
        }
    }

    private int GenerateRandomNumber()
    {
        int randomNum = Random.Range(1, 11);
        return randomNum;
    }

    private int GenerateRandomNumberNotBestPrize()
    {
        int randomNum = Random.Range(1, 10);
        return randomNum;
    }

    public void ShowWeaponOffer()
    {
        Item.ItemType firstWeaponReceived;
        Item.ItemType secondWeaponReceived;
        int isFirstWeaponReceivedAlreadyPurchased;
        int isSecondWeaponReceivedAlreadyPurchased;
        firstWeaponReceived = weaponShopManager.GetNextWeaponOffer(weaponShopManager.GetCurrentWeaponOfferCount());
        isFirstWeaponReceivedAlreadyPurchased = itemManager.CheckIfItemIsPurchased(firstWeaponReceived);
        while (isFirstWeaponReceivedAlreadyPurchased == 1)
        {
            weaponShopManager.CheckNextWeaponOffer();
            firstWeaponReceived = weaponShopManager.GetNextWeaponOffer(weaponShopManager.GetCurrentWeaponOfferCount());
            isFirstWeaponReceivedAlreadyPurchased = itemManager.CheckIfItemIsPurchased(firstWeaponReceived);
        }
        if (isFirstWeaponReceivedAlreadyPurchased == 0)
        {
            if (firstWeaponReceived == Item.ItemType.Empty)
            {
                Debug.Log("No items left to offer...");
                return;
            }
            if (weaponShopManager.GetIsSingleWeaponOffer())
            {
                SetSingleWeaponShopMenuActive(true);
                ShowSingleWeaponOfferElements(firstWeaponReceived);
                SetContinueBtnActive(false);
            }
            if (weaponShopManager.GetIsDoubleWeaponOffer())
            {
                secondWeaponReceived = weaponShopManager.GetNextWeaponOffer(weaponShopManager.GetCurrentWeaponOfferCount());
                isSecondWeaponReceivedAlreadyPurchased = itemManager.CheckIfItemIsPurchased(secondWeaponReceived);
                if (secondWeaponReceived == firstWeaponReceived)
                {
                    weaponShopManager.CheckNextWeaponOffer();
                    secondWeaponReceived = weaponShopManager.GetNextWeaponOffer(weaponShopManager.GetCurrentWeaponOfferCount());
                    isSecondWeaponReceivedAlreadyPurchased = itemManager.CheckIfItemIsPurchased(secondWeaponReceived);
                }
                while (isSecondWeaponReceivedAlreadyPurchased == 1)
                {
                    weaponShopManager.CheckNextWeaponOffer();
                    secondWeaponReceived = weaponShopManager.GetNextWeaponOffer(weaponShopManager.GetCurrentWeaponOfferCount());
                    isSecondWeaponReceivedAlreadyPurchased = itemManager.CheckIfItemIsPurchased(secondWeaponReceived);
                }
                if (isSecondWeaponReceivedAlreadyPurchased == 0)
                {
                    if (secondWeaponReceived == Item.ItemType.Empty) // Only found one option.
                    {
                        weaponShopManager.SetIsSingleWeaponOffer(true);
                        SetSingleWeaponShopMenuActive(true);
                        ShowSingleWeaponOfferElements(firstWeaponReceived);
                        SetContinueBtnActive(false);
                    } else
                    {
                        SetDoubleWeaponShopMenuActive(true);
                        ShowDoubleWeaponOfferElements(firstWeaponReceived);
                        ShowDoubleWeaponOfferElements(secondWeaponReceived);
                        SetContinueBtnActive(false);
                    }
                }
            }
        }
    }

    public void SetWeaponOfferEquipped()
    {
        Color32 green = new Color32(64, 210, 51, 255);
        if (weaponShopManager.GetIsSingleWeaponOffer())
        {
            weapon_image_Single.color = green;
            weaponPrice_image_Single.gameObject.SetActive(false);
            weaponEquippedTM_Single.gameObject.SetActive(true);
        }
        if (weaponShopManager.GetIsDoubleWeaponOffer())
        {
            if(GetWasFirstWeaponOfferSlotPurchased())
            {
                weapon_image_Double.color = green;
                weaponPrice_image_Double.gameObject.SetActive(false);
                weaponEquippedTM_Double_01.gameObject.SetActive(true);
                if (weaponEquippedTM_Double_02.gameObject.activeInHierarchy)
                {
                    weaponEquippedTM_Double_02.gameObject.SetActive(false);
                }
            }
            if (GetWasSecondWeaponOfferSlotPurchased())
            {
                weapon_02_image_Double.color = green;
                weaponPrice_02_image_Double.gameObject.SetActive(false);
                weaponEquippedTM_Double_02.gameObject.SetActive(true);
                if (weaponEquippedTM_Double_01.gameObject.activeInHierarchy)
                {
                    weaponEquippedTM_Double_01.gameObject.SetActive(false);
                }
            }
        }
    }

    public void ShowRank()
    {
        SetCreditsEarnedImageActive(false);
        SetContinueBtnActive(false);
        roundedFillAmount = Mathf.RoundToInt(rankManager.GetCurrentFillAmount() * 100);
        SetRankFillAmount(rankManager.GetCurrentFillAmount());
        SetRankPercentageText(roundedFillAmount);
        SetRankImageActive(true);
        StartCoroutine(nameof(AnimateRankPercentage));
    }

    public void ShowHelicopterRank()
    {
        SetCreditsEarnedImageActive(false);
        SetContinueBtnActive(false);
        roundedHelicopterFillAmount = Mathf.RoundToInt(helicopterRankManager.GetCurrentFillAmount() * 100);
        SetHelicopterRankFillAmount(helicopterRankManager.GetCurrentFillAmount());
        SetHelicopterRankPercentageText(roundedHelicopterFillAmount);
        SetHelicopterRankImageActive(true);
        StartCoroutine(nameof(AnimateHelicopterRankPercentage));
    }

    public void ShowPrizeMenu()
    {
        SetPrizeMenuActive(true);
    }

    public void HideWeaponOffer()
    {
        if (weaponShopManager.GetIsSingleWeaponOffer())
        {
            SetSingleWeaponShopMenuActive(false);
        }
        if (weaponShopManager.GetIsDoubleWeaponOffer())
        {
            SetDoubleWeaponShopMenuActive(false);
        }
        SetContinueBtnActive(true);
    }

    public void ShowCurrentWeaponOffer()
    {
        if (weaponShopManager.GetIsSingleWeaponOffer())
        {
            SetSingleWeaponShopMenuActive(true);
        }
        if (weaponShopManager.GetIsDoubleWeaponOffer())
        {
            SetDoubleWeaponShopMenuActive(true);
        }
        SetContinueBtnActive(false);
    }

    public void ExitBank()
    {
        SetBankMenuActive(false);
        //weaponShopManager.CheckForWeaponShopOffer(levelReached);
        ShowCurrentWeaponOffer();
        //iAPManager.HideAllLoadingPopUps();
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitPrizeMenu()
    {
        SetPrizeMenuActive(false);
        SetContinueBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void PurchaseSmallCreditPack()
    {
        creditManager.AddCredits(creditManager.GetSmallCreditPackageValue());
        creditManager.SetCreditCountUI_Animated(creditManager.GetSmallCreditPackageValue());
    }

    public void PurchaseMediumCreditPack()
    {
        creditManager.AddCredits(creditManager.GetMediumCreditPackageValue());
        creditManager.SetCreditCountUI_Animated(creditManager.GetMediumCreditPackageValue());
    }

    public void PurchaseLargeCreditPack()
    {
        creditManager.AddCredits(creditManager.GetLargeCreditPackageValue());
        creditManager.SetCreditCountUI_Animated(creditManager.GetLargeCreditPackageValue());
    }

    public void FollowInstagramReward()
    {
        Application.OpenURL("https://www.instagram.com/pablowaregames/?hl=en");
        creditManager.AddCredits(creditManager.GetInstagramFollowRewardValue());
        creditManager.SetCreditCountUI_Animated(creditManager.GetInstagramFollowRewardValue());
        hasCollectedInstagramReward = 1;
        PlayerPrefs.SetInt(hasCollectedInstagramRewardPlayerPrefsName, hasCollectedInstagramReward);
        SetInstagramBtnActive(false);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    private void SetInstagramBtnActive(bool isActive)
    {
        instagramBtn.SetActive(isActive);
    }

    public void SetLevelText(int currentLevel)
    {
        levelTM.text = "LEVEL " + currentLevel;
    }

    public void SetCreditsImageActive(bool isActive)
    {
        credits_image.gameObject.SetActive(isActive);
    }

    public void SetShieldImageActive(bool isActive)
    {
        shield_image.gameObject.SetActive(isActive);
    }

    public void SetKillCountText(int killCount)
    {
        if (!hasKilltacularStreak && !hasKillFrenzyStreak && !hasKilltrocityStreak && !hasFallStreak && !hasSquishStreak && !hasCollideStreak && !hasLaunchedStreak && !hasBuildingStreak)
        {
            killCountTM.text = GetBlueSkullSprite() + killCount;
            killCountTM.color = GetWhiteColor();
        } else
        {
            if (hasKilltacularStreak)
            {
                killCountTM.text = GetKilltacularSkullSprite() + killCount;
                killCountTM.color = GetKilltacularColor();
            }
            if (hasKillFrenzyStreak)
            {
                killCountTM.text = GetKillFrenzySkullSprite() + killCount;
                killCountTM.color = GetKillFrenzyColor();
            }
            if (hasKilltrocityStreak)
            {
                killCountTM.text = GetKilltrocitySkullSprite() + killCount;
                killCountTM.color = GetKilltrocityColor();
            }

            if (hasFallStreak)
            {
                killCountTM.text = GetFallSkullSprite() + killCount;
                killCountTM.color = GetFallColor();
            }

            if (hasSquishStreak)
            {
                killCountTM.text = GetSquishSkullSprite() + killCount;
                killCountTM.color = GetSquishColor();
            }

            if (hasCollideStreak)
            {
                killCountTM.text = GetCollideSkullSprite() + killCount;
                killCountTM.color = GetCollideColor();
            }

            if (hasLaunchedStreak)
            {
                killCountTM.text = GetLaunchedSkullSprite() + killCount;
                killCountTM.color = GetLaunchedColor();
            }

            if (hasBuildingStreak)
            {
                killCountTM.text = GetBuildingSkullSprite() + killCount;
                killCountTM.color = GetBuildingColor();
            }
        }
    }

    public void SetLevelCompletePanelActive(bool isActive)
    {
        levelCompletePanel.gameObject.SetActive(isActive);
    }

    public void SetGameOverPanelActive(bool isActive)
    {
        gameOverPanel.gameObject.SetActive(isActive);
    }

    public void SetOneStageUIVisuals()
    {
        stage_01_image.gameObject.SetActive(true);
        stage_02_image.gameObject.SetActive(false);
        stage_03_image.gameObject.SetActive(false);
    }

    public void SetTwoStageUIVisuals()
    {
        stage_01_image.gameObject.SetActive(true);
        stage_02_image.gameObject.SetActive(true);
        stage_03_image.gameObject.SetActive(false);
    }

    public void SetThreeStageUIVisuals()
    {
        stage_01_image.gameObject.SetActive(true);
        stage_02_image.gameObject.SetActive(true);
        stage_03_image.gameObject.SetActive(true);
    }

    public void SetStage_01_Passed()
    {
        stage_01_image.gameObject.SetActive(false);
        stage_01_passed_image.gameObject.SetActive(true);
    }

    public void SetStage_02_Passed()
    {
        stage_02_image.gameObject.SetActive(false);
        stage_02_passed_image.gameObject.SetActive(true);
    }

    public void SetStage_03_Passed()
    {
        stage_03_image.gameObject.SetActive(false);
        stage_03_passed_image.gameObject.SetActive(true);
    }

    public void SetCurrentCreditsCountText(int creditAmount)
    {
        currentCreditCountTM.text = creditAmount.ToString();
    }

    public void SetCreditsEarnedCountText(int creditAmount)
    {
        creditsEarnedCountTM.text = "+" + creditAmount;

        if (levelReached == 15 || levelReached == 25)
        {
            SetBossDestroyedBannerActive(true);
        }
    }

    public void SetCreditsEarnedImageActive(bool isActive)
    {
        creditsEarned_image.gameObject.SetActive(isActive);
    }

    public void SetSkipLevelBtnActive(bool isActive)
    {
        skipLevelBtn.SetActive(isActive);
    }

    public void SetCurrentShieldCountText(int shieldCount)
    {
        shieldCountTM.text = shieldCount.ToString();
    }

    public void SetGameUIActive(bool isActive)
    {
        gameUI.SetActive(isActive);
    }

    public void SetPausePanelActive(bool isActive)
    {
        pausePanel.SetActive(isActive);
        if (isActive)
        {
            InitSettingsBtns();
        }
    }

    public void Pause()
    {
        gameManager.PauseGame();
        AudioManager.Instance.Play_sfx_ui_tap();
        SetMapUIActive(false);
    }

    public void Resume()
    {
        //HideInfoMenu();
        gameManager.UnpauseGame();
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ShowKilltacularTextMesh()
    {
        if (!hasKillFrenzyStreak && !hasKilltrocityStreak)
        {
            killtacularTM.gameObject.SetActive(true);
            hasKilltacularStreak = true;
            SetKillCountText(gameManager.GetKillCount());
            Invoke(nameof(EndKilltacularStreak), killUIAnimationTime);
            EndAllHazardStreaks();
            fallTM.gameObject.SetActive(false);
            squishTM.gameObject.SetActive(false);
            collideTM.gameObject.SetActive(false);
            launchedTM.gameObject.SetActive(false);
            buildingTM.gameObject.SetActive(false);
        }
    }

    public void EndKilltacularStreak()
    {
        hasKilltacularStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowKillFrenzyTextMesh()
    {
        if (!hasKilltacularStreak && !hasKilltrocityStreak)
        {
            killFrenzyTM.gameObject.SetActive(true);
            hasKillFrenzyStreak = true;
            SetKillCountText(gameManager.GetKillCount());
            Invoke(nameof(EndKillFrenzyStreak), killUIAnimationTime);
            EndAllHazardStreaks();
            fallTM.gameObject.SetActive(false);
            squishTM.gameObject.SetActive(false);
            collideTM.gameObject.SetActive(false);
            launchedTM.gameObject.SetActive(false);
            buildingTM.gameObject.SetActive(false);
        }
    }

    public void EndKillFrenzyStreak()
    {
        hasKillFrenzyStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowKilltrocityTextMesh()
    {
        if (!hasKilltacularStreak && !hasKillFrenzyStreak)
        {
            killtrocityTM.gameObject.SetActive(true);
            hasKilltrocityStreak = true;
            SetKillCountText(gameManager.GetKillCount());
            Invoke(nameof(EndKilltrocityStreak), killUIAnimationTime);
            EndAllHazardStreaks();
            fallTM.gameObject.SetActive(false);
            squishTM.gameObject.SetActive(false);
            collideTM.gameObject.SetActive(false);
            launchedTM.gameObject.SetActive(false);
            buildingTM.gameObject.SetActive(false);
        }
    }

    public void EndKilltrocityStreak()
    {
        hasKilltrocityStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowFallTextMesh()
    {
        fallTM.gameObject.SetActive(true);
        hasFallStreak = true;
        SetKillCountText(gameManager.GetKillCount());
        Invoke(nameof(EndFallStreak), killUIAnimationTime);
        EndKilltacularStreak();
        EndKillFrenzyStreak();
        EndKilltrocityStreak();
        killtacularTM.gameObject.SetActive(false);
        killFrenzyTM.gameObject.SetActive(false);
        killtrocityTM.gameObject.SetActive(false);
        squishTM.gameObject.SetActive(false);
        collideTM.gameObject.SetActive(false);
        launchedTM.gameObject.SetActive(false);
        buildingTM.gameObject.SetActive(false);
    }

    public void EndFallStreak()
    {
        hasFallStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowSquishTextMesh()
    {
        squishTM.gameObject.SetActive(true);
        hasSquishStreak = true;
        SetKillCountText(gameManager.GetKillCount());
        Invoke(nameof(EndSquishStreak), killUIAnimationTime);
        EndKilltacularStreak();
        EndKillFrenzyStreak();
        EndKilltrocityStreak();
        killtacularTM.gameObject.SetActive(false);
        killFrenzyTM.gameObject.SetActive(false);
        killtrocityTM.gameObject.SetActive(false);
        fallTM.gameObject.SetActive(false);
        collideTM.gameObject.SetActive(false);
        launchedTM.gameObject.SetActive(false);
        buildingTM.gameObject.SetActive(false);
    }

    public void EndSquishStreak()
    {
        hasSquishStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowCollideTextMesh()
    {
        collideTM.gameObject.SetActive(true);
        hasCollideStreak = true;
        SetKillCountText(gameManager.GetKillCount());
        Invoke(nameof(EndCollideStreak), killUIAnimationTime);
        EndKilltacularStreak();
        EndKillFrenzyStreak();
        EndKilltrocityStreak();
        killtacularTM.gameObject.SetActive(false);
        killFrenzyTM.gameObject.SetActive(false);
        killtrocityTM.gameObject.SetActive(false);
        fallTM.gameObject.SetActive(false);
        squishTM.gameObject.SetActive(false);
        launchedTM.gameObject.SetActive(false);
        buildingTM.gameObject.SetActive(false);
    }

    public void EndCollideStreak()
    {
        hasCollideStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowLaunchedTextMesh()
    {
        launchedTM.gameObject.SetActive(true);
        hasLaunchedStreak = true;
        SetKillCountText(gameManager.GetKillCount());
        Invoke(nameof(EndLaunchedStreak), killUIAnimationTime);
        EndKilltacularStreak();
        EndKillFrenzyStreak();
        EndKilltrocityStreak();
        killtacularTM.gameObject.SetActive(false);
        killFrenzyTM.gameObject.SetActive(false);
        killtrocityTM.gameObject.SetActive(false);
        fallTM.gameObject.SetActive(false);
        squishTM.gameObject.SetActive(false);
        collideTM.gameObject.SetActive(false);
        buildingTM.gameObject.SetActive(false);
    }

    public void EndLaunchedStreak()
    {
        hasLaunchedStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    public void ShowBuildingTextMesh()
    {
        buildingTM.gameObject.SetActive(true);
        hasBuildingStreak = true;
        SetKillCountText(gameManager.GetKillCount());
        Invoke(nameof(EndBuildingStreak), killUIAnimationTime);
        EndKilltacularStreak();
        EndKillFrenzyStreak();
        EndKilltrocityStreak();
        killtacularTM.gameObject.SetActive(false);
        killFrenzyTM.gameObject.SetActive(false);
        killtrocityTM.gameObject.SetActive(false);
        fallTM.gameObject.SetActive(false);
        squishTM.gameObject.SetActive(false);
        collideTM.gameObject.SetActive(false);
        launchedTM.gameObject.SetActive(false);
    }

    public void EndBuildingStreak()
    {
        hasBuildingStreak = false;
        SetKillCountText(gameManager.GetKillCount());
    }

    private void EndAllHazardStreaks()
    {
        EndFallStreak();
        EndSquishStreak();
        EndCollideStreak();
        EndLaunchedStreak();
        EndBuildingStreak();
    }

    public void SetPauseBtnActive(bool isActive)
    {
        pauseBtn.SetActive(isActive);
    }

    public void SetContinueBtnActive(bool isActive)
    {
        continueBtn.SetActive(isActive);
    }

    public void SetBankMenuActive(bool isActive)
    {
        bankMenu.SetActive(isActive);
        if (isActive)
        {
            SetSmallCreditPackageValueText(creditManager.GetSmallCreditPackageValue());
            SetMediumCreditPackageValueText(creditManager.GetMediumCreditPackageValue());
            SetLargeCreditPackageValueText(creditManager.GetLargeCreditPackageValue());
        }
    }

    public void SetSkinMenuActive(bool isActive)
    {
        skinMenu.SetActive(isActive);
        if (isActive)
        {
            StartCoroutine(WaitSetExitSkinBtnActive(3f));
        }
    }

    public void SetHelicopterMenuActive(bool isActive)
    {
        helicopterMenu.SetActive(isActive);
        if (isActive)
        {
            StartCoroutine(WaitSetExitHelicopterSkinBtnActive(3f));
        }
    }

    public void SetSingleWeaponShopMenuActive(bool isActive)
    {
        weaponShopMenu_Single.SetActive(isActive);
        if (isActive)
        {
            StartCoroutine(WaitShowExitWeaponShopBtn_Single(1.5f));
        }
    }

    public void SetDoubleWeaponShopMenuActive(bool isActive)
    {
        weaponShopMenu_Double.SetActive(isActive);
        if (isActive)
        {
            StartCoroutine(WaitShowExitWeaponShopBtn_Double(1.5f));
        }
    }

    //public void HideInfoMenu()
    //{
    //    SetInfoMenuActive(false);
    //    AudioManager.Instance.Play_sfx_ui_tap();
    //}

    public void SupportBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Application.OpenURL("https://pablowaregames.com/contact/");
    }

    //public void InfoBtn()
    //{
    //    SetInfoMenuActive(true);
    //    AudioManager.Instance.Play_sfx_ui_tap();
    //}

    public void IGBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Application.OpenURL("https://www.instagram.com/pablowaregames/?hl=en");
    }

    public void TwitterBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Application.OpenURL("https://twitter.com/pablowaregames?lang=en");
    }

    public void YouTubeBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Application.OpenURL("https://www.youtube.com/channel/UCs0EzGKDDdTQC6xqdbxbT7Q");
    }

    public void WebsiteBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Application.OpenURL("https://pablowaregames.com/");
    }

    public void DiscordBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        Application.OpenURL("https://discord.gg/MNV2XXBdSW");
    }

    private void SetAssaultWeaponSingleImageActive(bool isActive)
    {
        assaultWeapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetShotgunWeaponSingleImageActive(bool isActive)
    {
        shotgunWeapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetSMGWeaponSingleImageActive(bool isActive)
    {
        smgWeapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetRifle_01WeaponSingleImageActive(bool isActive)
    {
        rifle_01Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetSMG_02WeaponSingleImageActive(bool isActive)
    {
        smg_02Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetShotgun_02WeaponSingleImageActive(bool isActive)
    {
        shotgun_02Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetAssault_02WeaponSingleImageActive(bool isActive)
    {
        assault_02Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetShotgunWeapon_Slot_01_ImageActive(bool isActive)
    {
        shotgunWeapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetSMG_03WeaponSingleImageActive(bool isActive)
    {
        smg_03Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetAssault_03WeaponSingleImageActive(bool isActive)
    {
        assault_03Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetRifle_02WeaponSingleImageActive(bool isActive)
    {
        rifle_02Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetMachineGun_01WeaponSingleImageActive(bool isActive)
    {
        machineGun_01Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetMachineGun_02WeaponSingleImageActive(bool isActive)
    {
        machineGun_02Weapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetRocketLauncherWeaponSingleImageActive(bool isActive)
    {
        rocketLauncherWeapon_Single_image.gameObject.SetActive(isActive);
    }

    private void SetSMGWeapon_Slot_01_ImageActive(bool isActive)
    {
        smgWeapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetRifle_01Weapon_Slot_01_ImageActive(bool isActive)
    {
        rifle_01Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetSMG_02Weapon_Slot_01_ImageActive(bool isActive)
    {
        smg_02Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetShotgun_02Weapon_Slot_01_ImageActive(bool isActive)
    {
        shotgun_02Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetAssault_02Weapon_Slot_01_ImageActive(bool isActive)
    {
        assault_02Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetSMG_03Weapon_Slot_01_ImageActive(bool isActive)
    {
        smg_03Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetAssault_03Weapon_Slot_01_ImageActive(bool isActive)
    {
        assault_03Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetRifle_02Weapon_Slot_01_ImageActive(bool isActive)
    {
        rifle_02Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetMachineGun_01Weapon_Slot_01_ImageActive(bool isActive)
    {
        machineGun_01Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetMachineGun_02Weapon_Slot_01_ImageActive(bool isActive)
    {
        machineGun_02Weapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetRocketLauncherWeapon_Slot_01_ImageActive(bool isActive)
    {
        rocketLauncherWeapon_Slot_01_image.gameObject.SetActive(isActive);
    }

    private void SetSMGWeapon_Slot_02_ImageActive(bool isActive)
    {
        smgWeapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetRifle_01Weapon_Slot_02_ImageActive(bool isActive)
    {
        rifle_01Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetSMG_02Weapon_Slot_02_ImageActive(bool isActive)
    {
        smg_02Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetShotgun_02Weapon_Slot_02_ImageActive(bool isActive)
    {
        shotgun_02Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetAssault_02Weapon_Slot_02_ImageActive(bool isActive)
    {
        assault_02Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetSMG_03Weapon_Slot_02_ImageActive(bool isActive)
    {
        smg_03Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetAssault_03Weapon_Slot_02_ImageActive(bool isActive)
    {
        assault_03Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetRifle_02Weapon_Slot_02_ImageActive(bool isActive)
    {
        rifle_02Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetMachineGun_01Weapon_Slot_02_ImageActive(bool isActive)
    {
        machineGun_01Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetMachineGun_02Weapon_Slot_02_ImageActive(bool isActive)
    {
        machineGun_02Weapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetRocketLauncherWeapon_Slot_02_ImageActive(bool isActive)
    {
        rocketLauncherWeapon_Slot_02_image.gameObject.SetActive(isActive);
    }

    private void SetSingleWeaponShopPriceText(Item.ItemType itemType)
    {
        weaponPriceTM_Single.text = Item.GetCost(itemType).ToString();
    }

    private void SetDoubleWeaponShopPriceText_01(Item.ItemType itemType)
    {
        weaponPriceTM_Double_01.text = Item.GetCost(itemType).ToString();
    }

    private void SetDoubleWeaponShopPriceText_02(Item.ItemType itemType)
    {
        weaponPriceTM_Double_02.text = Item.GetCost(itemType).ToString();
    }

    private void SetSmallCreditPackageValueText(int value)
    {
        smallCreditPackageValueTM.text = value.ToString();
    }

    private void SetMediumCreditPackageValueText(int value)
    {
        mediumCreditPackageValueTM.text = value.ToString();
    }

    private void SetLargeCreditPackageValueText(int value)
    {
        largeCreditPackageValueTM.text = value.ToString();
    }

    public void SetCreditsNeededText(int value)
    {
        creditsNeededTM.text = value.ToString();
    }

    public void SetWeaponOffered(Item.ItemType weapon)
    {
        weaponOffered = weapon;
    }

    public void SetSecondWeaponOffered(Item.ItemType weapon)
    {
        secondWeaponOffered = weapon;
    }

    private Item.ItemType GetWeaponOffered()
    {
        return weaponOffered;
    }

    private Item.ItemType GetSecondWeaponOffered()
    {
        return secondWeaponOffered;
    }

    private void ShowSingleWeaponOfferElements(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Assault:
                SetAssaultWeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Assault);
                SetWeaponOffered(Item.ItemType.Assault);
                break;
            case Item.ItemType.Shotgun:
                SetShotgunWeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Shotgun);
                SetWeaponOffered(Item.ItemType.Shotgun);
                break;
            case Item.ItemType.SMG:
                SetSMGWeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.SMG);
                SetWeaponOffered(Item.ItemType.SMG);
                break;
            case Item.ItemType.Rifle_01:
                SetRifle_01WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Rifle_01);
                SetWeaponOffered(Item.ItemType.Rifle_01);
                break;
            case Item.ItemType.SMG_02:
                SetSMG_02WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.SMG_02);
                SetWeaponOffered(Item.ItemType.SMG_02);
                break;
            case Item.ItemType.Shotgun_02:
                SetShotgun_02WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Shotgun_02);
                SetWeaponOffered(Item.ItemType.Shotgun_02);
                break;
            case Item.ItemType.Assault_02:
                SetAssault_02WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Assault_02);
                SetWeaponOffered(Item.ItemType.Assault_02);
                break;
            case Item.ItemType.SMG_03:
                SetSMG_03WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.SMG_03);
                SetWeaponOffered(Item.ItemType.SMG_03);
                break;
            case Item.ItemType.Assault_03:
                SetAssault_03WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Assault_03);
                SetWeaponOffered(Item.ItemType.Assault_03);
                break;
            case Item.ItemType.Rifle_02:
                SetRifle_02WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.Rifle_02);
                SetWeaponOffered(Item.ItemType.Rifle_02);
                break;
            case Item.ItemType.MachineGun_01:
                SetMachineGun_01WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.MachineGun_01);
                SetWeaponOffered(Item.ItemType.MachineGun_01);
                break;
            case Item.ItemType.MachineGun_02:
                SetMachineGun_02WeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.MachineGun_02);
                SetWeaponOffered(Item.ItemType.MachineGun_02);
                break;
            case Item.ItemType.RocketLauncher:
                SetRocketLauncherWeaponSingleImageActive(true);
                SetSingleWeaponShopPriceText(Item.ItemType.RocketLauncher);
                SetWeaponOffered(Item.ItemType.RocketLauncher);
                break;
            default:
                Debug.Log("Single Weapon not recognized...");
                break;
        }
    }

    private void ShowDoubleWeaponOfferElements(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Shotgun:
                SetIsFirstWeaponOfferSlotFilled(true);
                SetShotgunWeapon_Slot_01_ImageActive(true);
                SetDoubleWeaponShopPriceText_01(Item.ItemType.Shotgun);
                SetWeaponOffered(Item.ItemType.Shotgun);
                break;
            case Item.ItemType.SMG:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.SMG);
                    SetSMGWeapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.SMG);
                    SetWeaponOffered(Item.ItemType.SMG);
                } else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.SMG);
                    SetSMGWeapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.SMG);
                    SetSecondWeaponOffered(Item.ItemType.SMG);
                }
                break;
            case Item.ItemType.Rifle_01:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Rifle_01);
                    SetRifle_01Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Rifle_01);
                    SetWeaponOffered(Item.ItemType.Rifle_01);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Rifle_01);
                    SetRifle_01Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Rifle_01);
                    SetSecondWeaponOffered(Item.ItemType.Rifle_01);
                }
                break;
            case Item.ItemType.SMG_02:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.SMG_02);
                    SetSMG_02Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.SMG_02);
                    SetWeaponOffered(Item.ItemType.SMG_02);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.SMG_02);
                    SetSMG_02Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.SMG_02);
                    SetSecondWeaponOffered(Item.ItemType.SMG_02);
                }
                break;
            case Item.ItemType.Shotgun_02:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Shotgun_02);
                    SetShotgun_02Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Shotgun_02);
                    SetWeaponOffered(Item.ItemType.Shotgun_02);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Shotgun_02);
                    SetShotgun_02Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Shotgun_02);
                    SetSecondWeaponOffered(Item.ItemType.Shotgun_02);
                }
                break;
            case Item.ItemType.Assault_02:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Assault_02);
                    SetAssault_02Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Assault_02);
                    SetWeaponOffered(Item.ItemType.Assault_02);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Assault_02);
                    SetAssault_02Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Assault_02);
                    SetSecondWeaponOffered(Item.ItemType.Assault_02);
                }
                break;
            case Item.ItemType.SMG_03:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.SMG_03);
                    SetSMG_03Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.SMG_03);
                    SetWeaponOffered(Item.ItemType.SMG_03);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.SMG_03);
                    SetSMG_03Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.SMG_03);
                    SetSecondWeaponOffered(Item.ItemType.SMG_03);
                }
                break;
            case Item.ItemType.Assault_03:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Assault_03);
                    SetAssault_03Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Assault_03);
                    SetWeaponOffered(Item.ItemType.Assault_03);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Assault_03);
                    SetAssault_03Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Assault_03);
                    SetSecondWeaponOffered(Item.ItemType.Assault_03);
                }
                break;
            case Item.ItemType.Rifle_02:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Rifle_02);
                    SetRifle_02Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.Rifle_02);
                    SetWeaponOffered(Item.ItemType.Rifle_02);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Rifle_02);
                    SetRifle_02Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.Rifle_02);
                    SetSecondWeaponOffered(Item.ItemType.Rifle_02);
                }
                break;
            case Item.ItemType.MachineGun_01:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.MachineGun_01);
                    SetMachineGun_01Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.MachineGun_01);
                    SetWeaponOffered(Item.ItemType.MachineGun_01);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.MachineGun_01);
                    SetMachineGun_01Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.MachineGun_01);
                    SetSecondWeaponOffered(Item.ItemType.MachineGun_01);
                }
                break;
            case Item.ItemType.MachineGun_02:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.MachineGun_02);
                    SetMachineGun_02Weapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.MachineGun_02);
                    SetWeaponOffered(Item.ItemType.MachineGun_02);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.MachineGun_02);
                    SetMachineGun_02Weapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.MachineGun_02);
                    SetSecondWeaponOffered(Item.ItemType.MachineGun_02);
                }
                break;
            case Item.ItemType.RocketLauncher:
                if (!GetIsFirstWeaponOfferSlotFilled())
                {
                    SetIsFirstWeaponOfferSlotFilled(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.RocketLauncher);
                    SetRocketLauncherWeapon_Slot_01_ImageActive(true);
                    SetDoubleWeaponShopPriceText_01(Item.ItemType.RocketLauncher);
                    SetWeaponOffered(Item.ItemType.RocketLauncher);
                }
                else
                {
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.RocketLauncher);
                    SetRocketLauncherWeapon_Slot_02_ImageActive(true);
                    SetDoubleWeaponShopPriceText_02(Item.ItemType.RocketLauncher);
                    SetSecondWeaponOffered(Item.ItemType.RocketLauncher);
                }
                break;
            default:
                Debug.Log("Double Weapon not recognized...");
                break;
        }
    }

    private void SetIsFirstWeaponOfferSlotFilled(bool isFilled)
    {
        isFirstWeaponOfferSlotFilled = isFilled;
    }

    private bool GetIsFirstWeaponOfferSlotFilled()
    {
        return isFirstWeaponOfferSlotFilled;
    }

    private void SetWasFirstWeaponOfferPurchased(bool isTrue)
    {
        wasFirstWeaponOfferPurchased = isTrue;
    }

    private bool GetWasFirstWeaponOfferSlotPurchased()
    {
        return wasFirstWeaponOfferPurchased;
    }

    private void SetWasSecondWeaponOfferPurchased(bool isTrue)
    {
        wasSecondWeaponOfferPurchased = isTrue;
    }

    private bool GetWasSecondWeaponOfferSlotPurchased()
    {
        return wasSecondWeaponOfferPurchased;
    }

    private void SetRankImageActive(bool isActive)
    {
        rank_image.gameObject.SetActive(isActive);
    }

    private void SetHelicopterRankImageActive(bool isActive)
    {
        helicopterRank_image.gameObject.SetActive(isActive);
    }

    private void SetRankPercentageText(float percentage)
    {
        rankFillPercentageTM.text = "%" + percentage;
    }

    private void SetSkinEquippedTextActive(bool isActive)
    {
        skinEquippedTM.gameObject.SetActive(isActive);
    }

    private void SetHelicopterSkinEquippedTextActive(bool isActive)
    {
        helicopterSkinEquippedTM.gameObject.SetActive(isActive);
    }

    private void SetHelicopterRankPercentageText(float percentage)
    {
        helicopterRankFillPercentageTM.text = "%" + percentage;
    }

    private void SetRankFillAmount(float fillAmount)
    {
        rankFill_image.fillAmount = fillAmount;
    }

    private void SetHelicopterRankFillAmount(float fillAmount)
    {
        helicopterRankFill_image.fillAmount = fillAmount;
    }

    public void SetMultiplyCreditsEarnedBtnActive(bool isActive)
    {
        multiplyCreditsEarnedBtn.gameObject.SetActive(isActive);
    }

    public void SetMultiplyCreditsArrowImageActive(bool isActive)
    {
        multiplyCreditsArrow_image.gameObject.SetActive(isActive);
    }

    private void SetPrizeMenuActive(bool isActive)
    {
        prizeMenu.SetActive(isActive);
    }

    private void SetPrizeCrate_01Active(bool isActive)
    {
        prizeCrate_01.SetActive(isActive);
    }

    private void SetPrizeCrate_02Active(bool isActive)
    {
        prizeCrate_02.SetActive(isActive);
    }

    private void SetPrizeCrate_03Active(bool isActive)
    {
        prizeCrate_03.SetActive(isActive);
    }

    private void SetPrize_01ImageActive(bool isActive)
    {
        prize_01_image.gameObject.SetActive(isActive);
    }

    private void SetPrize_02ImageActive(bool isActive)
    {
        prize_02_image.gameObject.SetActive(isActive);
    }

    private void SetPrize_03ImageActive(bool isActive)
    {
        prize_03_image.gameObject.SetActive(isActive);
    }

    private void SetPrice_Btn_01ImageActive(bool isActive)
    {
        priceBtn_01_image.gameObject.SetActive(isActive);
    }

    private void SetPrice_Btn_02ImageActive(bool isActive)
    {
        priceBtn_02_image.gameObject.SetActive(isActive);
    }

    private void SetPrice_Btn_03ImageActive(bool isActive)
    {
        priceBtn_03_image.gameObject.SetActive(isActive);
    }

    private void SetCheckmark_01ImageActive(bool isActive)
    {
        checkmark_01_image.gameObject.SetActive(isActive);
    }

    private void SetCheckmark_02ImageActive(bool isActive)
    {
        checkmark_02_image.gameObject.SetActive(isActive);
    }

    private void SetCheckmark_03ImageActive(bool isActive)
    {
        checkmark_03_image.gameObject.SetActive(isActive);
    }

    private void SetAdBtnImage_01Active(bool isActive)
    {
        adBtn_01_image.gameObject.SetActive(isActive);
    }

    private void SetAdBtnImage_02Active(bool isActive)
    {
        adBtn_02_image.gameObject.SetActive(isActive);
    }

    private void SetAdBtnImage_03Active(bool isActive)
    {
        adBtn_03_image.gameObject.SetActive(isActive);
    }

    private void SetPrizeBtnImage_01RaycastTarget(bool isRaycastTarget)
    {
        prizeBtn_01_image.raycastTarget = isRaycastTarget;
    }

    private void SetPrizeBtnImage_02RaycastTarget(bool isRaycastTarget)
    {
        prizeBtn_02_image.raycastTarget = isRaycastTarget;
    }

    private void SetPrizeBtnImage_03RaycastTarget(bool isRaycastTarget)
    {
        prizeBtn_03_image.raycastTarget = isRaycastTarget;
    }

    private void SetPrize_Amount_01Text(int amount)
    {
        prize_amount_01TM.text = amount.ToString();
    }

    private void SetPrize_Amount_02Text(int amount)
    {
        prize_amount_02TM.text = amount.ToString();
    }

    private void SetPrize_Amount_03Text(int amount)
    {
        prize_amount_03TM.text = amount.ToString();
    }

    private void SetHasPrize_01BeenReceived(bool _hasPrize_01BeenReceived)
    {
        hasPrize_01BeenReceived = _hasPrize_01BeenReceived;
    }

    private void SetHasPrize_02BeenReceived(bool _hasPrize_02BeenReceived)
    {
        hasPrize_02BeenReceived = _hasPrize_02BeenReceived;
    }

    private void SetHasPrize_03BeenReceived(bool _hasPrize_03BeenReceived)
    {
        hasPrize_03BeenReceived = _hasPrize_03BeenReceived;
    }

    private void SetExitPrizeMenuBtnActive(bool isActive)
    {
        exitPrizeMenuBtn.SetActive(isActive);
    }

    private void SetContinuePrizeMenuBtnActive(bool isActive)
    {
        continuePrizeMenuBtn.SetActive(isActive);
    }

    private bool GetHasPrize_01BeenReceived()
    {
        return hasPrize_01BeenReceived;
    }

    private bool GetHasPrize_02BeenReceived()
    {
        return hasPrize_02BeenReceived;
    }

    private bool GetHasPrize_03BeenReceived()
    {
        return hasPrize_03BeenReceived;
    }

    public void SetLevelCompletedText(int level)
    {
        levelCompletedTM.text = "LEVEL " + level;
    }

    private IEnumerator AnimateRankPercentage()
    {
        roundedFillAmount = Mathf.RoundToInt(rankManager.GetCurrentFillAmount() * 100);
        roundedTargetFillAmount = Mathf.RoundToInt(rankManager.GetTargetFillAmount() * 100);
        while (roundedFillAmount != roundedTargetFillAmount)
        {
            yield return new WaitForSecondsRealtime(.1f);
            roundedFillAmount = Mathf.RoundToInt(rankManager.GetCurrentFillAmount() * 100);
            roundedTargetFillAmount = Mathf.RoundToInt(rankManager.GetTargetFillAmount() * 100);
            SetRankFillAmount(rankManager.GetCurrentFillAmount() + .01f);
            rankManager.SetCurrentFillAmount(rankFill_image.fillAmount);
            SetRankPercentageText(roundedFillAmount);
        }
        rankManager.SaveFillAmount(rankManager.GetTargetFillAmount());
        if (roundedTargetFillAmount != 100)
        {
            StartCoroutine(nameof(WaitHideRank), 1.5f);
        }
        else
        {
            if (rankManager.GetIsSkinShopUnlocked() == 0)
            {
                rankManager.UnlockSkinShop();
            }
            SetRankImageActive(false);
            rankManager.ResetRankFillAmount();
            SetSkinMenuActive(true);
            SetNewSkinFXActive(true);
            if (rankManager.GetIsMale_01SkinOffer())
            {
                SetSkin_Male_01Active(true);
            }
            if (rankManager.GetIsHomelessSkinOffer())
            {
                SetSkin_HomelessActive(true);
            }
            if (rankManager.GetIsBikerSkinOffer())
            {
                SetSkin_BikerActive(true);
            }
            if (rankManager.GetIsFemale_01SkinOffer())
            {
                SetSkin_Female_01Active(true);
            }
        }
    }

    private IEnumerator AnimateHelicopterRankPercentage()
    {
        roundedHelicopterFillAmount = Mathf.RoundToInt(helicopterRankManager.GetCurrentFillAmount() * 100);
        roundedHelicopterTargetFillAmount = Mathf.RoundToInt(helicopterRankManager.GetTargetFillAmount() * 100);
        while (roundedHelicopterFillAmount != roundedHelicopterTargetFillAmount)
        {
            yield return new WaitForSecondsRealtime(.1f);
            roundedHelicopterFillAmount = Mathf.RoundToInt(helicopterRankManager.GetCurrentFillAmount() * 100);
            roundedHelicopterTargetFillAmount = Mathf.RoundToInt(helicopterRankManager.GetTargetFillAmount() * 100);
            SetHelicopterRankFillAmount(helicopterRankManager.GetCurrentFillAmount() + .01f);
            helicopterRankManager.SetCurrentFillAmount(helicopterRankFill_image.fillAmount);
            SetHelicopterRankPercentageText(roundedHelicopterFillAmount);
        }
        helicopterRankManager.SaveFillAmount(helicopterRankManager.GetTargetFillAmount());
        if (roundedHelicopterTargetFillAmount != 100)
        {
            StartCoroutine(nameof(WaitHideHelicopterRank), 1.5f);
        }
        else
        {
            if (helicopterRankManager.GetIsHelicopterShopUnlocked() == 0)
            {
                helicopterRankManager.UnlockHelicopterShop();
            }
            SetHelicopterRankImageActive(false);
            helicopterRankManager.ResetRankFillAmount();
            SetHelicopterMenuActive(true);
            SetNewSkinFXActive(true);
            if (helicopterRankManager.GetIsHelicopter_02SkinOffer())
            {
                SetHelicopter_02SkinActive(true);
            }
            if (helicopterRankManager.GetIsHelicopter_04SkinOffer())
            {
                SetHelicopter_04SkinActive(true);
            }
        }
    }

    public void DeclineNewSkin()
    {
        SetSkinMenuActive(false);
        StartCoroutine(WaitHideRank(0));
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void DeclineNewHelicopterSkin()
    {
        SetHelicopterMenuActive(false);
        StartCoroutine(WaitHideHelicopterRank(0));
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public IEnumerator WaitHideRank(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetRankImageActive(false);
        SetCreditsEarnedImageActive(true);
        if (!prizeManager.GetIsPrizeLevel())
        {
            SetContinueBtnActive(true);
            if (levelReached == 2)
            {
#if UNITY_IOS
                Device.RequestStoreReview();
                Debug.Log(Device.RequestStoreReview());
#elif UNITY_ANDROID
                StartCoroutine(nameof(requireRate));
#endif
            }
            weaponShopManager.CheckForWeaponShopOffer(levelReached);
        } else
        {
            ShowPrizeMenu();
        }
        SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
        if (creditManager.GetIsMultiplyCreditsLevel())
        {
            SetMultiplyCreditsEarnedBtnActive(true);
            SetMultiplyCreditsArrowImageActive(true);
        }
        creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
    }

    public IEnumerator WaitSetSkinMenuActive(bool isActive, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetSkinMenuActive(isActive);
    }

    public IEnumerator WaitSetHelicopterMenuActive(bool isActive, float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetHelicopterMenuActive(isActive);
    }

    public IEnumerator WaitHideHelicopterRank(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetHelicopterRankImageActive(false);
        SetCreditsEarnedImageActive(true);
        if (!prizeManager.GetIsPrizeLevel())
        {
            SetContinueBtnActive(true);
            weaponShopManager.CheckForWeaponShopOffer(levelReached);
        }
        else
        {
            ShowPrizeMenu();
        }
        SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
        if (creditManager.GetIsMultiplyCreditsLevel())
        {
            SetMultiplyCreditsEarnedBtnActive(true);
            SetMultiplyCreditsArrowImageActive(true);
        }
        creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
    }

    public void SetStartLevelMapVisuals(int levelNumber)
    {
        switch (levelNumber)
        {
            case 11:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber));
                break;
            case 12:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber));
                break;
            case 13:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber));
                break;
            case 14:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber));
                break;
            case 15:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber));
                break;
            case 16:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber));
                break;
            case 17:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber));
                break;
            case 18:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber));
                break;
            case 19:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber));
                break;
            case 20:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber));
                break;
            case 21:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber));
                break;
            case 22:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber));
                break;
            case 23:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber));
                break;
            case 24:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber));
                break;
            case 25:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber));
                break;
            case 26:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber));
                break;
            case 27:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber));
                break;
            case 28:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber));
                break;
            case 29:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber));
                break;
            case 30:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber));
                break;
            case 31:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber));
                break;
            default:
                break;
        }
    }


    public void SetEndLevelMapVisuals(int levelNumber)
    {
        switch (levelNumber)
        {
            case 10:
                SetUnlockedMapVisualsActive();
                break;
            case 11:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber + 1));
                break;
            case 12:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber + 1));
                break;
            case 13:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber + 1));
                break;
            case 14:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber + 1));
                break;
            case 15:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber + 1));
                break;
            case 16:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber + 1));
                break;
            case 17:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber + 1));
                break;
            case 18:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber + 1));
                break;
            case 19:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber + 1));
                break;
            case 20:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber + 1));
                break;
            case 21:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber + 1));
                break;
            case 22:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber + 1));
                break;
            case 23:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber + 1));
                break;
            case 24:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber + 1));
                break;
            case 25:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber + 1));
                break;
            case 26:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber + 1));
                break;
            case 27:
                StartCoroutine(ShowWaitHideSlot_03MapVisuals(2f, levelNumber + 1));
                break;
            case 28:
                StartCoroutine(ShowWaitHideSlot_04MapVisuals(2f, levelNumber + 1));
                break;
            case 29:
                StartCoroutine(ShowWaitHideSlot_05MapVisuals(2f, levelNumber + 1));
                break;
            case 30:
                StartCoroutine(ShowWaitHideSlot_01MapVisuals(2f, levelNumber + 1));
                break;
            case 31:
                StartCoroutine(ShowWaitHideSlot_02MapVisuals(2f, levelNumber + 1));
                break;
            default:
                Debug.Log("Level number invalid...");
                break;
        }
    }

    private void SetUnlockedMapVisualsActive()
    {
        SetMapUIActive(true);
        SetMapSlot_01TextColor(Color.black);
        SetMapSlot_01BackgroundAlpha(1f);
        SetMapSlot_01CurrentImageActive(true);
        SetUnlockMapTextActive(true);
        SetContinueMapsBtnActive(true);
        SetContinueBtnActive(false);
        SetCreditsEarnedImageActive(false);
    }

    public void HideMapUI()
    {
        SetMapUIActive(false);
        helicopterRankManager.CheckForHelicopterRankLevel(gameManager.currentLevel);
        if (!helicopterRankManager.GetIsHelicopterRankLevel())
        {
            rankManager.CheckForRankLevel(gameManager.currentLevel);
            prizeManager.CheckIfPrizeLevel(gameManager.currentLevel);
            if (!rankManager.GetIsRankLevel())
            {
                if (!prizeManager.GetIsPrizeLevel())
                {
                    weaponShopManager.CheckForWeaponShopOffer(gameManager.currentLevel);
                }
                else
                {
                    ShowPrizeMenu();
                    SetContinueBtnActive(false);
                }
                SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                if (creditManager.GetIsMultiplyCreditsLevel())
                {
                    SetMultiplyCreditsEarnedBtnActive(true);
                    SetMultiplyCreditsArrowImageActive(true);
                }
                creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
            }
        }
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    private void ResetMapVisuals()
    {
        SetMapSlot_01TextColor(Color.white);
        SetMapSlot_02TextColor(Color.white);
        SetMapSlot_03TextColor(Color.white);
        SetMapSlot_04TextColor(Color.white);
        SetMapSlot_05TextColor(Color.white);
        SetMapSlot_01BackgroundAlpha(0f);
        SetMapSlot_02BackgroundAlpha(0f);
        SetMapSlot_03BackgroundAlpha(0f);
        SetMapSlot_04BackgroundAlpha(0f);
        SetMapSlot_05BackgroundAlpha(0f);
        SetMapSlot_01CurrentImageActive(false);
        SetMapSlot_02CurrentImageActive(false);
        SetMapSlot_03CurrentImageActive(false);
        SetMapSlot_04CurrentImageActive(false);
        SetMapSlot_05CurrentImageActive(false);
        SetMapSlot_05BossImageColor(Color.white);
    }

    private IEnumerator ShowWaitHideSlot_01MapVisuals(float delay, int levelReached)
    {
        ResetMapVisuals();
        SetMapUIActive(true);
        SetMapSlot_01Text(levelReached.ToString());
        SetMapSlot_02Text((levelReached + 1).ToString());
        SetMapSlot_03Text((levelReached + 2).ToString());
        SetMapSlot_04Text((levelReached + 3).ToString());
        if (levelReached > 15)
        {
            if (levelReached < 26)
            {
                SetWorldNumberText("WORLD 2");
            } else
            {
                SetWorldNumberText("WORLD 3");
            }
            if (levelReached < 21 || levelReached > 25 && levelReached < 31)
            {
                SetMapSlot_05TextActive(true);
                SetMapSlot_05Text((levelReached + 4).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            } else
            {
                SetMapSlot_05TextActive(false);
                SetMapSlot_05BossTextActive(true);
                SetMapSlot_05BossImageActive(true);
            }
        }
        SetMapSlot_01TextColor(Color.black);
        SetMapSlot_01BackgroundAlpha(1f);
        SetMapSlot_01CurrentImageActive(true);
        SetContinueBtnActive(false);
        SetCreditsEarnedImageActive(false);

        yield return new WaitForSecondsRealtime(delay);

        SetMapUIActive(false);
        if (GameManager.isLevelComplete)
        {
            helicopterRankManager.CheckForHelicopterRankLevel(gameManager.currentLevel);
            if (!helicopterRankManager.GetIsHelicopterRankLevel())
            {
                rankManager.CheckForRankLevel(gameManager.currentLevel);
                prizeManager.CheckIfPrizeLevel(gameManager.currentLevel);
                if (!rankManager.GetIsRankLevel())
                {
                    if (!prizeManager.GetIsPrizeLevel())
                    {
                        weaponShopManager.CheckForWeaponShopOffer(gameManager.currentLevel);
                    }
                    else
                    {
                        ShowPrizeMenu();
                        SetContinueBtnActive(false);
                    }
                    SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                    if (creditManager.GetIsMultiplyCreditsLevel())
                    {
                        SetMultiplyCreditsEarnedBtnActive(true);
                        SetMultiplyCreditsArrowImageActive(true);
                    }
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                }
            }
        }
    }

    private IEnumerator ShowWaitHideSlot_02MapVisuals(float delay, int levelReached)
    {
        ResetMapVisuals();
        SetMapUIActive(true);
        SetMapSlot_01Text((levelReached - 1).ToString());
        SetMapSlot_02Text(levelReached.ToString());
        SetMapSlot_03Text((levelReached + 1).ToString());
        SetMapSlot_04Text((levelReached + 2).ToString());
        if (levelReached > 15)
        {
            if (levelReached < 26)
            {
                SetWorldNumberText("WORLD 2");
            } else
            {
                SetWorldNumberText("WORLD 3");
            }
            if (levelReached < 21 || levelReached > 25 && levelReached < 31)
            {
                SetMapSlot_05TextActive(true);
                SetMapSlot_05Text((levelReached + 3).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            }
        }
        SetMapSlot_02TextColor(Color.black);
        SetMapSlot_02BackgroundAlpha(1f);
        SetMapSlot_02CurrentImageActive(true);
        SetContinueBtnActive(false);
        SetCreditsEarnedImageActive(false);

        yield return new WaitForSecondsRealtime(delay);

        SetMapUIActive(false);
        if (GameManager.isLevelComplete)
        {
            helicopterRankManager.CheckForHelicopterRankLevel(gameManager.currentLevel);
            if (!helicopterRankManager.GetIsHelicopterRankLevel())
            {
                rankManager.CheckForRankLevel(gameManager.currentLevel);
                prizeManager.CheckIfPrizeLevel(gameManager.currentLevel);
                if (!rankManager.GetIsRankLevel())
                {
                    if (!prizeManager.GetIsPrizeLevel())
                    {
                        weaponShopManager.CheckForWeaponShopOffer(gameManager.currentLevel);
                    }
                    else
                    {
                        ShowPrizeMenu();
                        SetContinueBtnActive(false);
                    }
                    SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                    if (creditManager.GetIsMultiplyCreditsLevel())
                    {
                        SetMultiplyCreditsEarnedBtnActive(true);
                        SetMultiplyCreditsArrowImageActive(true);
                    }
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                }
            }
        }
    }

    private IEnumerator ShowWaitHideSlot_03MapVisuals(float delay, int levelReached)
    {
        ResetMapVisuals();
        SetMapUIActive(true);
        SetMapSlot_01Text((levelReached - 2).ToString());
        SetMapSlot_02Text((levelReached - 1).ToString());
        SetMapSlot_03Text(levelReached.ToString());
        SetMapSlot_04Text((levelReached + 1).ToString());
        if (levelReached > 15)
        {
            if (levelReached < 26)
            {
                SetWorldNumberText("WORLD 2");
            }
            else
            {
                SetWorldNumberText("WORLD 3");
            }
            if (levelReached < 21 || levelReached > 25 && levelReached < 31)
            {
                SetMapSlot_05TextActive(true);
                SetMapSlot_05Text((levelReached + 2).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            }
        }
        SetMapSlot_03TextColor(Color.black);
        SetMapSlot_03BackgroundAlpha(1f);
        SetMapSlot_03CurrentImageActive(true);
        SetContinueBtnActive(false);
        SetCreditsEarnedImageActive(false);

        yield return new WaitForSecondsRealtime(delay);

        SetMapUIActive(false);
        if (GameManager.isLevelComplete)
        {
            helicopterRankManager.CheckForHelicopterRankLevel(gameManager.currentLevel);
            if (!helicopterRankManager.GetIsHelicopterRankLevel())
            {
                rankManager.CheckForRankLevel(gameManager.currentLevel);
                prizeManager.CheckIfPrizeLevel(gameManager.currentLevel);
                if (!rankManager.GetIsRankLevel())
                {
                    if (!prizeManager.GetIsPrizeLevel())
                    {
                        weaponShopManager.CheckForWeaponShopOffer(gameManager.currentLevel);
                    }
                    else
                    {
                        ShowPrizeMenu();
                        SetContinueBtnActive(false);
                    }
                    SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                    if (creditManager.GetIsMultiplyCreditsLevel())
                    {
                        SetMultiplyCreditsEarnedBtnActive(true);
                        SetMultiplyCreditsArrowImageActive(true);
                    }
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                }
            }
        }
    }

    private IEnumerator ShowWaitHideSlot_04MapVisuals(float delay, int levelReached)
    {
        ResetMapVisuals();
        SetMapUIActive(true);
        SetMapSlot_01Text((levelReached - 3).ToString());
        SetMapSlot_02Text((levelReached - 2).ToString());
        SetMapSlot_03Text((levelReached - 1).ToString());
        SetMapSlot_04Text(levelReached.ToString());
        if (levelReached > 15)
        {
            if (levelReached < 26)
            {
                SetWorldNumberText("WORLD 2");
            }
            else
            {
                SetWorldNumberText("WORLD 3");
            }
            if (levelReached < 21 || levelReached > 25 && levelReached < 31)
            {
                SetMapSlot_05TextActive(true);
                SetMapSlot_05Text((levelReached + 1).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            }
        }
        SetMapSlot_04TextColor(Color.black);
        SetMapSlot_04BackgroundAlpha(1f);
        SetMapSlot_04CurrentImageActive(true);
        SetContinueBtnActive(false);
        SetCreditsEarnedImageActive(false);

        yield return new WaitForSecondsRealtime(delay);

        SetMapUIActive(false);
        if (GameManager.isLevelComplete)
        {
            helicopterRankManager.CheckForHelicopterRankLevel(gameManager.currentLevel);
            if (!helicopterRankManager.GetIsHelicopterRankLevel())
            {
                rankManager.CheckForRankLevel(gameManager.currentLevel);
                prizeManager.CheckIfPrizeLevel(gameManager.currentLevel);
                if (!rankManager.GetIsRankLevel())
                {
                    if (!prizeManager.GetIsPrizeLevel())
                    {
                        weaponShopManager.CheckForWeaponShopOffer(gameManager.currentLevel);
                    }
                    else
                    {
                        ShowPrizeMenu();
                        SetContinueBtnActive(false);
                    }
                    SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                    if (creditManager.GetIsMultiplyCreditsLevel())
                    {
                        SetMultiplyCreditsEarnedBtnActive(true);
                        SetMultiplyCreditsArrowImageActive(true);
                    }
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                }
            }
        }
    }

    private IEnumerator ShowWaitHideSlot_05MapVisuals(float delay, int levelReached)
    {
        ResetMapVisuals();
        SetMapUIActive(true);
        SetMapSlot_01Text((levelReached - 4).ToString());
        SetMapSlot_02Text((levelReached - 3).ToString());
        SetMapSlot_03Text((levelReached - 2).ToString());
        SetMapSlot_04Text((levelReached - 1).ToString());
        if (levelReached > 15)
        {
            if (levelReached < 26)
            {
                SetWorldNumberText("WORLD 2");
            }
            else
            {
                SetWorldNumberText("WORLD 3");
            }
            if (levelReached < 21 || levelReached > 25 && levelReached < 31)
            {
                SetMapSlot_05TextActive(true);
                SetMapSlot_05Text((levelReached).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
                SetMapSlot_05TextColor(Color.black);
            }
            else
            {
                SetMapSlot_05BossImageColor(Color.black);
                SetMapSlot_05BossTextColor(Color.black);
            }
        }
        else
        {
            SetMapSlot_05BossImageColor(Color.black);
            SetMapSlot_05BossTextColor(Color.black);
        }

        SetMapSlot_05BackgroundAlpha(1f);
        SetMapSlot_05CurrentImageActive(true);
        SetContinueBtnActive(false);
        SetCreditsEarnedImageActive(false);

        yield return new WaitForSecondsRealtime(delay);

        SetMapUIActive(false);
        if (GameManager.isLevelComplete)
        {
            helicopterRankManager.CheckForHelicopterRankLevel(gameManager.currentLevel);
            if (!helicopterRankManager.GetIsHelicopterRankLevel())
            {
                rankManager.CheckForRankLevel(gameManager.currentLevel);
                prizeManager.CheckIfPrizeLevel(gameManager.currentLevel);
                if (!rankManager.GetIsRankLevel())
                {
                    if (!prizeManager.GetIsPrizeLevel())
                    {
                        weaponShopManager.CheckForWeaponShopOffer(gameManager.currentLevel);
                    }
                    else
                    {
                        ShowPrizeMenu();
                        SetContinueBtnActive(false);
                    }
                    SetCreditsEarnedCountText(creditManager.GetEarnedCreditCount());
                    if (!creditManager.GetIsMultiplyCreditsLevel())
                    {
                        SetMultiplyCreditsEarnedBtnActive(true);
                        SetMultiplyCreditsArrowImageActive(true);
                    }
                    creditManager.VisualLevelCreditChange(true, creditManager.GetStartLevelCreditCount(), creditManager.GetCreditCount());
                }
            }
        }
    }

    public void ToggleBlood()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        if (GetIsBloodOn() == 0)
        {
            ToggleBloodOn();
            SetIsBloodOn(1);
            return;
        }
        else
        {
            ToggleBloodOff();
            SetIsBloodOn(0);
            return;
        }
    }

    public void ToggleMusic()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        if (GetIsMusicOn() == 0)
        {
            ToggleMusicOn();
            SetIsMusicOn(1);
            return;
        }
        else
        {
            ToggleMusicOff();
            SetIsMusicOn(0);
            return;
        }
    }

    public void ToggleSoundEffects()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        if (GetIsSoundEffectsOn() == 0)
        {
            ToggleSoundEffectsOn();
            SetIsSoundEffectsOn(1);
            return;
        }
        else
        {
            ToggleSoundEffectsOff();
            SetIsSoundEffectsOn(0);
            return;
        }
    }

    public void ToggleHaptics()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
        if (GetIsHapticsOn() == 0)
        {
            ToggleHapticsOn();
            SetIsHapticsOn(1);
            //HapticPatterns.PlayPreset(HapticPatterns.PresetType.Selection);
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.MediumImpact);
            return;
        }
        else
        {
            ToggleHapticsOff();
            SetIsHapticsOn(0);
            return;
        }
    }

    private void InitSettingsBtns()
    {
        if (GetIsBloodOn() == 1)
        {
            ToggleBloodOn();
        }
        else
        {
            ToggleBloodOff();
        }
        if (GetIsMusicOn() == 1)
        {
            ToggleMusicOn();
        }
        else
        {
            ToggleMusicOff();
        }
        if (GetIsSoundEffectsOn() == 1)
        {
            ToggleSoundEffectsOn();
        }
        else
        {
            ToggleSoundEffectsOff();
        }
        if (GetIsHapticsOn() == 1)
        {
            ToggleHapticsOn();
        }
        else
        {
            ToggleHapticsOff();
        }
    }

    private void SetMapUIActive(bool isActive)
    {
        mapUI.SetActive(isActive);
    }

    private void SetWorldNumberText(string text)
    {
        worldNumberText.text = text;
    }

    private void SetMapSlot_01Text(string text)
    {
        mapSlot_01Text.text = text;
    }

    private void SetMapSlot_02Text(string text)
    {
        mapSlot_02Text.text = text;
    }

    private void SetMapSlot_03Text(string text)
    {
        mapSlot_03Text.text = text;
    }

    private void SetMapSlot_04Text(string text)
    {
        mapSlot_04Text.text = text;
    }

    private void SetMapSlot_05Text(string text)
    {
        mapSlot_05Text.text = text;
    }

    private void SetMapSlot_05BossText(string text)
    {
        mapSlot_05BossText.text = text;
    }

    private void SetMapSlot_01TextColor(Color color)
    {
        mapSlot_01Text.color = color;
    }

    private void SetMapSlot_02TextColor(Color color)
    {
        mapSlot_02Text.color = color;
    }

    private void SetMapSlot_03TextColor(Color color)
    {
        mapSlot_03Text.color = color;
    }

    private void SetMapSlot_04TextColor(Color color)
    {
        mapSlot_04Text.color = color;
    }

    private void SetMapSlot_05TextColor(Color color)
    {
        mapSlot_05Text.color = color;
    }

    private void SetMapSlot_05BossTextColor(Color color)
    {
        mapSlot_05BossText.color = color;
    }

    private void SetMapSlot_01BackgroundAlpha(float alpha)
    {
        Color tempColor = mapSlot_01Background.color;
        tempColor.a = alpha;
        mapSlot_01Background.color = tempColor;
    }

    private void SetMapSlot_02BackgroundAlpha(float alpha)
    {
        Color tempColor = mapSlot_02Background.color;
        tempColor.a = alpha;
        mapSlot_02Background.color = tempColor;
    }

    private void SetMapSlot_03BackgroundAlpha(float alpha)
    {
        Color tempColor = mapSlot_03Background.color;
        tempColor.a = alpha;
        mapSlot_03Background.color = tempColor;
    }

    private void SetMapSlot_04BackgroundAlpha(float alpha)
    {
        Color tempColor = mapSlot_04Background.color;
        tempColor.a = alpha;
        mapSlot_04Background.color = tempColor;
    }

    private void SetMapSlot_05BackgroundAlpha(float alpha)
    {
        Color tempColor = mapSlot_05Background.color;
        tempColor.a = alpha;
        mapSlot_05Background.color = tempColor;
    }

    private void SetMapSlot_01CurrentImageActive(bool isActive)
    {
        mapSlot_01CurrentImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_02CurrentImageActive(bool isActive)
    {
        mapSlot_02CurrentImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_03CurrentImageActive(bool isActive)
    {
        mapSlot_03CurrentImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_04CurrentImageActive(bool isActive)
    {
        mapSlot_04CurrentImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05CurrentImageActive(bool isActive)
    {
        mapSlot_05CurrentImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05TextActive(bool isActive)
    {
        mapSlot_05Text.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05BossImageActive(bool isActive)
    {
        mapSlot_05BossImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05BossTextActive(bool isActive)
    {
        mapSlot_05BossText.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05BossImageColor(Color color)
    {
        mapSlot_05BossImage.color = color;
    }

    private void SetContinueMapsBtnActive(bool isActive)
    {
        continueMapBtn.SetActive(isActive);
    }

    private void SetUnlockMapTextActive(bool isActive)
    {
        unlockMapText.gameObject.SetActive(isActive);
    }

    private void SetSkin_Male_01Active(bool isActive)
    {
        skin_Male_01.SetActive(isActive);
    }

    private void SetSkin_HomelessActive(bool isActive)
    {
        skin_Homeless.SetActive(isActive);
    }

    private void SetSkin_BikerActive(bool isActive)
    {
        skin_Biker.SetActive(isActive);
    }

    private void SetSkin_Female_01Active(bool isActive)
    {
        skin_Female_01.SetActive(isActive);
    }

    private void SetHelicopter_02SkinActive(bool isActive)
    {
        skin_Helicopter_02.SetActive(isActive);
    }

    private void SetHelicopter_04SkinActive(bool isActive)
    {
        skin_Helicopter_04.SetActive(isActive);
    }

    private IEnumerator WaitSetExitSkinBtnActive(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetExitSkinBtnActive(true);
    }

    private void SetExitSkinBtnActive(bool isActive)
    {
        exitSkinBtn.SetActive(isActive);
    }

    private IEnumerator WaitSetExitHelicopterSkinBtnActive(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        SetExitHelicopterSkinBtnActive(true);
    }

    private void SetExitHelicopterSkinBtnActive(bool isActive)
    {
        exitHelicopterSkinBtn.SetActive(isActive);
    }

    //private void SetPurchaseSkinBtnActive(bool isActive)
    //{
    //    purchaseSkinBtn.SetActive(isActive);
    //}

    //private void SetPurchaseHelicopterSkinBtnActive(bool isActive)
    //{
    //    purchaseHelicopterSkinBtn.SetActive(isActive);
    //}

    private void SetNewSkinBtnActive(bool isActive)
    {
        newSkinBtn.SetActive(isActive);
    }

    private void SetNewHelicopterSkinBtnActive(bool isActive)
    {
        newHelicopterSkinBtn.SetActive(isActive);
    }

    //private void SetNewSkinBtnInteractable(bool isInteractable)
    //{
    //    newSkinBtn.GetComponent<Image>().raycastTarget = isInteractable;
    //}

    //private void SetNewHelicopterSkinBtnInteractable(bool isInteractable)
    //{
    //    newHelicopterSkinBtn.GetComponent<Image>().raycastTarget = isInteractable;
    //}

    private void SetBossBattleBannerActive(bool isActive)
    {
        bossBattleBanner.gameObject.SetActive(isActive);
    }

    private void SetBossDestroyedBannerActive(bool isActive)
    {
        bossDestroyedBanner.gameObject.SetActive(isActive);
    }

    private IEnumerator ShowBossBannerWaitHide(float delay)
    {
        SetBossBattleBannerActive(true);

        yield return new WaitForSecondsRealtime(delay);

        SetBossBattleBannerActive(false);
    }

    public void ShowBossBanner()
    {
        StartCoroutine(ShowBossBannerWaitHide(2f));
    }

    public void SetCreditFXActive(bool isActive)
    {
        creditFX.gameObject.SetActive(isActive);
    }

    private void SetNewSkinFXActive(bool isActive)
    {
        newSkinFX.gameObject.SetActive(isActive);
    }

    private void SetHasBestPrizeBeenReceived(bool _hasBestPrizeBeenReceived)
    {
        hasBestPrizeBeenReceived = _hasBestPrizeBeenReceived;
    }

    private void ShowExitWeaponShopBtn_Single()
    {
        exitWeaponShopBtn_Single.SetActive(true);
    }

    private void ShowExitWeaponShopBtn_Double()
    {
        exitWeaponShopBtn_Double.SetActive(true);
    }

    private IEnumerator WaitShowExitWeaponShopBtn_Single(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        ShowExitWeaponShopBtn_Single();
    }

    private IEnumerator WaitShowExitWeaponShopBtn_Double(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);

        ShowExitWeaponShopBtn_Double();
    }


    private void ToggleBloodOn()
    {
        SetToggleBloodOnImageActive(true);
        SetToggleBloodOffImageActive(false);
    }

    private void ToggleBloodOff()
    {
        SetToggleBloodOnImageActive(false);
        SetToggleBloodOffImageActive(true);
    }

    private void ToggleMusicOn()
    {
        AudioManager.Instance.ToggleMusicOn();
        SetToggleMusicOnImageActive(true);
        SetToggleMusicOffImageActive(false);
    }

    private void ToggleMusicOff()
    {
        AudioManager.Instance.ToggleMusicOff();
        SetToggleMusicOnImageActive(false);
        SetToggleMusicOffImageActive(true);
    }

    private void ToggleSoundEffectsOn()
    {
        AudioManager.Instance.ToggleSoundEffectsOn();
        SetToggleSoundEffectsOnImageActive(true);
        SetToggleSoundEffectsOffImageActive(false);
    }

    private void ToggleSoundEffectsOff()
    {
        AudioManager.Instance.ToggleSoundEffectsOff();
        SetToggleSoundEffectsOnImageActive(false);
        SetToggleSoundEffectsOffImageActive(true);
    }

    private void ToggleHapticsOn()
    {
        SetToggleHapticsOnImageActive(true);
        SetToggleHapticsOffImageActive(false);
    }

    private void ToggleHapticsOff()
    {
        SetToggleHapticsOnImageActive(false);
        SetToggleHapticsOffImageActive(true);
    }

    private void SetToggleBloodOnImageActive(bool isActive)
    {
        toggleBloodOn_image.gameObject.SetActive(isActive);
    }

    private void SetToggleBloodOffImageActive(bool isActive)
    {
        toggleBloodOff_image.gameObject.SetActive(isActive);
    }

    private void SetToggleMusicOnImageActive(bool isActive)
    {
        toggleMusicOn_image.gameObject.SetActive(isActive);
    }

    private void SetToggleMusicOffImageActive(bool isActive)
    {
        toggleMusicOff_image.gameObject.SetActive(isActive);
    }

    private void SetToggleSoundEffectsOnImageActive(bool isActive)
    {
        toggleSoundEffectsOn_image.gameObject.SetActive(isActive);
    }

    private void SetToggleSoundEffectsOffImageActive(bool isActive)
    {
        toggleSoundEffectsOff_image.gameObject.SetActive(isActive);
    }

    private void SetToggleHapticsOnImageActive(bool isActive)
    {
        toggleHapticssOn_image.gameObject.SetActive(isActive);
    }

    private void SetToggleHapticsOffImageActive(bool isActive)
    {
        toggleHapticsOff_image.gameObject.SetActive(isActive);
    }

    public int GetIsBloodOn()
    {
        isBloodOn = PlayerPrefs.GetInt(isBloodOnPlayerPrefsName, 1);
        return isBloodOn;
    }

    private int GetIsMusicOn()
    {
        isMusicOn = PlayerPrefs.GetInt(isMusicOnPlayerPrefsName, 1);
        return isMusicOn;
    }

    private int GetIsSoundEffectsOn()
    {
        isSoundEffectsOn = PlayerPrefs.GetInt(isSoundEffectsOnPlayerPrefsName, 1);
        return isSoundEffectsOn;
    }

    public int GetIsHapticsOn()
    {
        isHapticsOn = PlayerPrefs.GetInt(isHapticsOnPlayerPrefsName, 1);
        return isHapticsOn;
    }

    private void SetIsBloodOn(int _isBloodOn)
    {
        PlayerPrefs.SetInt(isBloodOnPlayerPrefsName, _isBloodOn);
    }

    private void SetIsMusicOn(int _isMusicOn)
    {
        PlayerPrefs.SetInt(isMusicOnPlayerPrefsName, _isMusicOn);
    }

    private void SetIsSoundEffectsOn(int _isSoundEffectsOn)
    {
        PlayerPrefs.SetInt(isSoundEffectsOnPlayerPrefsName, _isSoundEffectsOn);
    }

    private void SetIsHapticsOn(int _isHapticsOn)
    {
        PlayerPrefs.SetInt(isHapticsOnPlayerPrefsName, _isHapticsOn);
    }

    public void IncreaseKillCountScale(float scale)
    {
        killCount.transform.localScale += new Vector3(scale, scale, scale);
    }

    public Color GetWhiteColor()
    {
        Color color = new Color32(255, 255, 255, 255);
        return color;
    }

    public Color GetKilltacularColor()
    {
        Color color = new Color32(248, 214, 36, 255);
        return color;
    }

    public Color GetKillFrenzyColor()
    {
        Color color = new Color32(241, 151, 28, 255);
        return color;
    }

    public Color GetKilltrocityColor()
    {
        Color color = new Color32(176, 241, 28, 255);
        return color;
    }

    public Color GetFallColor()
    {
        Color color = new Color32(224, 219, 54, 255);
        return color;
    }

    public Color GetSquishColor()
    {
        Color color = new Color32(241, 151, 28, 255);
        return color;
    }

    public Color GetCollideColor()
    {
        Color color = new Color32(241, 92, 28, 255);
        return color;
    }

    public Color GetLaunchedColor()
    {
        Color color = new Color32(241, 52, 28, 255);
        return color;
    }

    public Color GetBuildingColor()
    {
        Color color = new Color32(241, 151, 28, 255);
        return color;
    }

    public string GetBlueSkullSprite()
    {
        return "<sprite=0 color=#6294E0> ";
    }

    public string GetKilltacularSkullSprite()
    {
        return "<sprite=0 color=#F8D624> ";
    }

    public string GetKillFrenzySkullSprite()
    {
        return "<sprite=0 color=#F1971C> ";
    }

    public string GetKilltrocitySkullSprite()
    {
        return "<sprite=0 color=#B0F11C> ";
    }

    public string GetFallSkullSprite()
    {
        return "<sprite=0 color=#E0DB36> ";
    }

    public string GetSquishSkullSprite()
    {
        return "<sprite=0 color=#F1971C> ";
    }

    public string GetCollideSkullSprite()
    {
        return "<sprite=0 color=#F15C1C> ";
    }

    public string GetLaunchedSkullSprite()
    {
        return "<sprite=0 color=#F1341C> ";
    }

    public string GetBuildingSkullSprite()
    {
        return "<sprite=0 color=#F1971C> ";
    }

    public int GetNumberOfLevelsSkipped()
    {
        numberOfLevelsSkipped = PlayerPrefs.GetInt(numberOfLevelsSkippedPlayerPrefsName, 0);
        return numberOfLevelsSkipped;
    }

    private void IncreaseNumberOfLevelsSkipped()
    {
        numberOfLevelsSkipped = GetNumberOfLevelsSkipped();
        numberOfLevelsSkipped++;
        PlayerPrefs.SetInt(numberOfLevelsSkippedPlayerPrefsName, numberOfLevelsSkipped);
    }

    private void SetVersionText()
    {
        versionNumberTM.text = "v" + Application.version.ToString();
    }

    //private void SetInfoMenuActive(bool isActive)
    //{
    //    infoMenu.SetActive(isActive);
    //    if (isActive)
    //    {
    //        SetInfoBtnActive(false);
    //    }
    //    else
    //    {
    //        SetInfoBtnActive(true);
    //    }
    //}

    //private void SetInfoBtnActive(bool isActive)
    //{
    //    infoBtn.SetActive(isActive);
    //}

#if UNITY_IOS
#elif UNITY_ANDROID
       private IEnumerator requireRate()
    {
        ReviewManager _reviewManager;
        PlayReviewInfo _playReviewInfo;
        _reviewManager = new ReviewManager();
        var requestFlowOperation = _reviewManager.RequestReviewFlow();
        yield return requestFlowOperation;
        if (requestFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            Debug.Log(requestFlowOperation.Error.ToString());
            yield break;
        }
        _playReviewInfo = requestFlowOperation.GetResult();
        var launchFlowOperation = _reviewManager.LaunchReviewFlow(_playReviewInfo);
        yield return launchFlowOperation;
        _playReviewInfo = null; // Reset the object
        if (launchFlowOperation.Error != ReviewErrorCode.NoError)
        {
            // Log error. For example, using requestFlowOperation.Error.ToString().
            Debug.Log(requestFlowOperation.Error.ToString());
            yield break;
        }
        // The flow has finished. The API does not indicate whether the user
        // reviewed or not, or even whether the review dialog was shown. Thus, no
        // matter the result, we continue our app flow.
    }
#endif
}
