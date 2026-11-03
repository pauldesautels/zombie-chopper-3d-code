using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    [SerializeField] private GameObject shieldFX;
    [SerializeField] private RunnerController runner;
    [SerializeField] private LevelUI levelUI;

    private Vector3 runnerPos;

    private int shieldCount;
    private string shieldCountPlayerPrefsName = "shieldCount";

    public int GetShieldCount()
    {
        shieldCount = PlayerPrefs.GetInt(shieldCountPlayerPrefsName, 0);
        return shieldCount;
    }

    public void AddShields(int amount)
    {
        shieldCount += amount;
        SaveShieldCount(shieldCount);
    }

    public void UseZombieShield()
    {
        runnerPos = runner.transform.position;

        shieldCount--;
        Instantiate(shieldFX, runnerPos, transform.rotation);

        SaveShieldCount(shieldCount);
        levelUI.SetCurrentShieldCountText(shieldCount);
        runner.SetShieldImageActive(true);
    }

    public void UseRunnerShield()
    {
        shieldCount--;
        SaveShieldCount(shieldCount);
        levelUI.SetCurrentShieldCountText(shieldCount);
        runner.SetShieldImageActive(true);
    }

    public void SaveShieldCount(int count)
    {
        shieldCount = count;
        PlayerPrefs.SetInt(shieldCountPlayerPrefsName, shieldCount);
    }    
}
