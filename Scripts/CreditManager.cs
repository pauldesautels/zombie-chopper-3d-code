using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditManager : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private HomeUI homeUI;
    [SerializeField] private ItemManager itemManager;
    [SerializeField] private WeaponShopManager weaponShopManager;

    private int zombieKillValue = 1;
    private int creditCount;
    private int startLevelCreditCount;
    private int endLevelCreditCount;
    private int earnedCreditCount;
    private string creditCountPlayerPrefsName = "creditCount";

    private int instagramFollowRewardValue = 200;
    private int smallCreditPackageValue = 20000;
    private int mediumCreditPackageValue = 50000;
    private int largeCreditPackageValue = 150000;
    private int creditsNeeded;

    private bool isMultiplyCreditsLevel;

    private void Start()
    {
        //PlayerPrefs.DeleteKey(creditCountPlayerPrefsName);
        startLevelCreditCount = GetCreditCount();
    }

    private void TryBuyItem(Item.ItemType itemType)
    {
        if (TrySpendCreditAmount(Item.GetCost(itemType)))
        {
            // Can afford - Purchase.
            itemManager.PurchaseItem(itemType);
            itemManager.EquipItem(itemType);
            levelUI.SetWeaponOfferEquipped();
            AudioManager.Instance.Play_sfx_ui_equip();
        }
        else
        {
            // Can't afford - Open bank.
            levelUI.HideWeaponOffer();
            levelUI.SetBankMenuActive(true);
            levelUI.SetCreditsNeededText(creditsNeeded);
        }
    }

    public bool TrySpendCreditAmount(int amount)
    {
        if (GetCreditCount() >= amount)
        {
            Debug.Log("Price: " + amount + ", you have " + GetCreditCount() + ", therefore, you can afford it. Purchasing...");
            creditCount -= amount;
            SaveCreditCount();
            Debug.Log("New credit amount: " + creditCount);
            VisualLevelCreditChange(false, creditCount + amount, creditCount);
            return true; // Able to spend this many credits.
        }
        else
        {
            creditsNeeded = amount - GetCreditCount();
            Debug.Log("Not enough credits!");
            return false; // Cannot afford to spend this many credits.
        }
    }

    public void CheckForMultiplyCreditsLevel(int levelNumber)
    {
        switch (levelNumber)
        {
            case 1:
                break;
            case 2:
                break;
            default:
                SetIsMultiplyCreditsLevel(true);
                break;
        }
    }

    public void AddZombieKillCredit()
    {
        creditCount += zombieKillValue;
    }

    public void AddCredits(int amount)
    {
        creditCount += amount;
        SaveCreditCount();
    }

    public void SetCreditCountUI_Animated(int creditsAdded)
    {
        if (levelUI != null)
        {
            VisualLevelCreditChange(true, GetCreditCount() - creditsAdded, GetCreditCount());
        }
        if (homeUI != null)
        {
            VisualHomeCreditChange(true, GetCreditCount() - creditsAdded, GetCreditCount());
        }
    }

    public void SetCreditCountUI_Instant()
    {
        if (levelUI != null)
        {
            levelUI.SetCurrentCreditsCountText(GetCreditCount());
        }
        if (homeUI != null)
        {
            homeUI.SetCurrentCreditsCountText(GetCreditCount());
        }
    }

    public void VisualLevelCreditChange(bool isIncreasing, int currentCreditsAmount, int targetCreditAmount)
    {
        StartCoroutine(ChangeLevelCredits(isIncreasing, currentCreditsAmount, targetCreditAmount));
    }

    public void VisualHomeCreditChange(bool isIncreasing, int currentCreditsAmount, int targetCreditAmount)
    {
        StartCoroutine(ChangeHomeCredits(isIncreasing, currentCreditsAmount, targetCreditAmount));
    }

    private IEnumerator ChangeLevelCredits(bool isIncreasing, int currentCreditAmount, int targetCreditAmount)
    {
        bool isAnimationTimeUp = false;
        float totalAnimationTimeElapsed = 0;
        if (isIncreasing)
        {
            levelUI.SetCreditFXActive(false);
            levelUI.SetCreditFXActive(true);
        }
        while (currentCreditAmount != targetCreditAmount && !isAnimationTimeUp)
        {
            yield return new WaitForSecondsRealtime(.02f);
            totalAnimationTimeElapsed += 0.2f;
            if (totalAnimationTimeElapsed >= 6)
            {
                isAnimationTimeUp = true;
            }
            if (!isIncreasing)
            {
                currentCreditAmount -= 1;
                levelUI.SetCurrentCreditsCountText(currentCreditAmount);
            } else
            {
                currentCreditAmount += 1;
                levelUI.SetCurrentCreditsCountText(currentCreditAmount);
            }
        }
        SetCreditCountUI_Instant();
        if (isIncreasing)
        {
            AudioManager.Instance.Play_sfx_ui_cash();
        }
    }

    private IEnumerator ChangeHomeCredits(bool isIncreasing, int currentCreditAmount, int targetCreditAmount)
    {
        bool isAnimationTimeUp = false;
        float totalAnimationTimeElapsed = 0;
        while (currentCreditAmount != targetCreditAmount && !isAnimationTimeUp)
        {
            yield return new WaitForSecondsRealtime(.02f);
            totalAnimationTimeElapsed += 0.2f;
            if (totalAnimationTimeElapsed >= 6)
            {
                isAnimationTimeUp = true;
            }
            if (!isIncreasing)
            {
                currentCreditAmount -= 1;
                homeUI.SetCurrentCreditsCountText(currentCreditAmount);
            }
            else
            {
                currentCreditAmount += 1;
                homeUI.SetCurrentCreditsCountText(currentCreditAmount);
            }
        }
        SetCreditCountUI_Instant();
        if (isIncreasing)
        {
            AudioManager.Instance.Play_sfx_ui_cash();
        }
    }

    public int GetCreditCount()
    {
        creditCount = PlayerPrefs.GetInt(creditCountPlayerPrefsName, 0);
        return creditCount;
    }

    public void SaveCreditCount()
    {
        PlayerPrefs.SetInt(creditCountPlayerPrefsName, creditCount);
    }

    public void SaveNewCreditCount(int newCreditCount)
    {
        PlayerPrefs.SetInt(creditCountPlayerPrefsName, newCreditCount);
    }

    public void AttemptWeaponPurchase(Item.ItemType itemType)
    {
        TryBuyItem(itemType);
    }

    public int GetSmallCreditPackageValue()
    {
        return smallCreditPackageValue;
    }

    public int GetMediumCreditPackageValue()
    {
        return mediumCreditPackageValue;
    }

    public int GetLargeCreditPackageValue()
    {
        return largeCreditPackageValue;
    }

    public int GetInstagramFollowRewardValue()
    {
        return instagramFollowRewardValue;
    }

    public int GetStartLevelCreditCount()
    {
        return startLevelCreditCount;
    }

    public int GetEarnedCreditCount()
    {
        earnedCreditCount = GetEndLevelCreditCount() - GetStartLevelCreditCount();
        return earnedCreditCount;
    }

    public void SetIsMultiplyCreditsLevel(bool isTrue)
    {
        isMultiplyCreditsLevel = isTrue;
    }

    public void SetEndLevelCreditCount(int amount)
    {
        endLevelCreditCount = amount;
    }

    public int GetEndLevelCreditCount()
    {
        return endLevelCreditCount;
    }

    public bool GetIsMultiplyCreditsLevel()
    {
        return isMultiplyCreditsLevel;
    }
}
