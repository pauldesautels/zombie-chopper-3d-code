using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertZoneDetection : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponentInParent<ZombieController>();
        BossController boss = other.GetComponentInParent<BossController>();

        if (zombie != null && zombie.GetIsDead() == false)
        {
            if (zombie.GetIsAlerted() == false)
            {
                zombie.AlertZombie();
            }
        }

        if (boss != null && boss.GetIsDead() == false)
        {
            if (boss.GetIsAlerted() == false)
            {
                boss.AlertZombie();
            }
        }
    }
}
