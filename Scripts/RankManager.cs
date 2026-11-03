using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankManager : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private ItemManager itemManager;

    private float currentFillAmount;
    private float startFillAmount;
    private float targetFillAmount;

    private int isSkinShopUnlocked;
    private int hasMale_01SkinBeenOffered;
    private int hasHomelessSkinBeenOffered;
    private int hasBikerSkinBeenOffered;
    private int hasFemale_01SkinBeenOffered;
    private string skinShopUnlockedPlayerPrefsName = "skinShopUnlocked";
    private string currentRankFillAmountPlayerPrefsName = "currentRankFillAmount";
    private string male_01SkinOfferedPlayerPrefsName = "male_01SkinOffered";
    private string homelessSkinOfferedPlayerPrefsName = "homelessSkinOffered";
    private string bikerSkinOfferedPlayerPrefsName = "bikerSkinOffered";
    private string female_01SkinOfferedPlayerPrefsName = "female_01SkinOffered";
    private bool isRankLevel;
    private bool isMale_01SkinOffer;
    private bool isHomelessSkinOffer;
    private bool isBikerSkinOffer;
    private bool isFemale_01SkinOffer;

    private void Start()
    {
        //PlayerPrefs.DeleteKey(currentRankFillAmountPlayerPrefsName);
        //PlayerPrefs.DeleteKey(skinShopUnlockedPlayerPrefsName);
        currentFillAmount = PlayerPrefs.GetFloat(currentRankFillAmountPlayerPrefsName, 0);
        startFillAmount = currentFillAmount;
    }

    public void CheckForRankLevel(int levelNumber)
    {
        switch (levelNumber - levelUI.GetNumberOfLevelsSkipped())
        {
            case 2:
                SetIsRankLevel(true);
                levelUI.ShowRank(); //20%
                break;
            case 3:
                if (GetCurrentFillAmount() != .2f)
                {
                    SetCurrentFillAmount(.2f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //40%
                break;
            case 4:
                if (GetCurrentFillAmount() != .4f)
                {
                    SetCurrentFillAmount(.4f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //60%
                break;
            case 5:
                if (GetCurrentFillAmount() != .6f)
                {
                    SetCurrentFillAmount(.6f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //80%
                break;
            case 6:
                if (GetCurrentFillAmount() != .8f)
                {
                    SetCurrentFillAmount(.8f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //100%
                SetIsMale_01SkinOffer(true);
                break;
            case 7:
                if (GetCurrentFillAmount() != 0f)
                {
                    SetCurrentFillAmount(0f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //20%
                break;
            case 8:
                if (GetCurrentFillAmount() != .2f)
                {
                    SetCurrentFillAmount(.2f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //40%
                break;
            case 9:
                if (GetCurrentFillAmount() != .4f)
                {
                    SetCurrentFillAmount(.4f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //60%
                break;
            case 10:
                if (GetCurrentFillAmount() != .6f)
                {
                    SetCurrentFillAmount(.6f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //80%
                break;
            case 11:
                if (GetCurrentFillAmount() != .8f)
                {
                    SetCurrentFillAmount(.8f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //100%
                SetIsHomelessSkinOffer(true);
                break;
            case 17:
                if (GetCurrentFillAmount() != 0f)
                {
                    SetCurrentFillAmount(0f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //20%
                break;
            case 18:
                if (GetCurrentFillAmount() != .2f)
                {
                    SetCurrentFillAmount(.2f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //40%
                break;
            case 19:
                if (GetCurrentFillAmount() != .4f)
                {
                    SetCurrentFillAmount(.4f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //60%
                break;
            case 20:
                if (GetCurrentFillAmount() != .6f)
                {
                    SetCurrentFillAmount(.6f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //80%
                break;
            case 21:
                if (GetCurrentFillAmount() != .8f)
                {
                    SetCurrentFillAmount(.8f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //100%
                SetIsBikerSkinOffer(true);
                break;
            case 22:
                if (GetCurrentFillAmount() != 0f)
                {
                    SetCurrentFillAmount(0f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //20%
                break;
            case 23:
                if (GetCurrentFillAmount() != .2f)
                {
                    SetCurrentFillAmount(.2f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //40%
                break;
            case 24:
                if (GetCurrentFillAmount() != .4f)
                {
                    SetCurrentFillAmount(.4f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //60%
                break;
            case 25:
                if (GetCurrentFillAmount() != .6f)
                {
                    SetCurrentFillAmount(.6f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //80%
                break;
            case 26:
                if (GetCurrentFillAmount() != .8f)
                {
                    SetCurrentFillAmount(.8f);
                    startFillAmount = GetCurrentFillAmount();
                }
                SetIsRankLevel(true);
                levelUI.ShowRank(); //100%
                SetIsFemale_01SkinOffer(true);
                break;
            default:
                break;
        }
    }

    public void ClaimRankUpSkin(int levelNumber)
    {
        switch (levelNumber)
        {
            case 6:
                ClaimMale_01Skin();
                break;
            case 11:
                ClaimHomelessSkin();
                break;
            case 21:
                ClaimBikerSkin();
                break;
            case 26:
                ClaimFemale_01Skin();
                break;
            default:
                Debug.Log("No skin to receive!...");
                break;
        }
    }

    public float GetCurrentFillAmount()
    {
        return currentFillAmount;
    }

    public float GetTargetFillAmount()
    {
        targetFillAmount = startFillAmount + .2f;
        return targetFillAmount;
    }

    public void SetCurrentFillAmount(float amount)
    {
        currentFillAmount = amount;
    }

    public void SaveFillAmount(float amount)
    {
        PlayerPrefs.SetFloat(currentRankFillAmountPlayerPrefsName, amount);
    }

    private void SetIsRankLevel(bool isTrue)
    {
        isRankLevel = isTrue;
    }

    public bool GetIsRankLevel()
    {
        return isRankLevel;
    }

    public void ResetRankFillAmount()
    {
        PlayerPrefs.DeleteKey(currentRankFillAmountPlayerPrefsName);
    }

    private void ClaimMale_01Skin()
    {
        Debug.Log("Male_01 Skin Received!");
        itemManager.PurchaseItem(Item.ItemType.Male_01Skin);
        itemManager.EquipItem(Item.ItemType.Male_01Skin);
    }

    private void ClaimHomelessSkin()
    {
        Debug.Log("Homeless Skin Received!");
        itemManager.PurchaseItem(Item.ItemType.HomelessSkin);
        itemManager.EquipItem(Item.ItemType.HomelessSkin);
    }

    private void ClaimBikerSkin()
    {
        Debug.Log("Biker Skin Received!");
        itemManager.PurchaseItem(Item.ItemType.BikerSkin);
        itemManager.EquipItem(Item.ItemType.BikerSkin);
    }

    private void ClaimFemale_01Skin()
    {
        Debug.Log("Female_01 Skin Received!");
        itemManager.PurchaseItem(Item.ItemType.Female_01Skin);
        itemManager.EquipItem(Item.ItemType.Female_01Skin);
    }

    public void UnlockSkinShop()
    {
        isSkinShopUnlocked = 1;
        PlayerPrefs.SetInt(skinShopUnlockedPlayerPrefsName, isSkinShopUnlocked);
    }

    public int GetIsSkinShopUnlocked()
    {
        isSkinShopUnlocked = PlayerPrefs.GetInt(skinShopUnlockedPlayerPrefsName, 0);
        return isSkinShopUnlocked;
    }

    public void SetMale_01SkinAsOffered()
    {
        hasMale_01SkinBeenOffered = 1;
        PlayerPrefs.SetInt(male_01SkinOfferedPlayerPrefsName, hasMale_01SkinBeenOffered);
    }

    public void SetHomelessSkinAsOffered()
    {
        hasHomelessSkinBeenOffered = 1;
        PlayerPrefs.SetInt(homelessSkinOfferedPlayerPrefsName, hasHomelessSkinBeenOffered);
    }

    public void SetBikerSkinAsOffered()
    {
        hasBikerSkinBeenOffered = 1;
        PlayerPrefs.SetInt(bikerSkinOfferedPlayerPrefsName, hasBikerSkinBeenOffered);
    }

    public void SetFemale_01SkinAsOffered()
    {
        hasFemale_01SkinBeenOffered = 1;
        PlayerPrefs.SetInt(female_01SkinOfferedPlayerPrefsName, hasFemale_01SkinBeenOffered);
    }

    public int GetHasMale_01SkinBeenOffered()
    {
        hasMale_01SkinBeenOffered = PlayerPrefs.GetInt(male_01SkinOfferedPlayerPrefsName, 0);
        return hasMale_01SkinBeenOffered;
    }

    public int GetHasHomelessSkinBeenOffered()
    {
        hasHomelessSkinBeenOffered = PlayerPrefs.GetInt(homelessSkinOfferedPlayerPrefsName, 0);
        return hasHomelessSkinBeenOffered;
    }

    public int GetHasBikerSkinBeenOffered()
    {
        hasBikerSkinBeenOffered = PlayerPrefs.GetInt(bikerSkinOfferedPlayerPrefsName, 0);
        return hasBikerSkinBeenOffered;
    }

    public int GetHasFemale_01SkinBeenOffered()
    {
        hasFemale_01SkinBeenOffered = PlayerPrefs.GetInt(female_01SkinOfferedPlayerPrefsName, 0);
        return hasFemale_01SkinBeenOffered;
    }

    private void SetIsMale_01SkinOffer(bool _isMale_01SkinOffer)
    {
        isMale_01SkinOffer = _isMale_01SkinOffer;
    }

    private void SetIsHomelessSkinOffer(bool _isHomelessSkinOffer)
    {
        isHomelessSkinOffer = _isHomelessSkinOffer;
    }

    private void SetIsBikerSkinOffer(bool _isBikerSkinOffer)
    {
        isBikerSkinOffer = _isBikerSkinOffer;
    }

    private void SetIsFemale_01SkinOffer(bool _isFemale_01SkinOffer)
    {
        isFemale_01SkinOffer = _isFemale_01SkinOffer;
    }

    public bool GetIsMale_01SkinOffer()
    {
        return isMale_01SkinOffer;
    }

    public bool GetIsHomelessSkinOffer()
    {
        return isHomelessSkinOffer;
    }


    public bool GetIsBikerSkinOffer()
    {
        return isBikerSkinOffer;
    }

    public bool GetIsFemale_01SkinOffer()
    {
        return isFemale_01SkinOffer;
    }
}
