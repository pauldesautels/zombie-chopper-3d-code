using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBossSpawner : MonoBehaviour
{
    [SerializeField] private BossController boss;

    private void OnTriggerEnter(Collider other)
    {
        RunnerController runner = other.GetComponent<RunnerController>();
        if (runner != null)
        {
            boss.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
