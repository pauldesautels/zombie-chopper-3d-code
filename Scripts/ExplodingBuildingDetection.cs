using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodingBuildingDetection : MonoBehaviour
{
    private ShieldManager shieldManager;
    private bool hasDetectedRunner;

    private void Start()
    {
        shieldManager = FindObjectOfType<ShieldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponentInParent<ZombieController>();
        RunnerController runner = other.GetComponentInParent<RunnerController>();

        if (zombie != null)
        {
            if (zombie.GetIsExploded() == false)
            {
                zombie.SquishDeath();
                Hazard_Building hazard_Building = GetComponentInParent<Hazard_Building>();
                hazard_Building.IncreaseZombiesKilledCount();
            }

            if (!LevelUI.hasShownBuildingUI && !GameManager.isGameOver && !GameManager.isLevelComplete)
            {
                FindObjectOfType<LevelUI>().ShowBuildingTextMesh();
                LevelUI.hasShownBuildingUI = true;
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
                    runner.Die();
                }
            }
            hasDetectedRunner = true;
        }
    }
}
