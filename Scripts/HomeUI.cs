using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Lofelt.NiceVibrations;

using DG.Tweening;


public class HomeUI : MonoBehaviour
{
    [SerializeField] private GameObject Object_Top;
    [Space]
    [SerializeField] private GunTrialManager gunTrialManager;
    [SerializeField] private PackManager packManager;
    [SerializeField] private HomeManager homeManager;
    [SerializeField] private CreditManager creditManager;
    [SerializeField] private TextMeshProUGUI currentCreditCountTM;
    [SerializeField] private TextMeshProUGUI shieldCountTM;
    [SerializeField] private TextMeshProUGUI levelTM;
    [SerializeField] private Image levelTextHeader;
    [SerializeField] private Image credits_image;
    [SerializeField] private Image shield_image;
    [SerializeField] private Button starterPackBtn;
    [SerializeField] private Button secondPackBtn;
    [SerializeField] private Button thirdPackBtn;
    [SerializeField] private TextMeshProUGUI starterPackTabTimeLeftTM;
    [SerializeField] private TextMeshProUGUI secondPackTabTimeLeftTM;
    [SerializeField] private TextMeshProUGUI thirdPackTabTimeLeftTM;
    [SerializeField] private WorldTimer worldTimer;
    [SerializeField] private Image purchasesDisableAds_image;
    [SerializeField] private Image mapUI;
    [SerializeField] private TextMeshProUGUI versionNumberTM;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform shopCamTransform;
    //[SerializeField] private IAPManager iAPManager;

    [Header("Shop Tabs UI")]
    [SerializeField] private CameraManager cameraManager;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private GameObject shopTabs;
    [SerializeField] private HomeNPC homeNPC;
    [SerializeField] private GameObject bankShopTab;
    [SerializeField] private GameObject weaponShopTab;
    [SerializeField] private GameObject skinsShopTab;
    [SerializeField] private GameObject helicopterShopTab;
    [SerializeField] private GameObject mapTab;
    [SerializeField] private Image bankShop_image;
    [SerializeField] private Image weaponShop_image;
    [SerializeField] private Image skinsShop_image;
    [SerializeField] private Image helicopterShop_image;
    [SerializeField] private Image mapIcon_image;
    [SerializeField] private Image bankShopLocked_image;
    [SerializeField] private Image weaponShopLocked_image;
    [SerializeField] private Image skinsShopLocked_image;
    [SerializeField] private Image helicopterShopLocked_image;
    [SerializeField] private Image mapLocked_image;

    [Header("Bank Shop")]
    [SerializeField] private GameObject bankShop;

    [Header("Weapon Shop")]
    [SerializeField] private GameObject weaponShop;
    [SerializeField] private TextMeshProUGUI weaponNicknameTM;
    [SerializeField] private TextMeshProUGUI bulletDamageTM;
    [SerializeField] private TextMeshProUGUI bulletCountTM;
    [SerializeField] private Image pistol_unlocked_image;
    [SerializeField] private Image pistol_selected_image;
    [SerializeField] private Image assault_unlocked_image;
    [SerializeField] private Image assault_locked_image;
    [SerializeField] private Image assault_selected_image;
    [SerializeField] private Image shotgun_unlocked_image;
    [SerializeField] private Image shotgun_locked_image;
    [SerializeField] private Image shotgun_selected_image;
    [SerializeField] private Image smg_unlocked_image;
    [SerializeField] private Image smg_locked_image;
    [SerializeField] private Image smg_selected_image;
    [SerializeField] private Image rifle_01_unlocked_image;
    [SerializeField] private Image rifle_01_locked_image;
    [SerializeField] private Image rifle_01_selected_image;
    [SerializeField] private Image smg_02_unlocked_image;
    [SerializeField] private Image smg_02_locked_image;
    [SerializeField] private Image smg_02_selected_image;
    [SerializeField] private Image shotgun_02_unlocked_image;
    [SerializeField] private Image shotgun_02_locked_image;
    [SerializeField] private Image shotgun_02_selected_image;
    [SerializeField] private Image assault_02_unlocked_image;
    [SerializeField] private Image assault_02_locked_image;
    [SerializeField] private Image assault_02_selected_image;
    [SerializeField] private Image smg_03_unlocked_image;
    [SerializeField] private Image smg_03_locked_image;
    [SerializeField] private Image smg_03_selected_image;
    [SerializeField] private Image assault_03_unlocked_image;
    [SerializeField] private Image assault_03_locked_image;
    [SerializeField] private Image assault_03_selected_image;
    [SerializeField] private Image rifle_02_unlocked_image;
    [SerializeField] private Image rifle_02_locked_image;
    [SerializeField] private Image rifle_02_selected_image;
    [SerializeField] private Image machineGun_01_unlocked_image;
    [SerializeField] private Image machineGun_01_locked_image;
    [SerializeField] private Image machineGun_01_selected_image;
    [SerializeField] private Image machineGun_02_unlocked_image;
    [SerializeField] private Image machineGun_02_locked_image;
    [SerializeField] private Image machineGun_02_selected_image;
    [SerializeField] private Image rocketLauncher_unlocked_image;
    [SerializeField] private Image rocketLauncher_locked_image;
    [SerializeField] private Image rocketLauncher_02_selected_image;
    [SerializeField] private Scrollbar weaponShopScrollbar;
    private bool isWeaponShopOpen;

    [Header("Skins Shop")]
    [SerializeField] private RankManager rankManager;
    [SerializeField] private GameObject skinsShop;
    [SerializeField] private Image default_unlocked_image;
    [SerializeField] private Image default_selected_image;
    [SerializeField] private Image male_01_unlocked_image;
    [SerializeField] private Image male_01_locked_image;
    [SerializeField] private Image male_01_selected_image;
    [SerializeField] private Image homeless_unlocked_image;
    [SerializeField] private Image homeless_locked_image;
    [SerializeField] private Image homeless_selected_image;
    [SerializeField] private Image biker_unlocked_image;
    [SerializeField] private Image biker_locked_image;
    [SerializeField] private Image biker_selected_image;
    [SerializeField] private Image soldier_unlocked_image;
    [SerializeField] private Image soldier_locked_image;
    [SerializeField] private Image soldier_selected_image;
    [SerializeField] private Image hazmat_unlocked_image;
    [SerializeField] private Image hazmat_locked_image;
    [SerializeField] private Image hazmat_selected_image;
    [SerializeField] private Image riotCop_unlocked_image;
    [SerializeField] private Image riotCop_locked_image;
    [SerializeField] private Image riotCop_selected_image;
    [SerializeField] private Image female_01_unlocked_image;
    [SerializeField] private Image female_01_locked_image;
    [SerializeField] private Image female_01_selected_image;
    [SerializeField] private Image male_01_watch_ad_image;
    [SerializeField] private Image homeless_watch_ad_image;
    [SerializeField] private Image biker_watch_ad_image;
    [SerializeField] private Image soldier_watch_ad_image;
    [SerializeField] private Image hazmat_watch_ad_image;
    [SerializeField] private Image riotCop_watch_ad_image;
    [SerializeField] private Image female_01_watch_ad_image;
    private bool isSkinShopOpen;

    [Header("Helicopter Shop")]
    [SerializeField] private HelicopterRankManager helicopterRankManager;
    [SerializeField] private GameObject helicopterShop;
    [SerializeField] private Image default_helicopter_unlocked_image;
    [SerializeField] private Image helicopter_02_unlocked_image;
    [SerializeField] private Image helicopter_03_unlocked_image;
    [SerializeField] private Image helicopter_04_unlocked_image;
    [SerializeField] private Image helicopter_02_locked_image;
    [SerializeField] private Image helicopter_03_locked_image;
    [SerializeField] private Image helicopter_04_locked_image;
    [SerializeField] private Image default_helicopter_selected_image;
    [SerializeField] private Image helicopter_02_selected_image;
    [SerializeField] private Image helicopter_03_selected_image;
    [SerializeField] private Image helicopter_04_selected_image;
    [SerializeField] private Image helicopter_02_watch_ad_image;
    [SerializeField] private Image helicopter_03_watch_ad_image;
    [SerializeField] private Image helicopter_04_watch_ad_image;
    private bool isHelicopterShopOpen;

    [Header("Map UI")]
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
    [SerializeField] private Image mapSlot_01Background;
    [SerializeField] private Image mapSlot_02Background;
    [SerializeField] private Image mapSlot_03Background;
    [SerializeField] private Image mapSlot_04Background;
    [SerializeField] private Image mapSlot_05Background;
    [SerializeField] private Image mapSlot_05BossImage;
    private bool isMapOpen;

    [Header("Boss Battle UI")]
    [SerializeField] private Image bossTab;
    [SerializeField] private TextMeshProUGUI bossTabLevelsLeftTM;
    [SerializeField] private GameObject bossBattleMenu;
    [SerializeField] private Image bossBattleBanner;
    [SerializeField] private Image bossBattle_01_image;
    [SerializeField] private Image bossBattle_02_image;
    [SerializeField] private Image boss_01_image;
    [SerializeField] private Image boss_02_image;

    [Header("Settings UI")]
    [SerializeField] private GameObject settingsBtn;
    [SerializeField] private GameObject settingsMenu;
    [SerializeField] private Image toggleBloodOn_image;
    [SerializeField] private Image toggleBloodOff_image;
    [SerializeField] private Image toggleMusicOn_image;
    [SerializeField] private Image toggleMusicOff_image;
    [SerializeField] private Image toggleSoundEffectsOn_image;
    [SerializeField] private Image toggleSoundEffectsOff_image;
    [SerializeField] private Image toggleHapticsOn_image;
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
    //private bool isInfoMenuOpen;

    private int levelReached;
    private string levelReachPlayerPrefsName = "levelReached";
    private AdsInitializer adsInitializer;
    private Vector3 originalCamPos;
    private bool hasShownBossBattleMenu;
    private bool hasTappedToPlay;

    private void Awake()
    {
        Object_Top.GetComponent<RectTransform>().DOAnchorPosY(200, 0);

        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        if (LevelUI.offerGunTrialAgain)
        {
            homeManager.SetIsShowingGunTrial(true);
            hasTappedToPlay = true;
            gunTrialManager.CheckForGunTrial(levelReached);
            LevelUI.offerGunTrialAgain = false;
        }
        if (LevelUI.offerShieldPackageAgain)
        {
            homeManager.SetIsShowingShieldPack(true);
            hasTappedToPlay = true;
            if (levelReached < 11)
            {
                packManager.CheckForOnPlayPackOffer(levelReached);
            }
            else
            {
                packManager.SetIsOnPlayPackOfferAvailable(true);
                packManager.SetShieldPackOfferActive();
            }
            LevelUI.offerShieldPackageAgain = false;
        }
    }

    private void Start()
    {
        SetVersionText();
        originalCamPos = mainCamera.transform.localPosition;
        hasCollectedInstagramReward = PlayerPrefs.GetInt(hasCollectedInstagramRewardPlayerPrefsName);
        if (hasCollectedInstagramReward == 1)
        {
            SetInstagramBtnActive(false);
        }



        DOTween.Kill("moveTop");
        Object_Top.GetComponent<RectTransform>().DOAnchorPosY(200, 0);
        Object_Top.GetComponent<RectTransform>().DOAnchorPosY(0, 0.75f).SetEase(Ease.OutBack).SetId("moveTop");
    }




    public void TapToPlay()
    {
        hasTappedToPlay = true;
        if (AdsInitializer.isInitialized)
        {
            adsInitializer = FindObjectOfType<AdsInitializer>();
            if (!BannerAd.isShowing && AdsInitializer.isBannerAdLoaded)
            {
                adsInitializer.ShowBannerAd();
            }
        }
        if (!gunTrialManager.GetHasCheckedForGunTrial() && !packManager.GetHasCheckedForOnPlayPackOffer())
        {
            gunTrialManager.CheckForGunTrial(levelReached);
            packManager.CheckForOnPlayPackOffer(levelReached);
            if (!gunTrialManager.GetIsGunTrialAvailable() && !packManager.GetIsOnPlayPackOfferAvailable())
            {
                LoadCurrentLevel(levelReached);
                QualitySettings.shadowDistance = 75;

                if (PlayerPrefs.GetInt("isPlayNewSong") == 1)
                {
                    AudioManager.Instance.PlayNewSong();
                }
                if (packManager.GetIsStarterPackLastChance())
                {
                    packManager.EndStarterPackOffer();
                }
                if (packManager.GetIsSecondPackLastChance())
                {
                    packManager.EndSecondPackOffer();
                }
                if (packManager.GetIsThirdPackLastChance())
                {
                    packManager.EndThirdPackOffer();
                }
            }
            if (gunTrialManager.GetIsGunTrialAvailable() || packManager.GetIsOnPlayPackOfferAvailable())
            {
                if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
                    && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
                {
                    SetStarterPackBtnActive(false);
                }
                if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
                    && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
                {
                    SetSecondPackBtnActive(false);
                }
                if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
                    && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
                {
                    SetThirdPackBtnActive(false);
                }
                SetBossTabActive(false);
                if(levelReached == 15 || levelReached == 25)
                {
                    if (adsInitializer != null)
                    {
                        adsInitializer.HideBannerAd();
                    }
                    SetBossBattleBannerActive(true);
                }
                SetShopTabsActive(false);
                SetSettingsBtnActive(false);
            }
        } else
        {
            LoadCurrentLevel(levelReached);
            QualitySettings.shadowDistance = 75;

            if (PlayerPrefs.GetInt("isPlayNewSong") == 1)
            {
                AudioManager.Instance.PlayNewSong();
            }

            if (packManager.GetIsStarterPackLastChance())
            {
                packManager.EndStarterPackOffer();
            }
            if (packManager.GetIsSecondPackLastChance())
            {
                packManager.EndSecondPackOffer();
            }
            if (packManager.GetIsThirdPackLastChance())
            {
                packManager.EndThirdPackOffer();
            }
        }
    }

    public void ShowShieldPackOffer()
    {
        if (!hasTappedToPlay)
        {
            AudioManager.Instance.Play_sfx_ui_tap();
            if (AdsInitializer.isInitialized)
            {
                adsInitializer = FindObjectOfType<AdsInitializer>();
                if (!BannerAd.isShowing && AdsInitializer.isBannerAdLoaded)
                {
                    adsInitializer.ShowBannerAd();
                }
            }
            packManager.SetIsOnPlayPackOfferAvailable(true);
            packManager.SetShieldPackOfferActive();

            if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
                && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
            {
                SetStarterPackBtnActive(false);
            }
            if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
                && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
            {
                SetSecondPackBtnActive(false);
            }
            if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
                && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
            {
                SetThirdPackBtnActive(false);
            }
            SetBossTabActive(false);
            if (levelReached == 15 || levelReached == 25)
            {
                if (adsInitializer != null)
                {
                    adsInitializer.HideBannerAd();
                }
                SetBossBattleBannerActive(true);
            }
            SetShopTabsActive(false);
            SetSettingsBtnActive(false);
            packManager.SetHasCheckedForOnPlayPackOffer(true);
            packManager.SetHasCheckedForOnPlayPackOffer(true);
        }
        hasTappedToPlay = true;
    }

    public void BankShopTab()
    {
        if (!isWeaponShopOpen && !isSkinShopOpen && !isHelicopterShopOpen && !isMapOpen && !hasTappedToPlay)
        {
            //TWEEN ----
            DOTween.Kill("bankScale");
            bankShop.transform.DOScale(new Vector3(0.8f, 0.8f, 1), 0);
            bankShop.transform.DOScale(new Vector3(1f, 1f, 1), 0.5f).SetEase(Ease.OutBounce).SetId("bankScale");
            
            
            SetBankShopActive(true);
            packManager.SetPlayBtnActive(false);
            SetShopTabsActive(false);
            mainCamera.transform.position = shopCamTransform.position;
            SetLevelTextHeaderActive(false);
            SetShieldImageActive(false);

            if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
            && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
            {
                SetStarterPackBtnActive(false);
            }
            if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
            && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
            {
                SetSecondPackBtnActive(false);
            }
            if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
            && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
            {
                SetThirdPackBtnActive(false);
            }
            SetBossTabActive(false);
            SetSettingsBtnActive(false);
            AudioManager.Instance.Play_sfx_ui_tap();
        }
    }

    public void WeaponShopTab()
    {
        //TWEEN ----
        DOTween.Kill("weaponMoveUp");
        weaponShop.GetComponent<RectTransform>().DOAnchorPosY(-200, 0);
        weaponShop.GetComponent<RectTransform>().DOAnchorPosY(0, 0.75f).SetEase(Ease.OutBack).SetId("weaponMoveUp");

        SetWeaponShopActive(true);
        SetShopTabsActive(false);
        if (itemManager.GetIsAssaultPurchased() == 1)
        {
            SetAssaultBtnUnlocked();
        }
        if (itemManager.GetIsAssault_02Purchased() == 1)
        {
            SetAssault_02BtnUnlocked();
        }
        if (itemManager.GetIsAssault_03Purchased() == 1)
        {
            SetAssault_03BtnUnlocked();
        }
        if (itemManager.GetIsShotgunPurchased() == 1)
        {
            SetShotgunBtnUnlocked();
        }
        if (itemManager.GetIsShotgun_02Purchased() == 1)
        {
            SetShotgun_02BtnUnlocked();
        }
        if (itemManager.GetIsSMGPurchased() == 1)
        {
            SetSMGBtnUnlocked();
        }
        if (itemManager.GetIsSMG_02Purchased() == 1)
        {
            SetSMG_02BtnUnlocked();
        }
        if (itemManager.GetIsSMG_03Purchased() == 1)
        {
            SetSMG_03BtnUnlocked();
        }
        if (itemManager.GetIsRifle_01Purchased() == 1)
        {
            SetRifle_01BtnUnlocked();
        }
        if (itemManager.GetIsRifle_02Purchased() == 1)
        {
            SetRifle_02BtnUnlocked();
        }
        if (itemManager.GetIsMachineGun_01Purchased() == 1)
        {
            SetMachineGun_01BtnUnlocked();
        }
        if (itemManager.GetIsMachineGun_02Purchased() == 1)
        {
            SetMachineGun_02BtnUnlocked();
        }
        if (itemManager.GetIsRocketLauncherPurchased() == 1)
        {
            SetRocketLauncherBtnUnlocked();
        }
        SetEquippedWeaponBtn();
        mainCamera.transform.position = shopCamTransform.position;
        SetLevelTextHeaderActive(false);
        SetShieldImageActive(false);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(false);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(false);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
        && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(false);
        }
        SetBossTabActive(false);
        SetSettingsBtnActive(false);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SkinsShopTab()
    {
        //TWEEN ----
        DOTween.Kill("skinsMoveUp");
        skinsShop.GetComponent<RectTransform>().DOAnchorPosY(-200, 0);
        skinsShop.GetComponent<RectTransform>().DOAnchorPosY(0, 0.75f).SetEase(Ease.OutBack).SetId("skinsMoveUp");

        SetSkinsShopActive(true);
        SetShopTabsActive(false);
        if (rankManager.GetHasMale_01SkinBeenOffered() == 1)
        {
            SetMale_01BtnUnlocked();
            SetMale_01_Watch_Ad_ImageActive(true);
            if (itemManager.GetIsMale_01SkinPurchased() == 1)
            {
                SetMale_01_Watch_Ad_ImageActive(false);
            }
        }
        if (rankManager.GetHasHomelessSkinBeenOffered() == 1)
        {
            SetHomelessBtnUnlocked();
            SetHomeless_Watch_Ad_ImageActive(true);
            if (itemManager.GetIsHomelessSkinPurchased() == 1)
            {
                SetHomeless_Watch_Ad_ImageActive(false);
            }
        }
        if (rankManager.GetHasBikerSkinBeenOffered() == 1)
        {
            SetBikerBtnUnlocked();
            SetBiker_Watch_Ad_ImageActive(true);
            if (itemManager.GetIsBikerSkinPurchased() == 1)
            {
                SetBiker_Watch_Ad_ImageActive(false);
            }
        }
        if (rankManager.GetHasFemale_01SkinBeenOffered() == 1)
        {
            SetFemale_01BtnUnlocked();
            SetFemale_01_Watch_Ad_ImageActive(true);
            if (itemManager.GetIsFemale_01SkinPurchased() == 1)
            {
                SetFemale_01_Watch_Ad_ImageActive(false);
            }
        }
        if (itemManager.GetIsSoldierSkinPurchased() == 1)
        {
            SetSoldierBtnUnlocked();
        }
        if (itemManager.GetIsHazmatSkinPurchased() == 1)
        {
            SetHazmatBtnUnlocked();
        }
        if (itemManager.GetIsRiotCopSkinPurchased() == 1)
        {
            SetRiotCopBtnUnlocked();
        }
        SetEquippedSkinBtn();
        mainCamera.transform.position = shopCamTransform.position;
        SetLevelTextHeaderActive(false);
        SetShieldImageActive(false);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(false);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
           && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(false);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(false);
        }
        SetBossTabActive(false);
        SetSettingsBtnActive(false);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void HelicopterShopTab()
    {
        //TWEEN ----
        DOTween.Kill("helicopterMoveUp");
        helicopterShop.GetComponent<RectTransform>().DOAnchorPosY(-200, 0);
        helicopterShop.GetComponent<RectTransform>().DOAnchorPosY(0, 0.75f).SetEase(Ease.OutBack).SetId("helicopterMoveUp");

        SetHelicopterShopActive(true);
        SetShopTabsActive(false);
        if (helicopterRankManager.GetHasHelicopter_02SkinBeenOffered() == 1)
        {
            SetHelicopter_02BtnUnlocked();
            SetHelicopter_02_Watch_Ad_ImageActive(true);
            if (itemManager.GetIsHelicopter_02SkinPurchased() == 1)
            {
                SetHelicopter_02_Watch_Ad_ImageActive(false);
            }
        }
        if (itemManager.GetIsHelicopter_03SkinPurchased() == 1)
        {
            SetHelicopter_03BtnUnlocked();
            SetHelicopter_03_Watch_Ad_ImageActive(false);
        }
        if (helicopterRankManager.GetHasHelicopter_04SkinBeenOffered() == 1)
        {
            SetHelicopter_04BtnUnlocked();
            SetHelicopter_04_Watch_Ad_ImageActive(true);
            if (itemManager.GetIsHelicopter_04SkinPurchased() == 1)
            {
                SetHelicopter_04_Watch_Ad_ImageActive(false);
            }
        }
        SetEquippedHelicopterSkinBtn();
        mainCamera.transform.position = shopCamTransform.position;
        SetLevelTextHeaderActive(false);
        SetShieldImageActive(false);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(false);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
           && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(false);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(false);
        }
        SetBossTabActive(false);
        SetSettingsBtnActive(false);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void MapShopTab()
    {
        //TWEEN ----
        DOTween.Kill("mapScale");
        mapUI.transform.DOScale(new Vector3(0.8f, 0.8f, 1), 0);
        mapUI.transform.DOScale(new Vector3(1f, 1f, 1), 0.5f).SetEase(Ease.OutBounce).SetId("mapScale");

        SetMapVisuals(levelReached);
        packManager.SetPlayBtnActive(false);
        SetShopTabsActive(false);
        mainCamera.transform.position = shopCamTransform.position;
        SetLevelTextHeaderActive(false);
        SetShieldImageActive(false);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(false);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
           && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(false);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(false);
        }
        SetBossTabActive(false);
        SetSettingsBtnActive(false);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ShowBossBattleMenu()
    {
        SetBossBattleMenuActive(true);
        SetShopTabsActive(false);
        SetLevelTextHeaderActive(false);
        SetCreditsImageActive(false);
        SetShieldImageActive(false);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(false);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
           && packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(false);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(false);
        }
        SetBossTabActive(false);
        SetSettingsBtnActive(false);
        SetBossBattleImage();
    }

    public void ExitBankShop()
    {
        //if (itemManager.GetIsAssaultPurchased() == 1 && !packManager.GetIsStarterPackLastChance() && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
        //|| rankManager.GetIsSkinShopUnlocked() == 1 && !packManager.GetIsStarterPackLastChance() && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
        //|| packManager.GetIsStarterPackPurchased() == 1 && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
        //|| packManager.GetIsSecondPackPurchased() == 1 && !packManager.GetIsThirdPackLastChance()
        //|| packManager.GetIsThirdPackPurchased() == 1)
         if (itemManager.GetIsAssaultPurchased() == 1
            || rankManager.GetIsSkinShopUnlocked() == 1
            || packManager.GetIsStarterPackPurchased() == 1
            || packManager.GetIsSecondPackPurchased() == 1
            || packManager.GetIsThirdPackPurchased() == 1)
        {
            SetShopTabsActive(true);
        }
        SetBankShopActive(false);
        mainCamera.transform.localPosition = originalCamPos;
        SetLevelTextHeaderActive(true);
        if (levelReached != 1)
        {
            SetShieldImageActive(true);
        }

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(true);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(true);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(true);
        }
        CheckIfBossTab(levelReached);
        SetSettingsBtnActive(true);
        //iAPManager.HideAllLoadingPopUps();
        packManager.SetPlayBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitWeaponShop()
    {
        SetShopTabsActive(true);
        SetWeaponShopActive(false);
        mainCamera.transform.localPosition = originalCamPos;
        SetLevelTextHeaderActive(true);
        SetShieldImageActive(true);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(true);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(true);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(true);
        }
        CheckIfBossTab(levelReached);
        SetSettingsBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitSkinShop()
    {
        SetShopTabsActive(true);
        SetSkinsShopActive(false);
        mainCamera.transform.localPosition = originalCamPos;
        SetLevelTextHeaderActive(true);
        SetShieldImageActive(true);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(true);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(true);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(true);
        }
        CheckIfBossTab(levelReached);
        SetSettingsBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }


    public void ExitHelicopterShop()
    {
        SetShopTabsActive(true);
        SetHelicopterShopActive(false);
        mainCamera.transform.localPosition = originalCamPos;
        SetLevelTextHeaderActive(true);
        SetShieldImageActive(true);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(true);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(true);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(true);
        }
        CheckIfBossTab(levelReached);
        SetSettingsBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitMap()
    {
        packManager.SetPlayBtnActive(true);
        SetShopTabsActive(true);
        SetMapUIActive(false);
        mainCamera.transform.localPosition = originalCamPos;
        SetLevelTextHeaderActive(true);
        SetShieldImageActive(true);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(true);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(true);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(true);
        }
        CheckIfBossTab(levelReached);
        SetSettingsBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitBossBattleMenu()
    {
        SetShopTabsActive(true);
        SetBossBattleMenuActive(false);
        SetLevelTextHeaderActive(true);
        SetCreditsImageActive(true);
        SetShieldImageActive(true);
        SetBossTabActive(true);

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
        && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
        {
            SetStarterPackBtnActive(true);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
        && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
        {
            SetSecondPackBtnActive(true);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
           && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
        {
            SetThirdPackBtnActive(true);
        }
        CheckIfBossTab(levelReached);
        SetSettingsBtnActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void PistolBtn()
    {
        itemManager.EquipItem(Item.ItemType.Pistol);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void AssaultBtn()
    {
        itemManager.EquipItem(Item.ItemType.Assault);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void Assault_02Btn()
    {
        itemManager.EquipItem(Item.ItemType.Assault_02);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void Assault_03Btn()
    {
        itemManager.EquipItem(Item.ItemType.Assault_03);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void ShotgunBtn()
    {
        itemManager.EquipItem(Item.ItemType.Shotgun);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void Shotgun_02Btn()
    {
        itemManager.EquipItem(Item.ItemType.Shotgun_02);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void SMGBtn()
    {
        itemManager.EquipItem(Item.ItemType.SMG);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void SMG_02Btn()
    {
        itemManager.EquipItem(Item.ItemType.SMG_02);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void SMG_03Btn()
    {
        itemManager.EquipItem(Item.ItemType.SMG_03);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void Rifle_01Btn()
    {
        itemManager.EquipItem(Item.ItemType.Rifle_01);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void Rifle_02Btn()
    {
        itemManager.EquipItem(Item.ItemType.Rifle_02);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void MachineGun_01_Btn()
    {
        itemManager.EquipItem(Item.ItemType.MachineGun_01);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void MachineGun_02_Btn()
    {
        itemManager.EquipItem(Item.ItemType.MachineGun_02);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void Rocket_Launcher_Btn()
    {
        itemManager.EquipItem(Item.ItemType.RocketLauncher);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedWeaponBtn();
        AudioManager.Instance.Play_sfx_ui_equip();
    }

    public void DefaultBtn()
    {
        itemManager.EquipItem(Item.ItemType.DefaultSkin);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedSkinBtn();
        AudioManager.Instance.Play_sfx_ui_buzz();
    }

    public void SkinBtnClicked()
    {
        AudioManager.Instance.Play_sfx_ui_buzz();
    }

    public void Male_01Btn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Male_01Skin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.Male_01Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetMale_01_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.Male_01Skin);
            itemManager.EquipItem(Item.ItemType.Male_01Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void HomelessBtn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.HomelessSkin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.HomelessSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetHomeless_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.HomelessSkin);
            itemManager.EquipItem(Item.ItemType.HomelessSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void BikerBtn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.BikerSkin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.BikerSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetBiker_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.BikerSkin);
            itemManager.EquipItem(Item.ItemType.BikerSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void SoldierBtn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.SoldierSkin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.SoldierSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetSoldier_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.SoldierSkin);
            itemManager.EquipItem(Item.ItemType.SoldierSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void HazmatBtn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.HazmatSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetHazmat_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.HazmatSkin);
            itemManager.EquipItem(Item.ItemType.HazmatSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void RiotCopBtn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.RiotCopSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetRiotCop_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.RiotCopSkin);
            itemManager.EquipItem(Item.ItemType.RiotCopSkin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void Female_01Btn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Female_01Skin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.Female_01Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetFemale_01_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.Female_01Skin);
            itemManager.EquipItem(Item.ItemType.Female_01Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedSkinBtn();
    }

    public void DefaultHelicopterBtn()
    {
        itemManager.EquipItem(Item.ItemType.DefaultHelicopterSkin);
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
        SetEquippedHelicopterSkinBtn();
    }

    public void Helicopter_02Btn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_02Skin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.Helicopter_02Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetHelicopter_02_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.Helicopter_02Skin);
            itemManager.EquipItem(Item.ItemType.Helicopter_02Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedHelicopterSkinBtn();
    }

    public void Helicopter_03Btn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.Helicopter_03Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetHelicopter_03_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.Helicopter_03Skin);
            itemManager.EquipItem(Item.ItemType.Helicopter_03Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedHelicopterSkinBtn();
    }

    public void Helicopter_04Btn()
    {
        if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_04Skin) == 1)
        {
            itemManager.EquipItem(Item.ItemType.Helicopter_04Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        else
        {
            // Must Watch Ad
            SetHelicopter_04_Watch_Ad_ImageActive(false);
            itemManager.PurchaseItem(Item.ItemType.Helicopter_04Skin);
            itemManager.EquipItem(Item.ItemType.Helicopter_04Skin);
            itemManager.SetStartNPCAsCaller();
            itemManager.EquipItems();
        }
        SetEquippedHelicopterSkinBtn();
    }

    public void StarterPackBtn()
    {
        ////TWEEN ----
        //DOTween.Kill("starterPackScale");
        //Object_StarterPack.transform.DOScale(new Vector3(0.018f, 0.018f, 0.018f), 0);
        //Object_StarterPack.transform.DOScale(new Vector3(0.02f, 0.02f, 0.02f), 0.5f).SetEase(Ease.OutBounce).SetId("starterPackScale");


        //QualitySettings.shadowDistance = 15;

        packManager.SetStarterPackOfferMenuActive(true);
        SetStarterPackBtnActive(false);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SecondPackBtn()
    {
        packManager.SetSecondPackOfferMenuActive(true);
        SetSecondPackBtnActive(false);
        CheckIfBossTab(levelReached);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ThirdPackBtn()
    {
        packManager.SetThirdPackOfferMenuActive(true);
        SetThirdPackBtnActive(false);
        CheckIfBossTab(levelReached);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ShowSettingsMenu()
    {
        DOTween.Kill("settingsScale");
        settingsMenu.transform.DOScale(new Vector3(0.8f, 0.8f, 1), 0);
        settingsMenu.transform.DOScale(new Vector3(1f, 1f, 1), 0.5f).SetEase(Ease.OutBounce).SetId("settingsScale");

        SetSettingsMenuActive(true);
        SetCreditsImageActive(false);
        SetShieldImageActive(false);
        SetLevelTextHeaderActive(false);
        SetSettingsBtnActive(false);
        packManager.SetPlayBtnActive(false);
        SetShopTabsActive(false);
        SetStarterPackBtnActive(false);
        SetSecondPackBtnActive(false);
        SetThirdPackBtnActive(false);
        SetBossTabActive(false);
        InitSettingsBtns();
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void HideSettingsMenu()
    {
        //if (!isInfoMenuOpen)
        {
            SetSettingsMenuActive(false);
            SetCreditsImageActive(true);
            if (levelReached != 1)
            {
                SetShieldImageActive(true);
            }
            SetLevelTextHeaderActive(true);
            SetSettingsBtnActive(true);
            packManager.SetPlayBtnActive(true);
            if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
            && !packManager.GetIsStarterPackTabShowing() && packManager.GetIsStarterPackPurchased() == 0)
            {
                SetStarterPackBtnActive(true);
            }
            if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
            && !packManager.GetIsSecondPackTabShowing() && packManager.GetIsSecondPackPurchased() == 0)
            {
                SetSecondPackBtnActive(true);
            }
            if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
               && !packManager.GetIsThirdPackTabShowing() && packManager.GetIsThirdPackPurchased() == 0)
            {
                SetThirdPackBtnActive(true);
            }
            CheckIfBossTab(levelReached);
            homeManager.ShowUnlockedShopTabs();
        } //else
        //{
        //    SetInfoMenuActive(false);
        //}
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SupportBtn()
    {
        Application.OpenURL("https://pablowaregames.com/contact/");
        AudioManager.Instance.Play_sfx_ui_tap();
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
        } else
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

    private void SetEquippedWeaponBtn()
    {
        SetWeaponNickname(homeNPC.GetWeaponNickname());
        SetWeaponStats(homeNPC.GetWeaponBulletDamage(), homeNPC.GetWeaponBulletCount());
        if (itemManager.GetIsPistolEquipped() == 1)
        {
            pistol_selected_image.gameObject.SetActive(true);
            pistol_unlocked_image.gameObject.SetActive(false);
        }
        else
        {
            pistol_selected_image.gameObject.SetActive(false);
            pistol_unlocked_image.gameObject.SetActive(true);
        }
        if (itemManager.GetIsAssaultPurchased() == 1)
        {
            if (itemManager.GetIsAssaultEquipped() == 1)
            {
                assault_selected_image.gameObject.SetActive(true);
                assault_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                assault_selected_image.gameObject.SetActive(false);
                assault_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsAssault_02Purchased() == 1)
        {
            if (itemManager.GetIsAssault_02Equipped() == 1)
            {
                assault_02_selected_image.gameObject.SetActive(true);
                assault_02_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                assault_02_selected_image.gameObject.SetActive(false);
                assault_02_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsAssault_03Purchased() == 1)
        {
            if (itemManager.GetIsAssault_03Equipped() == 1)
            {
                assault_03_selected_image.gameObject.SetActive(true);
                assault_03_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                assault_03_selected_image.gameObject.SetActive(false);
                assault_03_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsShotgunPurchased() == 1)
        {
            if (itemManager.GetIsShotgunEquipped() == 1)
            {
                shotgun_selected_image.gameObject.SetActive(true);
                shotgun_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                shotgun_selected_image.gameObject.SetActive(false);
                shotgun_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsShotgun_02Purchased() == 1)
        {
            if (itemManager.GetIsShotgun_02Equipped() == 1)
            {
                shotgun_02_selected_image.gameObject.SetActive(true);
                shotgun_02_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                shotgun_02_selected_image.gameObject.SetActive(false);
                shotgun_02_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsSMGPurchased() == 1)
        {
            if (itemManager.GetIsSMGEquipped() == 1)
            {
                smg_selected_image.gameObject.SetActive(true);
                smg_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                smg_selected_image.gameObject.SetActive(false);
                smg_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsSMG_02Purchased() == 1)
        {
            if (itemManager.GetIsSMG_02Equipped() == 1)
            {
                smg_02_selected_image.gameObject.SetActive(true);
                smg_02_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                smg_02_selected_image.gameObject.SetActive(false);
                smg_02_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsSMG_03Purchased() == 1)
        {
            if (itemManager.GetIsSMG_03Equipped() == 1)
            {
                smg_03_selected_image.gameObject.SetActive(true);
                smg_03_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                smg_03_selected_image.gameObject.SetActive(false);
                smg_03_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsRifle_01Purchased() == 1)
        {
            if (itemManager.GetIsRifle_01Equipped() == 1)
            {
                rifle_01_selected_image.gameObject.SetActive(true);
                rifle_01_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                rifle_01_selected_image.gameObject.SetActive(false);
                rifle_01_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsRifle_02Purchased() == 1)
        {
            if (itemManager.GetIsRifle_02Equipped() == 1)
            {
                rifle_02_selected_image.gameObject.SetActive(true);
                rifle_02_unlocked_image.gameObject.SetActive(false);
                SetWeaponShopScrollbarValue(0.162f);
            }
            else
            {
                rifle_02_selected_image.gameObject.SetActive(false);
                rifle_02_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsMachineGun_01Purchased() == 1)
        {
            if (itemManager.GetIsMachineGun_01Equipped() == 1)
            {
                machineGun_01_selected_image.gameObject.SetActive(true);
                machineGun_01_unlocked_image.gameObject.SetActive(false);
                SetWeaponShopScrollbarValue(0.162f);
            }
            else
            {
                machineGun_01_selected_image.gameObject.SetActive(false);
                machineGun_01_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsMachineGun_02Purchased() == 1)
        {
            if (itemManager.GetIsMachineGun_02Equipped() == 1)
            {
                machineGun_02_selected_image.gameObject.SetActive(true);
                machineGun_02_unlocked_image.gameObject.SetActive(false);
                SetWeaponShopScrollbarValue(0.162f);
            }
            else
            {
                machineGun_02_selected_image.gameObject.SetActive(false);
                machineGun_02_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsRocketLauncherPurchased() == 1)
        {
            if (itemManager.GetIsRocketLauncherEquipped() == 1)
            {
                rocketLauncher_02_selected_image.gameObject.SetActive(true);
                rocketLauncher_unlocked_image.gameObject.SetActive(false);
                SetWeaponShopScrollbarValue(0.162f);
            }
            else
            {
                rocketLauncher_02_selected_image.gameObject.SetActive(false);
                rocketLauncher_unlocked_image.gameObject.SetActive(true);
            }
        }
    }

    private void SetEquippedSkinBtn()
    {
        if (itemManager.GetIsDefaultSkinEquipped() == 1)
        {
            default_selected_image.gameObject.SetActive(true);
            default_unlocked_image.gameObject.SetActive(false);
        }
        else
        {
            default_selected_image.gameObject.SetActive(false);
            default_unlocked_image.gameObject.SetActive(true);
        }
        if (rankManager.GetHasMale_01SkinBeenOffered() == 1)
        {
            if (itemManager.GetIsMale_01SkinPurchased() == 1)
            {
                if (itemManager.GetIsMale_01SkinEquipped() == 1)
                {
                    male_01_selected_image.gameObject.SetActive(true);
                    male_01_unlocked_image.gameObject.SetActive(false);
                }
                else
                {
                    male_01_selected_image.gameObject.SetActive(false);
                    male_01_unlocked_image.gameObject.SetActive(true);
                }
            }
        }
        if (rankManager.GetHasHomelessSkinBeenOffered() == 1)
        {
            if (itemManager.GetIsHomelessSkinPurchased() == 1)
            {
                if (itemManager.GetIsHomelessSkinEquipped() == 1)
                {
                    homeless_selected_image.gameObject.SetActive(true);
                    homeless_unlocked_image.gameObject.SetActive(false);
                }
                else
                {
                    homeless_selected_image.gameObject.SetActive(false);
                    homeless_unlocked_image.gameObject.SetActive(true);
                }
            }
        }
        if (rankManager.GetHasBikerSkinBeenOffered() == 1)
        {
            if (itemManager.GetIsBikerSkinPurchased() == 1)
            {
                if (itemManager.GetIsBikerSkinEquipped() == 1)
                {
                    biker_selected_image.gameObject.SetActive(true);
                    biker_unlocked_image.gameObject.SetActive(false);
                }
                else
                {
                    biker_selected_image.gameObject.SetActive(false);
                    biker_unlocked_image.gameObject.SetActive(true);
                }
            }
        }
        if (rankManager.GetHasFemale_01SkinBeenOffered() == 1)
        {
            if (itemManager.GetIsFemale_01SkinPurchased() == 1)
            {
                if (itemManager.GetIsFemale_01SkinEquipped() == 1)
                {
                    female_01_selected_image.gameObject.SetActive(true);
                    female_01_unlocked_image.gameObject.SetActive(false);
                }
                else
                {
                    female_01_selected_image.gameObject.SetActive(false);
                    female_01_unlocked_image.gameObject.SetActive(true);
                }
            }
        }
        if (itemManager.GetIsSoldierSkinPurchased() == 1)
        {
            if (itemManager.GetIsSoldierSkinEquipped() == 1)
            {
                soldier_selected_image.gameObject.SetActive(true);
                soldier_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                soldier_selected_image.gameObject.SetActive(false);
                soldier_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsHazmatSkinPurchased() == 1)
        {
            if (itemManager.GetIsHazmatSkinEquipped() == 1)
            {
                hazmat_selected_image.gameObject.SetActive(true);
                hazmat_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                hazmat_selected_image.gameObject.SetActive(false);
                hazmat_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (itemManager.GetIsRiotCopSkinPurchased() == 1)
        {
            if (itemManager.GetIsRiotCopSkinEquipped() == 1)
            {
                riotCop_selected_image.gameObject.SetActive(true);
                riotCop_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                riotCop_selected_image.gameObject.SetActive(false);
                riotCop_unlocked_image.gameObject.SetActive(true);
            }
        }
    }

    private void SetEquippedHelicopterSkinBtn()
    {
        if (itemManager.GetIsDefaultHelicopterSkinEquipped() == 1)
        {
            default_helicopter_selected_image.gameObject.SetActive(true);
            default_helicopter_unlocked_image.gameObject.SetActive(false);
        }
        else
        {
            default_helicopter_selected_image.gameObject.SetActive(false);
            default_helicopter_unlocked_image.gameObject.SetActive(true);
        }
        if (helicopterRankManager.GetHasHelicopter_02SkinBeenOffered() == 1)
        {
            if (itemManager.GetIsHelicopter_02SkinPurchased() == 1)
            {
                if (itemManager.GetIsHelicopter_02SkinEquipped() == 1)
                {
                    helicopter_02_selected_image.gameObject.SetActive(true);
                    helicopter_02_unlocked_image.gameObject.SetActive(false);
                }
                else
                {
                    helicopter_02_selected_image.gameObject.SetActive(false);
                    helicopter_02_unlocked_image.gameObject.SetActive(true);
                }
            }
        }
        if (itemManager.GetIsHelicopter_03SkinPurchased() == 1)
        {
            if (itemManager.GetIsHelicopter_03SkinEquipped() == 1)
            {
                helicopter_03_selected_image.gameObject.SetActive(true);
                helicopter_03_unlocked_image.gameObject.SetActive(false);
            }
            else
            {
                helicopter_03_selected_image.gameObject.SetActive(false);
                helicopter_03_unlocked_image.gameObject.SetActive(true);
            }
        }
        if (helicopterRankManager.GetHasHelicopter_04SkinBeenOffered() == 1)
        {
            if (itemManager.GetIsHelicopter_04SkinPurchased() == 1)
            {
                if (itemManager.GetIsHelicopter_04SkinEquipped() == 1)
                {
                    helicopter_04_selected_image.gameObject.SetActive(true);
                    helicopter_04_unlocked_image.gameObject.SetActive(false);
                }
                else
                {
                    helicopter_04_selected_image.gameObject.SetActive(false);
                    helicopter_04_unlocked_image.gameObject.SetActive(true);
                }
            }
        }
    }

    private void SetWeaponStats(int bulletDamage, int bulletCount)
    {
        bulletDamageTM.text = bulletDamage.ToString();
        bulletCountTM.text = bulletCount.ToString();
    }

    private void SetWeaponNickname(string nickname)
    {
        weaponNicknameTM.text = nickname;
    }

    public void ClaimGunTrial()
    {
        gunTrialManager.ClaimGunTrial(levelReached);
    }

    public void DeactivateGunTrial()
    {
        gunTrialManager.FindActiveGunTrial(levelReached);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void PurchaseShieldPack()
    {
        packManager.PurchaseShieldPack();
    }

    public void ClaimFreeShieldPack()
    {
        packManager.ClaimFreeShieldPack();
    }

    public void FreeShieldPackBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void DeclineShieldPack()
    {
        packManager.DeclineShieldPack();
        if (!PackManager.isViewingShieldPackAgain)
        {
            packManager.SetPlayBtnActive(true);
        }
        else
        {
            TapToPlay();
        }
        //iAPManager.HideAllLoadingPopUps();
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

    public void GunTrialBtn()
    {
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    private void SetInstagramBtnActive(bool isActive)
    {
        instagramBtn.SetActive(isActive);
    }

    public void SetLevelText(int levelReached)
    {
        levelTM.text = "LEVEL " + levelReached;
    }

    public void SetLevelTextHeaderActive(bool isActive)
    {
        levelTextHeader.gameObject.SetActive(isActive);
    }

    public void SetCreditsImageActive(bool isActive)
    {
        credits_image.gameObject.SetActive(isActive);
    }

    public void SetShieldImageActive(bool isActive)
    {
        shield_image.gameObject.SetActive(isActive);
    }

    public void SetCurrentShieldCountText(int shieldCount)
    {
        shieldCountTM.text = shieldCount.ToString();
    }

    public void SetCurrentCreditsCountText(int creditAmount)
    {
        currentCreditCountTM.text = creditAmount.ToString();
    }

    public void SetStarterPackBtnActive(bool isActive)
    {
        starterPackBtn.gameObject.SetActive(isActive);
        if (isActive)
        {
            packManager.SetIsStarterPackTabActive(true);
            if (worldTimer.GetIsSubtractingTimerRunning() == false)
            {
                if (!packManager.GetIsStarterPackLastChance())
                {
                    worldTimer.StartSubtractTimer(packManager.GetStarterPackOfferTimeRemaining());
                }
                else
                {
                    packManager.SetStarterPackLastChanceText();
                }
            }
            else
            {
                packManager.SetStarterPackTimeLeftText(worldTimer.GetHoursLeft(), worldTimer.GetMinutesLeft(), worldTimer.GetSecondsLeft());
            }
        }
        else
        {
            packManager.SetIsStarterPackTabActive(false);
        }
    }

    public void SetSecondPackBtnActive(bool isActive)
    {
        if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsStarterPackTabShowing())
        {
            if (packManager.GetIsSecondPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0
            && itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 0)
            {
                secondPackBtn.gameObject.SetActive(isActive);
                if (isActive)
                {
                    packManager.SetIsSecondPackTabActive(true);
                    if (worldTimer.GetIsSubtractingTimerRunning() == false)
                    {
                        if (!packManager.GetIsSecondPackLastChance())
                        {
                            worldTimer.StartSubtractTimer(packManager.GetSecondPackOfferTimeRemaining());
                        }
                        else
                        {
                            packManager.SetSecondPackLastChanceText();
                        }
                    }
                    else
                    {
                        packManager.SetSecondPackTimeLeftText(worldTimer.GetHoursLeft(), worldTimer.GetMinutesLeft(), worldTimer.GetSecondsLeft());
                    }
                }
                else
                {
                    packManager.SetIsSecondPackTabActive(false);
                }
            }
        }
    }

    public void SetThirdPackBtnActive(bool isActive)
    {
        if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsStarterPackTabShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsSecondPackTabShowing())
        {
            if (packManager.GetIsThirdPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0
            && itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 0)
            {
                thirdPackBtn.gameObject.SetActive(isActive);
                if (isActive)
                {
                    packManager.SetIsThirdPackTabActive(true);
                    if (worldTimer.GetIsSubtractingTimerRunning() == false)
                    {
                        if (!packManager.GetIsThirdPackLastChance())
                        {
                            worldTimer.StartSubtractTimer(packManager.GetThirdPackOfferTimeRemaining());
                        }
                        else
                        {
                            packManager.SetThirdPackLastChanceText();
                        }
                    }
                    else
                    {
                        packManager.SetThirdPackTimeLeftText(worldTimer.GetHoursLeft(), worldTimer.GetMinutesLeft(), worldTimer.GetSecondsLeft());
                    }
                }
                else
                {
                    packManager.SetIsThirdPackTabActive(false);
                }
            }
        }
    }

    public void SetShopTabsActive(bool isActive)
    {
        shopTabs.SetActive(isActive);
    }

    public void SetBankShopActive(bool isActive)
    {
        bankShop.SetActive(isActive);

        if (isActive)
        {
            mainCamera.transform.localPosition = originalCamPos;
        }
    }

    public void SetWeaponShopActive(bool isActive)
    {
        weaponShop.SetActive(isActive);

        if (isActive)
        {
            isWeaponShopOpen = true;
        } else
        {
            isWeaponShopOpen = false;
        }
    }

    public void SetSkinsShopActive(bool isActive)
    {
        skinsShop.SetActive(isActive);

        if (isActive)
        {
            isSkinShopOpen = true;
        }
        else
        {
            isSkinShopOpen = false;
        }
    }

    public void SetHelicopterShopActive(bool isActive)
    {
        helicopterShop.SetActive(isActive);

        if (isActive)
        {
            isHelicopterShopOpen = true;
        }
        else
        {
            isHelicopterShopOpen = false;
        }
    }

    public void SetMapUIActive(bool isActive)
    {
        mapUI.gameObject.SetActive(isActive);

        if (isActive)
        {
            isMapOpen = true;
        }
        else
        {
            isMapOpen = false;
        }
    }

    public void SetBankShopImageActive(bool isActive)
    {
        bankShop_image.gameObject.SetActive(isActive);
    }

    public void SetWeaponShopImageActive(bool isActive)
    {
        weaponShop_image.gameObject.SetActive(isActive);
        if (isActive)
        {
            SetTabInteractable(weaponShopTab, true);
        }
    }

    public void SetSkinsShopImageActive(bool isActive)
    {
        skinsShop_image.gameObject.SetActive(isActive);
        if (isActive)
        {
            SetTabInteractable(skinsShopTab, true);
        }
    }

    public void SetHelicopterShopImageActive(bool isActive)
    {
        helicopterShop_image.gameObject.SetActive(isActive);
        if (isActive)
        {
            SetTabInteractable(helicopterShopTab, true);
        }
    }

    public void SetMapIconImageActive(bool isActive)
    {
        mapIcon_image.gameObject.SetActive(isActive);
        if (isActive)
        {
            SetTabInteractable(mapTab, true);
        }
    }

    private void SetBossBattleMenuActive(bool isActive)
    {
        if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
        {
            bossBattleMenu.SetActive(isActive);
        }
    }

    public void SetBankShoplockedImageActive(bool isActive)
    {
        bankShopLocked_image.gameObject.SetActive(isActive);
    }

    public void SetWeaponShoplockedImageActive(bool isActive)
    {
        weaponShopLocked_image.gameObject.SetActive(isActive);
    }

    public void SetSkinsShoplockedImageActive(bool isActive)
    {
        skinsShopLocked_image.gameObject.SetActive(isActive);
    }

    public void SetHelicopterShoplockedImageActive(bool isActive)
    {
        helicopterShopLocked_image.gameObject.SetActive(isActive);
    }

    public void SetMaplockedImageActive(bool isActive)
    {
        mapLocked_image.gameObject.SetActive(isActive);
    }

    private void SetTabInteractable(GameObject tab, bool isInteractable)
    {
        tab.GetComponent<Image>().raycastTarget = isInteractable;
    }

    private void SetAssaultBtnUnlocked()
    {
        assault_locked_image.gameObject.SetActive(false);
        assault_unlocked_image.gameObject.SetActive(true);
    }

    private void SetAssault_02BtnUnlocked()
    {
        assault_02_locked_image.gameObject.SetActive(false);
        assault_02_unlocked_image.gameObject.SetActive(true);
    }

    private void SetAssault_03BtnUnlocked()
    {
        assault_03_locked_image.gameObject.SetActive(false);
        assault_03_unlocked_image.gameObject.SetActive(true);
    }

    private void SetShotgunBtnUnlocked()
    {
        shotgun_locked_image.gameObject.SetActive(false);
        shotgun_unlocked_image.gameObject.SetActive(true);
    }


    private void SetShotgun_02BtnUnlocked()
    {
        shotgun_02_locked_image.gameObject.SetActive(false);
        shotgun_02_unlocked_image.gameObject.SetActive(true);
    }

    private void SetSMGBtnUnlocked()
    {
        smg_locked_image.gameObject.SetActive(false);
        smg_unlocked_image.gameObject.SetActive(true);
    }

    private void SetSMG_02BtnUnlocked()
    {
        smg_02_locked_image.gameObject.SetActive(false);
        smg_02_unlocked_image.gameObject.SetActive(true);
    }

    private void SetSMG_03BtnUnlocked()
    {
        smg_03_locked_image.gameObject.SetActive(false);
        smg_03_unlocked_image.gameObject.SetActive(true);
    }

    private void SetRifle_01BtnUnlocked()
    {
        rifle_01_locked_image.gameObject.SetActive(false);
        rifle_01_unlocked_image.gameObject.SetActive(true);
    }

    private void SetRifle_02BtnUnlocked()
    {
        rifle_02_locked_image.gameObject.SetActive(false);
        rifle_02_unlocked_image.gameObject.SetActive(true);
    }

    private void SetMachineGun_01BtnUnlocked()
    {
        machineGun_01_locked_image.gameObject.SetActive(false);
        machineGun_01_unlocked_image.gameObject.SetActive(true);
    }

    private void SetMachineGun_02BtnUnlocked()
    {
        machineGun_02_locked_image.gameObject.SetActive(false);
        machineGun_02_unlocked_image.gameObject.SetActive(true);
    }

    private void SetRocketLauncherBtnUnlocked()
    {
        rocketLauncher_locked_image.gameObject.SetActive(false);
        rocketLauncher_unlocked_image.gameObject.SetActive(true);
    }

    private void SetMale_01BtnUnlocked()
    {
        male_01_locked_image.gameObject.SetActive(false);
        male_01_unlocked_image.gameObject.SetActive(true);
    }

    private void SetHomelessBtnUnlocked()
    {
        homeless_locked_image.gameObject.SetActive(false);
        homeless_unlocked_image.gameObject.SetActive(true);
    }

    private void SetBikerBtnUnlocked()
    {
        biker_locked_image.gameObject.SetActive(false);
        biker_unlocked_image.gameObject.SetActive(true);
    }

    private void SetSoldierBtnUnlocked()
    {
        soldier_locked_image.gameObject.SetActive(false);
        soldier_unlocked_image.gameObject.SetActive(true);
    }

    private void SetHazmatBtnUnlocked()
    {
        hazmat_locked_image.gameObject.SetActive(false);
        hazmat_unlocked_image.gameObject.SetActive(true);
    }

    private void SetRiotCopBtnUnlocked()
    {
        riotCop_locked_image.gameObject.SetActive(false);
        riotCop_unlocked_image.gameObject.SetActive(true);
    }

    private void SetFemale_01BtnUnlocked()
    {
        female_01_locked_image.gameObject.SetActive(false);
        female_01_unlocked_image.gameObject.SetActive(true);
    }

    private void SetHelicopter_02BtnUnlocked()
    {
        helicopter_02_locked_image.gameObject.SetActive(false);
        helicopter_02_unlocked_image.gameObject.SetActive(true);
    }

    private void SetHelicopter_03BtnUnlocked()
    {
        helicopter_03_locked_image.gameObject.SetActive(false);
        helicopter_03_unlocked_image.gameObject.SetActive(true);
    }

    private void SetHelicopter_04BtnUnlocked()
    {
        helicopter_04_locked_image.gameObject.SetActive(false);
        helicopter_04_unlocked_image.gameObject.SetActive(true);
    }

    private void SetMale_01_Watch_Ad_ImageActive(bool isActive)
    {
        male_01_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetHomeless_Watch_Ad_ImageActive(bool isActive)
    {
        homeless_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetBiker_Watch_Ad_ImageActive(bool isActive)
    {
        biker_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetSoldier_Watch_Ad_ImageActive(bool isActive)
    {
        soldier_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetHazmat_Watch_Ad_ImageActive(bool isActive)
    {
        hazmat_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetRiotCop_Watch_Ad_ImageActive(bool isActive)
    {
        riotCop_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetFemale_01_Watch_Ad_ImageActive(bool isActive)
    {
        female_01_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetHelicopter_02_Watch_Ad_ImageActive(bool isActive)
    {
        helicopter_02_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetHelicopter_03_Watch_Ad_ImageActive(bool isActive)
    {
        helicopter_03_watch_ad_image.gameObject.SetActive(isActive);
    }

    private void SetHelicopter_04_Watch_Ad_ImageActive(bool isActive)
    {
        helicopter_04_watch_ad_image.gameObject.SetActive(isActive);
    }

    public void SetPurchasesDisableAdsImageActive(bool isActive)
    {
        purchasesDisableAds_image.gameObject.SetActive(isActive);
    }

    public TextMeshProUGUI GetStarterPackTabTimeLeftTM()
    {
        return starterPackTabTimeLeftTM;
    }

    public TextMeshProUGUI GetSecondPackTabTimeLeftTM()
    {
        return secondPackTabTimeLeftTM;
    }

    public TextMeshProUGUI GetThirdPackTabTimeLeftTM()
    {
        return thirdPackTabTimeLeftTM;
    }

    private void LoadCurrentLevel(int levelReached)
    {
        switch (levelReached)
        {
            case 1:
                Debug.Log("Loading level 1!");
                Loader.Load(Loader.Scene.Level_01);
                break;
            case 2:
                Debug.Log("Loading level 2!");
                Loader.Load(Loader.Scene.Level_02);
                break;
            case 3:
                Debug.Log("Loading level 3!");
                Loader.Load(Loader.Scene.Level_03);
                break;
            case 4:
                Debug.Log("Loading level 4!");
                Loader.Load(Loader.Scene.Level_04);
                break;
            case 5:
                Debug.Log("Loading level 5!");
                Loader.Load(Loader.Scene.Level_05);
                break;
            case 6:
                Debug.Log("Loading level 6!");
                Loader.Load(Loader.Scene.Level_06);
                break;
            case 7:
                Debug.Log("Loading level 7!");
                Loader.Load(Loader.Scene.Level_07);
                break;
            case 8:
                Debug.Log("Loading level 8!");
                Loader.Load(Loader.Scene.Level_08);
                break;
            case 9:
                Debug.Log("Loading level 9!");
                Loader.Load(Loader.Scene.Level_09);
                break;
            case 10:
                Debug.Log("Loading level 10!");
                Loader.Load(Loader.Scene.Level_10);
                break;
            case 11:
                Debug.Log("Loading level 11!");
                Loader.Load(Loader.Scene.Level_11);
                break;
            case 12:
                Debug.Log("Loading level 12!");
                Loader.Load(Loader.Scene.Level_12);
                break;
            case 13:
                Debug.Log("Loading level 13!");
                Loader.Load(Loader.Scene.Level_13);
                break;
            case 14:
                Debug.Log("Loading level 14!");
                Loader.Load(Loader.Scene.Level_14);
                break;
            case 15:
                Debug.Log("Loading level 15!");
                Loader.Load(Loader.Scene.Level_15);
                break;
            case 16:
                Debug.Log("Loading level 16!");
                Loader.Load(Loader.Scene.Level_16);
                break;
            case 17:
                Debug.Log("Loading level 17!");
                Loader.Load(Loader.Scene.Level_17);
                break;
            case 18:
                Debug.Log("Loading level 18!");
                Loader.Load(Loader.Scene.Level_18);
                break;
            case 19:
                Debug.Log("Loading level 19!");
                Loader.Load(Loader.Scene.Level_19);
                break;
            case 20:
                Debug.Log("Loading level 20!");
                Loader.Load(Loader.Scene.Level_20);
                break;
            case 21:
                Debug.Log("Loading level 21!");
                Loader.Load(Loader.Scene.Level_21);
                break;
            case 22:
                Debug.Log("Loading level 22!");
                Loader.Load(Loader.Scene.Level_22);
                break;
            case 23:
                Debug.Log("Loading level 23!");
                Loader.Load(Loader.Scene.Level_23);
                break;
            case 24:
                Debug.Log("Loading level 24!");
                Loader.Load(Loader.Scene.Level_24);
                break;
            case 25:
                Debug.Log("Loading level 25!");
                Loader.Load(Loader.Scene.Level_25);
                break;
            case 26:
                Debug.Log("Loading level 26!");
                Loader.Load(Loader.Scene.Level_26);
                break;
            case 27:
                Debug.Log("Loading level 27!");
                Loader.Load(Loader.Scene.Level_27);
                break;
            case 28:
                Debug.Log("Loading level 28!");
                Loader.Load(Loader.Scene.Level_28);
                break;
            case 29:
                Debug.Log("Loading level 29!");
                Loader.Load(Loader.Scene.Level_29);
                break;
            case 30:
                Debug.Log("Loading level 30!");
                Loader.Load(Loader.Scene.Level_30);
                break;
            case 31:
                Debug.Log("Loading level 31!");
                Loader.Load(Loader.Scene.Level_31);
                break;
            default:
                Debug.Log("Reached MAX Level... Loading last level");
                Loader.Load(Loader.Scene.Level_31);
                break;
        }
    }

    private void SetMapVisuals(int levelNumber)
    {
        switch (levelNumber)
        {
            case 11:
                ShowSlot_01MapVisuals();
                break;
            case 12:
                ShowSlot_02MapVisuals();
                break;
            case 13:
                ShowSlot_03MapVisuals();
                break;
            case 14:
                ShowSlot_04MapVisuals();
                break;
            case 15:
                ShowSlot_05MapVisuals();
                break;
            case 16:
                ShowSlot_01MapVisuals();
                break;
            case 17:
                ShowSlot_02MapVisuals();
                break;
            case 18:
                ShowSlot_03MapVisuals();
                break;
            case 19:
                ShowSlot_04MapVisuals();
                break;
            case 20:
                ShowSlot_05MapVisuals();
                break;
            case 21:
                ShowSlot_01MapVisuals();
                break;
            case 22:
                ShowSlot_02MapVisuals();
                break;
            case 23:
                ShowSlot_03MapVisuals();
                break;
            case 24:
                ShowSlot_04MapVisuals();
                break;
            case 25:
                ShowSlot_05MapVisuals();
                break;
            case 26:
                ShowSlot_01MapVisuals();
                break;
            case 27:
                ShowSlot_02MapVisuals();
                break;
            case 28:
                ShowSlot_03MapVisuals();
                break;
            case 29:
                ShowSlot_04MapVisuals();
                break;
            case 30:
                ShowSlot_05MapVisuals();
                break;
            case 31:
                ShowSlot_01MapVisuals();
                break;
            case 32:
                ShowSlot_02MapVisuals();
                break;
            default:
                break;
        }
    }

    private void ShowSlot_01MapVisuals()
    {
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
            }
            else
            {
                SetWorldNumberText("WORLD 3");
            }
            if (levelReached < 21 || levelReached > 25 && levelReached < 31)
            {
                SetMapSlot_05TextActive(true);
                SetMapSlot_05Text((levelReached + 4).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            }
            else
            {
                SetMapSlot_05TextActive(false);
                SetMapSlot_05BossTextActive(true);
                SetMapSlot_05BossImageActive(true);
            }
        }
        SetMapSlot_01TextColor(Color.black);
        SetMapSlot_01BackgroundAlpha(1f);
        SetMapSlot_01CurrentImageActive(true);
    }

    private void ShowSlot_02MapVisuals()
    {
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
            }
            else
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
    }

    private void ShowSlot_03MapVisuals()
    {
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
                SetMapSlot_05Text((levelReached + 3).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            }
        }
        SetMapSlot_03TextColor(Color.black);
        SetMapSlot_03BackgroundAlpha(1f);
        SetMapSlot_03CurrentImageActive(true);
    }

    private void ShowSlot_04MapVisuals()
    {
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
                SetMapSlot_05Text((levelReached + 3).ToString());
                SetMapSlot_05BossTextActive(false);
                SetMapSlot_05BossImageActive(false);
            }
        }
        SetMapSlot_04TextColor(Color.black);
        SetMapSlot_04BackgroundAlpha(1f);
        SetMapSlot_04CurrentImageActive(true);
    }

    private void ShowSlot_05MapVisuals()
    {
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

    private void SetMapSlot_05TextActive(bool isActive)
    {
        mapSlot_05Text.gameObject.SetActive(isActive);
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

    private void SetMapSlot_05BossTextActive(bool isActive)
    {
        mapSlot_05BossText.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05BossImageActive(bool isActive)
    {
        mapSlot_05BossImage.gameObject.SetActive(isActive);
    }

    private void SetMapSlot_05BossImageColor(Color color)
    {
        mapSlot_05BossImage.color = color;
    }

    private void SetWeaponShopScrollbarValue(float value)
    {
        weaponShopScrollbar.value = value;
    }

    public void SetBossTabActive(bool isActive)
    {
        bossTab.gameObject.SetActive(isActive);
        if (isActive)
        {
            SetBossTabImage();
        }
    }

    private void SetBossBattleBannerActive(bool isActive)
    {
        bossBattleBanner.gameObject.SetActive(isActive);
    }

    public void SetSettingsBtnActive(bool isActive)
    {
        settingsBtn.SetActive(isActive);
    }

    private void SetSettingsMenuActive(bool isActive)
    {
        settingsMenu.SetActive(isActive);
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
        toggleHapticsOn_image.gameObject.SetActive(isActive);
    }

    private void SetToggleHapticsOffImageActive(bool isActive)
    {
        toggleHapticsOff_image.gameObject.SetActive(isActive);
    }

    private int GetIsBloodOn()
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

    private int GetIsHapticsOn()
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

    private void SetVersionText()
    {
        versionNumberTM.text = "v" + Application.version.ToString();
    }

    private void SetBossBattleImage()
    {
        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        if (levelReached == 15)
        {
            SetBossBattle_01ImageActive(true);
        }
        if (levelReached == 25)
        {
            SetBossBattle_01ImageActive(false);
            SetBossBattle_02ImageActive(true);
        }
    }

    private void SetBossBattle_01ImageActive(bool isActive)
    {
        bossBattle_01_image.gameObject.SetActive(isActive);
    }

    private void SetBossBattle_02ImageActive(bool isActive)
    {
        bossBattle_02_image.gameObject.SetActive(isActive);
    }

    private void SetBossTabImage()
    {
        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        if (levelReached < 16)
        {
            SetBoss_01ImageActive(true);
        }
        if (levelReached >= 16 && levelReached < 36)
        {
            SetBoss_01ImageActive(false);
            SetBoss_02ImageActive(true);
        }
    }

    private void SetBoss_01ImageActive(bool isActive)
    {
        boss_01_image.gameObject.SetActive(isActive);
    }

    private void SetBoss_02ImageActive(bool isActive)
    {
        boss_02_image.gameObject.SetActive(isActive);
    }

    public void SetBossTabLevelsLeftText(int levelReached)
    {
        int levelsLeft = GetLevelsLeftUntilBoss(levelReached);
        if (levelsLeft > 0)
        {
            bossTabLevelsLeftTM.text = levelsLeft + " LEVELS LEFT";
        }
        else
        {
            bossTabLevelsLeftTM.text = "READY";
        }
    }

    private int GetLevelsLeftUntilBoss(int levelNumber)
    {
        switch (levelNumber)
        {
            case 11:
                return 4;
            case 12:
                return 3;
            case 13:
                return 2;
            case 14:
                return 1;
            case 15:
                return 0;
            case 21:
                return 4;
            case 22:
                return 3;
            case 23:
                return 2;
            case 24:
                return 1;
            case 25:
                return 0;
            default:
                return 0;
        }
    }

    public void CheckIfBossTab(int levelNumber)
    {
        switch (levelNumber)
        {
            case 11:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 12:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 13:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 14:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 15:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 21:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 22:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 23:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 24:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            case 25:
                if (!packManager.GetIsStarterPackMenuShowing() && !packManager.GetIsSecondPackMenuShowing() && !packManager.GetIsThirdPackMenuShowing())
                {
                    SetBossTabLevelsLeftText(levelNumber);
                    SetBossTabActive(true);
                }
                break;
            default:
                SetBossTabLevelsLeftText(levelNumber);
                SetBossTabActive(false);
                break;
        }
    }

    public bool GetHasShownBossBattleMenu()
    {
        return hasShownBossBattleMenu;
    }

    public void SetHasShownBossBattleMenu(bool _hasShownBossBattleMenu)
    {
        hasShownBossBattleMenu = _hasShownBossBattleMenu;
    }

    //private void SetInfoMenuActive(bool isActive)
    //{
    //    infoMenu.SetActive(isActive);
    //    if (isActive)
    //    {
    //        isInfoMenuOpen = true;
    //        SetInfoBtnActive(false);
    //    } else
    //    {
    //        isInfoMenuOpen = false;
    //        SetInfoBtnActive(true);
    //    }
    //}

    //private void SetInfoBtnActive(bool isActive)
    //{
    //    infoBtn.SetActive(isActive);
    //}
}
