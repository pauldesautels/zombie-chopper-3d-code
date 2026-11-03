using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Colliding : MonoBehaviour
{
    [SerializeField] private int force;

    private int zombiesKilledCount;

    private bool isActivated;
    private bool hasShownCollideUI;

    public void ApplyForce()
    {
        if (!isActivated)
        {
            Rigidbody rb = gameObject.AddComponent<Rigidbody>();
            rb.useGravity = false;
            rb.AddForce(-transform.forward * force, ForceMode.VelocityChange);
            Destroy(gameObject, 3f);
            isActivated = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isActivated)
        {
            ZombieController zombie = other.GetComponentInParent<ZombieController>();

            if (zombie != null)
            {
                if (zombie.GetIsExploded() == false)
                {
                    zombie.ExplosionDeath(transform.forward);
                    zombiesKilledCount++;
                }

                if (!hasShownCollideUI && !GameManager.isGameOver && !GameManager.isLevelComplete)
                {
                    FindObjectOfType<LevelUI>().ShowCollideTextMesh();
                    hasShownCollideUI = true;
                }
            }
        }
    }

    private void OnDestroy()
    {
        if (zombiesKilledCount >= 5 && zombiesKilledCount <= 9)
        {
            FindObjectOfType<LevelUI>().ShowKilltacularTextMesh();
        }
        if (zombiesKilledCount >= 10 && zombiesKilledCount <= 14)
        {
            FindObjectOfType<LevelUI>().ShowKillFrenzyTextMesh();
        }
        if (zombiesKilledCount >= 15)
        {
            FindObjectOfType<LevelUI>().ShowKilltrocityTextMesh();
        }
    }
}
