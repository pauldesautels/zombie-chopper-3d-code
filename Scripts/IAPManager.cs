using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    [SerializeField] private GameObject restorePurchasesBtn;
    [SerializeField] private HomeUI homeUI;
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private PackManager packManager;
    //[SerializeField] private GameObject starterPackLoadingPopUp;
    //[SerializeField] private GameObject secondPackLoadingPopUp;
    //[SerializeField] private GameObject thirdPackLoadingPopUp;
    //[SerializeField] private GameObject shieldPackLoadingPopUp;
    //[SerializeField] private GameObject smallCreditPackLoadingPopUp;
    //[SerializeField] private GameObject mediumCreditPackLoadingPopUp;
    //[SerializeField] private GameObject largeCreditPackLoadingPopUp;

    private string shieldPackID = "com.shdgames.zombiechopper.shieldpack";
    private string starterPackID = "com.shdgames.zombiechopper.starterpack";
    private string secondPackID = "com.shdgames.zombiechopper.secondpack";
    private string thirdPackID = "com.shdgames.zombiechopper.thirdpack";
    private string smallCreditPackID = "com.shdgames.zombiechopper.smallcreditpack";
    private string mediumCreditPackID = "com.shdgames.zombiechopper.mediumcreditpack";
    private string largeCreditPackID = "com.shdgames.zombiechopper.largecreditpack";

    private void Awake()
    {
        if (restorePurchasesBtn != null)
        {
            DisableRestorePurchasesBtn();
        }
    }

    public void StarterPackClick()
    {
        //SetStarterPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SecondPackClick()
    {
        //SetSecondPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ThirdPackClick()
    {
        //SetThirdPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void ShieldPackClick()
    {
        //SetShieldPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void SmallCreditPackClick()
    {
        //SetSmallCreditPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void MediumCreditPackClick()
    {
        //SetMediumCreditPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void LargeCreditPackClick()
    {
        //SetLargeCreditPackLoadingPopUpActive(true);
        AudioManager.Instance.Play_sfx_ui_tap();
    }

    public void OnPurchaseComplete(Product product)
    {
        if (product.definition.id == shieldPackID)
        {
            homeUI.PurchaseShieldPack();
            homeUI.TapToPlay();
            FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
        }
        if (product.definition.id == starterPackID)
        {
            packManager.PurchaseStarterPack();
            FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
        }
        if (product.definition.id == secondPackID)
        {
            packManager.PurchaseSecondPack();
            FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
        }
        if (product.definition.id == thirdPackID)
        {
            packManager.PurchaseThirdPack();
            FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
        }
        if (product.definition.id == smallCreditPackID)
        {
            if (homeUI != null)
            {
                homeUI.PurchaseSmallCreditPack();
                FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
            }
            if (levelUI != null)
            {
                levelUI.PurchaseSmallCreditPack();
                FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
            }
        }
        if (product.definition.id == mediumCreditPackID)
        {
            if (homeUI != null)
            {
                homeUI.PurchaseMediumCreditPack();
                FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
            }
            if (levelUI != null)
            {
                levelUI.PurchaseMediumCreditPack();
                FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
            }
        }
        if (product.definition.id == largeCreditPackID)
        {
            if (homeUI != null)
            {
                homeUI.PurchaseLargeCreditPack();
                FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
            }
            if (levelUI != null)
            {
                levelUI.PurchaseLargeCreditPack();
                FindObjectOfType<AdsManager>().SetHasCompletedFirstPurchaseTrue();
            }
        }
        //HideAllLoadingPopUps();
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason reason)
    {
        Debug.Log("Purchase of " + product.definition.id + " failed due to " + reason);
        //HideAllLoadingPopUps();
    }

    private void DisableRestorePurchasesBtn()
    {
#if UNITY_IOS
        
#elif UNITY_ANDROID
        restorePurchasesBtn.SetActive(false);
#endif
    }

    //private void SetStarterPackLoadingPopUpActive(bool isActive)
    //{
    //    if (starterPackLoadingPopUp != null)
    //    {
    //        starterPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //private void SetSecondPackLoadingPopUpActive(bool isActive)
    //{
    //    if (secondPackLoadingPopUp != null)
    //    {
    //        secondPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //private void SetThirdPackLoadingPopUpActive(bool isActive)
    //{
    //    if (thirdPackLoadingPopUp != null)
    //    {
    //        thirdPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //private void SetShieldPackLoadingPopUpActive(bool isActive)
    //{
    //    if (shieldPackLoadingPopUp != null)
    //    {
    //        shieldPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //private void SetSmallCreditPackLoadingPopUpActive(bool isActive)
    //{
    //    if (smallCreditPackLoadingPopUp != null)
    //    {
    //        smallCreditPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //private void SetMediumCreditPackLoadingPopUpActive(bool isActive)
    //{
    //    if (mediumCreditPackLoadingPopUp != null)
    //    {
    //        mediumCreditPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //private void SetLargeCreditPackLoadingPopUpActive(bool isActive)
    //{
    //    if (largeCreditPackLoadingPopUp != null)
    //    {
    //        largeCreditPackLoadingPopUp.SetActive(isActive);
    //    }
    //}

    //public void HideAllLoadingPopUps()
    //{
    //    SetStarterPackLoadingPopUpActive(false);
    //    SetSecondPackLoadingPopUpActive(false);
    //    SetThirdPackLoadingPopUpActive(false);
    //    SetShieldPackLoadingPopUpActive(false);
    //    SetSmallCreditPackLoadingPopUpActive(false);
    //    SetMediumCreditPackLoadingPopUpActive(false);
    //    SetLargeCreditPackLoadingPopUpActive(false);
    //}
}
