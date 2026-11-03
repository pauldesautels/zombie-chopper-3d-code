using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BridgeInteractSwitch : MonoBehaviour
{
    [SerializeField] private GameObject bridge_Up;
    [SerializeField] private GameObject bridge_Down;
    [SerializeField] private GameObject bridge_Raised;
    [SerializeField] private GameObject litScreen;
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private Image shootImage;
    [SerializeField] private Image aimCircleImage;
    [SerializeField] private GameObject tutorialHitZone;

    private RunnerController runnerController;
    private bool isSwitchActivated;

    private void Start()
    {
        runnerController = FindObjectOfType<RunnerController>();
    }

    public void ActivateBridge()
    {
        if (!isSwitchActivated)
        {
            Debug.Log("Bridge Activated!");
            SetLitScreenActive(false);
            if (bridge_Up != null)
            {
                bridge_Up.GetComponentInParent<Hazard_Bridge>().Animate();
            }
            if (bridge_Down != null)
            {
                bridge_Down.GetComponentInParent<Hazard_Bridge>().Animate();
            }
            if (bridge_Raised != null)
            {
                bridge_Raised.GetComponentInParent<Hazard_Bridge>().Animate();
                StartCoroutine(runnerController.WaitResetBridge(.1f));
            }
            if (bridge_Up == null && bridge_Down == null && bridge_Raised == null)
            {
                Debug.Log("No Bridge Assigned...");
            }
            isSwitchActivated = true;
        }
    }

    private void SetLitScreenActive(bool isActive)
    {
        litScreen.SetActive(isActive);
    }

    public void SetShootImageActive(bool isActive)
    {
        shootImage.gameObject.SetActive(isActive);
    }

    public void SetAimCircleImageActive(bool isActive)
    {
        aimCircleImage.gameObject.SetActive(isActive);
    }

    public void SetTutorialHitZoneActive(bool isActive)
    {
        tutorialHitZone.SetActive(isActive);
    }

    public void TriggerBridgeTutorial()
    {
        TutorialManager.isBridgeTutorialActive = true;
        SetShootImageActive(true);
        SetAimCircleImageActive(true);
        SetTutorialHitZoneActive(true);
        tutorialManager.ActivateTutorial();
    }

    public void FindBridgeTutorialSwitch()
    {
        if (shootImage != null)
        {
            if (shootImage.gameObject.activeInHierarchy)
            {
                SetShootImageActive(false);
            }
        }
        if (aimCircleImage != null)
        {
            if (aimCircleImage.gameObject.activeInHierarchy)
            {
                SetAimCircleImageActive(false);
            }
        }
        if (tutorialHitZone)
        {
            if (tutorialHitZone.activeInHierarchy)
            {
                SetTutorialHitZoneActive(false);
            }
        }

        TutorialManager tutorialManager = FindObjectOfType<TutorialManager>();
        if (tutorialManager != null)
        {
            tutorialManager.DeactivateTutorial();
        }
    }

    public bool GetIsSwitchActivate()
    {
        return isSwitchActivated;
    }
}
