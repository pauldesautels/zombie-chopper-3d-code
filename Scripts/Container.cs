using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    [SerializeField] private Transform vfxSmoke;

    private ShieldManager shieldManager;
    private int zombiesKilledCount;
    private bool hasDetectedRunner;
    private bool hasShownSquishUI;
    private bool hasShownSmoke;
    private string containerLandingZoneTag = "ContainerLandingZone";

    private void Start()
    {
        shieldManager = FindObjectOfType<ShieldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponentInParent<ZombieController>();
        RunnerController runner = other.GetComponent<RunnerController>();

        if (zombie != null)
        {
            zombie.FallDeath();
            zombiesKilledCount++;

            if (!hasShownSquishUI && !GameManager.isGameOver && !GameManager.isLevelComplete)
            {
                FindObjectOfType<LevelUI>().ShowSquishTextMesh();
                hasShownSquishUI = true;
            }
        }

        if (runner != null && !hasDetectedRunner)
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
                    runner.SetIsFallingThroughGlass(true);
                    runner.Die();
                }
            }
            hasDetectedRunner = true;
        }

        if (other.CompareTag(containerLandingZoneTag) && !hasShownSmoke)
        {
            ShowSmokeFX(other.transform.position);
            hasShownSmoke = true;
        }
    }

    private void OnDestroy()
    {
        if (zombiesKilledCount >= 10 && zombiesKilledCount <= 19)
        {
            FindObjectOfType<LevelUI>().ShowKilltacularTextMesh();
        }
        if (zombiesKilledCount >= 20 && zombiesKilledCount <= 29)
        {
            FindObjectOfType<LevelUI>().ShowKillFrenzyTextMesh();
        }
        if (zombiesKilledCount >= 30)
        {
            FindObjectOfType<LevelUI>().ShowKilltrocityTextMesh();
        }
    }

    private void ShowSmokeFX(Vector3 position)
    {
        Instantiate(vfxSmoke, position, Quaternion.identity);
    }
}
