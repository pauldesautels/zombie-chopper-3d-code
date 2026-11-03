using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor.Animations;

public class ActiveWeapon : MonoBehaviour
{
    [SerializeField] private Transform weaponParent;
    [SerializeField] private Transform weaponLeftGrip;
    [SerializeField] private Transform weaponRightGrip;
    [SerializeField] private Transform weaponLeftHint;
    [SerializeField] private Transform weaponRightHint;
    [SerializeField] private Animator rigController;

    private RaycastWeapon weapon;
    private Animator animator;
    private AnimatorOverrideController overrides;
    private WeaponRecoil recoil;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        overrides = animator.runtimeAnimatorController as AnimatorOverrideController;
    }

    public void EquipWeapon(RaycastWeapon newWeapon)
    {
        weapon = newWeapon;
        // Set weapon position.
        weapon.transform.parent = weaponParent;
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;
        // Set animation clip.
        overrides["weapon_anim_empty"] = weapon.weaponAnimation;
        AssignWeaponRecoil(weapon);
    }

    public void AssignWeaponRecoil(RaycastWeapon newWeapon)
    {
        recoil = newWeapon.GetComponent<WeaponRecoil>();
        recoil.rigController = rigController;
    }

    public Transform GetWeaponBullets()
    {
        return weapon.pfBulletProjectile;
    }

    public Transform GetSpawnBulletTransform()
    {
        return weapon.spawnBulletTransform;
    }

    public WeaponRecoil GetWeaponRecoil()
    {
        return recoil;
    }

    public string GetWeaponName()
    {
        return weapon.weaponName;
    }

    public ParticleSystem GetWeaponMuzzleFlash()
    {
        return weapon.muzzleFlash;
    }

    public TrailRenderer GetBulletTrail()
    {
        return weapon.bulletTrail;
    }

    public ParticleSystem GetWeaponBulletShell()
    {
        return weapon.bulletShell;
    }

    public int GetWeaponBulletDamage()
    {
        return weapon.bulletDamage;
    }

    //[ContextMenu("Save weapon pose")]
    //private void SaveWeaponPose()
    //{
    //    GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
    //    recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
    //    recorder.BindComponentsOfType<Transform>(weaponLeftGrip.gameObject, false);
    //    recorder.BindComponentsOfType<Transform>(weaponRightGrip.gameObject, false);
    //    recorder.BindComponentsOfType<Transform>(weaponLeftHint.gameObject, false);
    //    recorder.BindComponentsOfType<Transform>(weaponRightHint.gameObject, false);
    //    recorder.TakeSnapshot(0.0f);
    //    recorder.SaveToClip(weapon.weaponAnimation);
    //}
}
