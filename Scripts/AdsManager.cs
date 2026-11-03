using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    public static AdsManager instance;

    private int hasCompletedFirstPurchase;
    private string hasCompletedFirstPurchasePlayerPrefsName = "hasCompletedFirstPurchase";

    private void Awake()
    {
        //if (GetHasCompletedFirstPurchase() == 0)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(instance);
            } else
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetHasCompletedFirstPurchaseTrue()
    {
        hasCompletedFirstPurchase = 1;
        PlayerPrefs.SetInt(hasCompletedFirstPurchasePlayerPrefsName, hasCompletedFirstPurchase);
    }

    public int GetHasCompletedFirstPurchase()
    {
        hasCompletedFirstPurchase = PlayerPrefs.GetInt(hasCompletedFirstPurchasePlayerPrefsName, 0);
        return hasCompletedFirstPurchase;
    }

    private void ResetHasCompletedFirstPurchase()
    {
        PlayerPrefs.DeleteKey(hasCompletedFirstPurchasePlayerPrefsName);
    }
}
