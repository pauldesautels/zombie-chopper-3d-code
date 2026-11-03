using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class Checkpoint : MonoBehaviour
{
    [SerializeField] Transform checkpointStartTransform;
    [SerializeField] private SpawnPointSetter[] preCheckpointSpawnPointSetters;
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private TriggerZombieSpawner checkpointTriggerZombieSpawner;

    private int checkpointReached;
    private string checkPointReachedPlayerPrefsName = "checkpointReached";
    private string runnerTag = "Runner";

    // Analytics.
    private string checkpointReachedEventName = "checkpointReached";
    private int currentLevel;

    private void Start()
    {
        checkpointReached = PlayerPrefs.GetInt(checkPointReachedPlayerPrefsName, 0);
        currentLevel = FindObjectOfType<GameManager>().currentLevel;

        if (checkpointReached == 1)
        {
            SetPreCheckpointSpawnPointSetters(false);
            FindObjectOfType<TriggerZombieSpawner>().gameObject.SetActive(false);
            checkpointTriggerZombieSpawner.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(runnerTag))
        {
            if (PlayerPrefs.GetInt(checkPointReachedPlayerPrefsName, 0) == 0)
            {
                checkpointReached = 1;
                PlayerPrefs.SetInt(checkPointReachedPlayerPrefsName, checkpointReached); // 0 means no, 1 means yes.
                SetCheckpoint();

                if (PlayerPrefs.GetInt(checkpointReachedEventName + currentLevel, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                    {  "userLevel", currentLevel },
                };
                    AnalyticsService.Instance.CustomData(checkpointReachedEventName, parameters);
                    PlayerPrefs.SetInt(checkpointReachedEventName + currentLevel, 1);
                }

                gameObject.SetActive(false);
            }
        }
    }

    private void SetCheckpointUIElementPassed()
    {
        checkpointReached = PlayerPrefs.GetInt(checkPointReachedPlayerPrefsName, 0);

        if (checkpointReached == 1)
        {
            levelUI.SetStage_01_Passed();
            checkpointReached = 0;
            PlayerPrefs.GetInt(checkPointReachedPlayerPrefsName, checkpointReached);
        }
    }

    private void SetPreCheckpointSpawnPointSetters(bool isActive)
    {
        foreach (SpawnPointSetter spawnPointSetter in preCheckpointSpawnPointSetters)
        {
            if (spawnPointSetter != null)
            {
                spawnPointSetter.gameObject.SetActive(isActive);
            }
        }
    }

    private void SetCheckpoint()
    {
        SetCheckpointUIElementPassed();
        gameObject.GetComponent<Collider>().enabled = false;
    }

    public Transform GetCheckpointStartTransform()
    {
        return checkpointStartTransform;
    }

    public void ClearCheckpoint()
    {
        PlayerPrefs.DeleteKey(checkPointReachedPlayerPrefsName);
    }

    public int GetIsCheckpointReached()
    {
        checkpointReached = PlayerPrefs.GetInt(checkPointReachedPlayerPrefsName, 0);
        return checkpointReached;
    }
}
