using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.EventSystems;
using TMPro;
using Unity.Services.Analytics;

public class RewardedAdsButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] Button _showAdButton;
    [SerializeField] string _androidAdUnitId = "Rewarded_Android";
    [SerializeField] string _iOSAdUnitId = "Rewarded_iOS";
    [SerializeField] private TextMeshProUGUI noConnectionTM;
    [SerializeField] private EventTrigger noConnectionPopUpEvent;
    private float noConnectionTextAnimationTime = 1f;
    string _adUnitId = null; // This will remain null for unsupported platforms
    private string gunTrialBtn = "GUN_TRIAL_BTN";
    private string multiplyCreditsEarnedBtn = "MULTIPLY_CREDITS_EARNED_BTN";
    private string freeShieldPackBtn = "FREE_SHIELD_PACK_BTN";
    private string newSkinBtn = "NEW_SKIN_BTN";
    private string newHelicopterSkinBtn = "NEW_HELICOPTER_SKIN_BTN";
    private string male_01WatchAdBtn = "MALE_01_WATCH_AD_BTN";
    private string soldierWatchAdBtn = "SOLDIER_WATCH_AD_BTN";
    private string hazmatWatchAdBtn = "HAZMAT_WATCH_AD_BTN";
    private string homelessWatchAdBtn = "HOMELESS_WATCH_AD_BTN";
    private string bikerWatchAdBtn = "BIKER_WATCH_AD_BTN";
    private string riotCopWatchAdBtn = "RIOT_COP_WATCH_AD_BTN";
    private string female_01WatchAdBtn = "FEMALE_01_WATCH_AD_BTN";
    private string helicopter_02WatchAdBtn = "HELICOPTER_02_WATCH_AD_BTN";
    private string helicopter_03WatchAdBtn = "HELICOPTER_03_WATCH_AD_BTN";
    private string helicopter_04WatchAdBtn = "HELICOPTER_04_WATCH_AD_BTN";
    private string prizeBtn_01WatchAdBtn = "PRIZE_WATCH_AD_BTN_01";
    private string prizeBtn_02WatchAdBtn = "PRIZE_WATCH_AD_BTN_02";
    private string prizeBtn_03WatchAdBtn = "PRIZE_WATCH_AD_BTN_03";
    private string skipLevelBtn = "SKIP_LEVEL_BTN";
    private bool isRewardedAdLoaded;

    // Analytics.
    private string levelSkippedEventName = "levelSkipped";
    private string levelCompleteEventName = "levelComplete";
    private string tutorialGlassTriggeredEventName = "tutorialGlassTriggered";
    private string tutorialGlassEndedEventName = "tutorialGlassEnded";
    private string checkpointReachedEventName = "checkpointReached";
    private string tutorialFallTriggeredEventName = "tutorialFallTriggered";
    private string tutorialFallEndedEventName = "tutorialFallEnded";

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
#if UNITY_IOS
        _adUnitId = _iOSAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        //Disable the button until the ad is ready to show:
        _showAdButton.interactable = false;
        if (AdsInitializer.isInitialized && !isRewardedAdLoaded)
        {
            LoadAd();
        }
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        isRewardedAdLoaded = true;
        noConnectionPopUpEvent.enabled = false;

        if (adUnitId.Equals(_adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            _showAdButton.onClick.AddListener(ShowAd);
            // Enable the button for users to click:
            _showAdButton.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button:
    public void ShowAd()
    {
        // Disable the button:
        _showAdButton.interactable = false;
        // Then show the ad:
        Advertisement.Show(_adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            AdsInitializer.hasWatchedRewardedAd = true;
            if (gameObject.name == gunTrialBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.ClaimGunTrial();
                homeUI.TapToPlay();
            }
            if (gameObject.name == freeShieldPackBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.ClaimFreeShieldPack();
                homeUI.TapToPlay();
            }
            if (gameObject.name == male_01WatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.Male_01Btn();
            }
            if (gameObject.name == soldierWatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.SoldierBtn();
            }
            if (gameObject.name == hazmatWatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.HazmatBtn();
            }
            if (gameObject.name == homelessWatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.HomelessBtn();
            }
            if (gameObject.name == bikerWatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.BikerBtn();
            }
            if (gameObject.name == riotCopWatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.RiotCopBtn();
            }
            if (gameObject.name == female_01WatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.Female_01Btn();
            }
            if (gameObject.name == helicopter_02WatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.Helicopter_02Btn();
            }
            if (gameObject.name == helicopter_03WatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.Helicopter_03Btn();
            }
            if (gameObject.name == helicopter_04WatchAdBtn)
            {
                HomeUI homeUI = FindObjectOfType<HomeUI>();
                homeUI.Helicopter_04Btn();
            }
            if (gameObject.name == multiplyCreditsEarnedBtn)
            {
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.MultiplyCreditsEarnedBtn();
            }
            if (gameObject.name == newSkinBtn)
            {
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.NewSkinBtn();
            }
            if (gameObject.name == newHelicopterSkinBtn)
            {
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.NewHelicopterSkinBtn();
            }
            if (gameObject.name == prizeBtn_01WatchAdBtn)
            {
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.PrizeBtn_01();
            }
            if (gameObject.name == prizeBtn_02WatchAdBtn)
            {
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.PrizeBtn_02();
            }
            if (gameObject.name == prizeBtn_03WatchAdBtn)
            {
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.PrizeBtn_03();
            }
            if (gameObject.name == skipLevelBtn)
            {
                GameManager gameManager = FindObjectOfType<GameManager>();
                if (PlayerPrefs.GetInt(levelSkippedEventName + gameManager.currentLevel, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    {  "userLevel", gameManager.currentLevel },
                    };
                    AnalyticsService.Instance.CustomData(levelSkippedEventName, parameters);
                    PlayerPrefs.SetInt(levelSkippedEventName + gameManager.currentLevel, 1);
                }
                if (gameManager.currentLevel == 2 || gameManager.currentLevel == 3 || gameManager.currentLevel == 4 || gameManager.currentLevel == 5)
                {
                    if (gameManager.currentLevel == 3 || gameManager.currentLevel == 4)
                    {
                        if (gameManager.currentLevel == 3)
                        {
                            if (PlayerPrefs.GetInt(tutorialGlassTriggeredEventName, 0) == 0)
                            {
                                Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            {  "tutorialStatus", "Skipped" },
                            };
                                AnalyticsService.Instance.CustomData(tutorialGlassTriggeredEventName, parameters);
                                PlayerPrefs.SetInt(tutorialGlassTriggeredEventName, 1);
                            }
                            if (PlayerPrefs.GetInt(tutorialGlassEndedEventName, 0) == 0)
                            {
                                Dictionary<string, object> parameters = new Dictionary<string, object>()
                                {
                                };
                                AnalyticsService.Instance.CustomData(tutorialGlassEndedEventName, parameters);
                                PlayerPrefs.SetInt(tutorialGlassEndedEventName, 1);
                            }
                        }

                        if (PlayerPrefs.GetInt(checkpointReachedEventName + gameManager.currentLevel, 0) == 0)
                        {
                            Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            {  "userLevel", gameManager.currentLevel },
                            };
                            AnalyticsService.Instance.CustomData(checkpointReachedEventName, parameters);
                            PlayerPrefs.SetInt(checkpointReachedEventName + gameManager.currentLevel, 1);
                        }
                    }

                    if (gameManager.currentLevel == 4)
                    {
                        if (PlayerPrefs.GetInt(tutorialFallTriggeredEventName, 0) == 0)
                        {
                            Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            {  "tutorialStatus", "Skipped" },
                            };
                            AnalyticsService.Instance.CustomData(tutorialFallTriggeredEventName, parameters);
                            PlayerPrefs.SetInt(tutorialFallTriggeredEventName, 1);
                        }
                        if (PlayerPrefs.GetInt(tutorialFallEndedEventName, 0) == 0)
                        {
                            Dictionary<string, object> parameters = new Dictionary<string, object>()
                            {
                            };
                            AnalyticsService.Instance.CustomData(tutorialFallEndedEventName, parameters);
                            PlayerPrefs.SetInt(tutorialFallEndedEventName, 1);
                        }
                    }


                    if (PlayerPrefs.GetInt(levelCompleteEventName + gameManager.currentLevel, 0) == 0)
                    {
                        Dictionary<string, object> parameters = new Dictionary<string, object>()
                        {
                        {  "userLevel", gameManager.currentLevel },
                        };
                        AnalyticsService.Instance.CustomData(levelCompleteEventName, parameters);
                        PlayerPrefs.SetInt(levelCompleteEventName + gameManager.currentLevel, 1);
                    }
                }
                LevelUI levelUI = FindObjectOfType<LevelUI>();
                levelUI.SkipLevel();
            }

            isRewardedAdLoaded = false;
            // Load another ad:
            Advertisement.Load(_adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        _showAdButton.onClick.RemoveAllListeners();
    }

    public void SetNoConnectionTextActive(bool isActive)
    {
        noConnectionTM.gameObject.SetActive(isActive);
    }

    public void StartNoConnectionAnimation()
    {
        StartCoroutine(ShowWaitHideNoConnectionText());
        if (!AdsInitializer.isInitialized)
        {
            AdsInitializer adsInitializer = FindObjectOfType<AdsInitializer>();
            if (adsInitializer != null)
            {
                adsInitializer.InitializeAds();
            }
        } else
        {
            if (!isRewardedAdLoaded)
            {
                LoadAd();
            }
        }
    }

    private IEnumerator ShowWaitHideNoConnectionText()
    {
        SetNoConnectionTextActive(true);

        yield return new WaitForSecondsRealtime(noConnectionTextAnimationTime);

        SetNoConnectionTextActive(false);
    }
}
