using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeNPC : MonoBehaviour
{
    [SerializeField] private GameObject pistolWeapon;
    [SerializeField] private GameObject assaultWeapon;
    [SerializeField] private GameObject assault_02Weapon;
    [SerializeField] private GameObject assault_03Weapon;
    [SerializeField] private GameObject smgWeapon;
    [SerializeField] private GameObject smg_02Weapon;
    [SerializeField] private GameObject smg_03Weapon;
    [SerializeField] private GameObject shotgunWeapon;
    [SerializeField] private GameObject shotgun_02Weapon;
    [SerializeField] private GameObject rifle_01Weapon;
    [SerializeField] private GameObject rifle_02Weapon;
    [SerializeField] private GameObject machineGun_01Weapon;
    [SerializeField] private GameObject machineGun_02Weapon;
    [SerializeField] private GameObject rocketLauncherWeapon;

    private ItemManager itemManager;
    private RaycastWeapon weapon;

    void Awake()
    {
        CallEquipItems();
    }

    public void EquipWeapon(RaycastWeapon newWeapon)
    {
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }
        weapon = newWeapon;
        SetWeaponActive(weapon.name);
        Destroy(weapon.gameObject);
    }

    public int GetWeaponBulletDamage()
    {
        return weapon.bulletDamage;
    }

    public int GetWeaponBulletCount()
    {
        return weapon.bulletCount;
    }

    public string GetWeaponNickname()
    {
        return weapon.nickname;
    }

    public void CallEquipItems()
    {
        itemManager = FindObjectOfType<ItemManager>();
        itemManager.SetStartNPCAsCaller();
        itemManager.EquipItems();
    }

    private void SetWeaponActive(string weaponName)
    {
        switch (weaponName)
        {
            case "Weapon_Pistol(Clone)":
                pistolWeapon.SetActive(true);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Assault(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(true);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Assault_02(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(true);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Assault_03(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(true);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_SMG(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(true);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_SMG_02(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(true);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_SMG_03(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(true);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Shotgun(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(true);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Shotgun_02(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(true);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Rifle_01(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(true);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_Rifle_02(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(true);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_MachineGun_01(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(true);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_MachineGun_02(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(true);
                rocketLauncherWeapon.SetActive(false);
                break;
            case "Weapon_RocketLauncher(Clone)":
                pistolWeapon.SetActive(false);
                assaultWeapon.SetActive(false);
                assault_02Weapon.SetActive(false);
                assault_03Weapon.SetActive(false);
                smgWeapon.SetActive(false);
                smg_02Weapon.SetActive(false);
                smg_03Weapon.SetActive(false);
                shotgunWeapon.SetActive(false);
                shotgun_02Weapon.SetActive(false);
                rifle_01Weapon.SetActive(false);
                rifle_02Weapon.SetActive(false);
                machineGun_01Weapon.SetActive(false);
                machineGun_02Weapon.SetActive(false);
                rocketLauncherWeapon.SetActive(true);
                break;
            default:
                break;
        }
    }
}
