public class Item
{
    public enum ItemType
    {
        Empty,
        Pistol,
        Shotgun,
        Shotgun_02,
        Assault,
        Assault_02,
        Assault_03,
        SMG,
        SMG_02,
        SMG_03,
        Rifle_01,
        Rifle_02,
        MachineGun_01,
        MachineGun_02,
        RocketLauncher,
        TrialWeapons,
        TrialWeapon,
        TrialShotgun_02,
        TrialSMG_03,
        TrialRifle_02,
        TrialMachineGun_02,
        TrialRocketLauncher,
        DefaultSkin,
        SoldierSkin,
        Male_01Skin,
        HazmatSkin,
        HomelessSkin,
        BikerSkin,
        RiotCopSkin,
        Female_01Skin,
        DefaultHelicopterSkin,
        Helicopter_02Skin,
        Helicopter_03Skin,
        Helicopter_04Skin
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.Pistol: // 100 total damage - 1 bullet
                return 0;
            case ItemType.Assault: // 260 total damage - 2 bullets
                return 400;
            case ItemType.Shotgun: // 240 total damage - 3 bullets
                return 500;
            case ItemType.SMG: // 240 total damage - 3 bullets
                return 600;
            case ItemType.Rifle_01: // 320 total damage - 2 bullets
                return 700;
            case ItemType.SMG_02: // 450 total damage - 3 bullets
                return 800;
            case ItemType.MachineGun_01: // 400 total damage - 5 bullet
                return 900;
            case ItemType.Shotgun_02: // 320 total damage - 3 bullets
                return 1000;
            case ItemType.Assault_02: // 320 total damage - 4 bullets
                return 1250;
            case ItemType.Assault_03: // 400 total damage - 4 bullets
                return 1500;
            case ItemType.Rifle_02: // 480 total damage - 4 bullets
                return 1750;
            case ItemType.SMG_03: // 540 total damage - 3 bullets
                return 2250;
            case ItemType.RocketLauncher: // 500 total damage - 1 bullet
                return 2750;
            case ItemType.MachineGun_02: // 550 total damage - 5 bullet
                return 3250;
        }
    }
}
