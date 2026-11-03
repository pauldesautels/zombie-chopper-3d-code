using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeManager : MonoBehaviour
{
    private bool isPrizeLevel;

    public void CheckIfPrizeLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 7:
                SetIsPrizeLevel(true);
                break;
            case 17:
                SetIsPrizeLevel(true);
                break;
            case 22:
                SetIsPrizeLevel(true);
                break;
            case 30:
                SetIsPrizeLevel(true);
                break;
            default:
                break;
        }
    }

    private void SetIsPrizeLevel(bool _isPrizeLevel)
    {
        isPrizeLevel = _isPrizeLevel;
    }

    public bool GetIsPrizeLevel()
    {
        return isPrizeLevel;
    }
}
