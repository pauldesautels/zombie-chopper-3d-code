using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointSetter : MonoBehaviour
{
    [SerializeField] private GameObject[] spawnPointsToActivate;
    [SerializeField] private GameObject[] spawnPointsToDeactivate;
    [SerializeField] private ZombieSpawner zombieSpawner;

    private void OnTriggerEnter(Collider other)
    {
        RunnerController runner = other.GetComponent<RunnerController>();
        if (runner != null)
        {
            if (gameObject.name != "StopZombieSpawnTrigger")
            {
                SetSpawnPoints();
            } else
            {
                FindObjectOfType<ZombieSpawner>().StopSpawning();
            }
            gameObject.SetActive(false);
        }
    }

    private void SetSpawnPoints()
    {
        foreach (GameObject spawnPoint in spawnPointsToActivate)
        {
            spawnPoint.SetActive(true);
        }

        foreach (GameObject spawnPoint in spawnPointsToDeactivate)
        {
            spawnPoint.SetActive(false);
        }

        zombieSpawner.CheckActiveSpawnPositions();
    }
}
