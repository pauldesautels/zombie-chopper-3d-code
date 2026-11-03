using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastWeapon : MonoBehaviour
{
    public string weaponName;
    public string nickname;
    public int bulletDamage;
    public int bulletCount;
    public Transform pfBulletProjectile;
    public Transform spawnBulletTransform;
    public AnimationClip weaponAnimation;
    public AnimationClip weaponRecoilAnimation;
    //public AnimationClip weaponHomeAnimation;
    public TrailRenderer bulletTrail;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bulletShell;

    public static int BULLET_DAMAGE;
    public static int BULLET_COUNT;

    public static bool pistolEquipped;
    public static bool shotgunEquipped;
    public static bool shotgun_02Equipped;
    public static bool assaultEquipped;
    public static bool assault_02Equipped;
    public static bool assault_03Equipped;
    public static bool smgEquipped;
    public static bool smg_02Equipped;
    public static bool smg_03Equipped;
    public static bool rifle_01Equipped;
    public static bool rifle_02Equipped;
    public static bool machineGun_01Equipped;
    public static bool machineGun_02Equipped;
    public static bool rocketLauncherEquipped;

    private void Awake()
    {
        ResetWeaponEquipped();
        //SetWeaponEquipped(weaponName);
        BULLET_DAMAGE = bulletDamage;
        BULLET_COUNT = bulletCount;
    }

    public bool SetWeaponEquipped(string weaponName)
    {
        switch (weaponName)
        {
            case "pistol":
                Debug.Log("Pistol Equipped!");
                return pistolEquipped = true;
            case "shotgun":
                Debug.Log("Shotgun Equipped!");
                return shotgunEquipped = true;
            case "shotgun_02":
                Debug.Log("Shotgun_02 Equipped!");
                return shotgun_02Equipped = true;
            case "assault":
                Debug.Log("Assault Equipped!");
                return assaultEquipped = true;
            case "assault_02":
                Debug.Log("Assault_02 Equipped!");
                return assault_02Equipped = true;
            case "assault_03":
                Debug.Log("Assault_03 Equipped!");
                return assault_03Equipped = true;
            case "smg":
                Debug.Log("SMG Equipped!");
                return smgEquipped = true;
            case "smg_02":
                Debug.Log("SMG_02 Equipped!");
                return smg_02Equipped = true;
            case "smg_03":
                Debug.Log("SMG_03 Equipped!");
                return smg_03Equipped = true;
            case "rifle_01":
                Debug.Log("Rifle_01 Equipped!");
                return rifle_01Equipped = true;
            case "rifle_02":
                Debug.Log("Rifle_02 Equipped!");
                return rifle_02Equipped = true;
            case "machine_gun_01":
                Debug.Log("MachineGun_01 Equipped!");
                return machineGun_01Equipped = true;
            case "machine_gun_02":
                Debug.Log("MachineGun_02 Equipped!");
                return machineGun_02Equipped = true;
            case "rocket_launcher":
                Debug.Log("Rocket Launcher Equipped!");
                return rocketLauncherEquipped = true;
            default:
                Debug.Log("Invalid weapon - pistol equipped by default...");
                return pistolEquipped = true;
        }
    }

    private void ResetWeaponEquipped()
    {
        pistolEquipped = false;
        shotgunEquipped = false;
        shotgun_02Equipped = false;
        assaultEquipped = false;
        assault_02Equipped = false;
        assault_03Equipped = false;
        smgEquipped = false;
        smg_02Equipped = false;
        smg_03Equipped = false;
        rifle_01Equipped = false;
        rifle_02Equipped = false;
        machineGun_01Equipped = false;
        machineGun_02Equipped = false;
        rocketLauncherEquipped = false;
    }
}


