using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Services.Analytics;

public class GunTrialManager : MonoBehaviour
{
    [SerializeField] private HomeUI homeUI;
    [SerializeField] private GameObject trialUI;
    [SerializeField] private GameObject shotgun_02Trial;
    [SerializeField] private GameObject smg_03Trial;
    [SerializeField] private GameObject rifle_02Trial;
    [SerializeField] private GameObject rocketLauncherTrial;
    [SerializeField] private GameObject machineGun_02Trial;
    [SerializeField] private Button playBtn;
    [SerializeField] private Button declineTrialBtn;
    [SerializeField] private ItemManager itemManager;

    private bool hasCheckedForGunTrial;
    private bool isGunTrialAvailable;

    // Analytics.
    private string firstGunTrialOfferedEventName = "firstGunTrialOffered"; // 0 means false, 1 means true
    private string firstGunTrialAdvancedEventName = "firstGunTrialAdvanced";

    void Awake()
    {
        itemManager.UnequipItem(Item.ItemType.TrialWeapons);
    }

    public void CheckForGunTrial(int levelNumber)
    {
        SetHasCheckedForGunTrial(true);
        switch (levelNumber)
        {
            case 1:
                break;
            case 2:
                SetIsGunTrialAvailable(true);
                SetShotgun_02GunTrialActive();
                break;
            case 9:
                if (itemManager.CheckIfItemIsPurchased(Item.ItemType.SMG_03) == 0)
                {
                    SetIsGunTrialAvailable(true);
                    SetSMG_03GunTrialActive();
                }
                break;
            case 16:
                if (itemManager.CheckIfItemIsPurchased(Item.ItemType.Rifle_02) == 0)
                {
                    SetIsGunTrialAvailable(true);
                    SetRifle_02GunTrialActive();
                }
                break;
            case 24:
                if (itemManager.CheckIfItemIsPurchased(Item.ItemType.RocketLauncher) == 0)
                {
                    SetIsGunTrialAvailable(true);
                    SetRocketLauncherGunTrialActive();
                }
                break;
            case 29:
                if (itemManager.CheckIfItemIsPurchased(Item.ItemType.MachineGun_02) == 0)
                {
                    SetIsGunTrialAvailable(true);
                    SetMachineGun_02TrialActive();
                }
                break;
            default:
                break;
        }
    }

    private void SetShotgun_02GunTrialActive()
    {
        trialUI.SetActive(true);
        shotgun_02Trial.SetActive(true);
        playBtn.gameObject.SetActive(false);
        homeUI.SetSettingsBtnActive(false);
        StartCoroutine(WaitSetDeclineTrialBtnActive(2f));

        if (PlayerPrefs.GetInt(firstGunTrialOfferedEventName, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
            };
            AnalyticsService.Instance.CustomData(firstGunTrialOfferedEventName, parameters);
            PlayerPrefs.SetInt(firstGunTrialOfferedEventName, 1);
        }
    }

    private void SetSMG_03GunTrialActive()
    {
        trialUI.SetActive(true);
        smg_03Trial.SetActive(true);
        playBtn.gameObject.SetActive(false);
        homeUI.SetSettingsBtnActive(false);
        StartCoroutine(WaitSetDeclineTrialBtnActive(3f));
    }

    private void SetRifle_02GunTrialActive()
    {
        trialUI.SetActive(true);
        rifle_02Trial.SetActive(true);
        playBtn.gameObject.SetActive(false);
        homeUI.SetSettingsBtnActive(false);
        StartCoroutine(WaitSetDeclineTrialBtnActive(3f));
    }

    private void SetRocketLauncherGunTrialActive()
    {
        trialUI.SetActive(true);
        rocketLauncherTrial.SetActive(true);
        playBtn.gameObject.SetActive(false);
        homeUI.SetSettingsBtnActive(false);
        StartCoroutine(WaitSetDeclineTrialBtnActive(3f));
    }

    private void SetMachineGun_02TrialActive()
    {
        trialUI.SetActive(true);
        machineGun_02Trial.SetActive(true);
        playBtn.gameObject.SetActive(false);
        homeUI.SetSettingsBtnActive(false);
        StartCoroutine(WaitSetDeclineTrialBtnActive(3f));
    }

    public void ClaimGunTrial(int levelNumber)
    {
        switch (levelNumber)
        {
            case 2:
                ClaimShotgun_02Trial();
                break;
            case 9:
                ClaimSMG_03Trial();
                break;
            case 16:
                ClaimRifle_02Trial();
                break;
            case 24:
                ClaimRocketLauncherTrial();
                break;
            case 29:
                ClaimMachineGun_02Trial();
                break;
            default:
                break;
        }
    }

    private void ClaimShotgun_02Trial()
    {
        Debug.Log("Shotgun_02 Trial Claimed!");
        itemManager.EquipItem(Item.ItemType.TrialWeapon);
        itemManager.EquipItem(Item.ItemType.TrialShotgun_02);

        if (PlayerPrefs.GetInt(firstGunTrialAdvancedEventName, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "gunTrialStatus", "Claimed" },
            };
            AnalyticsService.Instance.CustomData(firstGunTrialAdvancedEventName, parameters);
            PlayerPrefs.SetInt(firstGunTrialAdvancedEventName, 1);
        }
    }

    private void ClaimSMG_03Trial()
    {
        Debug.Log("SMG_03 Trial Claimed!");
        itemManager.EquipItem(Item.ItemType.TrialWeapon);
        itemManager.EquipItem(Item.ItemType.TrialSMG_03);
    }

    private void ClaimRifle_02Trial()
    {
        Debug.Log("Rifle_02 Trial Claimed!");
        itemManager.EquipItem(Item.ItemType.TrialWeapon);
        itemManager.EquipItem(Item.ItemType.TrialRifle_02);
    }

    private void ClaimRocketLauncherTrial()
    {
        Debug.Log("RocketLauncher Trial Claimed!");
        itemManager.EquipItem(Item.ItemType.TrialWeapon);
        itemManager.EquipItem(Item.ItemType.TrialRocketLauncher);
    }

    private void ClaimMachineGun_02Trial()
    {
        Debug.Log("MachineGun_02 Trial Claimed!");
        itemManager.EquipItem(Item.ItemType.TrialWeapon);
        itemManager.EquipItem(Item.ItemType.TrialMachineGun_02);
    }

    public void FindActiveGunTrial(int levelNumber)
    {
        switch (levelNumber)
        {
            case 2:
                DeactivateShotgun_02Trial();
                break;
            case 9:
                DeactivateSMG_03Trial();
                break;
            case 16:
                DeactivateRifle_02Trial();
                break;
            case 24:
                DeactivateRocketLauncherTrial();
                break;
            case 29:
                DeactivateMachineGun_02Trial();
                break;
            default:
                break;
        }
    }

    public void DeactivateShotgun_02Trial()
    {
        trialUI.SetActive(false);
        shotgun_02Trial.SetActive(false);
        declineTrialBtn.gameObject.SetActive(false);
        homeUI.TapToPlay();

        if (PlayerPrefs.GetInt(firstGunTrialAdvancedEventName, 0) == 0)
        {
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {  "gunTrialStatus", "Declined" },
            };
            AnalyticsService.Instance.CustomData(firstGunTrialAdvancedEventName, parameters);
            PlayerPrefs.SetInt(firstGunTrialAdvancedEventName, 1);
        }
    }

    private void DeactivateSMG_03Trial()
    {
        trialUI.SetActive(false);
        smg_03Trial.SetActive(false);
        declineTrialBtn.gameObject.SetActive(false);
        homeUI.TapToPlay();
    }

    private void DeactivateRifle_02Trial()
    {
        trialUI.SetActive(false);
        rifle_02Trial.SetActive(false);
        declineTrialBtn.gameObject.SetActive(false);
        homeUI.TapToPlay();
    }

    private void DeactivateRocketLauncherTrial()
    {
        trialUI.SetActive(false);
        rocketLauncherTrial.SetActive(false);
        declineTrialBtn.gameObject.SetActive(false);
        homeUI.TapToPlay();
    }

    private void DeactivateMachineGun_02Trial()
    {
        trialUI.SetActive(false);
        machineGun_02Trial.SetActive(false);
        declineTrialBtn.gameObject.SetActive(false);
        homeUI.TapToPlay();
    }

    public IEnumerator WaitSetDeclineTrialBtnActive(float delay)
    {
        yield return new WaitForSeconds(delay);

        declineTrialBtn.gameObject.SetActive(true);
    }

    public bool GetHasCheckedForGunTrial()
    {
        return hasCheckedForGunTrial;
    }

    public bool GetIsGunTrialAvailable()
    {
        return isGunTrialAvailable;
    }

    private void SetHasCheckedForGunTrial(bool hasChecked)
    {
        hasCheckedForGunTrial = hasChecked;
    }

    private void SetIsGunTrialAvailable(bool isAvailable)
    {
        isGunTrialAvailable = isAvailable;
    }
}
