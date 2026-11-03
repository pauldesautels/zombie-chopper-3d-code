using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Services.Analytics;

using DG.Tweening;

public class PackManager : MonoBehaviour
{
    [SerializeField] private GameObject starterPackUI;
    [SerializeField] private GameObject starterPackGeometry;
    [SerializeField] private GameObject shieldPackUI;
    [SerializeField] private GameObject shieldPackGeometry;
    [SerializeField] private GameObject declineShiedPackBtn;
    [SerializeField] private GameObject secondPackUI;
    [SerializeField] private GameObject secondPackGeometry;
    [SerializeField] private GameObject thirdPackUI;
    [SerializeField] private GameObject thirdPackGeometry;
    [SerializeField] private Button playBtn;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private ShieldManager shieldManager;
    [SerializeField] private HomeUI homeUI;
    [SerializeField] private HomeNPC homeNPC;
    [SerializeField] private TextMeshProUGUI starterPackMenuTimeLeftTM;
    [SerializeField] private TextMeshProUGUI secondPackMenuTimeLeftTM;
    [SerializeField] private TextMeshProUGUI thirdPackMenuTimeLeftTM;
    [SerializeField] private WorldTimer worldTimer;
    [SerializeField] private HomeManager homeManager;
    [SerializeField] private RankManager rankManager;
    //[SerializeField] private IAPManager iAPManager;

    private int levelReached;
    private string levelReachPlayerPrefsName = "levelReached";
    private bool isPackOfferLevel;

    // Starter Pack.
    private int starterPackOfferTime = 300; // 5 minutes.
    private int isStarterPackPurchased;
    private int isStarterPackOffered;
    private int isStarterPackExpired;
    private string starterPackTimeLeftPrefsName = "starterPackTimeleft";
    private string starterPackPurchasedPlayerPrefsName = "starterPackPurchased";
    private string starterPackOfferedPlayerPrefsName = "starterPackOffered";
    private string starterPackExpiredPlayerPrefsName = "starterPackExpired";
    private bool isStarterPackMenuShowing;
    private bool isStarterPackLastChance;
    private bool isStarterPackTabShowing;

    // Shield Pack.
    private int shieldPackValue = 30;
    private int freeShieldPackValue = 3;
    private bool hasCheckedForOnPlayPackOffer;
    private bool isOnPlayPackOfferAvailable;
    public static bool isViewingShieldPackAgain;

    // Second Pack.
    private int secondPackOfferTime = 900; // 15 minutes.
    private int isSecondPackPurchased;
    private int isSecondPackOffered;
    private int isSecondPackExpired;
    private string secondPackTimeLeftPrefsName = "secondPackTimeleft";
    private string secondPackPurchasedPlayerPrefsName = "secondPackPurchased";
    private string secondPackOfferedPlayerPrefsName = "secondPackOffered";
    private string secondPackExpiredPlayerPrefsName = "secondPackExpired";
    private bool isSecondPackMenuShowing;
    private bool isSecondPackLastChance;
    private bool isSecondPackTabShowing;

    // Third Pack.
    private int thirdPackOfferTime = 900; // 15 minutes.
    private int isThirdPackPurchased;
    private int isThirdPackOffered;
    private int isThirdPackExpired;
    private string thirdPackTimeLeftPrefsName = "thirdPackTimeleft";
    private string thirdPackPurchasedPlayerPrefsName = "thirdPackPurchased";
    private string thirdPackOfferedPlayerPrefsName = "thirdPackOffered";
    private string thirdPackExpiredPlayerPrefsName = "thirdPackExpired";
    private bool isThirdPackMenuShowing;
    private bool isThirdPackLastChance;
    private bool isThirdPackTabShowing;

    // Analytics.
    private string firstPackOfferedEventName = "firstPackOffered"; // 0 means false, 1 means true
    private string firstPackAdvancedEventName = "firstPackAdvanced";

    // Start is called before the first frame update
    void Start()
    {
        //PlayerPrefs.DeleteKey(levelReachPlayerPrefsName);
        //PlayerPrefs.DeleteKey(starterPackTimeLeftPrefsName);
        //PlayerPrefs.DeleteKey(starterPackPurchasedPlayerPrefsName);
        //PlayerPrefs.DeleteKey(starterPackOfferedPlayerPrefsName);
        //PlayerPrefs.DeleteKey(starterPackExpiredPlayerPrefsName);
        //PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
        levelReached = PlayerPrefs.GetInt(levelReachPlayerPrefsName, 1);
        CheckForImmediatePackOffer(levelReached);
    }

    private void CheckForImmediatePackOffer(int levelNumber)
    {
        switch (levelNumber)
        {
            case 3:
                if (GetIsStarterPackPurchased() == 0 && GetIsStarterPackExpired() == 0)
                {
                    SetIsPackOfferLevel(true);
                    SetStarterPackOffered();
                    SetStarterPackOfferMenuActive(true);
                }
                break;
            case 10:
                if (GetIsSecondPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 0 && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing()
                    && GetIsSecondPackExpired() == 0)
                {
                    if (!isViewingShieldPackAgain)
                    {
                        if (GetIsStarterPackOffered() == 1)
                        {
                            if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                            {
                                SetIsPackOfferLevel(true);
                                SetSecondPackOffered();
                                SetSecondPackOfferMenuActive(true);
                            }
                        } else
                        {
                            SetIsPackOfferLevel(true);
                            SetSecondPackOffered();
                            SetSecondPackOfferMenuActive(true);
                        }
                    }
                }
                break;
            case 17:
                if (GetIsThirdPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 0
                    && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing() && !GetIsSecondPackMenuShowing() && !GetIsSecondPackTabShowing()
                    && GetIsThirdPackExpired() == 0)
                {
                    if (!isViewingShieldPackAgain)
                    {
                        if (GetIsStarterPackOffered() == 1 || GetIsSecondPackOffered() == 1)
                        {
                            if (GetIsSecondPackOffered() == 0)
                            {
                                if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                {
                                    SetIsPackOfferLevel(true);
                                    SetThirdPackOffered();
                                    SetThirdPackOfferMenuActive(true);
                                }
                            } else if (GetIsStarterPackOffered() == 0)
                            {
                                if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                {
                                    SetIsPackOfferLevel(true);
                                    SetThirdPackOffered();
                                    SetThirdPackOfferMenuActive(true);
                                }
                            } else // Both packs have been offered.
                            {
                                if (GetIsStarterPackExpired() == 1 && GetIsSecondPackExpired() == 1
                                    || GetIsStarterPackPurchased() == 1 && GetIsSecondPackExpired() == 1
                                    || GetIsSecondPackPurchased() == 1 && GetIsStarterPackExpired() == 1)
                                {
                                    SetIsPackOfferLevel(true);
                                    SetThirdPackOffered();
                                    SetThirdPackOfferMenuActive(true);
                                }
                            }
                        } else
                        {
                            SetIsPackOfferLevel(true);
                            SetThirdPackOffered();
                            SetThirdPackOfferMenuActive(true);
                        }
                    }
                }
                break;
            case 24:
                if (GetIsSecondPackOffered() == 0) // Try and show second pack if it has never been shown before.
                {
                    if (GetIsSecondPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 0 && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing()
                    && !GetIsThirdPackMenuShowing() && !GetIsThirdPackTabShowing())
                    {
                        if (!isViewingShieldPackAgain)
                        {
                            if (GetIsStarterPackOffered() == 1 || GetIsThirdPackOffered() == 1)
                            {
                                if (GetIsThirdPackOffered() == 0)
                                {
                                    if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                                else if (GetIsStarterPackOffered() == 0)
                                {
                                    if (GetIsThirdPackExpired() == 1 || GetIsThirdPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                                else // Both packs have been offered.
                                {
                                    if (GetIsStarterPackExpired() == 1 && GetIsThirdPackExpired() == 1
                                        || GetIsStarterPackPurchased() == 1 && GetIsThirdPackExpired() == 1
                                        || GetIsThirdPackPurchased() == 1 && GetIsStarterPackExpired() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                            }
                            else
                            {
                                if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                {
                                    PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                    PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                }
                                SetIsPackOfferLevel(true);
                                SetSecondPackOffered();
                                SetSecondPackOfferMenuActive(true);
                            }
                        }
                    }
                } else if(GetIsThirdPackOffered() == 0) // Try and show third pack if it has never been shown before.
                {
                    if (GetIsThirdPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 0
                    && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing() && !GetIsSecondPackMenuShowing() && !GetIsSecondPackTabShowing())
                    {
                        if (!isViewingShieldPackAgain)
                        {
                            if (GetIsStarterPackOffered() == 1 || GetIsSecondPackOffered() == 1)
                            {
                                if (GetIsSecondPackOffered() == 0)
                                {
                                    if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                                else if (GetIsStarterPackOffered() == 0)
                                {
                                    if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                                else // Both packs have been offered.
                                {
                                    if (GetIsStarterPackExpired() == 1 && GetIsSecondPackExpired() == 1
                                        || GetIsStarterPackPurchased() == 1 && GetIsSecondPackExpired() == 1
                                        || GetIsSecondPackPurchased() == 1 && GetIsStarterPackExpired() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                            }
                            else
                            {
                                if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                {
                                    PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                    PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                }
                                SetIsPackOfferLevel(true);
                                SetThirdPackOffered();
                                SetThirdPackOfferMenuActive(true);
                            }
                        }
                    }
                } else // Second and third packs have already been shown.
                {
                    if (GetIsSecondPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 0 && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing()
                    && !GetIsThirdPackMenuShowing() && !GetIsThirdPackTabShowing())
                    {
                        if (!isViewingShieldPackAgain)
                        {
                            if (GetIsStarterPackOffered() == 1)
                            {
                                if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                {
                                    if (GetIsThirdPackExpired() == 1 || GetIsThirdPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                            }
                            else
                            {
                                if (GetIsThirdPackExpired() == 1 || GetIsThirdPackPurchased() == 1)
                                {
                                    if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                    {
                                        PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                        PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                    }
                                    SetIsPackOfferLevel(true);
                                    SetSecondPackOffered();
                                    SetSecondPackOfferMenuActive(true);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GetIsThirdPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0
                        && itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 0
                        && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing() && !GetIsSecondPackMenuShowing() && !GetIsSecondPackTabShowing())
                        {
                            if (!isViewingShieldPackAgain)
                            {
                                if (GetIsStarterPackOffered() == 1)
                                {
                                    if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                        {
                                            if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                            {
                                                PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                                PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                            }
                                            SetIsPackOfferLevel(true);
                                            SetThirdPackOffered();
                                            SetThirdPackOfferMenuActive(true);
                                        }
                                    }
                                }
                                else
                                {
                                    if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            case 30:
                if (GetIsSecondPackOffered() == 0) // Try and show second pack if it has never been shown before.
                {
                    if (GetIsSecondPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 0 && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing()
                    && !GetIsThirdPackMenuShowing() && !GetIsThirdPackTabShowing())
                    {
                        if (!isViewingShieldPackAgain)
                        {
                            if (GetIsStarterPackOffered() == 1 || GetIsThirdPackOffered() == 1)
                            {
                                if (GetIsThirdPackOffered() == 0)
                                {
                                    if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                                else if (GetIsStarterPackOffered() == 0)
                                {
                                    if (GetIsThirdPackExpired() == 1 || GetIsThirdPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                                else // Both packs have been offered.
                                {
                                    if (GetIsStarterPackExpired() == 1 && GetIsThirdPackExpired() == 1
                                        || GetIsStarterPackPurchased() == 1 && GetIsThirdPackExpired() == 1
                                        || GetIsThirdPackPurchased() == 1 && GetIsStarterPackExpired() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                            }
                            else
                            {
                                if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                {
                                    PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                    PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                }
                                SetIsPackOfferLevel(true);
                                SetSecondPackOffered();
                                SetSecondPackOfferMenuActive(true);
                            }
                        }
                    }
                }
                else if (GetIsThirdPackOffered() == 0) // Try and show third pack if it has never been shown before.
                {
                    if (GetIsThirdPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 0
                    && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing() && !GetIsSecondPackMenuShowing() && !GetIsSecondPackTabShowing())
                    {
                        if (!isViewingShieldPackAgain)
                        {
                            if (GetIsStarterPackOffered() == 1 || GetIsSecondPackOffered() == 1)
                            {
                                if (GetIsSecondPackOffered() == 0)
                                {
                                    if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                                else if (GetIsStarterPackOffered() == 0)
                                {
                                    if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                                else // Both packs have been offered.
                                {
                                    if (GetIsStarterPackExpired() == 1 && GetIsSecondPackExpired() == 1
                                        || GetIsStarterPackPurchased() == 1 && GetIsSecondPackExpired() == 1
                                        || GetIsSecondPackPurchased() == 1 && GetIsStarterPackExpired() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                            }
                            else
                            {
                                if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                {
                                    PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                    PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                }
                                SetIsPackOfferLevel(true);
                                SetThirdPackOffered();
                                SetThirdPackOfferMenuActive(true);
                            }
                        }
                    }
                }
                else // Second and third packs have already been shown.
                {
                    if (GetIsSecondPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0
                    && itemManager.CheckIfItemIsPurchased(Item.ItemType.HazmatSkin) == 0 && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing()
                    && !GetIsThirdPackMenuShowing() && !GetIsThirdPackTabShowing())
                    {
                        if (!isViewingShieldPackAgain)
                        {
                            if (GetIsStarterPackOffered() == 1)
                            {
                                if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                {
                                    if (GetIsThirdPackExpired() == 1 || GetIsThirdPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetSecondPackOffered();
                                        SetSecondPackOfferMenuActive(true);
                                    }
                                }
                            }
                            else
                            {
                                if (GetIsThirdPackExpired() == 1 || GetIsThirdPackPurchased() == 1)
                                {
                                    if (GetIsSecondPackPurchased() == 0 && GetIsSecondPackExpired() == 1) // Reset Pack.
                                    {
                                        PlayerPrefs.DeleteKey(secondPackTimeLeftPrefsName);
                                        PlayerPrefs.DeleteKey(secondPackExpiredPlayerPrefsName);
                                    }
                                    SetIsPackOfferLevel(true);
                                    SetSecondPackOffered();
                                    SetSecondPackOfferMenuActive(true);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (GetIsThirdPackPurchased() == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0
                        && itemManager.CheckIfItemIsPurchased(Item.ItemType.RiotCopSkin) == 0 && itemManager.CheckIfItemIsPurchased(Item.ItemType.Helicopter_03Skin) == 0
                        && !GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing() && !GetIsSecondPackMenuShowing() && !GetIsSecondPackTabShowing())
                        {
                            if (!isViewingShieldPackAgain)
                            {
                                if (GetIsStarterPackOffered() == 1)
                                {
                                    if (GetIsStarterPackExpired() == 1 || GetIsStarterPackPurchased() == 1)
                                    {
                                        if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                        {
                                            if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                            {
                                                PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                                PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                            }
                                            SetIsPackOfferLevel(true);
                                            SetThirdPackOffered();
                                            SetThirdPackOfferMenuActive(true);
                                        }
                                    }
                                }
                                else
                                {
                                    if (GetIsSecondPackExpired() == 1 || GetIsSecondPackPurchased() == 1)
                                    {
                                        if (GetIsThirdPackPurchased() == 0 && GetIsThirdPackExpired() == 1) // Reset Pack.
                                        {
                                            PlayerPrefs.DeleteKey(thirdPackTimeLeftPrefsName);
                                            PlayerPrefs.DeleteKey(thirdPackExpiredPlayerPrefsName);
                                        }
                                        SetIsPackOfferLevel(true);
                                        SetThirdPackOffered();
                                        SetThirdPackOfferMenuActive(true);
                                    }
                                }
                            }
                        }
                    }
                }
                break;
            default:
                SetIsPackOfferLevel(false);
                break;
        }
    }

    public void CheckForOnPlayPackOffer(int levelNumber)
    {
        SetHasCheckedForOnPlayPackOffer(true);
        switch (levelNumber)
        {
            case 6:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            case 10:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            case 15:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            case 17:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            case 20:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            case 25:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            case 28:
                SetIsOnPlayPackOfferAvailable(true);
                SetShieldPackOfferActive();
                break;
            default:
                break;
        }
    }

    public void PurchaseStarterPack()
    {
        Debug.Log("Starter Pack Purchased!");
        itemManager.PurchaseItem(Item.ItemType.Shotgun_02);
        itemManager.EquipItem(Item.ItemType.Shotgun_02);
        itemManager.PurchaseItem(Item.ItemType.SoldierSkin);
        itemManager.EquipItem(Item.ItemType.SoldierSkin);
        shieldManager.AddShields(10);
        homeUI.SetCurrentShieldCountText(shieldManager.GetShieldCount());
        homeNPC.CallEquipItems();
        SaveStarterPackPurchased();
        //SetStarterPackOfferMenuActive(false);
        StartCoroutine(WaitSetStarterPackOfferMenuActive(.001f, false));
        homeUI.SetStarterPackBtnActive(false);
        homeManager.ShowUnlockedShopTabs();

        if (PlayerPrefs.GetInt(firstPackAdvancedEventName, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "packStatus", "Purchased" },
            };
            AnalyticsService.Instance.CustomData(firstPackAdvancedEventName, parameters);
            PlayerPrefs.SetInt(firstPackAdvancedEventName, 1);
        }
    }

    public void PurchaseSecondPack()
    {
        Debug.Log("Second Pack Purchased!");
        itemManager.PurchaseItem(Item.ItemType.SMG_03);
        itemManager.EquipItem(Item.ItemType.SMG_03);
        itemManager.PurchaseItem(Item.ItemType.HazmatSkin);
        itemManager.EquipItem(Item.ItemType.HazmatSkin);
        shieldManager.AddShields(10);
        homeUI.SetCurrentShieldCountText(shieldManager.GetShieldCount());
        homeNPC.CallEquipItems();
        SaveSecondPackPurchased();
        //SetSecondPackOfferMenuActive(false);
        StartCoroutine(WaitSetSecondPackOfferMenuActive(.001f, false));
        homeUI.SetSecondPackBtnActive(false);
    }

    public void PurchaseThirdPack()
    {
        Debug.Log("Third Pack Purchased!");
        itemManager.PurchaseItem(Item.ItemType.Rifle_02);
        itemManager.EquipItem(Item.ItemType.Rifle_02);
        itemManager.PurchaseItem(Item.ItemType.RiotCopSkin);
        itemManager.EquipItem(Item.ItemType.RiotCopSkin);
        itemManager.PurchaseItem(Item.ItemType.Helicopter_03Skin);
        itemManager.EquipItem(Item.ItemType.Helicopter_03Skin);
        homeNPC.CallEquipItems();
        SaveThirdPackPurchased();
        //SetThirdPackOfferMenuActive(false);
        StartCoroutine(WaitSetThirdPackOfferMenuActive(.001f, false));
        homeUI.SetThirdPackBtnActive(false);
    }

    public void PurchaseShieldPack()
    {
        Debug.Log("Shield Pack Purchased!");
        shieldManager.AddShields(shieldPackValue);
        homeUI.SetCurrentShieldCountText(shieldManager.GetShieldCount());
    }

    public void ClaimFreeShieldPack()
    {
        Debug.Log("Free Shield Pack Claimed!");
        shieldManager.AddShields(freeShieldPackValue);
        homeUI.SetCurrentShieldCountText(shieldManager.GetShieldCount());
    }

    public void DeclineShieldPack()
    {
        shieldPackUI.SetActive(false);
        shieldPackGeometry.SetActive(false);
        declineShiedPackBtn.gameObject.SetActive(false);
        homeUI.TapToPlay();
    }

    public void SetShieldPackOfferActive()
    {
        //TWEEN ----
        DOTween.Kill("shieldPackScale");
        shieldPackUI.transform.DOScale(new Vector3(0.8f, 0.8f, 1), 0);
        shieldPackUI.transform.DOScale(new Vector3(1f, 1f, 1), 0.5f).SetEase(Ease.OutBounce).SetId("shieldPackScale");

        shieldPackUI.SetActive(true);
        shieldPackGeometry.SetActive(true);
        SetPlayBtnActive(false);
        homeUI.SetSettingsBtnActive(false);
        StartCoroutine(WaitSetDeclineShielPackBtnActive(2f));
    }

    public IEnumerator WaitSetDeclineShielPackBtnActive(float delay)
    {
        yield return new WaitForSeconds(delay);

        declineShiedPackBtn.SetActive(true);
    }

    public IEnumerator WaitSetStarterPackOfferMenuActive(float delay, bool isActive)
    {
        yield return new WaitForSeconds(delay);

        SetStarterPackOfferMenuActive(isActive);
    }

    public void SetStarterPackOfferMenuActive(bool isActive)
    {
        //TWEEN ----
        DOTween.Kill("starterPackScale");
        starterPackUI.transform.DOScale(new Vector3(0.018f, 0.018f, 0.018f), 0);
        starterPackUI.transform.DOScale(new Vector3(0.02f, 0.02f, 0.02f), 0.5f).SetEase(Ease.OutBounce).SetId("starterPackScale");


        QualitySettings.shadowDistance = 15;

        starterPackUI.SetActive(isActive);
        starterPackGeometry.SetActive(isActive);
        SetPlayBtnActive(!isActive);
        if (isActive)
        {
            SetIsStarterPackMenuShowingActive(true);
            if (worldTimer.GetIsSubtractingTimerRunning() == false)
            {
                if (!GetIsStarterPackLastChance())
                {
                    worldTimer.StartSubtractTimer(GetStarterPackOfferTimeRemaining());
                }
                else
                {
                    SetStarterPackLastChanceText();
                }
            }
            else
            {
                SetStarterPackTimeLeftText(worldTimer.GetHoursLeft(), worldTimer.GetMinutesLeft(), worldTimer.GetSecondsLeft());
            }
            homeUI.SetShopTabsActive(false);
            homeUI.SetCreditsImageActive(false);
            homeUI.SetShieldImageActive(false);
            homeUI.SetSettingsBtnActive(false);
            homeUI.SetLevelTextHeaderActive(false);

            if (PlayerPrefs.GetInt(firstPackOfferedEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(firstPackOfferedEventName, parameters);
                PlayerPrefs.SetInt(firstPackOfferedEventName, 1);
            }
            homeUI.SetBossTabActive(false);
        }
        else
        {
            SetIsStarterPackMenuShowingActive(false);
            if (GetIsStarterPackExpired() == 0 && GetIsStarterPackPurchased() == 0)
            {
                homeUI.SetStarterPackBtnActive(true);
                if (GetIsStarterPackLastChance())
                {
                    SetStarterPackLastChanceText();
                }
            }
            homeManager.ShowUnlockedShopTabs();
            homeUI.SetCreditsImageActive(true);
            homeUI.SetShieldImageActive(true);
            homeUI.SetSettingsBtnActive(true);
            homeUI.SetLevelTextHeaderActive(true);
        }
    }

    public IEnumerator WaitSetSecondPackOfferMenuActive(float delay, bool isActive)
    {
        yield return new WaitForSeconds(delay);

        SetSecondPackOfferMenuActive(isActive);
    }

    public void SetSecondPackOfferMenuActive(bool isActive)
    {
        //TWEEN ----
        DOTween.Kill("secondPackScale");
        secondPackUI.transform.DOScale(new Vector3(0.018f, 0.018f, 0.018f), 0);
        secondPackUI.transform.DOScale(new Vector3(0.02f, 0.02f, 0.02f), 0.5f).SetEase(Ease.OutBounce).SetId("secondPackScale");


        QualitySettings.shadowDistance = 15;

        if (!GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing())
        {
            secondPackUI.SetActive(isActive);
            secondPackGeometry.SetActive(isActive);
            SetPlayBtnActive(!isActive);
            if (isActive)
            {
                SetIsSecondPackMenuShowingActive(true);
                if (worldTimer.GetIsSubtractingTimerRunning() == false)
                {
                    if (!GetIsSecondPackLastChance())
                    {
                        worldTimer.StartSubtractTimer(GetSecondPackOfferTimeRemaining());
                    }
                    else
                    {
                        SetSecondPackLastChanceText();
                    }
                }
                else
                {
                    SetSecondPackTimeLeftText(worldTimer.GetHoursLeft(), worldTimer.GetMinutesLeft(), worldTimer.GetSecondsLeft());
                }
                homeUI.SetPurchasesDisableAdsImageActive(true);
                homeUI.SetShopTabsActive(false);
                homeUI.SetCreditsImageActive(false);
                homeUI.SetShieldImageActive(false);
                homeUI.SetSettingsBtnActive(false);
                homeUI.SetLevelTextHeaderActive(false);
                homeUI.SetBossTabActive(false);
            }
            else
            {
                SetIsSecondPackMenuShowingActive(false);
                if (GetIsSecondPackExpired() == 0 && GetIsSecondPackPurchased() == 0)
                {
                    homeUI.SetSecondPackBtnActive(true);
                    if (GetIsSecondPackLastChance())
                    {
                        SetSecondPackLastChanceText();
                    }
                }
                homeUI.SetPurchasesDisableAdsImageActive(false);
                homeManager.ShowUnlockedShopTabs();
                homeUI.SetCreditsImageActive(true);
                homeUI.SetShieldImageActive(true);
                homeUI.SetSettingsBtnActive(true);
                homeUI.SetLevelTextHeaderActive(true);
            }
        }
    }

    public IEnumerator WaitSetThirdPackOfferMenuActive(float delay, bool isActive)
    {
        yield return new WaitForSeconds(delay);

        SetThirdPackOfferMenuActive(isActive);
    }

    public void SetThirdPackOfferMenuActive(bool isActive)
    {
        //TWEEN ----
        DOTween.Kill("thirdPackScale");
        thirdPackUI.transform.DOScale(new Vector3(0.018f, 0.018f, 0.018f), 0);
        thirdPackUI.transform.DOScale(new Vector3(0.02f, 0.02f, 0.02f), 0.5f).SetEase(Ease.OutBounce).SetId("thirdPackScale");


        QualitySettings.shadowDistance = 15;

        if (!GetIsStarterPackMenuShowing() && !GetIsStarterPackTabShowing() && !GetIsSecondPackMenuShowing() && !GetIsSecondPackTabShowing())
        {
            thirdPackUI.SetActive(isActive);
            thirdPackGeometry.SetActive(isActive);
            SetPlayBtnActive(!isActive);
            if (isActive)
            {
                SetIsThirdPackMenuShowingActive(true);
                if (worldTimer.GetIsSubtractingTimerRunning() == false)
                {
                    if (!GetIsThirdPackLastChance())
                    {
                        worldTimer.StartSubtractTimer(GetThirdPackOfferTimeRemaining());
                    }
                    else
                    {
                        SetThirdPackLastChanceText();
                    }
                }
                else
                {
                    SetThirdPackTimeLeftText(worldTimer.GetHoursLeft(), worldTimer.GetMinutesLeft(), worldTimer.GetSecondsLeft());
                }
                homeUI.SetPurchasesDisableAdsImageActive(true);
                homeUI.SetShopTabsActive(false);
                homeUI.SetCreditsImageActive(false);
                homeUI.SetShieldImageActive(false);
                homeUI.SetSettingsBtnActive(false);
                homeUI.SetLevelTextHeaderActive(false);
                homeUI.SetBossTabActive(false);
            }
            else
            {
                SetIsThirdPackMenuShowingActive(false);
                if (GetIsThirdPackExpired() == 0 && GetIsThirdPackPurchased() == 0)
                {
                    homeUI.SetThirdPackBtnActive(true);
                    if (GetIsThirdPackLastChance())
                    {
                        SetThirdPackLastChanceText();
                    }
                }
                homeUI.SetPurchasesDisableAdsImageActive(false);
                homeManager.ShowUnlockedShopTabs();
                homeUI.SetCreditsImageActive(true);
                homeUI.SetShieldImageActive(true);
                homeUI.SetSettingsBtnActive(true);
                homeUI.SetLevelTextHeaderActive(true);
            }
        }
    }

    public void SetStarterPackTimeLeftText(int hours, int minutes, int seconds)
    {
        if (GetIsStarterPackMenuShowing())
        {
            starterPackMenuTimeLeftTM.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        } else if (GetIsStarterPackTabShowing())
        {
            homeUI.GetStarterPackTabTimeLeftTM().text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        } else
        {
            Debug.Log("Can't set starter pack time. Neither the menu or the tab is showing!");
        }
    }

    public void SetSecondPackTimeLeftText(int hours, int minutes, int seconds)
    {
        if (GetIsSecondPackMenuShowing())
        {
            secondPackMenuTimeLeftTM.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else if (GetIsSecondPackTabShowing())
        {
            homeUI.GetSecondPackTabTimeLeftTM().text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else
        {
            Debug.Log("Can't set second pack time. Neither the menu or the tab is showing!");
        }
    }

    public void SetThirdPackTimeLeftText(int hours, int minutes, int seconds)
    {
        if (GetIsThirdPackMenuShowing())
        {
            thirdPackMenuTimeLeftTM.text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else if (GetIsThirdPackTabShowing())
        {
            homeUI.GetThirdPackTabTimeLeftTM().text = hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
        else
        {
            Debug.Log("Can't set third pack time. Neither the menu or the tab is showing!");
        }
    }

    public void SetIsStarterPackLastChance(bool isTrue)
    {
        isStarterPackLastChance = isTrue;
    }

    public void SetIsSecondPackLastChance(bool isTrue)
    {
        isSecondPackLastChance = isTrue;
    }

    public void SetIsThirdPackLastChance(bool isTrue)
    {
        isThirdPackLastChance = isTrue;
    }

    public void SetStarterPackLastChanceText()
    {
        SetIsStarterPackLastChance(true);
        if (GetIsStarterPackMenuShowing())
        {
            starterPackMenuTimeLeftTM.text = "LAST CHANCE";
        }
        else if (GetIsStarterPackTabShowing())
        {
            homeUI.GetStarterPackTabTimeLeftTM().text = "LAST CHANCE";
        }
        else
        {
            Debug.Log("Can't set starter pack text. Neither the menu or the tab is showing!");
        }
    }

    public void SetSecondPackLastChanceText()
    {
        SetIsSecondPackLastChance(true);
        if (GetIsSecondPackMenuShowing())
        {
            secondPackMenuTimeLeftTM.text = "LAST CHANCE";
        }
        else if (GetIsSecondPackTabShowing())
        {
            homeUI.GetSecondPackTabTimeLeftTM().text = "LAST CHANCE";
        }
        else
        {
            Debug.Log("Can't set second pack text. Neither the menu or the tab is showing!");
        }
    }

    public void SetThirdPackLastChanceText()
    {
        SetIsThirdPackLastChance(true);
        if (GetIsThirdPackMenuShowing())
        {
            thirdPackMenuTimeLeftTM.text = "LAST CHANCE";
        }
        else if (GetIsThirdPackTabShowing())
        {
            homeUI.GetThirdPackTabTimeLeftTM().text = "LAST CHANCE";
        }
        else
        {
            Debug.Log("Can't set second pack text. Neither the menu or the tab is showing!");
        }
    }

    public bool GetIsStarterPackMenuShowing()
    {
        return isStarterPackMenuShowing;
    }

    public bool GetIsSecondPackMenuShowing()
    {
        return isSecondPackMenuShowing;
    }

    public bool GetIsThirdPackMenuShowing()
    {
        return isThirdPackMenuShowing;
    }

    public void SetIsStarterPackMenuShowingActive(bool _isStarterPackMenuShowing)
    {
        isStarterPackMenuShowing = _isStarterPackMenuShowing;
    }

    public void SetIsSecondPackMenuShowingActive(bool _isSecondPackMenuShowing)
    {
        isSecondPackMenuShowing = _isSecondPackMenuShowing;
    }

    public void SetIsThirdPackMenuShowingActive(bool _isThirdPackMenuShowing)
    {
        isThirdPackMenuShowing = _isThirdPackMenuShowing;
    }

    public bool GetIsStarterPackTabShowing()
    {
        return isStarterPackTabShowing;
    }

    public bool GetIsSecondPackTabShowing()
    {
        return isSecondPackTabShowing;
    }

    public bool GetIsThirdPackTabShowing()
    {
        return isThirdPackTabShowing;
    }

    public bool GetIsStarterPackLastChance()
    {
        return isStarterPackLastChance;
    }

    public bool GetIsSecondPackLastChance()
    {
        return isSecondPackLastChance;
    }

    public bool GetIsThirdPackLastChance()
    {
        return isThirdPackLastChance;
    }

    public void EndStarterPackOffer()
    {
        SetStarterPackExpired();
        SetIsStarterPackLastChance(false);
    }

    public void EndSecondPackOffer()
    {
        SetSecondPackExpired();
        SetIsSecondPackLastChance(false);
    }

    public void EndThirdPackOffer()
    {
        SetThirdPackExpired();
        SetIsThirdPackLastChance(false);
    }

    public void SetStarterPackExpired()
    {
        isStarterPackExpired = 1;
        PlayerPrefs.SetInt(starterPackExpiredPlayerPrefsName, isStarterPackExpired);
    }

    public void SetSecondPackExpired()
    {
        isSecondPackExpired = 1;
        PlayerPrefs.SetInt(secondPackExpiredPlayerPrefsName, isSecondPackExpired);
    }

    public void SetThirdPackExpired()
    {
        isThirdPackExpired = 1;
        PlayerPrefs.SetInt(thirdPackExpiredPlayerPrefsName, isThirdPackExpired);
    }

    public void SetStarterPackOffered()
    {
        isStarterPackOffered = PlayerPrefs.GetInt(starterPackOfferedPlayerPrefsName, 0);
        if (isStarterPackOffered == 0)
        {
            isStarterPackOffered = 1;
            PlayerPrefs.SetInt(starterPackOfferedPlayerPrefsName, isStarterPackOffered);
        }
    }

    public void SetSecondPackOffered()
    {
        isSecondPackOffered = PlayerPrefs.GetInt(secondPackOfferedPlayerPrefsName, 0);
        if (isSecondPackOffered == 0)
        {
            isSecondPackOffered = 1;
            PlayerPrefs.SetInt(secondPackOfferedPlayerPrefsName, isSecondPackOffered);
        }
    }

    public void SetThirdPackOffered()
    {
        isThirdPackOffered = PlayerPrefs.GetInt(thirdPackOfferedPlayerPrefsName, 0);
        if (isThirdPackOffered == 0)
        {
            isThirdPackOffered = 1;
            PlayerPrefs.SetInt(thirdPackOfferedPlayerPrefsName, isThirdPackOffered);
        }
    }

    public void SetIsStarterPackTabActive(bool _isStarterPackTabShowing)
    {
        isStarterPackTabShowing = _isStarterPackTabShowing;
    }

    public void SetIsSecondPackTabActive(bool _isSecondPackTabShowing)
    {
        isSecondPackTabShowing = _isSecondPackTabShowing;
    }

    public void SetIsThirdPackTabActive(bool _isThirdPackTabShowing)
    {
        isThirdPackTabShowing = _isThirdPackTabShowing;
    }

    public void SaveStarterPackTimeRemaining(int timeLeft)
    {
        starterPackOfferTime = timeLeft;
        PlayerPrefs.SetInt(starterPackTimeLeftPrefsName, starterPackOfferTime);
    }

    public void SaveSecondPackTimeRemaining(int timeLeft)
    {
        secondPackOfferTime = timeLeft;
        PlayerPrefs.SetInt(secondPackTimeLeftPrefsName, secondPackOfferTime);
    }

    public void SaveThirdPackTimeRemaining(int timeLeft)
    {
        thirdPackOfferTime = timeLeft;
        PlayerPrefs.SetInt(thirdPackTimeLeftPrefsName, thirdPackOfferTime);
    }

    public int GetIsStarterPackOffered()
    {
        isStarterPackOffered = PlayerPrefs.GetInt(starterPackOfferedPlayerPrefsName, 0);
        return isStarterPackOffered;
    }

    public int GetIsSecondPackOffered()
    {
        isSecondPackOffered = PlayerPrefs.GetInt(secondPackOfferedPlayerPrefsName, 0);
        return isSecondPackOffered;
    }

    public int GetIsThirdPackOffered()
    {
        isThirdPackOffered = PlayerPrefs.GetInt(thirdPackOfferedPlayerPrefsName, 0);
        return isThirdPackOffered;
    }

    public int GetIsStarterPackExpired()
    {
        isStarterPackExpired = PlayerPrefs.GetInt(starterPackExpiredPlayerPrefsName, 0);
        return isStarterPackExpired;
    }

    public int GetIsSecondPackExpired()
    {
        isSecondPackExpired = PlayerPrefs.GetInt(secondPackExpiredPlayerPrefsName, 0);
        return isSecondPackExpired;
    }

    public int GetIsThirdPackExpired()
    {
        isThirdPackExpired = PlayerPrefs.GetInt(thirdPackExpiredPlayerPrefsName, 0);
        return isThirdPackExpired;
    }

    public int GetStarterPackOfferTimeRemaining()
    {
        starterPackOfferTime = PlayerPrefs.GetInt(starterPackTimeLeftPrefsName, starterPackOfferTime);
        return starterPackOfferTime;
    }

    public int GetSecondPackOfferTimeRemaining()
    {
        secondPackOfferTime = PlayerPrefs.GetInt(secondPackTimeLeftPrefsName, secondPackOfferTime);
        return secondPackOfferTime;
    }

    public int GetThirdPackOfferTimeRemaining()
    {
        thirdPackOfferTime = PlayerPrefs.GetInt(thirdPackTimeLeftPrefsName, thirdPackOfferTime);
        return thirdPackOfferTime;
    }

    public int GetIsStarterPackPurchased()
    {
        isStarterPackPurchased = PlayerPrefs.GetInt(starterPackPurchasedPlayerPrefsName, 0);
        return isStarterPackPurchased;
    }

    public int GetIsSecondPackPurchased()
    {
        isSecondPackPurchased = PlayerPrefs.GetInt(secondPackPurchasedPlayerPrefsName, 0);
        return isSecondPackPurchased;
    }

    public int GetIsThirdPackPurchased()
    {
        isThirdPackPurchased = PlayerPrefs.GetInt(thirdPackPurchasedPlayerPrefsName, 0);
        return isThirdPackPurchased;
    }

    private void SaveStarterPackPurchased()
    {
        isStarterPackPurchased = 1;
        PlayerPrefs.SetInt(starterPackPurchasedPlayerPrefsName, isStarterPackPurchased);
    }

    private void SaveSecondPackPurchased()
    {
        isSecondPackPurchased = 1;
        PlayerPrefs.SetInt(secondPackPurchasedPlayerPrefsName, isSecondPackPurchased);
    }

    private void SaveThirdPackPurchased()
    {
        isThirdPackPurchased = 1;
        PlayerPrefs.SetInt(thirdPackPurchasedPlayerPrefsName, isThirdPackPurchased);
    }

    public void ExitStarterPackMenu()
    {
        QualitySettings.shadowDistance = 25;

        SetStarterPackOfferMenuActive(false);
        if (itemManager.GetIsAssaultPurchased() == 1 || rankManager.GetIsSkinShopUnlocked() == 1)
        {
            homeUI.SetShopTabsActive(true);
            if (rankManager.GetIsSkinShopUnlocked() == 1 || GetIsStarterPackPurchased() == 1)
            {
                homeUI.SetSkinsShopImageActive(true);
                homeUI.SetSkinsShoplockedImageActive(false);
            }
            if (itemManager.GetIsAssaultPurchased() == 1 || GetIsStarterPackPurchased() == 1)
            {
                homeUI.SetBankShopImageActive(true);
                homeUI.SetBankShoplockedImageActive(false);
                homeUI.SetWeaponShopImageActive(true);
                homeUI.SetWeaponShoplockedImageActive(false);
            }
        }

        if (PlayerPrefs.GetInt(firstPackAdvancedEventName, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "packStatus", "Exited" },
            };
            AnalyticsService.Instance.CustomData(firstPackAdvancedEventName, parameters);
            PlayerPrefs.SetInt(firstPackAdvancedEventName, 1);
        }
        //iAPManager.HideAllLoadingPopUps();
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitSecondPackMenu()
    {
        QualitySettings.shadowDistance = 25;

        SetSecondPackOfferMenuActive(false);
        if (itemManager.GetIsAssaultPurchased() == 1 || rankManager.GetIsSkinShopUnlocked() == 1)
        {
            homeUI.SetShopTabsActive(true);
            if (rankManager.GetIsSkinShopUnlocked() == 1 || GetIsStarterPackPurchased() == 1 || GetIsSecondPackPurchased() == 1)
            {
                homeUI.SetSkinsShopImageActive(true);
                homeUI.SetSkinsShoplockedImageActive(false);
            }
            if (itemManager.GetIsAssaultPurchased() == 1 || GetIsStarterPackPurchased() == 1 || GetIsSecondPackPurchased() == 1)
            {
                homeUI.SetBankShopImageActive(true);
                homeUI.SetBankShoplockedImageActive(false);
                homeUI.SetWeaponShopImageActive(true);
                homeUI.SetWeaponShoplockedImageActive(false);
            }
        }
        if (levelReached == 15 || levelReached == 25)
        {
            if (!homeUI.GetHasShownBossBattleMenu())
            {
                homeUI.ShowBossBattleMenu();
                homeUI.SetHasShownBossBattleMenu(true);
            }
        }
        //iAPManager.HideAllLoadingPopUps();
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ExitThirdPackMenu()
    {
        QualitySettings.shadowDistance = 25;

        SetThirdPackOfferMenuActive(false);
        if (itemManager.GetIsAssaultPurchased() == 1 || rankManager.GetIsSkinShopUnlocked() == 1)
        {
            homeUI.SetShopTabsActive(true);
            if (rankManager.GetIsSkinShopUnlocked() == 1 || GetIsStarterPackPurchased() == 1 || GetIsSecondPackPurchased() == 1)
            {
                homeUI.SetSkinsShopImageActive(true);
                homeUI.SetSkinsShoplockedImageActive(false);
            }
            if (itemManager.GetIsAssaultPurchased() == 1 || GetIsStarterPackPurchased() == 1 || GetIsSecondPackPurchased() == 1)
            {
                homeUI.SetBankShopImageActive(true);
                homeUI.SetBankShoplockedImageActive(false);
                homeUI.SetWeaponShopImageActive(true);
                homeUI.SetWeaponShoplockedImageActive(false);
            }
        }
        if (levelReached == 15 || levelReached == 25)
        {
            if (!homeUI.GetHasShownBossBattleMenu())
            {
                homeUI.ShowBossBattleMenu();
                homeUI.SetHasShownBossBattleMenu(true);
            }
        }
        //iAPManager.HideAllLoadingPopUps();
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SetHasCheckedForOnPlayPackOffer(bool hasChecked)
    {
        hasCheckedForOnPlayPackOffer = hasChecked;
    }

    public bool GetHasCheckedForOnPlayPackOffer()
    {
        return hasCheckedForOnPlayPackOffer;
    }

    public void SetIsOnPlayPackOfferAvailable(bool isAvailable)
    {
        isOnPlayPackOfferAvailable = isAvailable;
    }

    public bool GetIsOnPlayPackOfferAvailable()
    {
        return isOnPlayPackOfferAvailable;
    }

    public void SetPlayBtnActive(bool isActive)
    {
        playBtn.gameObject.SetActive(isActive);
    }

    private void SetIsPackOfferLevel(bool _isPackOfferLevel)
    {
        isPackOfferLevel = _isPackOfferLevel;
    }

    public bool GetIsPackOfferLevel()
    {
        return isPackOfferLevel;
    }
}
