using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFallDetection : MonoBehaviour
{
    private bool hasShownFallUI;

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponentInParent<ZombieController>();

        if (zombie != null)
        {
            if (zombie.GetIsFalling() == false)
            {
                zombie.FallDeath();
            }

            if (!hasShownFallUI && !GameManager.isGameOver && !GameManager.isLevelComplete)
            {
                FindObjectOfType<LevelUI>().ShowFallTextMesh();
                hasShownFallUI = true;
            }
        }
    }
}
