using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShopManager : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;

    private Item.ItemType weaponToOffer;
    private int weaponOfferCount = 1;

    private bool isSingleWeaponOffer;
    private bool isDoubleWeaponOffer;

    public void CheckForWeaponShopOffer(int levelNumber)
    {
        switch (levelNumber)
        {
            case 1:
                break;
            case 2:
                break;
            case 7:
                break;
            default:
                levelUI.ShowWeaponOffer();
                break;
        }
    }

    public void CheckNextWeaponOffer()
    {
        weaponOfferCount++;
    }

    public Item.ItemType GetNextWeaponOffer(int weaponOfferCount)
    {
        switch (weaponOfferCount)
        {
            case 1:
                SetIsSingleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Assault;
                return weaponToOffer;
            case 2:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Shotgun;
                return weaponToOffer;
            case 3:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.SMG;
                return weaponToOffer;
            case 4:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Rifle_01;
                return weaponToOffer;
            case 5:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.SMG_02;
                return weaponToOffer;
            case 6:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.MachineGun_01;
                return weaponToOffer;
            case 7:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Shotgun_02;
                return weaponToOffer;
            case 8:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Assault_02;
                return weaponToOffer;
            case 9:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Assault_03;
                return weaponToOffer;
            case 10:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.Rifle_02;
                return weaponToOffer;
            case 11:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.SMG_03;
                return weaponToOffer;
            case 12:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.RocketLauncher;
                return weaponToOffer;
            case 13:
                SetIsDoubleWeaponOffer(true);
                weaponToOffer = Item.ItemType.MachineGun_02;
                return weaponToOffer;
            default:
                // Ran out of weapon offers.
                weaponToOffer = Item.ItemType.Empty;
                return weaponToOffer;
        }
    }

    public void SetIsSingleWeaponOffer(bool isTrue)
    {
        isSingleWeaponOffer = isTrue;
        isDoubleWeaponOffer = !isTrue;
    }

    private void SetIsDoubleWeaponOffer(bool isTrue)
    {
        isDoubleWeaponOffer = isTrue;
        isSingleWeaponOffer = !isTrue;
    }

    public bool GetIsSingleWeaponOffer()
    {
        return isSingleWeaponOffer;
    }

    public bool GetIsDoubleWeaponOffer()
    {
        return isDoubleWeaponOffer;
    }

    public int GetCurrentWeaponOfferCount()
    {
        return weaponOfferCount;
    }
}
