using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private Queue<ZombieController> zombiePool = new Queue<ZombieController>();
    [SerializeField] private int poolStartSize = 10;

    [SerializeField] private ZombieController pfZombie;
    [SerializeField] private int spawnAmount = 20;
    [SerializeField] private float spawnFrequency = 2f;
    [SerializeField] private float spawnDelay = 0.2f;

    private List<Vector3> spawnPositionList;
    private string spawnPointsName = "ZombieSpawnPoints";

    private Vector3 tempPos;

    private void Awake()
    {
        CheckActiveSpawnPositions();
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolStartSize; i++)
        {
            ZombieController zombie = Instantiate(pfZombie);
            zombiePool.Enqueue(zombie);
            zombie.gameObject.SetActive(false);
        }

        InvokeRepeating(nameof(GetZombie), spawnDelay, spawnFrequency);
    }

    public ZombieController GetZombie()
    {
        if (!GameManager.isGameOver && !GameManager.isLevelComplete)
        {
            Vector3 spawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)];
            if (zombiePool.Count > 0)
            {
                ZombieController zombie = zombiePool.Dequeue();
                zombie.transform.position = spawnPosition;
                zombie.gameObject.SetActive(true);
                zombie.Init(ZombieDie);
                return zombie;
            }
            else
            {
                ZombieController zombie = Instantiate(pfZombie, spawnPosition, Quaternion.identity);
                zombie.Init(ZombieDie);
                return zombie;
            }
        } else
        {
            return null;
        }
    }

    public void ReturnZombie(ZombieController zombie)
    {
        zombiePool.Enqueue(zombie);
        zombie.gameObject.SetActive(false);
    }

    private void ZombieDie(ZombieController zombie)
    {
        ReturnZombie(zombie);
    }

    public void CheckActiveSpawnPositions()
    {
        spawnPositionList = new List<Vector3>();

        foreach (Transform spawnPosition in transform.Find(spawnPointsName))
        {
            if (spawnPosition.gameObject.activeInHierarchy)
            {
                spawnPositionList.Add(spawnPosition.position);
            }
        }

        Vector3 randomSpawnPosition = spawnPositionList[Random.Range(0, spawnPositionList.Count)];
        tempPos = randomSpawnPosition;
    }

    public void StopSpawning()
    {
        CancelInvoke(nameof(GetZombie));
    }
}
