using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    // Static References
    public static AdsInitializer instance;
    public static bool isInitialized;

    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    private string _gameId;

    [SerializeField] private InterstitialAd interstitialAd;
    [SerializeField] private BannerAd bannerAd;
    [SerializeField] private AdsManager adsManager;
    private int levelReached;
    private string levelReachPlayerPrefsName = "levelReached";
    public static bool hasWatchedRewardedAd;
    public static bool isInterstitialAdLoaded;
    public static bool isBannerAdLoaded;
    public static int levelToBeginInterstitialAds = 5;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
            InitializeAds();
        }
    }

    public void InitializeAds()
    {
#if UNITY_IOS
       _gameId = _iOSGameId;
#elif UNITY_ANDROID
        _gameId = _androidGameId;
#endif
        Advertisement.Initialize(_gameId, _testMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        isInitialized = true;
        LoadInterstitialAd();
        LoadBannerAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void LoadInterstitialAd()
    {
        if (adsManager.GetHasCompletedFirstPurchase() == 0)
        {
            if (interstitialAd != null)
            {
                interstitialAd.LoadAd();
            }
        }
    }

    //public void ShowInterstitialAd()
    //{
    //    if (adsManager.GetHasCompletedFirstPurchase() == 0)
    //    {
    //        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
    //        if (levelReached >= levelToBeginInterstitialAds && !hasWatchedRewardedAd && !GameManager.isExitingLevel)
    //        {
    //            interstitialAd.ShowAd();
    //        }
    //    }
    //}

    public void LoadBannerAd()
    {
        if (adsManager.GetHasCompletedFirstPurchase() == 0)
        {
            if (bannerAd != null)
            {
                bannerAd.LoadBanner();
            }
        }
    }

    public void ShowBannerAd()
    {
        if (adsManager.GetHasCompletedFirstPurchase() == 0)
        {
            levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
            if (levelReached >= 3 && !BannerAd.isShowing)
            {
                bannerAd.ShowBannerAd();
            }
        }
    }

    public void HideBannerAd()
    {
        if (bannerAd != null)
        {
            bannerAd.HideBannerAd();
        }
    }
}
