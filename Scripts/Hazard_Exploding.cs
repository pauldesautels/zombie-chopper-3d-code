using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lofelt.NiceVibrations;

public class Hazard_Exploding : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private GameObject vfxExplosion;
    [SerializeField] private ParticleSystem vfxFire;
    [SerializeField] private Material blinkMaterial;
    [SerializeField] private Image explodeImage;
    [SerializeField] private Image aimCircleImage;
    [SerializeField] private GameObject tutorialHitZone;
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private Transform vfxHitZombie;

    private int explosionDamage = 1000;
    private float explosionForce = 2000f;
    private Material originalMeshMaterial;
    private MeshRenderer meshRenderer;
    private int zombiesKilledCount;
    private LevelUI levelUI;

    [Header("Blinking Setup")]
    [SerializeField] private float interval = .2f;
    [SerializeField] private float startDelay = 0.5f;

    private bool isExploding;
    private bool isTriggered;
    private bool isBlinking;
    private bool isShowingBlinkMaterial;
    private static int explodingHazardsHit;
    private bool isDelayed;
    private Cinemachine.CinemachineImpulseSource cameraShake;

    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        originalMeshMaterial = meshRenderer.material;
        levelUI = FindObjectOfType<LevelUI>();

        StartBlink();
    }

    public void Explode()
    {
        cameraShake = GetComponent<Cinemachine.CinemachineImpulseSource>();
        cameraShake.GenerateImpulse(1);
        SetIsExploding(true);
        AudioManager.Instance.Play_sfx_explosion_barrel_Random();
        if (levelUI.GetIsHapticsOn() == 1)
        {
            //HapticPatterns.PlayPreset(HapticPatterns.PresetType.MediumImpact);
            HapticPatterns.PlayPreset(HapticPatterns.PresetType.HeavyImpact);
        }

        Instantiate(vfxExplosion, transform.position, transform.rotation);
        if (vfxFire != null)
        {
            ParticleSystem tempFire = Instantiate(vfxFire, transform.position, transform.rotation);
            Destroy(tempFire.gameObject, 5f);
        }
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider collider in collidersInRange)
        {
            
            ZombieController zombie = collider.GetComponent<ZombieController>();
            BossController boss = collider.GetComponent<BossController>();
            Hazard_Exploding[] explodingHazards = collider.GetComponents<Hazard_Exploding>();
            Hazard_Colliding collidingHazard = collider.GetComponent<Hazard_Colliding>();
            Hazard_Falling fallingHazard = collider.GetComponentInParent<Hazard_Falling>();
            Hazard_Building buildingHazard = collider.GetComponentInParent<Hazard_Building>();
            GlassPane glassPane = collider.GetComponentInParent<GlassPane>();

            if (zombie != null)
            {
                if (zombie.GetIsExploded() == false)
                {
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
                    zombiesKilledCount++;
                }
            }

            if (boss != null)
            {
                HealthManager healthManager = boss.GetComponent<HealthManager>();
                healthManager.TakeDamage(explosionDamage);
                if (healthManager.GetCurrentHealth() == 0)
                {
                    Vector3 explosionPos = transform.position;
                    boss.ExplosionDeath(explosionPos);
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
                        Instantiate(vfxHitZombie, boss.transform.position, Quaternion.identity);
                    }
                    zombiesKilledCount++;
                }
            }

            if (explodingHazards != null)
            {
                foreach (Hazard_Exploding explodingHazard in explodingHazards)
                {
                    if (!explodingHazard.GetIsExploding())
                    {
                        if (!explodingHazard.GetIsTriggered())
                        {
                            explodingHazardsHit++;
                            explodingHazard.SetIsTriggered(true);
                        }
                        explodingHazard.StartExplodeCountdown(explodingHazardsHit * .5f);
                    }
                }
            }

            if (collidingHazard != null)
            {
                collidingHazard.ApplyForce();
            }

            if (fallingHazard != null)
            {
                fallingHazard.DropHazard();
            }

            if (buildingHazard != null)
            {
                buildingHazard.CreateExplodingBuilding();
            }

            if (glassPane != null)
            {
                glassPane.ShowBrokenGlassPane();
            }
        }
        if (!GetIsDelayed())
        {
            FindObjectOfType<GameManager>().StartSlowMo(1f);
        }
        Destroy();
        if (tutorialManager != null)
        {
            FindExplodeTutorialHazard();
        }
    }

    private void StartBlink()
    {
        // Do not invoke the blink twice - needed if you need to start the blink from an external object
        if (GetIsBlinking())
        {
            return;
        }

        SetIsBlinking(true);
        InvokeRepeating("ToggleState", startDelay, interval);
    }

    private void ToggleState()
    {
        if (GetIsShowingBlinkMaterial())
        {
            Flash();
        }
        else
        {
            ResetColor();
        }

        isShowingBlinkMaterial = !isShowingBlinkMaterial;
    }

    public void Flash()
    {
        meshRenderer.material = blinkMaterial;
    }

    public void ResetColor()
    {
        meshRenderer.material = originalMeshMaterial;
    }

    public void StopFlash()
    {
        CancelInvoke("ToggleState");
        ResetColor();
    }

    public void SetExplodeImageActive(bool isActive)
    {
        explodeImage.gameObject.SetActive(isActive);
    }

    public void SetAimCircleImageActive(bool isActive)
    {
        aimCircleImage.gameObject.SetActive(isActive);
    }

    public void SetTutorialHitZoneActive(bool isActive)
    {
        tutorialHitZone.SetActive(isActive);
    }

    public void FindExplodeTutorialHazard()
    {
        if (explodeImage != null)
        {
            if (explodeImage.gameObject.activeInHierarchy)
            {
                SetExplodeImageActive(false);
            }
        }
        if (aimCircleImage != null)
        {
            if (aimCircleImage.gameObject.activeInHierarchy)
            {
                SetAimCircleImageActive(false);
            }
        }
        if (tutorialHitZone)
        {
            if (tutorialHitZone.activeInHierarchy)
            {
                SetTutorialHitZoneActive(false);
            }
        }

        if (tutorialManager != null)
        {
            tutorialManager.DeactivateTutorial();
        }
    }

    private void OnDestroy()
    {
        if (zombiesKilledCount >= 5 && zombiesKilledCount <= 9)
        {
            levelUI.ShowKilltacularTextMesh();
        }
        if (zombiesKilledCount >= 10 && zombiesKilledCount <= 14)
        {
            levelUI.ShowKillFrenzyTextMesh();
        }
        if (zombiesKilledCount >= 15)
        {
            levelUI.ShowKilltrocityTextMesh();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void SetIsExploding(bool _isExploding)
    {
        isExploding = _isExploding;
    }

    private void SetIsTriggered(bool _isTriggered)
    {
        isTriggered = _isTriggered;
    }

    private void SetIsBlinking(bool _isBlinking)
    {
        isBlinking = _isBlinking;
    }

    private void SetIsDelayed(bool _isDelayed)
    {
        isDelayed = _isDelayed;
    }

    public bool GetIsExploding()
    {
        return isExploding;
    }

    public bool GetIsTriggered()
    {
        return isTriggered;
    }

    private bool GetIsDelayed()
    {
        return isDelayed;
    }

    private bool GetIsBlinking()
    {
        return isBlinking;
    }

    private bool GetIsShowingBlinkMaterial()
    {
        return isShowingBlinkMaterial;
    }

    public void StartExplodeCountdown(float countdown)
    {
        StartCoroutine(WaitExplode(countdown));
    }

    private IEnumerator WaitExplode(float delay)
    {
        yield return new WaitForSeconds(delay);

        SetIsDelayed(true);
        Explode();
        explodingHazardsHit--;
    }
}
