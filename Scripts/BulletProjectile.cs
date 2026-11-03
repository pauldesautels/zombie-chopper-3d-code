using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private Transform vfxHitZombie;
    [SerializeField] private Transform vfxMiss;
    [SerializeField] private Transform vfxExplosion;

    private float velocity;
    private float explosionForce = 2000f;
    private Rigidbody bulletRigidbody;
    private ShieldManager shieldManager;
    private LevelUI levelUI;
    private string headshotTag = "Headshot";

    private bool hasHitZombie;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
        shieldManager = FindObjectOfType<ShieldManager>();
        levelUI = FindObjectOfType<LevelUI>();
        Collider collider = GetComponent<Collider>();
        Physics.IgnoreCollision(collider, collider);
    }

    private void Start()
    {
        if (!RaycastWeapon.smg_02Equipped && !RaycastWeapon.smg_03Equipped && !RaycastWeapon.rifle_02Equipped && !RaycastWeapon.machineGun_01Equipped
            && !RaycastWeapon.machineGun_02Equipped)
        {
            //TEMP ORIGINAL 
            // velocity = 75f;
            velocity = 100f;
        }
        else
        {
            velocity = 100f * 1.25f;
        }
        bulletRigidbody.velocity = transform.forward * velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject.name != "pfBulletProjectile_Rocket(Clone)")
        {
            FindBulletCollisions(collision);
        }
        else
        {
            FindBulletCollisions(collision);
            int radius = 2;
            Collider[] collidersInRange = Physics.OverlapSphere(transform.position, radius);
            foreach (Collider collider in collidersInRange)
            {
                FindExplosionCollisions(collider);
            }
            Instantiate(vfxExplosion, transform.position, Quaternion.identity);
        }
    }

    private void FindBulletCollisions(Collision collision)
    {
        RunnerController runner = collision.gameObject.GetComponentInParent<RunnerController>();
        ZombieController zombie = collision.gameObject.GetComponentInParent<ZombieController>();
        BossController boss = collision.gameObject.GetComponentInParent<BossController>();
        Hazard_Exploding explodingHazard = collision.gameObject.GetComponentInParent<Hazard_Exploding>();
        BulletProjectile bullet = collision.gameObject.GetComponent<BulletProjectile>();
        GlassPane glassPane = collision.gameObject.GetComponentInParent<GlassPane>();
        BridgeInteractSwitch bridgeSwitch = collision.gameObject.GetComponentInParent<BridgeInteractSwitch>();
        WindowPane windowPane = collision.gameObject.GetComponentInParent<WindowPane>();

        if (runner != null)
        {
            runner.IncreaseNumberOfWarningsCount();
            if (!GameManager.isLevelComplete)
            {
                if (runner.GetHasBeenWarned())
                {
                    if (shieldManager.GetShieldCount() > 0)
                    {
                        if (!RunnerController.isUsingShield)
                        {
                            shieldManager.UseRunnerShield();
                        }
                    }
                    else
                    {
                        if (!runner.GetIsDead())
                        {
                            if (levelUI.GetIsBloodOn() == 1)
                            {
                                Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                            }
                            runner.Die();
                        }
                    }
                }
                else
                {
                    runner.ShowWarningText();
                }

                Destroy(gameObject);
            }
        }

        if (zombie != null)
        {
            if (!zombie.GetIsDead())
            {
                if (collision.gameObject.CompareTag(headshotTag))
                {
                    zombie.CreateDamagePopUp(transform.position);
                }
                if (levelUI.GetIsBloodOn() == 1)
                {
                    Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                }
                //zombie.RegularDeath(transform.forward);
                zombie.RegularDeath(Camera.main.transform.forward);
            }
            hasHitZombie = true;
            Destroy(gameObject);
        }

        if (boss != null)
        {
            if (!boss.GetIsDead())
            {
                HealthManager healthManager = boss.GetComponent<HealthManager>();
                healthManager.TakeDamage(RaycastWeapon.BULLET_DAMAGE * RaycastWeapon.BULLET_COUNT);
                if (healthManager.GetCurrentHealth() == 0)
                {
                    boss.RegularDeath(transform.forward);
                }
                if (levelUI.GetIsBloodOn() == 1)
                {
                    Instantiate(vfxHitZombie, transform.position, Quaternion.identity);
                }
                boss.CreateDamagePopUp(transform.position, Camera.main.transform.rotation);
            }
            hasHitZombie = true;
            Destroy(gameObject);
        }

        if (explodingHazard != null)
        {
            explodingHazard.Explode();
            Destroy(gameObject);
        }

        if (glassPane != null)
        {
            glassPane.ShowBrokenGlassPane();
            Instantiate(vfxMiss, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (windowPane != null)
        {
            windowPane.CreateBrokenWindow();
            Instantiate(vfxMiss, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (bridgeSwitch != null)
        {
            bridgeSwitch.ActivateBridge();
            Instantiate(vfxMiss, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (runner == null && zombie == null && boss == null && explodingHazard == null && bullet == null && glassPane == null && bridgeSwitch == null)
        {
            // Missed
            if (!hasHitZombie)
            {
                Instantiate(vfxMiss, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

    }

    private void FindExplosionCollisions(Collider collider)
    {
        ZombieController zombie = collider.GetComponentInParent<ZombieController>();
        BossController boss = collider.GetComponentInParent<BossController>();
        Hazard_Exploding explodingHazard = collider.GetComponentInParent<Hazard_Exploding>();
        BulletProjectile bullet = collider.GetComponent<BulletProjectile>();
        GlassPane glassPane = collider.GetComponentInParent<GlassPane>();

        if (zombie != null)
        {
            if (zombie.GetIsDead() == false)
            {
                int radius = 2;
                Vector3 explosionPos = transform.position;
                zombie.ExplosionDeath(explosionPos);
                Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
                foreach (Collider hit in colliders)
                {
                    Rigidbody rb = hit.GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        rb.AddExplosionForce(explosionForce, explosionPos, radius, 3.0F);
                    }
                }
                if (levelUI.GetIsBloodOn() == 1)
                {
                    Instantiate(vfxHitZombie, zombie.transform.position, Quaternion.identity);
                }
            }
            hasHitZombie = true;
        }

        if (boss != null)
        {
            if (!boss.GetIsDead())
            {
                HealthManager healthManager = boss.GetComponent<HealthManager>();
                healthManager.TakeDamage(RaycastWeapon.BULLET_DAMAGE * RaycastWeapon.BULLET_COUNT);
                if (healthManager.GetCurrentHealth() == 0)
                {
                    boss.RegularDeath(transform.forward);
                }
                boss.CreateDamagePopUp(boss.transform.position, transform.rotation);
            }
            if (levelUI.GetIsBloodOn() == 1)
            {
                Instantiate(vfxHitZombie, boss.transform.position, Quaternion.identity);
            }
            hasHitZombie = true;
        }

        if (explodingHazard != null)
        {
            explodingHazard.Explode();
            Destroy(gameObject);
        }

        if (glassPane != null)
        {
            glassPane.ShowBrokenGlassPane();
            Destroy(gameObject);
        }

        if (zombie == null && boss == null && explodingHazard == null && bullet == null && glassPane == null && collider.gameObject.layer != 2)
        {
            // Missed
            if (!hasHitZombie)
            {
                Instantiate(vfxMiss, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
