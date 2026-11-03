using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchDetection : MonoBehaviour
{
    private bool hasShownLaunchUI;

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponentInParent<ZombieController>();
        RunnerController runner = other.GetComponent<RunnerController>();

        if (zombie != null)
        {
            if (zombie.GetIsGettingLaunched() == false)
            {
                zombie.LaunchDeath();
            }
            if (!hasShownLaunchUI && !GameManager.isGameOver && !GameManager.isLevelComplete)
            {
                FindObjectOfType<LevelUI>().ShowLaunchedTextMesh();
                hasShownLaunchUI = true;
            }
        }

        if (runner != null)
        {
            runner.SetIsGettingLaunched(true);
            runner.Die();
        }
    }
}
