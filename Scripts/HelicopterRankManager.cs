using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterRankManager : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private ItemManager itemManager;

    private float currentFillAmount;
    private float startFillAmount;
    private float targetFillAmount;

    private int isHelicopterShopUnlocked;
    private int hasHelicopter_02SkinBeenOffered;
    private int hasHelicopter_04SkinBeenOffered;
    private string helicopterShopUnlockedPlayerPrefsName = "helicopterShopUnlocked";
    private string currentHelicopterRankFillAmountPlayerPrefsName = "currentHelicopterRankFillAmount";
    private string helicopter_02SkinOfferedPlayerPrefsName = "helicopter_02SkinOffered";
    private string helicopter_04SkinOfferedPlayerPrefsName = "helicopter_04SkinOffered";
    private bool isHelicopterRankLevel;
    private bool isHelicopter_02SkinOffer;
    private bool isHelicopter_04SkinOffer;

    private void Start()
    {
        //PlayerPrefs.DeleteKey(currentHelicopterRankFillAmountPlayerPrefsName);
        //PlayerPrefs.DeleteKey(helicopterShopUnlockedPlayerPrefsName);
        currentFillAmount = PlayerPrefs.GetFloat(currentHelicopterRankFillAmountPlayerPrefsName, 0);
        startFillAmount = currentFillAmount;
    }

    public void CheckForHelicopterRankLevel(int levelNumber)
    {
        switch (levelNumber - levelUI.GetNumberOfLevelsSkipped())
        {
            case 12:
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //20%
                break;
            case 13:
                if (GetCurrentFillAmount() != .2f)
                {
                    SetCurrentFillAmount(.2f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //40%
                break;
            case 14:
                if (GetCurrentFillAmount() != .4f)
                {
                    SetCurrentFillAmount(.4f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //60%
                break;
            case 15:
                if (GetCurrentFillAmount() != .6f)
                {
                    SetCurrentFillAmount(.6f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //80%
                break;
            case 16:
                if (GetCurrentFillAmount() != .8f)
                {
                    SetCurrentFillAmount(.8f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //100%
                SetIsHelicopter_02SkinOffer(true);
                break;
            case 27:
                if (GetCurrentFillAmount() != 0f)
                {
                    SetCurrentFillAmount(0f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //20%
                break;
            case 28:
                if (GetCurrentFillAmount() != .2f)
                {
                    SetCurrentFillAmount(.2f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //40%
                break;
            case 29:
                if (GetCurrentFillAmount() != .4f)
                {
                    SetCurrentFillAmount(.4f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //60%
                break;
            case 30:
                if (GetCurrentFillAmount() != .6f)
                {
                    SetCurrentFillAmount(.6f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //80%
                break;
            case 31:
                if (GetCurrentFillAmount() != .8f)
                {
                    SetCurrentFillAmount(.8f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsHelicopterRankLevel(true);
                levelUI.ShowHelicopterRank(); //100%
                SetIsHelicopter_04SkinOffer(true);
                break;
            default:
                break;
        }
    }

    public void ClaimHelicopterRankUpSkin(int levelNumber)
    {
        switch (levelNumber)
        {
            case 16:
                ClaimHelicopter_02Skin();
                break;
            case 31:
                ClaimHelicopter_04Skin();
                break;
            default:
                Debug.Log("No helicopter skin to receive!...");
                break;
        }
    }

    public float GetCurrentFillAmount()
    {
        return currentFillAmount;
    }

    public float GetTargetFillAmount()
    {
        targetFillAmount = (startFillAmount + .2f);
        return targetFillAmount;
    }

    public void SetCurrentFillAmount(float amount)
    {
        currentFillAmount = amount;
    }

    public void SaveFillAmount(float amount)
    {
        PlayerPrefs.SetFloat(currentHelicopterRankFillAmountPlayerPrefsName, amount);
    }

    private void SetIsHelicopterRankLevel(bool isTrue)
    {
        isHelicopterRankLevel = isTrue;
    }

    public bool GetIsHelicopterRankLevel()
    {
        return isHelicopterRankLevel;
    }

    public void ResetRankFillAmount()
    {
        PlayerPrefs.DeleteKey(currentHelicopterRankFillAmountPlayerPrefsName);
    }

    public void ClaimHelicopter_02Skin()
    {
        Debug.Log("Helicopter_02 Skin Received!");
        itemManager.PurchaseItem(Item.ItemType.Helicopter_02Skin);
        itemManager.EquipItem(Item.ItemType.Helicopter_02Skin);
    }

    public void ClaimHelicopter_04Skin()
    {
        Debug.Log("Helicopter_04 Skin Received!");
        itemManager.PurchaseItem(Item.ItemType.Helicopter_04Skin);
        itemManager.EquipItem(Item.ItemType.Helicopter_04Skin);
    }

    public void UnlockHelicopterShop()
    {
        isHelicopterShopUnlocked = 1;
        PlayerPrefs.SetInt(helicopterShopUnlockedPlayerPrefsName, isHelicopterShopUnlocked);
    }

    public int GetIsHelicopterShopUnlocked()
    {
        isHelicopterShopUnlocked = PlayerPrefs.GetInt(helicopterShopUnlockedPlayerPrefsName, 0);
        return isHelicopterShopUnlocked;
    }

    public void SetHelicopter_02SkinAsOffered()
    {
        hasHelicopter_02SkinBeenOffered = 1;
        PlayerPrefs.SetInt(helicopter_02SkinOfferedPlayerPrefsName, hasHelicopter_02SkinBeenOffered);
    }

    public void SetHelicopter_04SkinAsOffered()
    {
        hasHelicopter_04SkinBeenOffered = 1;
        PlayerPrefs.SetInt(helicopter_04SkinOfferedPlayerPrefsName, hasHelicopter_04SkinBeenOffered);
    }

    public int GetHasHelicopter_02SkinBeenOffered()
    {
        hasHelicopter_02SkinBeenOffered = PlayerPrefs.GetInt(helicopter_02SkinOfferedPlayerPrefsName, 0);
        return hasHelicopter_02SkinBeenOffered;
    }

    public int GetHasHelicopter_04SkinBeenOffered()
    {
        hasHelicopter_04SkinBeenOffered = PlayerPrefs.GetInt(helicopter_04SkinOfferedPlayerPrefsName, 0);
        return hasHelicopter_04SkinBeenOffered;
    }

    private void SetIsHelicopter_02SkinOffer(bool _isHelicopter_02SkinOffer)
    {
        isHelicopter_02SkinOffer = _isHelicopter_02SkinOffer;
    }

    private void SetIsHelicopter_04SkinOffer(bool _isHelicopter_04SkinOffer)
    {
        isHelicopter_04SkinOffer = _isHelicopter_04SkinOffer;
    }

    public bool GetIsHelicopter_02SkinOffer()
    {
        return isHelicopter_02SkinOffer;
    }

    public bool GetIsHelicopter_04SkinOffer()
    {
        return isHelicopter_04SkinOffer;
    }
}
