using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private LayerMask shootColliderLayerMask;
    [SerializeField] private LayerMask tutorialColliderLayerMask;
    [SerializeField] private Transform aimTargetTransform;
    [SerializeField] private InputManager inputManager;
    [SerializeField] ParentConstraint parentConstraint;

    private Transform pfBulletProjectile;
    private Transform spawnBulletTransform;
    private ActiveWeapon activeWeapon;
    private WeaponRecoil recoil;
    private GameObject tutorialHitZone;
    private List<GameObject> playerBulletTrails = new List<GameObject>();
    private List<GameObject> playerBulletProjectiles = new List<GameObject>();
    private string bulletTag = "Bullet";

    private bool hasTakenShot;

    // Start is called before the first frame update
    void Start()
    {
        Invoke(nameof(Init), .001f); // Level_04 was having execution order bug.
    }

    private void Init()
    {
        activeWeapon = GetComponent<ActiveWeapon>();
        pfBulletProjectile = activeWeapon.GetWeaponBullets();
        spawnBulletTransform = activeWeapon.GetSpawnBulletTransform();
        recoil = activeWeapon.GetWeaponRecoil();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (inputManager.GetIsUsingTouchControls() == false)
    //    {
    //        if (!GameManager.isGameOver && !GameManager.isLevelComplete && !GameManager.isPaused && GameManager.isReadyToShoot)
    //        {
    //            Vector3 mouseWorldPosition = Vector3.zero;
    //            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

    //            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, shootColliderLayerMask))
    //            {
    //                mouseWorldPosition = raycastHit.point;
    //            }

    //            if (!TutorialManager.isShootingTutorialActive && !TutorialManager.isExplodeTutorialActive && !TutorialManager.isGlassTutorialActive && !TutorialManager.isFallTutorialActive
    //                &&!TutorialManager.isBridgeTutorialActive)
    //            {
    //                if (Input.GetMouseButtonDown(0) && raycastHit.transform != null && !raycastHit.transform.CompareTag(bulletTag))
    //                {
    //                    Shoot(mouseWorldPosition, raycastHit);
    //                }
    //            }
    //            else
    //            {
    //                if (Physics.Raycast(ray, out RaycastHit hit, 999f, tutorialColliderLayerMask))
    //                {
    //                    mouseWorldPosition = hit.point;

    //                    tutorialHitZone = hit.collider.gameObject;
    //                }

    //                if (Input.GetMouseButtonDown(0))
    //                {
    //                    if (tutorialHitZone != null && hit.collider != null)
    //                    {
    //                        Shoot(mouseWorldPosition, raycastHit);
    //                    }
    //                    else
    //                    {
    //                        Debug.Log("MISSED TUTORIAL HIT ZONE!");
    //                    }
    //                }
    //            }
    //        }
    //    }
    //}

    public void Shoot(Vector3 worldPosition, RaycastHit raycastHit)
    {
        if (RaycastWeapon.pistolEquipped)
        {
            AudioManager.Instance.Play_sfx_weapon_pistol();
        }
        else if (RaycastWeapon.shotgunEquipped)
        {
            AudioManager.Instance.Play_sfx_weapon_shotgun();
        }
        else if (RaycastWeapon.shotgun_02Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_shotgun2();
        }
        else if (RaycastWeapon.assaultEquipped)
        {
            AudioManager.Instance.Play_sfx_weapon_assault1();
        }
        else if (RaycastWeapon.smgEquipped)
        {
            AudioManager.Instance.Play_sfx_weapon_smg1();
        }
        else if (RaycastWeapon.smg_03Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_smg3();
        }
        else if (RaycastWeapon.rifle_01Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_rifle1();
        }
        else if (RaycastWeapon.smg_02Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_smg2();
        }
        else if (RaycastWeapon.assault_02Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_assault2();
        }
        else if (RaycastWeapon.rifle_02Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_rifle2();
        }
        else if (RaycastWeapon.assault_03Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_assault3();
        }
        else if (RaycastWeapon.rocketLauncherEquipped)
        {
            AudioManager.Instance.Play_sfx_weapon_rocketlauncher();
        }
        else if (RaycastWeapon.machineGun_01Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_machinegun1();
        }
        else if (RaycastWeapon.machineGun_02Equipped)
        {
            AudioManager.Instance.Play_sfx_weapon_machinegun2();
        }





        Vector3 aimDir = (worldPosition - spawnBulletTransform.position).normalized;
        MakeBullet(aimDir, raycastHit); // 1 bullet.
        if (RaycastWeapon.shotgunEquipped || RaycastWeapon.shotgun_02Equipped) // 3 simultaneous bullet.
        {
            Vector3 leftOffset = new Vector3(aimDir.x + .01f, aimDir.y, aimDir.z);
            Vector3 rightOffset = new Vector3(aimDir.x - .01f, aimDir.y, aimDir.z);
            MakeBullet(leftOffset, raycastHit);
            MakeBullet(rightOffset, raycastHit);
            if (RaycastWeapon.shotgun_02Equipped) // 4 simultaneous bullet.
            {
                Vector3 upOffset = new Vector3(aimDir.x, aimDir.y + .01f, aimDir.z);
                MakeBullet(upOffset, raycastHit);
            }
        }
        if (RaycastWeapon.assaultEquipped || RaycastWeapon.rifle_01Equipped) // 2 delayed bullet.
        {
            StartCoroutine(WaitMakeBullet(.15f, aimDir, raycastHit));
        }
        if (RaycastWeapon.smgEquipped || RaycastWeapon.smg_02Equipped || RaycastWeapon.smg_03Equipped || RaycastWeapon.assault_02Equipped || RaycastWeapon.assault_03Equipped
            || RaycastWeapon.rifle_02Equipped || RaycastWeapon.machineGun_01Equipped || RaycastWeapon.machineGun_02Equipped) // 3 delayed bullet.
        {
            float randomX_01 = Random.Range(-0.01f, 0.01f);
            float randomX_02 = Random.Range(-0.01f, 0.01f);
            float randomY_01 = Random.Range(-0.01f, 0.01f);
            float randomY_02 = Random.Range(-0.01f, 0.01f);
            Vector3 randomOffset_01 = new Vector3(aimDir.x + randomX_01, aimDir.y + randomY_01, aimDir.z);
            Vector3 randomOffset_02 = new Vector3(aimDir.x + randomX_02, aimDir.y + randomY_02, aimDir.z);
            StartCoroutine(WaitMakeBullet(.1f, randomOffset_01, raycastHit));
            StartCoroutine(WaitMakeBullet(.2f, randomOffset_02, raycastHit));

            if (RaycastWeapon.assault_02Equipped || RaycastWeapon.assault_03Equipped || RaycastWeapon.rifle_02Equipped || RaycastWeapon.machineGun_01Equipped
                || RaycastWeapon.machineGun_02Equipped) // 4 delayed bullet.
            {
                float randomX_03 = Random.Range(-0.01f, 0.01f);
                float randomY_03 = Random.Range(-0.01f, 0.01f);
                Vector3 randomOffset_03 = new Vector3(aimDir.x + randomX_03, aimDir.y + randomY_03, aimDir.z);
                StartCoroutine(WaitMakeBullet(.3f, randomOffset_03, raycastHit));
            }

            if (RaycastWeapon.machineGun_01Equipped || RaycastWeapon.machineGun_02Equipped) // 5 delayed bullet.
            {
                float randomX_03 = Random.Range(-0.01f, 0.01f);
                float randomY_03 = Random.Range(-0.01f, 0.01f);
                Vector3 randomOffset_03 = new Vector3(aimDir.x + randomX_03, aimDir.y + randomY_03, aimDir.z);
                StartCoroutine(WaitMakeBullet(.3f, randomOffset_03, raycastHit));
            }
        }
        if (activeWeapon.GetWeaponBulletShell() != null)
        {
            activeWeapon.GetWeaponBulletShell().Emit(1);
        }
        recoil.GenerateRecoil(activeWeapon.GetWeaponName());

        //* Tutorial functionality.
        hasTakenShot = true;
        if (TutorialManager.isShootingTutorialActive)
        {
            FindObjectOfType<TutorialManager>().DeactivateTutorial();
            ZombieController[] zombies = FindObjectsOfType<ZombieController>();
            foreach (ZombieController zombie in zombies)
            {
                zombie.FindShootTutorialZombie();
            }
            TutorialManager.isShootingTutorialActive = false;
        }
        if (TutorialManager.isExplodeTutorialActive)
        {
            FindObjectOfType<TutorialManager>().DeactivateTutorial();
            Hazard_Exploding[] explodingBarrels = FindObjectsOfType<Hazard_Exploding>();
            foreach (Hazard_Exploding explodingBarrel in explodingBarrels)
            {
                explodingBarrel.FindExplodeTutorialHazard();
            }
            TutorialManager.isExplodeTutorialActive = false;
        }
        if (TutorialManager.isGlassTutorialActive)
        {
            FindObjectOfType<TutorialManager>().DeactivateTutorial();
            GlassPane[] glassPanes = FindObjectsOfType<GlassPane>();
            foreach (GlassPane glassPane in glassPanes)
            {
                glassPane.FindGlassTutorialHazard();
            }
            TutorialManager.isGlassTutorialActive = false;
        }
        if (TutorialManager.isFallTutorialActive)
        {
            FindObjectOfType<TutorialManager>().DeactivateTutorial();
            Hazard_Falling[] hangingContainers = FindObjectsOfType<Hazard_Falling>();
            foreach (Hazard_Falling hangingContainer in hangingContainers)
            {
                hangingContainer.FindFallTutorialHazard();
            }
            TutorialManager.isFallTutorialActive = false;
        }
        if (TutorialManager.isBridgeTutorialActive)
        {
            FindObjectOfType<TutorialManager>().DeactivateTutorial();
            BridgeInteractSwitch[] bridgeSwitches = FindObjectsOfType<BridgeInteractSwitch>();
            foreach (BridgeInteractSwitch bridgeSwitch in bridgeSwitches)
            {
                bridgeSwitch.FindBridgeTutorialSwitch();
            }
            TutorialManager.isBridgeTutorialActive = false;
        }
        //*
    }

    // private IEnumerator SpawnTrail(TrailRenderer trail, RaycastHit raycastHit)
    // {
    //     float time = 0;
    //     Vector3 startPosition = spawnBulletTransform.position;

    //     while (time < 1)
    //     {
    //         trail.transform.position = Vector3.Lerp(startPosition, raycastHit.point, time);
    //         time += Time.deltaTime / trail.time;

    //         yield return null;
    //     }

    //     //trail.transform.position = raycastHit.point;
    //     Destroy(trail.gameObject, trail.time);
    // }

    public bool GetHasTakenShot()
    {
        return hasTakenShot;
    }

    private void MakeBullet(Vector3 aimDir, RaycastHit raycastHit)
    {
        Transform bulletProjectileTrans = Instantiate(pfBulletProjectile, spawnBulletTransform.position, Quaternion.LookRotation(aimDir, Vector3.up));
        GameObject bulletProjectile = bulletProjectileTrans.gameObject;

        aimTargetTransform.position = raycastHit.point;
        activeWeapon.GetWeaponMuzzleFlash().Play();
        //TrailRenderer trail = Instantiate(activeWeapon.GetBulletTrail(), spawnBulletTransform.position, Quaternion.identity);
        // StartCoroutine(SpawnTrail(trail, raycastHit));
        playerBulletProjectiles.Add(bulletProjectile);
        //playerBulletTrails.Add(trail.gameObject);
    }

    public IEnumerator WaitMakeBullet(float delay, Vector3 aimDir, RaycastHit raycastHit)
    {
        yield return new WaitForSeconds(delay);

        MakeBullet(aimDir, raycastHit);
        if (RaycastWeapon.smgEquipped || RaycastWeapon.smg_02Equipped || RaycastWeapon.smg_03Equipped
            || RaycastWeapon.assaultEquipped || RaycastWeapon.assault_02Equipped || RaycastWeapon.assault_03Equipped
            || RaycastWeapon.rifle_01Equipped || RaycastWeapon.rifle_02Equipped || RaycastWeapon.machineGun_01Equipped
            || RaycastWeapon.machineGun_02Equipped)
        {
            activeWeapon.GetWeaponBulletShell().Emit(1);
        }
    }

    public void ConstrainPlayer(bool isConstrained)
    {
        parentConstraint.enabled = isConstrained;
    }

    public void ClearAllPlayerBulletProjectiles()
    {
        foreach (GameObject projectile in playerBulletProjectiles)
        {
            Destroy(projectile);
        }
    }

    //public void ClearAllPlayerBulletTrails()
    //{
    //    foreach (GameObject trails in playerBulletTrails)
    //    {
    //        Destroy(trails);
    //    }
    //}
}
