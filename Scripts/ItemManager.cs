using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [Header("Guns")]
    [SerializeField] private ActiveWeapon activeWeapon;
    [SerializeField] private RaycastWeapon pfPistol;
    [SerializeField] private RaycastWeapon pfShotgun;
    [SerializeField] private RaycastWeapon pfShotgun_02;
    [SerializeField] private RaycastWeapon pfAssault;
    [SerializeField] private RaycastWeapon pfAssault_02;
    [SerializeField] private RaycastWeapon pfAssault_03;
    [SerializeField] private RaycastWeapon pfSMG;
    [SerializeField] private RaycastWeapon pfSMG_02;
    [SerializeField] private RaycastWeapon pfSMG_03;
    [SerializeField] private RaycastWeapon pfRifle_01;
    [SerializeField] private RaycastWeapon pfRifle_02;
    [SerializeField] private RaycastWeapon pfMachineGun_01;
    [SerializeField] private RaycastWeapon pfMachineGun_02;
    [SerializeField] private RaycastWeapon pfRocketLauncher;

    private int isShotgunPurchased;
    private int isShotgun_02Purchased;
    private int isAssaultPurchased;
    private int isAssault_02Purchased;
    private int isAssault_03Purchased;
    private int isSMGPurchased;
    private int isSMG_02Purchased;
    private int isSMG_03Purchased;
    private int isRifle_01Purchased;
    private int isRifle_02Purchased;
    private int isMachineGun_01Purchased;
    private int isMachineGun_02Purchased;
    private int isRocketLauncherPurchased;

    private int isPistolEquipped;
    private int isShotgunEquipped;
    private int isShotgun_02Equipped;
    private int isAssaultEquipped;
    private int isAssault_02Equipped;
    private int isAssault_03Equipped;
    private int isSMGEquipped;
    private int isSMG_02Equipped;
    private int isSMG_03Equipped;
    private int isRifle_01Equipped;
    private int isRifle_02Equipped;
    private int isMachineGun_01Equipped;
    private int isMachineGun_02Equipped;
    private int isRocketLauncherEquipped;
    private int isTrialWeaponEquipped;
    private int isTrialShotgun_02Equipped;
    private int isTrialSMG_03Equipped;
    private int isTrialRifle_02Equipped;
    private int isTrialMachineGun_02Equipped;
    private int isTrialRocketLauncherEquipped;

    private string shotgunPurchasedPlayerPrefsName = "shotgunPurchased";
    private string shotgun_02PurchasedPlayerPrefsName = "shotgun_02Purchased";
    private string assaultPurchasedPlayerPrefsName = "assaultPurchased";
    private string assault_02PurchasedPlayerPrefsName = "assault_02Purchased";
    private string assault_03PurchasedPlayerPrefsName = "assault_03Purchased";
    private string smgPurchasedPlayerPrefsName = "smgPurchased";
    private string smg_02PurchasedPlayerPrefsName = "smg_02Purchased";
    private string smg_03PurchasedPlayerPrefsName = "smg_03Purchased";
    private string rifle_01PurchasedPlayerPrefsName = "rifle_01Purchased";
    private string rifle_02PurchasedPlayerPrefsName = "rifle_02Purchased";
    private string machineGun_01PurchasedPlayerPrefsName = "machineGun_01Purchased";
    private string machineGun_02PurchasedPlayerPrefsName = "machineGun_02Purchased";
    private string rocketLauncherPurchasedPlayerPrefsName = "rocketLauncherPurchased";
    private string pistolEquippedPlayerPrefsName = "pistolEquipped";
    private string shotgunEquippedPlayerPrefsName = "shotgunEquipped";
    private string shotgun_02EquippedPlayerPrefsName = "shotgun_02Equipped";
    private string assaultEquippedPlayerPrefsName = "assaultEquipped";
    private string assault_02EquippedPlayerPrefsName = "assault_02Equipped";
    private string assault_03EquippedPlayerPrefsName = "assault_03Equipped";
    private string smgEquippedPlayerPrefsName = "smgEquipped";
    private string smg_02EquippedPlayerPrefsName = "smg_02Equipped";
    private string smg_03EquippedPlayerPrefsName = "smg_03Equipped";
    private string rifle_01EquippedPlayerPrefsName = "rifle_01Equipped";
    private string rifle_02EquippedPlayerPrefsName = "rifle_02Equipped";
    private string machineGun_01EquippedPlayerPrefsName = "machineGun_01Equipped";
    private string machineGun_02EquippedPlayerPrefsName = "machineGun_02Equipped";
    private string rocketLauncherEquippedPlayerPrefsName = "rocketLauncherEquipped";
    private string trialWeaponEquippedPlayerPrefsName = "trialWeaponEquipped";
    private string trialShotgun_02EquippedPlayerPrefsName = "trialShotgun_02Equipped";
    private string trialSMG_03EquippedPlayerPrefsName = "trialSMG_03Equipped";
    private string trialRifle_02EquippedPlayerPrefsName = "trialRifle_02Equipped";
    private string trialMachineGun_02EquippedPlayerPrefsName = "trialMachine_02GunEquipped";
    private string trialRocketLauncherEquippedPlayerPrefsName = "trialRocketLauncherEquipped";

    [Header("Skins")]
    [SerializeField] private Mesh pfDefaultSkin;
    [SerializeField] private Mesh pfSoldierSkin;
    [SerializeField] private Mesh pfMale_01Skin;
    [SerializeField] private Mesh pfHazmatSkin;
    [SerializeField] private Mesh pfHomelessSkin;
    [SerializeField] private Mesh pfBikerSkin;
    [SerializeField] private Mesh pfRiotCopSkin;
    [SerializeField] private Mesh pfFemale_01Skin;
    [SerializeField] private Material defaultSkinMaterial;
    [SerializeField] private Material alternateSkinMaterial_01;

    private int isSoldierSkinPurchased;
    private int isMale_01SkinPurchased;
    private int isHazmatSkinPurchased;
    private int isHomelessSkinPurchased;
    private int isBikerSkinPurchased;
    private int isRiotCopSkinPurchased;
    private int isFemale_01SkinPurchased;

    private int isDefaultSkinEquipped;
    private int isSoldierSkinEquipped;
    private int isMale_01SkinEquipped;
    private int isHazmatSkinEquipped;
    private int isHomelessSkinEquipped;
    private int isBikerSkinEquipped;
    private int isRiotCopSkinEquipped;
    private int isFemale_01SkinEquipped;

    private SkinnedMeshRenderer skinToChange;
    private string soldierSkinPurchasedPlayerPrefsName = "soldierSkinPurchased";
    private string male_01SkinPurchasedPlayerPrefsName = "male_01SkinPurchased";
    private string hazmatSkinPurchasedPlayerPrefsName = "hazmatSkinPurchased";
    private string homelessSkinPurchasedPlayerPrefsName = "homelessSkinPurchased";
    private string bikerSkinPurchasedPlayerPrefsName = "bikerSkinPurchased";
    private string riotCopSkinPurchasedPlayerPrefsName = "riotCopSkinPurchased";
    private string female_01SkinPurchasedPlayerPrefsName = "female_01CopSkinPurchased";
    private string defaultSkinEquippedPlayerPrefsName = "defaultSkinEquipped";
    private string soldierSkinEquippedPlayerPrefsName = "soldierSkinEquipped";
    private string male_01SkinEquippedPlayerPrefsName = "male_01SkinEquipped";
    private string hazmatSkinEquippedPlayerPrefsName = "hazmatSkinEquipped";
    private string homelessSkinEquippedPlayerPrefsName = "homelessSkinEquipped";
    private string bikerSkinEquippedPlayerPrefsName = "bikerSkinEquipped";
    private string riotCopSkinEquippedPlayerPrefsName = "riotCopSkinEquipped";
    private string female_01SkinEquippedPlayerPrefsName = "female_01SkinEquipped";

    [Header("Player Skin Accessories")]
    [SerializeField] private GameObject pfDefault_Backpack;
    [SerializeField] private GameObject pfDefault_Hat;
    [SerializeField] private GameObject pfSoldier_ShoulderPad;
    [SerializeField] private GameObject pfSoldier_Glasses;
    [SerializeField] private GameObject pfSoldier_Helmet;
    [SerializeField] private GameObject pfSoldier_ThighPad;
    [SerializeField] private GameObject pfSoldier_Mags;
    [SerializeField] private GameObject pfMale_01_Pouch;
    [SerializeField] private GameObject pfMale_01_Mags;
    [SerializeField] private GameObject pfMale_01_Hair;
    [SerializeField] private GameObject pfHomeless_Backpack;
    [SerializeField] private GameObject pfHomeless_Pouch;
    [SerializeField] private GameObject pfBiker_Knife;
    [SerializeField] private GameObject pfBiker_Beard;
    [SerializeField] private GameObject pfBiker_Hair;
    [SerializeField] private GameObject pfRiotCop_Beard;
    [SerializeField] private GameObject pfRiotCop_Hair;
    [SerializeField] private GameObject pfRiotCop_Helmet;
    [SerializeField] private GameObject pfRiotCop_ShoulderPad_R;
    [SerializeField] private GameObject pfRiotCop_ShoulderPad_L;
    [SerializeField] private GameObject pfRiotCop_Radio;
    [SerializeField] private GameObject pfRiotCop_KneePad_R;
    [SerializeField] private GameObject pfRiotCop_KneePad_L;
    [SerializeField] private GameObject pfFemale_01_Mags;
    [SerializeField] private GameObject pfFemale_01_Backpack;
    [SerializeField] private GameObject pfFemale_01_ShoulderPad;
    [SerializeField] private GameObject pfFemale_01_Hair;

    private GameObject callerToChange;
    private Transform headTransform;
    private Transform clavicle_RTransform;
    private Transform clavicle_LTransform;
    private Transform spine_03Transform;
    private Transform upperLeg_LTransform;
    private Transform upperLeg_RTransform;
    private Transform lowerLeg_LTransform;
    private Transform lowerLeg_RTransform;
    private Transform hipsTransform;
    private string pathToHead = "Root/Hips/Spine_01/Spine_02/Spine_03/Neck/Head";
    private string pathToClavicle_R = "Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_R";
    private string pathToClavicle_L = "Root/Hips/Spine_01/Spine_02/Spine_03/Clavicle_L";
    private string pathToSpine_03 = "Root/Hips/Spine_01/Spine_02/Spine_03";
    private string pathToUpperLeg_L = "Root/Hips/UpperLeg_L";
    private string pathToUpperLeg_R = "Root/Hips/UpperLeg_R";
    private string pathToLowerLeg_L = "Root/Hips/UpperLeg_L/LowerLeg_L";
    private string pathToLowerLeg_R = "Root/Hips/UpperLeg_R/LowerLeg_R";
    private string pathToHips = "Root/Hips";
    private List<GameObject> skinAccessories = new List<GameObject>();

    [Header("Helicopter Skins")]
    [SerializeField] private Material pfDefaultHelicopterSkin;
    [SerializeField] private Material pfHelicopter_02Skin;
    [SerializeField] private Material pfHelicopter_03Skin;
    [SerializeField] private Material pfHelicopter_04Skin;

    private int isHelicopter_02SkinPurchased;
    private int isHelicopter_03SkinPurchased;
    private int isHelicopter_04SkinPurchased;

    private int isDefaultHelicopterSkinEquipped;
    private int isHelicopter_02SkinEquipped;
    private int isHelicopter_03SkinEquipped;
    private int isHelicopter_04SkinEquipped;

    private MeshRenderer[] helicopterSkinsToChange;
    private string helicopter_02SkinPurchasedPlayerPrefsName = "helicopter_02SkinPurchased";
    private string helicopter_03SkinPurchasedPlayerPrefsName = "helicopter_03SkinPurchased";
    private string helicopter_04SkinPurchasedPlayerPrefsName = "helicopter_04SkinPurchased";
    private string defaultHelicopterSkinEquippedPlayerPrefsName = "defaultHelicopterSkinEquipped";
    private string helicopter_02SkinEquippedPlayerPrefsName = "helicopter_02SkinEquipped";
    private string helicopter_03SkinEquippedPlayerPrefsName = "helicopter_03SkinEquipped";
    private string helicopter_04SkinEquippedPlayerPrefsName = "helicopter_04SkinEquipped";
    private string playerHelicopterTag = "PlayerHelicopter";
    private string npcHelicopterTag = "NPCHelicopter";
    private string homeHelicopterTag = "HomeHelicopter";
    private string helicopterTag = "Helicopter";
    private string glassTag = "Glass";

    private GameObject helicopterCallerToChange;

    private bool isPlayerCalling;
    private bool isLevelNPCCalling;
    private bool isHomeNPCCalling;

    public void PurchaseItem(Item.ItemType itemType)
    {
        Debug.Log("Bought item: " + itemType);
        switch (itemType)
        {
            case Item.ItemType.Shotgun:
                Debug.Log("Shotgun Purchased!");
                PurchaseShotgun();
                break;
            case Item.ItemType.Shotgun_02:
                Debug.Log("Shotgun_02 Purchased!");
                PurchaseShotgun_02();
                break;
            case Item.ItemType.Assault:
                Debug.Log("Assault Purchased!");
                PurchaseAssault();
                break;
            case Item.ItemType.Assault_02:
                Debug.Log("Assault_02 Purchased!");
                PurchaseAssault_02();
                break;
            case Item.ItemType.Assault_03:
                Debug.Log("Assault_03 Purchased!");
                PurchaseAssault_03();
                break;
            case Item.ItemType.SMG:
                Debug.Log("SMG Purchased!");
                PurchaseSMG();
                break;
            case Item.ItemType.SMG_02:
                Debug.Log("SMG_02 Purchased!");
                PurchaseSMG_02();
                break;
            case Item.ItemType.SMG_03:
                Debug.Log("SMG_03 Purchased!");
                PurchaseSMG_03();
                break;
            case Item.ItemType.Rifle_01:
                Debug.Log("Rifle_01 Purchased!");
                PurchaseRifle_01();
                break;
            case Item.ItemType.Rifle_02:
                Debug.Log("Rifle_02 Purchased!");
                PurchaseRifle_02();
                break;
            case Item.ItemType.MachineGun_01:
                Debug.Log("MachineGun_01 Purchased!");
                PurchaseMachineGun_01();
                break;
            case Item.ItemType.MachineGun_02:
                Debug.Log("MachineGun_02 Purchased!");
                PurchaseMachineGun_02();
                break;
            case Item.ItemType.RocketLauncher:
                Debug.Log("RocketLauncher Purchased!");
                PurchaseRocketLauncher();
                break;
            case Item.ItemType.SoldierSkin:
                Debug.Log("Soldier Skin Purchased!");
                PurchaseSoldierSkin();
                break;
            case Item.ItemType.Male_01Skin:
                Debug.Log("Male_01 Skin Purchased!");
                PurchaseMale_01Skin();
                break;
            case Item.ItemType.HazmatSkin:
                Debug.Log("Hazmat Skin Purchased!");
                PurchaseHazmatSkin();
                break;
            case Item.ItemType.HomelessSkin:
                Debug.Log("Homeless Skin Purchased!");
                PurchaseHomelessSkin();
                break;
            case Item.ItemType.BikerSkin:
                Debug.Log("Biker Skin Purchased!");
                PurchaseBikerSkin();
                break;
            case Item.ItemType.RiotCopSkin:
                Debug.Log("Riot Cop Skin Purchased!");
                PurchaseRiotCopSkin();
                break;
            case Item.ItemType.Female_01Skin:
                Debug.Log("Female_01 Skin Purchased!");
                PurchaseFemale_01Skin();
                break;
            case Item.ItemType.Helicopter_02Skin:
                Debug.Log("Helicopter_02 Skin Purchased!");
                PurchaseHelicopter_02Skin();
                break;
            case Item.ItemType.Helicopter_03Skin:
                Debug.Log("Helicopter_03 Skin Purchased!");
                PurchaseHelicopter_03Skin();
                break;
            case Item.ItemType.Helicopter_04Skin:
                Debug.Log("Helicopter_04 Skin Purchased!");
                PurchaseHelicopter_04Skin();
                break;
            default:
                Debug.Log("That item doesn't exist...");
                break;
        }
    }

    public void EquipItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Pistol:
                EquipPistol();
                Debug.Log("Pistol Equipped!");
                break;
            case Item.ItemType.Shotgun:
                EquipShotgun();
                Debug.Log("Shotgun Equipped!");
                break;
            case Item.ItemType.Shotgun_02:
                EquipShotgun_02();
                Debug.Log("Shotgun_02 Equipped!");
                break;
            case Item.ItemType.Assault:
                EquipAssault();
                Debug.Log("Assault Equipped!");
                break;
            case Item.ItemType.Assault_02:
                EquipAssault_02();
                Debug.Log("Assault_02 Equipped!");
                break;
            case Item.ItemType.Assault_03:
                EquipAssault_03();
                Debug.Log("Assault_03 Equipped!");
                break;
            case Item.ItemType.SMG:
                EquipSMG();
                Debug.Log("SMG Equipped!");
                break;
            case Item.ItemType.SMG_02:
                EquipSMG_02();
                Debug.Log("SMG_02 Equipped!");
                break;
            case Item.ItemType.SMG_03:
                EquipSMG_03();
                Debug.Log("SMG_03 Equipped!");
                break;
            case Item.ItemType.Rifle_01:
                EquipRifle_01();
                Debug.Log("Rifle_01 Equipped!");
                break;
            case Item.ItemType.Rifle_02:
                EquipRifle_02();
                Debug.Log("Rifle_02 Equipped!");
                break;
            case Item.ItemType.MachineGun_01:
                EquipMachineGun_01();
                Debug.Log("MachineGun_01 Equipped!");
                break;
            case Item.ItemType.MachineGun_02:
                EquipMachineGun_02();
                Debug.Log("MachineGun_02 Equipped!");
                break;
            case Item.ItemType.RocketLauncher:
                EquipRocketLauncher();
                Debug.Log("Rocket Launcher Equipped!");
                break;
            case Item.ItemType.TrialWeapon:
                EquipTrialWeapon();
                Debug.Log("Trial Weapon Equipped!");
                break;
            case Item.ItemType.TrialShotgun_02:
                EquipTrial_02Shotgun();
                Debug.Log("Trial Shotgun_02 Equipped!");
                break;
            case Item.ItemType.TrialSMG_03:
                EquipTrialSMG_03();
                Debug.Log("Trial SMG_03 Equipped!");
                break;
            case Item.ItemType.TrialRifle_02:
                EquipTrialRifle_02();
                Debug.Log("Trial Rifle_02 Equipped!");
                break;
            case Item.ItemType.TrialMachineGun_02:
                EquipTrialMachineGun_02();
                Debug.Log("Trial MachineGun_02 Equipped!");
                break;
            case Item.ItemType.TrialRocketLauncher:
                EquipTrialRocketLauncher();
                Debug.Log("Trial Rocket Launcher Equipped!");
                break;
            case Item.ItemType.DefaultSkin:
                EquipDefaultSkin();
                Debug.Log("Default Skin Equipped!");
                break;
            case Item.ItemType.SoldierSkin:
                EquipSoldierSkin();
                Debug.Log("Soldier Skin Equipped!");
                break;
            case Item.ItemType.Male_01Skin:
                EquipMale_01Skin();
                Debug.Log("Male_01 Skin Equipped!");
                break;
            case Item.ItemType.HazmatSkin:
                EquipHazmatSkin();
                Debug.Log("Hazmat Skin Equipped!");
                break;
            case Item.ItemType.HomelessSkin:
                EquipHomelessSkin();
                Debug.Log("Homeless Skin Equipped!");
                break;
            case Item.ItemType.BikerSkin:
                EquipBikerSkin();
                Debug.Log("Biker Skin Equipped!");
                break;
            case Item.ItemType.RiotCopSkin:
                EquipRiotCopSkin();
                Debug.Log("Riot Cop Skin Equipped!");
                break;
            case Item.ItemType.Female_01Skin:
                EquipFemale_01Skin();
                Debug.Log("Female_01 Skin Equipped!");
                break;
            case Item.ItemType.DefaultHelicopterSkin:
                EquipDefaultHelicopterSkin();
                Debug.Log("Default Helicopter Skin Equipped!");
                break;
            case Item.ItemType.Helicopter_02Skin:
                EquipHelicopter_02Skin();
                Debug.Log("Helicopter_02 Skin Equipped!");
                break;
            case Item.ItemType.Helicopter_03Skin:
                EquipHelicopter_03Skin();
                Debug.Log("Helicopter_03 Skin Equipped!");
                break;
            case Item.ItemType.Helicopter_04Skin:
                EquipHelicopter_04Skin();
                Debug.Log("Helicopter_04 Skin Equipped!");
                break;
            default:
                Debug.Log("That item doesn't exist...");
                break;
        }
    }

    public void UnequipItem(Item.ItemType itemType)
    {
        switch (itemType)
        {
            case Item.ItemType.Pistol:
                UnequipPistol();
                Debug.Log("Pistol Unequipped!");
                break;
            case Item.ItemType.Shotgun:
                UnequipShotgun();
                Debug.Log("Shotgun Unequipped!");
                break;
            case Item.ItemType.Shotgun_02:
                UnequipShotgun_02();
                Debug.Log("Shotgun_02 Unequipped!");
                break;
            case Item.ItemType.Assault:
                UnequipAssault();
                Debug.Log("Assault Unequipped!");
                break;
            case Item.ItemType.Assault_02:
                UnequipAssault_02();
                Debug.Log("Assault_02 Unequipped!");
                break;
            case Item.ItemType.Assault_03:
                UnequipAssault_03();
                Debug.Log("Assault_03 Unequipped!");
                break;
            case Item.ItemType.SMG:
                UnequipSMG();
                Debug.Log("SMG Unequipped!");
                break;
            case Item.ItemType.SMG_03:
                UnequipSMG_03();
                Debug.Log("SMG_03 Unequipped!");
                break;
            case Item.ItemType.Rifle_01:
                UnequipRifle_01();
                Debug.Log("Rifle_01 Unequipped!");
                break;
            case Item.ItemType.Rifle_02:
                UnequipRifle_02();
                Debug.Log("Rifle_02 Unequipped!");
                break;
            case Item.ItemType.MachineGun_01:
                UnequipMachineGun_01();
                Debug.Log("MachineGun_01 Unequipped!");
                break;
            case Item.ItemType.MachineGun_02:
                UnequipMachineGun_02();
                Debug.Log("MachineGun_02 Unequipped!");
                break;
            case Item.ItemType.RocketLauncher:
                UnequipRocketLauncher();
                Debug.Log("Rocket Launcher Unequipped!");
                break;
            case Item.ItemType.TrialWeapons:
                UnequipTrialWeapons();
                //Debug.Log("All Trial Weapons Unequipped!");
                break;
            case Item.ItemType.DefaultSkin:
                UnequipDefaultSkin();
                Debug.Log("Default Skin Unequipped!");
                break;
            case Item.ItemType.SoldierSkin:
                UnequipSoldierSkin();
                Debug.Log("Soldier Skin Unequipped!");
                break;
            case Item.ItemType.Male_01Skin:
                UnequipMale_01Skin();
                Debug.Log("Male_01 Skin Unequipped!");
                break;
            case Item.ItemType.HazmatSkin:
                UnequipHazmatSkin();
                Debug.Log("Hazmat Skin Unequipped!");
                break;
            case Item.ItemType.HomelessSkin:
                UnequipHomelessSkin();
                Debug.Log("Homeless Skin Unequipped!");
                break;
            case Item.ItemType.BikerSkin:
                UnequipBikerSkin();
                Debug.Log("Biker Skin Unequipped!");
                break;
            case Item.ItemType.RiotCopSkin:
                UnequipRiotCopSkin();
                Debug.Log("Riot Cop Skin Unequipped!");
                break;
            case Item.ItemType.Female_01Skin:
                UnequipFemale_01Skin();
                Debug.Log("Female_01 Skin Unequipped!");
                break;
            case Item.ItemType.DefaultHelicopterSkin:
                UnequipDefaultHelicopterSkin();
                Debug.Log("Default Helicopter Skin Unequipped!");
                break;
            case Item.ItemType.Helicopter_02Skin:
                UnequipHelicopter_02Skin();
                Debug.Log("Helicopter_02 Skin Unequipped!");
                break;
            case Item.ItemType.Helicopter_03Skin:
                UnequipHelicopter_03Skin();
                Debug.Log("Helicopter_03 Skin Unequipped!");
                break;
            case Item.ItemType.Helicopter_04Skin:
                UnequipHelicopter_04Skin();
                Debug.Log("Helicopter_04 Skin Unequipped!");
                break;
            default:
                Debug.Log("That item doesn't exist...");
                break;
        }
    }

    public void EquipItems()
    {
        if (GetIsTrialWeaponEquipped() == 0)
        {
            if (GetIsPistolEquipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfPistol);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsShotgunEquipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfShotgun);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsShotgun_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfShotgun_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsAssaultEquipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfAssault);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsAssault_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfAssault_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsAssault_03Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfAssault_03);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsSMGEquipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfSMG);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsSMG_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfSMG_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsSMG_03Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfSMG_03);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsRifle_01Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfRifle_01);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsRifle_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfRifle_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsMachineGun_01Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfMachineGun_01);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsMachineGun_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfMachineGun_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsRocketLauncherEquipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfRocketLauncher);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsPistolEquipped() == 0 && GetIsShotgunEquipped() == 0 && GetIsShotgun_02Equipped() == 0 && GetIsAssaultEquipped() == 0 && GetIsAssault_02Equipped() == 0
                && GetIsAssault_03Equipped() == 0 && GetIsSMGEquipped() == 0 && GetIsSMG_02Equipped() == 0 && GetIsSMG_03Equipped() == 0 && GetIsRifle_01Equipped() == 0
                && GetIsRifle_02Equipped() == 0 && GetIsMachineGun_01Equipped() == 0 && GetIsMachineGun_02Equipped() == 0 && GetIsRocketLauncherEquipped() == 0)
            {
                Debug.Log("No weapon equipped. Equipping pistol by default...");
                RaycastWeapon newWeapon = Instantiate(pfPistol);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }
        }
        else
        {
            if (GetIsTrialShotgun_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfShotgun_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsTrialSMG_03Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfSMG_03);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsTrialRifle_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfRifle_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsTrialMachineGun_02Equipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfMachineGun_02);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }

            if (GetIsTrialRocketLauncherEquipped() == 1)
            {
                RaycastWeapon newWeapon = Instantiate(pfRocketLauncher);
                SetUniqueCallerWeaponEquipFunctionality(newWeapon);
            }
        }


        //////// TEMP BUILD
        // RaycastWeapon newWeapon = Instantiate(pfMachineGun_02);
        // SetUniqueCallerWeaponEquipFunctionality(newWeapon);



        SetUniqueCallerSkinEquipFunctionality();
        SetUniqueCallerHelicopterSkinEquipFunctionality();
    }

    ///////////////////////////////////////////////////////////// Purchase Weapons /////////////////////////////////////////////////////////////
    private void PurchaseShotgun()
    {
        isShotgunPurchased = 1;
        PlayerPrefs.SetInt(shotgunPurchasedPlayerPrefsName, isShotgunPurchased);
    }

    private void PurchaseShotgun_02()
    {
        isShotgun_02Purchased = 1;
        PlayerPrefs.SetInt(shotgun_02PurchasedPlayerPrefsName, isShotgun_02Purchased);
    }

    private void PurchaseAssault()
    {
        isAssaultPurchased = 1;
        PlayerPrefs.SetInt(assaultPurchasedPlayerPrefsName, isAssaultPurchased);
    }

    private void PurchaseAssault_02()
    {
        isAssault_02Purchased = 1;
        PlayerPrefs.SetInt(assault_02PurchasedPlayerPrefsName, isAssault_02Purchased);
    }

    private void PurchaseAssault_03()
    {
        isAssault_03Purchased = 1;
        PlayerPrefs.SetInt(assault_03PurchasedPlayerPrefsName, isAssault_03Purchased);
    }

    private void PurchaseSMG()
    {
        isSMGPurchased = 1;
        PlayerPrefs.SetInt(smgPurchasedPlayerPrefsName, isSMGPurchased);
    }

    private void PurchaseSMG_02()
    {
        isSMG_02Purchased = 1;
        PlayerPrefs.SetInt(smg_02PurchasedPlayerPrefsName, isSMG_02Purchased);
    }

    private void PurchaseSMG_03()
    {
        isSMG_03Purchased = 1;
        PlayerPrefs.SetInt(smg_03PurchasedPlayerPrefsName, isSMG_03Purchased);
    }

    private void PurchaseRifle_01()
    {
        isRifle_01Purchased = 1;
        PlayerPrefs.SetInt(rifle_01PurchasedPlayerPrefsName, isRifle_01Purchased);
    }

    private void PurchaseRifle_02()
    {
        isRifle_02Purchased = 1;
        PlayerPrefs.SetInt(rifle_02PurchasedPlayerPrefsName, isRifle_02Purchased);
    }

    private void PurchaseMachineGun_01()
    {
        isMachineGun_01Purchased = 1;
        PlayerPrefs.SetInt(machineGun_01PurchasedPlayerPrefsName, isMachineGun_01Purchased);
    }

    private void PurchaseMachineGun_02()
    {
        isMachineGun_02Purchased = 1;
        PlayerPrefs.SetInt(machineGun_02PurchasedPlayerPrefsName, isMachineGun_02Purchased);
    }

    private void PurchaseRocketLauncher()
    {
        isRocketLauncherPurchased = 1;
        PlayerPrefs.SetInt(rocketLauncherPurchasedPlayerPrefsName, isRocketLauncherPurchased);
    }
    //////////////////////////////////////////////////////////////// Purchase Skins /////////////////////////////////////////////////////////////

    private void PurchaseSoldierSkin()
    {
        isSoldierSkinPurchased = 1;
        PlayerPrefs.SetInt(soldierSkinPurchasedPlayerPrefsName, isSoldierSkinPurchased);
    }

    private void PurchaseMale_01Skin()
    {
        isMale_01SkinPurchased = 1;
        PlayerPrefs.SetInt(male_01SkinPurchasedPlayerPrefsName, isMale_01SkinPurchased);
    }

    private void PurchaseHazmatSkin()
    {
        isHazmatSkinPurchased = 1;
        PlayerPrefs.SetInt(hazmatSkinPurchasedPlayerPrefsName, isHazmatSkinPurchased);
    }

    private void PurchaseHomelessSkin()
    {
        isHomelessSkinPurchased = 1;
        PlayerPrefs.SetInt(homelessSkinPurchasedPlayerPrefsName, isHomelessSkinPurchased);
    }

    private void PurchaseBikerSkin()
    {
        isBikerSkinPurchased = 1;
        PlayerPrefs.SetInt(bikerSkinPurchasedPlayerPrefsName, isBikerSkinPurchased);
    }

    private void PurchaseRiotCopSkin()
    {
        isRiotCopSkinPurchased = 1;
        PlayerPrefs.SetInt(riotCopSkinPurchasedPlayerPrefsName, isRiotCopSkinPurchased);
    }

    private void PurchaseFemale_01Skin()
    {
        isFemale_01SkinPurchased = 1;
        PlayerPrefs.SetInt(female_01SkinPurchasedPlayerPrefsName, isFemale_01SkinPurchased);
    }

    //////////////////////////////////////////////////////////////// Purchase Helicopter Skins /////////////////////////////////////////////////////////////

    private void PurchaseHelicopter_02Skin()
    {
        isHelicopter_02SkinPurchased = 1;
        PlayerPrefs.SetInt(helicopter_02SkinPurchasedPlayerPrefsName, isHelicopter_02SkinPurchased);
    }

    private void PurchaseHelicopter_03Skin()
    {
        isHelicopter_03SkinPurchased = 1;
        PlayerPrefs.SetInt(helicopter_03SkinPurchasedPlayerPrefsName, isHelicopter_03SkinPurchased);
    }

    private void PurchaseHelicopter_04Skin()
    {
        isHelicopter_04SkinPurchased = 1;
        PlayerPrefs.SetInt(helicopter_04SkinPurchasedPlayerPrefsName, isHelicopter_04SkinPurchased);
    }
    ///////////////////////////////////////////////////////////// Equip Weapons /////////////////////////////////////////////////////////////
    private void EquipPistol()
    {
        isPistolEquipped = 1;
        PlayerPrefs.SetInt(pistolEquippedPlayerPrefsName, isPistolEquipped);
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipShotgun()
    {
        isShotgunEquipped = 1;
        PlayerPrefs.SetInt(shotgunEquippedPlayerPrefsName, isShotgunEquipped);
        UnequipPistol();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipShotgun_02()
    {
        isShotgun_02Equipped = 1;
        PlayerPrefs.SetInt(shotgun_02EquippedPlayerPrefsName, isShotgun_02Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipAssault()
    {
        isAssaultEquipped = 1;
        PlayerPrefs.SetInt(assaultEquippedPlayerPrefsName, isAssaultEquipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipAssault_02()
    {
        isAssault_02Equipped = 1;
        PlayerPrefs.SetInt(assault_02EquippedPlayerPrefsName, isAssault_02Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipAssault_03()
    {
        isAssault_03Equipped = 1;
        PlayerPrefs.SetInt(assault_03EquippedPlayerPrefsName, isAssault_03Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipSMG()
    {
        isSMGEquipped = 1;
        PlayerPrefs.SetInt(smgEquippedPlayerPrefsName, isSMGEquipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipSMG_02()
    {
        isSMG_02Equipped = 1;
        PlayerPrefs.SetInt(smg_02EquippedPlayerPrefsName, isSMG_02Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipSMG_03()
    {
        isSMG_03Equipped = 1;
        PlayerPrefs.SetInt(smg_03EquippedPlayerPrefsName, isSMG_03Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipRifle_01()
    {
        isRifle_01Equipped = 1;
        PlayerPrefs.SetInt(rifle_01EquippedPlayerPrefsName, isRifle_01Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipRifle_02()
    {
        isRifle_02Equipped = 1;
        PlayerPrefs.SetInt(rifle_02EquippedPlayerPrefsName, isRifle_02Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipMachineGun_01()
    {
        isMachineGun_01Equipped = 1;
        PlayerPrefs.SetInt(machineGun_01EquippedPlayerPrefsName, isMachineGun_01Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_02();
        UnequipRocketLauncher();
    }

    private void EquipMachineGun_02()
    {
        isMachineGun_02Equipped = 1;
        PlayerPrefs.SetInt(machineGun_02EquippedPlayerPrefsName, isMachineGun_02Equipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipRocketLauncher();
    }

    private void EquipRocketLauncher()
    {
        isRocketLauncherEquipped = 1;
        PlayerPrefs.SetInt(rocketLauncherEquippedPlayerPrefsName, isRocketLauncherEquipped);
        UnequipPistol();
        UnequipShotgun();
        UnequipShotgun_02();
        UnequipAssault();
        UnequipAssault_02();
        UnequipAssault_03();
        UnequipSMG();
        UnequipSMG_02();
        UnequipSMG_03();
        UnequipRifle_01();
        UnequipRifle_02();
        UnequipMachineGun_01();
        UnequipMachineGun_02();
    }

    private void EquipTrialWeapon()
    {
        isTrialWeaponEquipped = 1;
        PlayerPrefs.SetInt(trialWeaponEquippedPlayerPrefsName, isTrialWeaponEquipped);
    }

    private void EquipTrial_02Shotgun()
    {
        isTrialShotgun_02Equipped = 1;
        PlayerPrefs.SetInt(trialShotgun_02EquippedPlayerPrefsName, isTrialShotgun_02Equipped);
    }

    private void EquipTrialSMG_03()
    {
        isTrialSMG_03Equipped = 1;
        PlayerPrefs.SetInt(trialSMG_03EquippedPlayerPrefsName, isTrialSMG_03Equipped);
    }

    private void EquipTrialRifle_02()
    {
        isTrialRifle_02Equipped = 1;
        PlayerPrefs.SetInt(trialRifle_02EquippedPlayerPrefsName, isTrialRifle_02Equipped);
    }

    private void EquipTrialMachineGun_02()
    {
        isTrialMachineGun_02Equipped = 1;
        PlayerPrefs.SetInt(trialMachineGun_02EquippedPlayerPrefsName, isTrialMachineGun_02Equipped);
    }

    private void EquipTrialRocketLauncher()
    {
        isTrialRocketLauncherEquipped = 1;
        PlayerPrefs.SetInt(trialRocketLauncherEquippedPlayerPrefsName, isTrialRocketLauncherEquipped);
    }

    ///////////////////////////////////////////////////////////// Unequip Weapons /////////////////////////////////////////////////////////////
    private void UnequipPistol()
    {
        isPistolEquipped = 0;
        PlayerPrefs.SetInt(pistolEquippedPlayerPrefsName, isPistolEquipped);
    }

    private void UnequipShotgun()
    {
        isShotgunEquipped = 0;
        PlayerPrefs.SetInt(shotgunEquippedPlayerPrefsName, isShotgunEquipped);
    }

    private void UnequipShotgun_02()
    {
        isShotgun_02Equipped = 0;
        PlayerPrefs.SetInt(shotgun_02EquippedPlayerPrefsName, isShotgun_02Equipped);
    }

    private void UnequipAssault()
    {
        isAssaultEquipped = 0;
        PlayerPrefs.SetInt(assaultEquippedPlayerPrefsName, isAssaultEquipped);
    }

    private void UnequipAssault_02()
    {
        isAssault_02Equipped = 0;
        PlayerPrefs.SetInt(assault_02EquippedPlayerPrefsName, isAssault_02Equipped);
    }

    private void UnequipAssault_03()
    {
        isAssault_03Equipped = 0;
        PlayerPrefs.SetInt(assault_03EquippedPlayerPrefsName, isAssault_03Equipped);
    }

    private void UnequipSMG()
    {
        isSMGEquipped = 0;
        PlayerPrefs.SetInt(smgEquippedPlayerPrefsName, isSMGEquipped);
    }

    private void UnequipSMG_02()
    {
        isSMG_02Equipped = 0;
        PlayerPrefs.SetInt(smg_02EquippedPlayerPrefsName, isSMG_02Equipped);
    }

    private void UnequipSMG_03()
    {
        isSMG_03Equipped = 0;
        PlayerPrefs.SetInt(smg_03EquippedPlayerPrefsName, isSMG_03Equipped);
    }

    private void UnequipRifle_01()
    {
        isRifle_01Equipped = 0;
        PlayerPrefs.SetInt(rifle_01EquippedPlayerPrefsName, isRifle_01Equipped);
    }

    private void UnequipRifle_02()
    {
        isRifle_02Equipped = 0;
        PlayerPrefs.SetInt(rifle_02EquippedPlayerPrefsName, isRifle_02Equipped);
    }

    private void UnequipMachineGun_01()
    {
        isMachineGun_01Equipped = 0;
        PlayerPrefs.SetInt(machineGun_01EquippedPlayerPrefsName, isMachineGun_01Equipped);
    }

    private void UnequipMachineGun_02()
    {
        isMachineGun_02Equipped = 0;
        PlayerPrefs.SetInt(machineGun_02EquippedPlayerPrefsName, isMachineGun_02Equipped);
    }

    private void UnequipRocketLauncher()
    {
        isRocketLauncherEquipped = 0;
        PlayerPrefs.SetInt(rocketLauncherEquippedPlayerPrefsName, isRocketLauncherEquipped);
    }

    private void UnequipTrialWeapons()
    {
        isTrialWeaponEquipped = 0;
        PlayerPrefs.SetInt(trialWeaponEquippedPlayerPrefsName, isTrialWeaponEquipped);
        isTrialShotgun_02Equipped = 0;
        PlayerPrefs.SetInt(trialShotgun_02EquippedPlayerPrefsName, isTrialShotgun_02Equipped);
        isTrialSMG_03Equipped = 0;
        PlayerPrefs.SetInt(trialSMG_03EquippedPlayerPrefsName, isTrialSMG_03Equipped);
        isTrialRifle_02Equipped = 0;
        PlayerPrefs.SetInt(trialRifle_02EquippedPlayerPrefsName, isTrialRifle_02Equipped);
        isTrialMachineGun_02Equipped = 0;
        PlayerPrefs.SetInt(trialMachineGun_02EquippedPlayerPrefsName, isTrialMachineGun_02Equipped);
        isTrialRocketLauncherEquipped = 0;
        PlayerPrefs.SetInt(trialRocketLauncherEquippedPlayerPrefsName, isTrialRocketLauncherEquipped);
    }

    ///////////////////////////////////////////////////////////// Equip Skins /////////////////////////////////////////////////////////////
    private void EquipDefaultSkin()
    {
        isDefaultSkinEquipped = 1;
        PlayerPrefs.SetInt(defaultSkinEquippedPlayerPrefsName, isDefaultSkinEquipped);
        UnequipSoldierSkin();
        UnequipMale_01Skin();
        UnequipHazmatSkin();
        UnequipHomelessSkin();
        UnequipBikerSkin();
        UnequipRiotCopSkin();
        UnequipFemale_01Skin();
    }

    private void EquipSoldierSkin()
    {
        isSoldierSkinEquipped = 1;
        PlayerPrefs.SetInt(soldierSkinEquippedPlayerPrefsName, isSoldierSkinEquipped);
        UnequipDefaultSkin();
        UnequipMale_01Skin();
        UnequipHazmatSkin();
        UnequipHomelessSkin();
        UnequipBikerSkin();
        UnequipRiotCopSkin();
        UnequipFemale_01Skin();
    }

    private void EquipMale_01Skin()
    {
        isMale_01SkinEquipped = 1;
        PlayerPrefs.SetInt(male_01SkinEquippedPlayerPrefsName, isMale_01SkinEquipped);
        UnequipDefaultSkin();
        UnequipSoldierSkin();
        UnequipHazmatSkin();
        UnequipHomelessSkin();
        UnequipBikerSkin();
        UnequipRiotCopSkin();
        UnequipFemale_01Skin();
    }

    private void EquipHazmatSkin()
    {
        isHazmatSkinEquipped = 1;
        PlayerPrefs.SetInt(hazmatSkinEquippedPlayerPrefsName, isHazmatSkinEquipped);
        UnequipDefaultSkin();
        UnequipSoldierSkin();
        UnequipMale_01Skin();
        UnequipHomelessSkin();
        UnequipBikerSkin();
        UnequipRiotCopSkin();
        UnequipFemale_01Skin();
    }

    private void EquipHomelessSkin()
    {
        isHomelessSkinEquipped = 1;
        PlayerPrefs.SetInt(homelessSkinEquippedPlayerPrefsName, isHomelessSkinEquipped);
        UnequipDefaultSkin();
        UnequipSoldierSkin();
        UnequipMale_01Skin();
        UnequipHazmatSkin();
        UnequipBikerSkin();
        UnequipRiotCopSkin();
        UnequipFemale_01Skin();
    }

    private void EquipBikerSkin()
    {
        isBikerSkinEquipped = 1;
        PlayerPrefs.SetInt(bikerSkinEquippedPlayerPrefsName, isBikerSkinEquipped);
        UnequipDefaultSkin();
        UnequipSoldierSkin();
        UnequipMale_01Skin();
        UnequipHazmatSkin();
        UnequipHomelessSkin();
        UnequipRiotCopSkin();
        UnequipFemale_01Skin();
    }

    private void EquipRiotCopSkin()
    {
        isRiotCopSkinEquipped = 1;
        PlayerPrefs.SetInt(riotCopSkinEquippedPlayerPrefsName, isRiotCopSkinEquipped);
        UnequipDefaultSkin();
        UnequipSoldierSkin();
        UnequipMale_01Skin();
        UnequipHazmatSkin();
        UnequipHomelessSkin();
        UnequipBikerSkin();
        UnequipFemale_01Skin();
    }

    private void EquipFemale_01Skin()
    {
        isFemale_01SkinEquipped = 1;
        PlayerPrefs.SetInt(female_01SkinEquippedPlayerPrefsName, isFemale_01SkinEquipped);
        UnequipDefaultSkin();
        UnequipSoldierSkin();
        UnequipMale_01Skin();
        UnequipHazmatSkin();
        UnequipHomelessSkin();
        UnequipBikerSkin();
        UnequipRiotCopSkin();
    }

    ///////////////////////////////////////////////////////////// Unequip Skins /////////////////////////////////////////////////////////////
    private void UnequipDefaultSkin()
    {
        isDefaultSkinEquipped = 0;
        PlayerPrefs.SetInt(defaultSkinEquippedPlayerPrefsName, isDefaultSkinEquipped);
    }

    private void UnequipSoldierSkin()
    {
        isSoldierSkinEquipped = 0;
        PlayerPrefs.SetInt(soldierSkinEquippedPlayerPrefsName, isSoldierSkinEquipped);
    }

    private void UnequipMale_01Skin()
    {
        isMale_01SkinEquipped = 0;
        PlayerPrefs.SetInt(male_01SkinEquippedPlayerPrefsName, isMale_01SkinEquipped);
    }

    private void UnequipHazmatSkin()
    {
        isHazmatSkinEquipped = 0;
        PlayerPrefs.SetInt(hazmatSkinEquippedPlayerPrefsName, isHazmatSkinEquipped);
    }

    private void UnequipHomelessSkin()
    {
        isHomelessSkinEquipped = 0;
        PlayerPrefs.SetInt(homelessSkinEquippedPlayerPrefsName, isHomelessSkinEquipped);
    }

    private void UnequipBikerSkin()
    {
        isBikerSkinEquipped = 0;
        PlayerPrefs.SetInt(bikerSkinEquippedPlayerPrefsName, isBikerSkinEquipped);
    }

    private void UnequipRiotCopSkin()
    {
        isRiotCopSkinEquipped = 0;
        PlayerPrefs.SetInt(riotCopSkinEquippedPlayerPrefsName, isRiotCopSkinEquipped);
    }

    private void UnequipFemale_01Skin()
    {
        isFemale_01SkinEquipped = 0;
        PlayerPrefs.SetInt(female_01SkinEquippedPlayerPrefsName, isFemale_01SkinEquipped);
    }

    ///////////////////////////////////////////////////////////// Create Skins Accessories /////////////////////////////////////////////////////////////
    private void CreateDefaultAccessories()
    {
        DestroyAllSkinAccessories();
        GameObject hat = Instantiate(pfDefault_Hat);
        Vector3 hatLocalPos = hat.transform.localPosition;
        Vector3 hatLocalRot = hat.transform.localEulerAngles;
        hat.transform.parent = headTransform;
        hat.transform.localPosition = hatLocalPos;
        hat.transform.localEulerAngles = hatLocalRot;

        GameObject backpack = Instantiate(pfDefault_Backpack);
        Vector3 backpackLocalPos = backpack.transform.localPosition;
        Vector3 backpackLocalRot = backpack.transform.localEulerAngles;
        backpack.transform.parent = spine_03Transform;
        backpack.transform.localPosition = backpackLocalPos;
        backpack.transform.localEulerAngles = backpackLocalRot;

        skinAccessories.Add(hat);
        skinAccessories.Add(backpack);
    }

    private void CreateSoldierAccessories()
    {
        DestroyAllSkinAccessories();
        GameObject shoulderPad = Instantiate(pfSoldier_ShoulderPad);
        Vector3 shoulderPadPos = shoulderPad.transform.localPosition;
        Vector3 shoulderPadRot = shoulderPad.transform.localEulerAngles;
        shoulderPad.transform.parent = clavicle_RTransform;
        shoulderPad.transform.localPosition = shoulderPadPos;
        shoulderPad.transform.localEulerAngles = shoulderPadRot;

        GameObject glasses = Instantiate(pfSoldier_Glasses);
        Vector3 glassesPos = glasses.transform.localPosition;
        Vector3 glassesRot = glasses.transform.localEulerAngles;
        glasses.transform.parent = headTransform;
        glasses.transform.localPosition = glassesPos;
        glasses.transform.localEulerAngles = glassesRot;

        GameObject helmet = Instantiate(pfSoldier_Helmet);
        Vector3 helmetPos = helmet.transform.localPosition;
        Vector3 helmetRot = helmet.transform.localEulerAngles;
        helmet.transform.parent = headTransform;
        helmet.transform.localPosition = helmetPos;
        helmet.transform.localEulerAngles = helmetRot;

        GameObject thighPad = Instantiate(pfSoldier_ThighPad);
        Vector3 thighPadPos = thighPad.transform.localPosition;
        Vector3 thighPadRot = thighPad.transform.localEulerAngles;
        thighPad.transform.parent = upperLeg_LTransform;
        thighPad.transform.localPosition = thighPadPos;
        thighPad.transform.localEulerAngles = thighPadRot;

        GameObject mags = Instantiate(pfSoldier_Mags);
        Vector3 magsPos = mags.transform.localPosition;
        Vector3 magsRot = mags.transform.localEulerAngles;
        mags.transform.parent = hipsTransform;
        mags.transform.localPosition = magsPos;
        mags.transform.localEulerAngles = magsRot;

        skinAccessories.Add(shoulderPad);
        skinAccessories.Add(glasses);
        skinAccessories.Add(helmet);
        skinAccessories.Add(thighPad);
        skinAccessories.Add(mags);
    }

    private void CreateMale_01Accessories()
    {
        DestroyAllSkinAccessories();
        GameObject pouch = Instantiate(pfMale_01_Pouch);
        Vector3 pouchPos = pouch.transform.localPosition;
        Vector3 pouchRot = pouch.transform.localEulerAngles;
        pouch.transform.parent = hipsTransform;
        pouch.transform.localPosition = pouchPos;
        pouch.transform.localEulerAngles = pouchRot;

        GameObject mags = Instantiate(pfMale_01_Mags);
        Vector3 magsPos = mags.transform.localPosition;
        Vector3 magsRot = mags.transform.localEulerAngles;
        mags.transform.parent = hipsTransform;
        mags.transform.localPosition = magsPos;
        mags.transform.localEulerAngles = magsRot;

        GameObject hair = Instantiate(pfMale_01_Hair);
        Vector3 hairPos = hair.transform.localPosition;
        Vector3 hairRot = hair.transform.localEulerAngles;
        hair.transform.parent = headTransform;
        hair.transform.localPosition = hairPos;
        hair.transform.localEulerAngles = hairRot;

        skinAccessories.Add(pouch);
        skinAccessories.Add(mags);
        skinAccessories.Add(hair);
    }

    private void CreateHomelessAccessories()
    {
        DestroyAllSkinAccessories();
        GameObject pouch = Instantiate(pfHomeless_Pouch);
        Vector3 pouchPos = pouch.transform.localPosition;
        Vector3 pouchRot = pouch.transform.localEulerAngles;
        pouch.transform.parent = upperLeg_LTransform;
        pouch.transform.localPosition = pouchPos;
        pouch.transform.localEulerAngles = pouchRot;

        GameObject backpack = Instantiate(pfHomeless_Backpack);
        Vector3 backpackPos = backpack.transform.localPosition;
        Vector3 backpackRot = backpack.transform.localEulerAngles;
        backpack.transform.parent = spine_03Transform;
        backpack.transform.localPosition = backpackPos;
        backpack.transform.localEulerAngles = backpackRot;

        skinAccessories.Add(pouch);
        skinAccessories.Add(backpack);
    }

    private void CreateBikerAccessories()
    {
        DestroyAllSkinAccessories();
        GameObject knife = Instantiate(pfBiker_Knife);
        Vector3 knifePos = knife.transform.localPosition;
        Vector3 knifeRot = knife.transform.localEulerAngles;
        knife.transform.parent = hipsTransform;
        knife.transform.localPosition = knifePos;
        knife.transform.localEulerAngles = knifeRot;

        GameObject beard = Instantiate(pfBiker_Beard);
        Vector3 beardPos = beard.transform.localPosition;
        Vector3 beardRot = beard.transform.localEulerAngles;
        beard.transform.parent = headTransform;
        beard.transform.localPosition = beardPos;
        beard.transform.localEulerAngles = beardRot;

        GameObject hair = Instantiate(pfBiker_Hair);
        Vector3 hairPos = hair.transform.localPosition;
        Vector3 hairRot = hair.transform.localEulerAngles;
        hair.transform.parent = headTransform;
        hair.transform.localPosition = hairPos;
        hair.transform.localEulerAngles = hairRot;

        skinAccessories.Add(knife);
        skinAccessories.Add(beard);
        skinAccessories.Add(hair);
    }

    private void CreateRiotCopAccessories()
    {
        DestroyAllSkinAccessories();
        GameObject beard = Instantiate(pfRiotCop_Beard);
        Vector3 beardPos = beard.transform.localPosition;
        Vector3 beardRot = beard.transform.localEulerAngles;
        beard.transform.parent = headTransform;
        beard.transform.localPosition = beardPos;
        beard.transform.localEulerAngles = beardRot;

        GameObject hair = Instantiate(pfRiotCop_Hair);
        Vector3 hairPos = hair.transform.localPosition;
        Vector3 hairRot = hair.transform.localEulerAngles;
        hair.transform.parent = headTransform;
        hair.transform.localPosition = hairPos;
        hair.transform.localEulerAngles = hairRot;

        GameObject helmet = Instantiate(pfRiotCop_Helmet);
        Vector3 helmetPos = helmet.transform.localPosition;
        Vector3 helmetRot = helmet.transform.localEulerAngles;
        helmet.transform.parent = headTransform;
        helmet.transform.localPosition = helmetPos;
        helmet.transform.localEulerAngles = helmetRot;

        GameObject shoulderPad_R = Instantiate(pfRiotCop_ShoulderPad_R);
        Vector3 shoulderPad_R_Pos = shoulderPad_R.transform.localPosition;
        Vector3 shoulderPad_R_Rot = shoulderPad_R.transform.localEulerAngles;
        shoulderPad_R.transform.parent = clavicle_RTransform;
        shoulderPad_R.transform.localPosition = shoulderPad_R_Pos;
        shoulderPad_R.transform.localEulerAngles = shoulderPad_R_Rot;

        GameObject shoulderPad_L = Instantiate(pfRiotCop_ShoulderPad_L);
        Vector3 shoulderPad_L_Pos = shoulderPad_L.transform.localPosition;
        Vector3 shoulderPad_L_Rot = shoulderPad_L.transform.localEulerAngles;
        shoulderPad_L.transform.parent = clavicle_LTransform;
        shoulderPad_L.transform.localPosition = shoulderPad_L_Pos;
        shoulderPad_L.transform.localEulerAngles = shoulderPad_L_Rot;

        GameObject radio = Instantiate(pfRiotCop_Radio);
        Vector3 radioPos = radio.transform.localPosition;
        Vector3 radioRot = radio.transform.localEulerAngles;
        radio.transform.parent = upperLeg_RTransform;
        radio.transform.localPosition = radioPos;
        radio.transform.localEulerAngles = radioRot;

        GameObject kneePad_R = Instantiate(pfRiotCop_KneePad_R);
        Vector3 kneePad_R_Pos = kneePad_R.transform.localPosition;
        Vector3 kneePad_R_Rot = kneePad_R.transform.localEulerAngles;
        kneePad_R.transform.parent = lowerLeg_RTransform;
        kneePad_R.transform.localPosition = kneePad_R_Pos;
        kneePad_R.transform.localEulerAngles = kneePad_R_Rot;

        GameObject kneePad_L = Instantiate(pfRiotCop_KneePad_L);
        Vector3 kneePad_L_Pos = kneePad_L.transform.localPosition;
        Vector3 kneePad_L_Rot = kneePad_L.transform.localEulerAngles;
        kneePad_L.transform.parent = lowerLeg_LTransform;
        kneePad_L.transform.localPosition = kneePad_L_Pos;
        kneePad_L.transform.localEulerAngles = kneePad_L_Rot;

        skinAccessories.Add(beard);
        skinAccessories.Add(hair);
        skinAccessories.Add(helmet);
        skinAccessories.Add(shoulderPad_R);
        skinAccessories.Add(shoulderPad_L);
        skinAccessories.Add(radio);
        skinAccessories.Add(kneePad_R);
        skinAccessories.Add(kneePad_L);
    }

    private void CreateFemale_01Accessories()
    {
        DestroyAllSkinAccessories();
        GameObject mags = Instantiate(pfFemale_01_Mags);
        Vector3 magsPos = mags.transform.localPosition;
        Vector3 magsRot = mags.transform.localEulerAngles;
        mags.transform.parent = hipsTransform;
        mags.transform.localPosition = magsPos;
        mags.transform.localEulerAngles = magsRot;

        GameObject backpack = Instantiate(pfFemale_01_Backpack);
        Vector3 backpackPos = backpack.transform.localPosition;
        Vector3 backpackRot = backpack.transform.localEulerAngles;
        backpack.transform.parent = spine_03Transform;
        backpack.transform.localPosition = backpackPos;
        backpack.transform.localEulerAngles = backpackRot;

        GameObject shoulderPad = Instantiate(pfFemale_01_ShoulderPad);
        Vector3 shoulderPadPos = shoulderPad.transform.localPosition;
        Vector3 shoulderPadRot = shoulderPad.transform.localEulerAngles;
        shoulderPad.transform.parent = clavicle_LTransform;
        shoulderPad.transform.localPosition = shoulderPadPos;
        shoulderPad.transform.localEulerAngles = shoulderPadRot;

        GameObject hair = Instantiate(pfFemale_01_Hair);
        Vector3 hairPos = hair.transform.localPosition;
        Vector3 hairRot = hair.transform.localEulerAngles;
        hair.transform.parent = headTransform;
        hair.transform.localPosition = hairPos;
        hair.transform.localEulerAngles = hairRot;

        skinAccessories.Add(mags);
        skinAccessories.Add(backpack);
        skinAccessories.Add(shoulderPad);
        skinAccessories.Add(hair);
    }

    private void DestroyAllSkinAccessories()
    {
        foreach (GameObject accessory in skinAccessories)
        {
            Destroy(accessory);
        }
    }

    ///////////////////////////////////////////////////////////// Equip Helicopter Skins /////////////////////////////////////////////////////////////
    private void EquipDefaultHelicopterSkin()
    {
        isDefaultHelicopterSkinEquipped = 1;
        PlayerPrefs.SetInt(defaultHelicopterSkinEquippedPlayerPrefsName, isDefaultHelicopterSkinEquipped);
        UnequipHelicopter_02Skin();
        UnequipHelicopter_03Skin();
        UnequipHelicopter_04Skin();
    }

    private void EquipHelicopter_02Skin()
    {
        isHelicopter_02SkinEquipped = 1;
        PlayerPrefs.SetInt(helicopter_02SkinEquippedPlayerPrefsName, isHelicopter_02SkinEquipped);
        UnequipDefaultHelicopterSkin();
        UnequipHelicopter_03Skin();
        UnequipHelicopter_04Skin();
    }

    private void EquipHelicopter_03Skin()
    {
        isHelicopter_03SkinEquipped = 1;
        PlayerPrefs.SetInt(helicopter_03SkinEquippedPlayerPrefsName, isHelicopter_03SkinEquipped);
        UnequipDefaultHelicopterSkin();
        UnequipHelicopter_02Skin();
        UnequipHelicopter_04Skin();
    }

    private void EquipHelicopter_04Skin()
    {
        isHelicopter_04SkinEquipped = 1;
        PlayerPrefs.SetInt(helicopter_04SkinEquippedPlayerPrefsName, isHelicopter_04SkinEquipped);
        UnequipDefaultHelicopterSkin();
        UnequipHelicopter_02Skin();
        UnequipHelicopter_03Skin();
    }

    ///////////////////////////////////////////////////////////// Unequip Helicopter Skins /////////////////////////////////////////////////////////////
    private void UnequipDefaultHelicopterSkin()
    {
        isDefaultHelicopterSkinEquipped = 0;
        PlayerPrefs.SetInt(defaultHelicopterSkinEquippedPlayerPrefsName, isDefaultHelicopterSkinEquipped);
    }

    private void UnequipHelicopter_02Skin()
    {
        isHelicopter_02SkinEquipped = 0;
        PlayerPrefs.SetInt(helicopter_02SkinEquippedPlayerPrefsName, isHelicopter_02SkinEquipped);
    }

    private void UnequipHelicopter_03Skin()
    {
        isHelicopter_03SkinEquipped = 0;
        PlayerPrefs.SetInt(helicopter_03SkinEquippedPlayerPrefsName, isHelicopter_03SkinEquipped);
    }

    private void UnequipHelicopter_04Skin()
    {
        isHelicopter_04SkinEquipped = 0;
        PlayerPrefs.SetInt(helicopter_04SkinEquippedPlayerPrefsName, isHelicopter_04SkinEquipped);
    }

    ///////////////////////////////////////////////////////////// Get Item States /////////////////////////////////////////////////////////////
    public int GetIsPistolEquipped()
    {
        //PlayerPrefs.DeleteKey(pistolEquippedPlayerPrefsName);
        isPistolEquipped = PlayerPrefs.GetInt(pistolEquippedPlayerPrefsName, 1);
        return isPistolEquipped;
    }

    public int GetIsShotgunEquipped()
    {
        //PlayerPrefs.DeleteKey(shotgunEquippedPlayerPrefsName);
        isShotgunEquipped = PlayerPrefs.GetInt(shotgunEquippedPlayerPrefsName, 0);
        return isShotgunEquipped;
    }

    public int GetIsShotgun_02Equipped()
    {
        //PlayerPrefs.DeleteKey(shotgun_02EquippedPlayerPrefsName);
        isShotgun_02Equipped = PlayerPrefs.GetInt(shotgun_02EquippedPlayerPrefsName, 0);
        return isShotgun_02Equipped;
    }

    public int GetIsAssaultEquipped()
    {
        //PlayerPrefs.DeleteKey(assaultEquippedPlayerPrefsName);
        isAssaultEquipped = PlayerPrefs.GetInt(assaultEquippedPlayerPrefsName, 0);
        return isAssaultEquipped;
    }

    public int GetIsAssault_02Equipped()
    {
        //PlayerPrefs.DeleteKey(assault_02EquippedPlayerPrefsName);
        isAssault_02Equipped = PlayerPrefs.GetInt(assault_02EquippedPlayerPrefsName, 0);
        return isAssault_02Equipped;
    }

    public int GetIsAssault_03Equipped()
    {
        //PlayerPrefs.DeleteKey(assault_03EquippedPlayerPrefsName);
        isAssault_03Equipped = PlayerPrefs.GetInt(assault_03EquippedPlayerPrefsName, 0);
        return isAssault_03Equipped;
    }

    public int GetIsSMGEquipped()
    {
        //PlayerPrefs.DeleteKey(smgEquippedPlayerPrefsName);
        isSMGEquipped = PlayerPrefs.GetInt(smgEquippedPlayerPrefsName, 0);
        return isSMGEquipped;
    }

    public int GetIsSMG_02Equipped()
    {
        //PlayerPrefs.DeleteKey(smg_02EquippedPlayerPrefsName);
        isSMG_02Equipped = PlayerPrefs.GetInt(smg_02EquippedPlayerPrefsName, 0);
        return isSMG_02Equipped;
    }

    public int GetIsSMG_03Equipped()
    {
        //PlayerPrefs.DeleteKey(smg_03EquippedPlayerPrefsName);
        isSMG_03Equipped = PlayerPrefs.GetInt(smg_03EquippedPlayerPrefsName, 0);
        return isSMG_03Equipped;
    }

    public int GetIsRifle_01Equipped()
    {
        //PlayerPrefs.DeleteKey(rifle_01EquippedPlayerPrefsName);
        isRifle_01Equipped = PlayerPrefs.GetInt(rifle_01EquippedPlayerPrefsName, 0);
        return isRifle_01Equipped;
    }

    public int GetIsRifle_02Equipped()
    {
        //PlayerPrefs.DeleteKey(rifle_02EquippedPlayerPrefsName);
        isRifle_02Equipped = PlayerPrefs.GetInt(rifle_02EquippedPlayerPrefsName, 0);
        return isRifle_02Equipped;
    }

    public int GetIsMachineGun_01Equipped()
    {
        //PlayerPrefs.DeleteKey(machineGun_01EquippedPlayerPrefsName);
        isMachineGun_01Equipped = PlayerPrefs.GetInt(machineGun_01EquippedPlayerPrefsName, 0);
        return isMachineGun_01Equipped;
    }

    public int GetIsMachineGun_02Equipped()
    {
        //PlayerPrefs.DeleteKey(machineGun_02EquippedPlayerPrefsName);
        isMachineGun_02Equipped = PlayerPrefs.GetInt(machineGun_02EquippedPlayerPrefsName, 0);
        return isMachineGun_02Equipped;
    }

    public int GetIsRocketLauncherEquipped()
    {
        //PlayerPrefs.DeleteKey(rocketLauncherEquippedPlayerPrefsName);
        isRocketLauncherEquipped = PlayerPrefs.GetInt(rocketLauncherEquippedPlayerPrefsName, 0);
        return isRocketLauncherEquipped;
    }

    public int GetIsTrialWeaponEquipped()
    {
        //PlayerPrefs.DeleteKey(trialWeaponEquippedPlayerPrefsName);
        isTrialWeaponEquipped = PlayerPrefs.GetInt(trialWeaponEquippedPlayerPrefsName, 0);
        return isTrialWeaponEquipped;
    }

    public int GetIsTrialShotgun_02Equipped()
    {
        //PlayerPrefs.DeleteKey(trialShotgun_02EquippedPlayerPrefsName);
        isTrialShotgun_02Equipped = PlayerPrefs.GetInt(trialShotgun_02EquippedPlayerPrefsName, 0);
        return isTrialShotgun_02Equipped;
    }

    public int GetIsTrialSMG_03Equipped()
    {
        //PlayerPrefs.DeleteKey(trialSMG_03EquippedPlayerPrefsName);
        isTrialSMG_03Equipped = PlayerPrefs.GetInt(trialSMG_03EquippedPlayerPrefsName, 0);
        return isTrialSMG_03Equipped;
    }

    public int GetIsTrialRifle_02Equipped()
    {
        //PlayerPrefs.DeleteKey(trialRifle_02EquippedPlayerPrefsName);
        isTrialRifle_02Equipped = PlayerPrefs.GetInt(trialRifle_02EquippedPlayerPrefsName, 0);
        return isTrialRifle_02Equipped;
    }

    public int GetIsTrialMachineGun_02Equipped()
    {
        //PlayerPrefs.DeleteKey(trialMachineGun_02EquippedPlayerPrefsName);
        isTrialMachineGun_02Equipped = PlayerPrefs.GetInt(trialMachineGun_02EquippedPlayerPrefsName, 0);
        return isTrialMachineGun_02Equipped;
    }

    public int GetIsTrialRocketLauncherEquipped()
    {
        //PlayerPrefs.DeleteKey(trialRocketLauncherEquippedPlayerPrefsName);
        isTrialRocketLauncherEquipped = PlayerPrefs.GetInt(trialRocketLauncherEquippedPlayerPrefsName, 0);
        return isTrialRocketLauncherEquipped;
    }

    public int GetIsDefaultSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(defaultSkinEquippedPlayerPrefsName);
        isDefaultSkinEquipped = PlayerPrefs.GetInt(defaultSkinEquippedPlayerPrefsName, 1);
        return isDefaultSkinEquipped;
    }

    public int GetIsSoldierSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(soldierSkinEquippedPlayerPrefsName);
        isSoldierSkinEquipped = PlayerPrefs.GetInt(soldierSkinEquippedPlayerPrefsName, 0);
        return isSoldierSkinEquipped;
    }

    public int GetIsMale_01SkinEquipped()
    {
        //PlayerPrefs.DeleteKey(male_01SkinEquippedPlayerPrefsName);
        isMale_01SkinEquipped = PlayerPrefs.GetInt(male_01SkinEquippedPlayerPrefsName, 0);
        return isMale_01SkinEquipped;
    }

    public int GetIsHazmatSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(hazmatSkinEquippedPlayerPrefsName);
        isHazmatSkinEquipped = PlayerPrefs.GetInt(hazmatSkinEquippedPlayerPrefsName, 0);
        return isHazmatSkinEquipped;
    }

    public int GetIsHomelessSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(homelessSkinEquippedPlayerPrefsName);
        isHomelessSkinEquipped = PlayerPrefs.GetInt(homelessSkinEquippedPlayerPrefsName, 0);
        return isHomelessSkinEquipped;
    }

    public int GetIsBikerSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(bikerSkinEquippedPlayerPrefsName);
        isBikerSkinEquipped = PlayerPrefs.GetInt(bikerSkinEquippedPlayerPrefsName, 0);
        return isBikerSkinEquipped;
    }

    public int GetIsRiotCopSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(riotCopSkinEquippedPlayerPrefsName);
        isRiotCopSkinEquipped = PlayerPrefs.GetInt(riotCopSkinEquippedPlayerPrefsName, 0);
        return isRiotCopSkinEquipped;
    }

    public int GetIsFemale_01SkinEquipped()
    {
        //PlayerPrefs.DeleteKey(female_01SkinEquippedPlayerPrefsName);
        isFemale_01SkinEquipped = PlayerPrefs.GetInt(female_01SkinEquippedPlayerPrefsName, 0);
        return isFemale_01SkinEquipped;
    }

    public int GetIsDefaultHelicopterSkinEquipped()
    {
        //PlayerPrefs.DeleteKey(defaultHelicopterSkinEquippedPlayerPrefsName);
        isDefaultHelicopterSkinEquipped = PlayerPrefs.GetInt(defaultHelicopterSkinEquippedPlayerPrefsName, 1);
        return isDefaultHelicopterSkinEquipped;
    }

    public int GetIsHelicopter_02SkinEquipped()
    {
        //PlayerPrefs.DeleteKey(helicopter_02SkinEquippedPlayerPrefsName);
        isHelicopter_02SkinEquipped = PlayerPrefs.GetInt(helicopter_02SkinEquippedPlayerPrefsName, 0);
        return isHelicopter_02SkinEquipped;
    }

    public int GetIsHelicopter_03SkinEquipped()
    {
        //PlayerPrefs.DeleteKey(helicopter_03SkinEquippedPlayerPrefsName);
        isHelicopter_03SkinEquipped = PlayerPrefs.GetInt(helicopter_03SkinEquippedPlayerPrefsName, 0);
        return isHelicopter_03SkinEquipped;
    }

    public int GetIsHelicopter_04SkinEquipped()
    {
        //PlayerPrefs.DeleteKey(helicopter_04SkinEquippedPlayerPrefsName);
        isHelicopter_04SkinEquipped = PlayerPrefs.GetInt(helicopter_04SkinEquippedPlayerPrefsName, 0);
        return isHelicopter_04SkinEquipped;
    }

    public int GetIsShotgunPurchased()
    {
        //PlayerPrefs.DeleteKey(shotgunPurchasedPlayerPrefsName);
        isShotgunPurchased = PlayerPrefs.GetInt(shotgunPurchasedPlayerPrefsName, 0);
        return isShotgunPurchased;
    }

    public int GetIsShotgun_02Purchased()
    {
        //PlayerPrefs.DeleteKey(shotgun_02PurchasedPlayerPrefsName);
        isShotgun_02Purchased = PlayerPrefs.GetInt(shotgun_02PurchasedPlayerPrefsName, 0);
        return isShotgun_02Purchased;
    }

    public int GetIsAssaultPurchased()
    {
        //PlayerPrefs.DeleteKey(assaultPurchasedPlayerPrefsName);
        isAssaultPurchased = PlayerPrefs.GetInt(assaultPurchasedPlayerPrefsName, 0);
        return isAssaultPurchased;
    }

    public int GetIsAssault_02Purchased()
    {
        //PlayerPrefs.DeleteKey(assault_02PurchasedPlayerPrefsName);
        isAssault_02Purchased = PlayerPrefs.GetInt(assault_02PurchasedPlayerPrefsName, 0);
        return isAssault_02Purchased;
    }

    public int GetIsAssault_03Purchased()
    {
        //PlayerPrefs.DeleteKey(assault_03PurchasedPlayerPrefsName);
        isAssault_03Purchased = PlayerPrefs.GetInt(assault_03PurchasedPlayerPrefsName, 0);
        return isAssault_03Purchased;
    }

    public int GetIsSMGPurchased()
    {
        //PlayerPrefs.DeleteKey(smgPurchasedPlayerPrefsName);
        isSMGPurchased = PlayerPrefs.GetInt(smgPurchasedPlayerPrefsName, 0);
        return isSMGPurchased;
    }

    public int GetIsSMG_02Purchased()
    {
        //PlayerPrefs.DeleteKey(smg_02PurchasedPlayerPrefsName);
        isSMG_02Purchased = PlayerPrefs.GetInt(smg_02PurchasedPlayerPrefsName, 0);
        return isSMG_02Purchased;
    }

    public int GetIsSMG_03Purchased()
    {
        //PlayerPrefs.DeleteKey(smg_03PurchasedPlayerPrefsName);
        isSMG_03Purchased = PlayerPrefs.GetInt(smg_03PurchasedPlayerPrefsName, 0);
        return isSMG_03Purchased;
    }

    public int GetIsRifle_01Purchased()
    {
        //PlayerPrefs.DeleteKey(rifle_01PurchasedPlayerPrefsName);
        isRifle_01Purchased = PlayerPrefs.GetInt(rifle_01PurchasedPlayerPrefsName, 0);
        return isRifle_01Purchased;
    }

    public int GetIsRifle_02Purchased()
    {
        //PlayerPrefs.DeleteKey(rifle_02PurchasedPlayerPrefsName);
        isRifle_02Purchased = PlayerPrefs.GetInt(rifle_02PurchasedPlayerPrefsName, 0);
        return isRifle_02Purchased;
    }

    public int GetIsMachineGun_01Purchased()
    {
        //PlayerPrefs.DeleteKey(machineGun_01PurchasedPlayerPrefsName);
        isMachineGun_01Purchased = PlayerPrefs.GetInt(machineGun_01PurchasedPlayerPrefsName, 0);
        return isMachineGun_01Purchased;
    }

    public int GetIsMachineGun_02Purchased()
    {
        //PlayerPrefs.DeleteKey(machineGun_02PurchasedPlayerPrefsName);
        isMachineGun_02Purchased = PlayerPrefs.GetInt(machineGun_02PurchasedPlayerPrefsName, 0);
        return isMachineGun_02Purchased;
    }

    public int GetIsRocketLauncherPurchased()
    {
        //PlayerPrefs.DeleteKey(rocketLauncherPurchasedPlayerPrefsName);
        isRocketLauncherPurchased = PlayerPrefs.GetInt(rocketLauncherPurchasedPlayerPrefsName, 0);
        return isRocketLauncherPurchased;
    }

    public int GetIsSoldierSkinPurchased()
    {
        //PlayerPrefs.DeleteKey(soldierSkinPurchasedPlayerPrefsName);
        isSoldierSkinPurchased = PlayerPrefs.GetInt(soldierSkinPurchasedPlayerPrefsName, 0);
        return isSoldierSkinPurchased;
    }

    public int GetIsMale_01SkinPurchased()
    {
        //PlayerPrefs.DeleteKey(male_01SkinPurchasedPlayerPrefsName);
        isMale_01SkinPurchased = PlayerPrefs.GetInt(male_01SkinPurchasedPlayerPrefsName, 0);
        return isMale_01SkinPurchased;
    }

    public int GetIsHazmatSkinPurchased()
    {
        //PlayerPrefs.DeleteKey(hazmatSkinPurchasedPlayerPrefsName);
        isHazmatSkinPurchased = PlayerPrefs.GetInt(hazmatSkinPurchasedPlayerPrefsName, 0);
        return isHazmatSkinPurchased;
    }

    public int GetIsHomelessSkinPurchased()
    {
        //PlayerPrefs.DeleteKey(homelessSkinPurchasedPlayerPrefsName);
        isHomelessSkinPurchased = PlayerPrefs.GetInt(homelessSkinPurchasedPlayerPrefsName, 0);
        return isHomelessSkinPurchased;
    }

    public int GetIsBikerSkinPurchased()
    {
        //PlayerPrefs.DeleteKey(bikerSkinPurchasedPlayerPrefsName);
        isBikerSkinPurchased = PlayerPrefs.GetInt(bikerSkinPurchasedPlayerPrefsName, 0);
        return isBikerSkinPurchased;
    }

    public int GetIsRiotCopSkinPurchased()
    {
        //PlayerPrefs.DeleteKey(riotCopSkinPurchasedPlayerPrefsName);
        isRiotCopSkinPurchased = PlayerPrefs.GetInt(riotCopSkinPurchasedPlayerPrefsName, 0);
        return isRiotCopSkinPurchased;
    }

    public int GetIsFemale_01SkinPurchased()
    {
        //PlayerPrefs.DeleteKey(female_01SkinPurchasedPlayerPrefsName);
        isFemale_01SkinPurchased = PlayerPrefs.GetInt(female_01SkinPurchasedPlayerPrefsName, 0);
        return isFemale_01SkinPurchased;
    }

    public int GetIsHelicopter_02SkinPurchased()
    {
        //PlayerPrefs.DeleteKey(helicopter_02SkinPurchasedPlayerPrefsName);
        isHelicopter_02SkinPurchased = PlayerPrefs.GetInt(helicopter_02SkinPurchasedPlayerPrefsName, 0);
        return isHelicopter_02SkinPurchased;
    }

    public int GetIsHelicopter_03SkinPurchased()
    {
        //PlayerPrefs.DeleteKey(helicopter_03SkinPurchasedPlayerPrefsName);
        isHelicopter_03SkinPurchased = PlayerPrefs.GetInt(helicopter_03SkinPurchasedPlayerPrefsName, 0);
        return isHelicopter_03SkinPurchased;
    }

    public int GetIsHelicopter_04SkinPurchased()
    {
        //PlayerPrefs.DeleteKey(helicopter_04SkinPurchasedPlayerPrefsName);
        isHelicopter_04SkinPurchased = PlayerPrefs.GetInt(helicopter_04SkinPurchasedPlayerPrefsName, 0);
        return isHelicopter_04SkinPurchased;
    }

    public void SetStartNPCAsCaller()
    {
        isHomeNPCCalling = true;
        isPlayerCalling = false;
        isLevelNPCCalling = false;
    }

    public void SetPlayerAsCaller()
    {
        isHomeNPCCalling = false;
        isPlayerCalling = true;
        isLevelNPCCalling = false;
    }

    public void SetLevelNPCAsCaller()
    {
        isHomeNPCCalling = false;
        isPlayerCalling = false;
        isLevelNPCCalling = true;
    }

    public void SetUniqueCallerWeaponEquipFunctionality(RaycastWeapon newWeapon)
    {
        if (isPlayerCalling)
        {
            activeWeapon.EquipWeapon(newWeapon);
            newWeapon.SetWeaponEquipped(newWeapon.weaponName);
        }
        else if (isLevelNPCCalling)
        {
            FindObjectOfType<NPC>().GetComponent<ActiveWeapon>().EquipWeapon(newWeapon);
        }
        else if (isHomeNPCCalling)
        {
            FindObjectOfType<HomeNPC>().EquipWeapon(newWeapon);
        }
    }

    public void SetUniqueCallerSkinEquipFunctionality()
    {
        headTransform = GetCallerToChange().transform.Find(pathToHead);
        hipsTransform = GetCallerToChange().transform.Find(pathToHips);
        clavicle_RTransform = GetCallerToChange().transform.Find(pathToClavicle_R);
        clavicle_LTransform = GetCallerToChange().transform.Find(pathToClavicle_L);
        spine_03Transform = GetCallerToChange().transform.Find(pathToSpine_03);
        upperLeg_LTransform = GetCallerToChange().transform.Find(pathToUpperLeg_L);
        upperLeg_RTransform = GetCallerToChange().transform.Find(pathToUpperLeg_R);
        lowerLeg_LTransform = GetCallerToChange().transform.Find(pathToLowerLeg_L);
        lowerLeg_RTransform = GetCallerToChange().transform.Find(pathToLowerLeg_R);

        if (GetIsDefaultSkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfDefaultSkin;
            skinToChange.material = defaultSkinMaterial;
            CreateDefaultAccessories();
        }
        if (GetIsSoldierSkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfSoldierSkin;
            skinToChange.material = defaultSkinMaterial;
            CreateSoldierAccessories();
        }
        if (GetIsMale_01SkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfMale_01Skin;
            skinToChange.material = alternateSkinMaterial_01;
            CreateMale_01Accessories();
        }
        if (GetIsHazmatSkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfHazmatSkin;
            skinToChange.material = defaultSkinMaterial;
            DestroyAllSkinAccessories();
        }
        if (GetIsHomelessSkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfHomelessSkin;
            skinToChange.material = defaultSkinMaterial;
            CreateHomelessAccessories();
        }
        if (GetIsBikerSkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfBikerSkin;
            skinToChange.material = defaultSkinMaterial;
            CreateBikerAccessories();
        }
        if (GetIsRiotCopSkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfRiotCopSkin;
            skinToChange.material = defaultSkinMaterial;
            CreateRiotCopAccessories();
        }
        if (GetIsFemale_01SkinEquipped() == 1)
        {
            skinToChange = GetCallerToChange().transform.Find("Skin").GetComponent<SkinnedMeshRenderer>();
            skinToChange.sharedMesh = pfFemale_01Skin;
            skinToChange.material = defaultSkinMaterial;
            CreateFemale_01Accessories();
        }
    }

    public void SetUniqueCallerHelicopterSkinEquipFunctionality()
    {
        if (GetIsDefaultHelicopterSkinEquipped() == 1)
        {
            helicopterSkinsToChange = GetHelicopterCallerToChange().GetComponentsInChildren<MeshRenderer>();
            foreach(MeshRenderer mesh in helicopterSkinsToChange)
            {
                if (mesh.CompareTag(helicopterTag) && !mesh.CompareTag(glassTag) || mesh.CompareTag(playerHelicopterTag))
                {
                    mesh.material = pfDefaultHelicopterSkin;
                }
            }
            //helicopterSkinToChange.material = pfDefaultHelicopterSkin;
        }
        if (GetIsHelicopter_02SkinEquipped() == 1)
        {
            helicopterSkinsToChange = GetHelicopterCallerToChange().GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in helicopterSkinsToChange)
            {
                if (mesh.CompareTag(helicopterTag) && !mesh.CompareTag(glassTag) || mesh.CompareTag(playerHelicopterTag))
                {
                    mesh.material = pfHelicopter_02Skin;
                }
            }
            //helicopterSkinToChange.material = pfHelicopter_02Skin;
        }
        if (GetIsHelicopter_03SkinEquipped() == 1)
        {
            helicopterSkinsToChange = GetHelicopterCallerToChange().GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in helicopterSkinsToChange)
            {
                if (mesh.CompareTag(helicopterTag) && !mesh.CompareTag(glassTag) || mesh.CompareTag(playerHelicopterTag))
                {
                    mesh.material = pfHelicopter_03Skin;
                }
            }
            //helicopterSkinToChange.material = pfHelicopter_03Skin;
        }
        if (GetIsHelicopter_04SkinEquipped() == 1)
        {
            helicopterSkinsToChange = GetHelicopterCallerToChange().GetComponentsInChildren<MeshRenderer>();
            foreach (MeshRenderer mesh in helicopterSkinsToChange)
            {
                if (mesh.CompareTag(helicopterTag) && !mesh.CompareTag(glassTag) || mesh.CompareTag(playerHelicopterTag))
                {
                    mesh.material = pfHelicopter_04Skin;
                }
            }
            //helicopterSkinToChange.material = pfHelicopter_03Skin;
        }
    }

    public GameObject GetCallerToChange()
    {
        if (isPlayerCalling)
        {
            callerToChange = FindObjectOfType<PlayerController>().gameObject;
            return callerToChange;
        }
        else if (isLevelNPCCalling)
        {
            callerToChange = FindObjectOfType<NPC>().gameObject;
            return callerToChange;
        }
        else if (isHomeNPCCalling)
        {
            callerToChange = FindObjectOfType<HomeNPC>().gameObject;
            return callerToChange;
        }
        else
        {
            return null;
        }
    }

    public GameObject GetHelicopterCallerToChange()
    {
        if (isPlayerCalling)
        {
            helicopterCallerToChange = GameObject.FindGameObjectWithTag(playerHelicopterTag);
            return helicopterCallerToChange;
        }
        else if (isLevelNPCCalling)
        {
            helicopterCallerToChange = GameObject.FindGameObjectWithTag(npcHelicopterTag);
            return helicopterCallerToChange;
        }
        else if (isHomeNPCCalling)
        {
            helicopterCallerToChange = GameObject.FindGameObjectWithTag(homeHelicopterTag);
            return helicopterCallerToChange;
        }
        else
        {
            return null;
        }
    }

    public int CheckIfItemIsPurchased(Item.ItemType item)
    {
        switch (item)
        {
            case Item.ItemType.Assault:
                return GetIsAssaultPurchased();
            case Item.ItemType.Assault_02:
                return GetIsAssault_02Purchased();
            case Item.ItemType.Assault_03:
                return GetIsAssault_03Purchased();
            case Item.ItemType.Shotgun:
                return GetIsShotgunPurchased();
            case Item.ItemType.Shotgun_02:
                return GetIsShotgun_02Purchased();
            case Item.ItemType.SMG:
                return GetIsSMGPurchased();
            case Item.ItemType.SMG_02:
                return GetIsSMG_02Purchased();
            case Item.ItemType.SMG_03:
                return GetIsSMG_03Purchased();
            case Item.ItemType.Rifle_01:
                return GetIsRifle_01Purchased();
            case Item.ItemType.Rifle_02:
                return GetIsRifle_02Purchased();
            case Item.ItemType.MachineGun_01:
                return GetIsMachineGun_01Purchased();
            case Item.ItemType.MachineGun_02:
                return GetIsMachineGun_02Purchased();
            case Item.ItemType.RocketLauncher:
                return GetIsRocketLauncherPurchased();
            case Item.ItemType.Male_01Skin:
                return GetIsMale_01SkinPurchased();
            case Item.ItemType.SoldierSkin:
                return GetIsSoldierSkinPurchased();
            case Item.ItemType.HazmatSkin:
                return GetIsHazmatSkinPurchased();
            case Item.ItemType.HomelessSkin:
                return GetIsHomelessSkinPurchased();
            case Item.ItemType.BikerSkin:
                return GetIsBikerSkinPurchased();
            case Item.ItemType.RiotCopSkin:
                return GetIsRiotCopSkinPurchased();
            case Item.ItemType.Female_01Skin:
                return GetIsFemale_01SkinPurchased();
            case Item.ItemType.Helicopter_02Skin:
                return GetIsHelicopter_02SkinPurchased();
            case Item.ItemType.Helicopter_03Skin:
                return GetIsHelicopter_03SkinPurchased();
            case Item.ItemType.Helicopter_04Skin:
                return GetIsHelicopter_04SkinPurchased();
            default:
                Debug.Log("Item was not recognized...");
                return 0;
        }
    }
}
