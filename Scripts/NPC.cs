using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private LayerMask shootColliderLayerMask;

    private Transform pfBulletProjectile;
    private Transform spawnBulletTransform;
    private ActiveWeapon activeWeapon;
    private WeaponRecoil recoil;
    private ItemManager itemManager;
    private Transform bulletTransform;

    // Start is called before the first frame update
    void Start()
    {
        itemManager = FindObjectOfType<ItemManager>();
        itemManager.SetLevelNPCAsCaller();
        itemManager.EquipItems();

        activeWeapon = GetComponent<ActiveWeapon>();
        pfBulletProjectile = activeWeapon.GetWeaponBullets();
        spawnBulletTransform = activeWeapon.GetSpawnBulletTransform();
        recoil = activeWeapon.GetWeaponRecoil();

        InvokeRepeating(nameof(Shoot), 0.2f, 1f);
    }

    private void Shoot()
    {
        bulletTransform = Instantiate(pfBulletProjectile, spawnBulletTransform.position, spawnBulletTransform.rotation);
        recoil.GenerateRecoil(activeWeapon.GetWeaponName());
        activeWeapon.GetWeaponMuzzleFlash().Play();
        if (activeWeapon.GetWeaponBulletShell() != null)
        {
            activeWeapon.GetWeaponBulletShell().Emit(1);
        }
    }
}
