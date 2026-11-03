using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeManager : MonoBehaviour
{
    [SerializeField] private HomeUI homeUI;
    [SerializeField] private CreditManager creditManager;
    [SerializeField] private ShieldManager shieldManager;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private PackManager packManager;
    [SerializeField] private RankManager rankManager;
    [SerializeField] private HelicopterRankManager helicopterRankManager;

    private int levelReached;
    private string levelReachPlayerPrefsName = "levelReached";
    private int numberOfLevelsSkipped;
    private string numberOfLevelsSkippedPlayerPrefsName = "numberOfLevelsSkipped";
    private bool isShowingShieldPack;
    private bool isShowingGunTrial;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        //PlayerPrefs.DeleteKey(levelReachPlayerPrefsName);
        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        numberOfLevelsSkipped = PlayerPrefs.GetInt(numberOfLevelsSkippedPlayerPrefsName, 0);
        if (levelReached == 15 || levelReached == 25)
        {
            if (!LevelUI.wasReviveBtnClicked)
            {
                homeUI.ShowBossBattleMenu();
                homeUI.SetBossTabActive(false);
            }
            else
            {
                if (GameManager.isExitingLevel)
                {
                    homeUI.ShowBossBattleMenu();
                    homeUI.SetBossTabActive(false);
                }
            }
        }
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        homeUI.SetLevelText(levelReached);
        homeUI.SetCurrentCreditsCountText(creditManager.GetCreditCount());
        Init();
        AdsInitializer.hasWatchedRewardedAd = false;
        GameManager.isExitingLevel = false;
    }

    public void Init()
    {
        if (levelReached == 1)
        {
            homeUI.SetShieldImageActive(false);
        }
        else
        {
            homeUI.SetCurrentShieldCountText(shieldManager.GetShieldCount());
        }

        //if (!packManager.GetIsPackOfferLevel() && !LevelUI.offerGunTrialAgain && !LevelUI.offerShieldPackageAgain)
        if (!packManager.GetIsPackOfferLevel() && GetIsShowingGunTrial() == false && GetIsShowingShieldPack() == false)
        {
            ShowUnlockedShopTabs();
        }
        if (levelReached == 7 + numberOfLevelsSkipped)
        {
            rankManager.SetMale_01SkinAsOffered();
        }
        if (levelReached == 12 + numberOfLevelsSkipped)
        {
            rankManager.SetHomelessSkinAsOffered();
        }
        if (levelReached == 17 + numberOfLevelsSkipped)
        {
            helicopterRankManager.SetHelicopter_02SkinAsOffered();
        }
        if (levelReached == 32 + numberOfLevelsSkipped)
        {
            helicopterRankManager.SetHelicopter_04SkinAsOffered();
        }
        if (levelReached == 22 + numberOfLevelsSkipped)
        {
            rankManager.SetBikerSkinAsOffered();
        }
        if (levelReached == 27 + numberOfLevelsSkipped)
        {
            rankManager.SetFemale_01SkinAsOffered();
        }
    }

    public void ShowUnlockedShopTabs()
    {
        if (levelReached == 7 + numberOfLevelsSkipped && rankManager.GetIsSkinShopUnlocked() == 0 || packManager.GetIsStarterPackPurchased() == 1 || packManager.GetIsSecondPackPurchased() == 1
            || packManager.GetIsThirdPackPurchased() == 1)
        {
            rankManager.UnlockSkinShop();
        }

        if (levelReached == 17 + numberOfLevelsSkipped && helicopterRankManager.GetIsHelicopterShopUnlocked() == 0)
        {
            helicopterRankManager.UnlockHelicopterShop();
        }
        if (itemManager.GetIsAssaultPurchased() == 1 && !packManager.GetIsStarterPackLastChance() && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
            || rankManager.GetIsSkinShopUnlocked() == 1 && !packManager.GetIsStarterPackLastChance() && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
            || packManager.GetIsStarterPackPurchased() == 1 && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
            || packManager.GetIsSecondPackPurchased() == 1 && !packManager.GetIsThirdPackLastChance()
            || packManager.GetIsThirdPackPurchased() == 1)
        {
            homeUI.SetShopTabsActive(true);
            if (rankManager.GetIsSkinShopUnlocked() == 1 || packManager.GetIsStarterPackPurchased() == 1 || packManager.GetIsSecondPackPurchased() == 1 || packManager.GetIsThirdPackPurchased() == 1)
            {
                homeUI.SetSkinsShopImageActive(true);
                homeUI.SetSkinsShoplockedImageActive(false);
            }
            if (helicopterRankManager.GetIsHelicopterShopUnlocked() == 1)
            {
                homeUI.SetHelicopterShopImageActive(true);
                homeUI.SetHelicopterShoplockedImageActive(false);
            }
        }

        if (itemManager.GetIsAssaultPurchased() == 1 && !packManager.GetIsStarterPackLastChance() && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
            || packManager.GetIsStarterPackPurchased() == 1 && !packManager.GetIsSecondPackLastChance() && !packManager.GetIsThirdPackLastChance()
            || packManager.GetIsSecondPackPurchased() == 1 && !packManager.GetIsThirdPackLastChance()
            || packManager.GetIsThirdPackPurchased() == 1)
        {
            homeUI.SetBankShopImageActive(true);
            homeUI.SetBankShoplockedImageActive(false);
            homeUI.SetWeaponShopImageActive(true);
            homeUI.SetWeaponShoplockedImageActive(false);
        }

        if (levelReached >= 11 + numberOfLevelsSkipped)
        {
            homeUI.SetMapIconImageActive(true);
            homeUI.SetMaplockedImageActive(false);
        }

        homeUI.CheckIfBossTab(levelReached);
    }

    public void SetIsShowingShieldPack(bool _isShowingShieldPack)
    {
        isShowingShieldPack = _isShowingShieldPack;
    }

    public void SetIsShowingGunTrial(bool _isShowingGunTrial)
    {
        isShowingGunTrial = _isShowingGunTrial;
    }

    public bool GetIsShowingShieldPack()
    {
        return isShowingShieldPack;
    }

    public bool GetIsShowingGunTrial()
    {
        return isShowingGunTrial;
    }
}
