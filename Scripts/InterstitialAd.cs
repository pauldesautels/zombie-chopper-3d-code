using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class InterstitialAd : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static InterstitialAd instance;
    [SerializeField] private AdsManager adsManager;

    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;

    private string levelReachPlayerPrefsName = "levelReached";

    void Awake()
    {
#if UNITY_IOS
        _adUnitId = _iOsAdUnitId;
#elif UNITY_ANDROID
        _adUnitId = _androidAdUnitId;
#endif
        //// Get the Ad Unit ID for the current platform:
        //_adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
        //    ? _iOsAdUnitId
        //    : _androidAdUnitId;

        if (adsManager.GetHasCompletedFirstPurchase() == 0)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            }
        }
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // Show the loaded content in the Ad Unit:
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
        AdsInitializer.isInterstitialAdLoaded = false;
        // Load another ad:
        Advertisement.Load(_adUnitId, this);
    }

    // Implement Load Listener and Show Listener interface methods: 
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        //ShowAd();
        Debug.Log("Interstital ad loaded");
        AdsInitializer.isInterstitialAdLoaded = true;
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (LevelUI.wasReviveBtnClicked) // Applies when an interstitial ad is shown mid-level because a player has clicked revive multiple times.
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            if (AdsInitializer.isBannerAdLoaded)
            {
                FindObjectOfType<AdsInitializer>().ShowBannerAd();
            }
            //LevelUI.hasAlreadyClickedReviveBtn = false;
            ItemManager itemManager = FindObjectOfType<ItemManager>();
            int levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
            if (levelReached == 6)
            {
                PackManager.isViewingShieldPackAgain = true;
                LevelUI.offerShieldPackageAgain = true;
            }
            if (levelReached == 9)
            {
                if (itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0)
                {
                    LevelUI.offerGunTrialAgain = true;
                } else
                {
                    PackManager.isViewingShieldPackAgain = true;
                    LevelUI.offerShieldPackageAgain = true;
                }
            }
            if (levelReached == 10)
            {
                PackManager.isViewingShieldPackAgain = true;
                LevelUI.offerShieldPackageAgain = true;
            }
            if (levelReached >= 11)
            {
                if (levelReached != 16)
                {
                    PackManager.isViewingShieldPackAgain = true;
                    LevelUI.offerShieldPackageAgain = true;
                }
                else
                {
                    if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0)
                    {
                        LevelUI.offerGunTrialAgain = true;
                    }
                    else
                    {
                        PackManager.isViewingShieldPackAgain = true;
                        LevelUI.offerShieldPackageAgain = true;
                    }
                }
            }
        }
    }
}
