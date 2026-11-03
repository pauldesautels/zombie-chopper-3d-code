using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaughtZoneDetection : MonoBehaviour
{
    private ShieldManager shieldManager;

    private void Start()
    {
        shieldManager = FindObjectOfType<ShieldManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponentInParent<ZombieController>();
        BossController boss = other.GetComponentInParent<BossController>();

        if (zombie != null && zombie.GetIsDead() == false) //&& !GameManager.isGameOver)
        {
            if (!GameManager.isGameOver)
            {
                if (shieldManager.GetShieldCount() > 0)
                {
                    shieldManager.UseZombieShield();
                    FindAlertedZombies();
                }
                else
                {
                    if (zombie.GetHasCaughtPlayer() == false)
                    {
                        zombie.CaughtPlayer();
                    }
                }
            } else
            {
                zombie.ShowAttackAnim();
            }
        }

        if (boss != null && boss.GetIsDead() == false) //&& !GameManager.isGameOver)
        {
            if (!GameManager.isGameOver)
            {
                if (shieldManager.GetShieldCount() > 0)
                {
                    shieldManager.UseZombieShield();
                    FindAlertedZombies();
                }
                else
                {
                    if (boss.GetHasCaughtPlayer() == false)
                    {
                        boss.CaughtPlayer();
                    }
                }
            } else
            {
                boss.ShowAttackAnim();
            }
        }
    }

    private void FindAlertedZombies()
    {
        ZombieController[] zombies = FindObjectsOfType<ZombieController>();
        BossController boss = FindObjectOfType<BossController>();
        foreach (ZombieController zombieInstance in zombies)
        {
            if (zombieInstance.GetIsAlerted() == true)
            {
                zombieInstance.SquishDeath();
            }
        }
        if (boss != null)
        {
            if (boss.GetIsAlerted() == true)
            {
                boss.SquishDeath();
            }
        }
    }
}
