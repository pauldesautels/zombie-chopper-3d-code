using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZombieSpawner : MonoBehaviour
{
    [SerializeField] private ZombieSpawner zombieSpawner;

    private void OnTriggerEnter(Collider other)
    {
        RunnerController runner = other.GetComponent<RunnerController>();
        if (runner != null)
        {
            zombieSpawner.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
