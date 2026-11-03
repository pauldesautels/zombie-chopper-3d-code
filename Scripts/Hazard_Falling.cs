using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hazard_Falling : MonoBehaviour
{
    [SerializeField] private GameObject pfFallingHazard;
    [SerializeField] private Transform attachPosition;
    [SerializeField] private GameObject partToDestroy;
    [SerializeField] private Image explodeImage;
    [SerializeField] private Image aimCircleImage;
    [SerializeField] private GameObject tutorialHitZone;
    [SerializeField] private TutorialManager tutorialManager;

    private GameObject fallingHazard;

    private bool isFalling;

    public void DropHazard()
    {
        if (!isFalling)
        {
            if (TutorialManager.isFallTutorialActive)
            {
                FindObjectOfType<TutorialManager>().DeactivateTutorial();
                TutorialManager.isFallTutorialActive = false;
            }
            fallingHazard = Instantiate(pfFallingHazard, attachPosition);
            Destroy(partToDestroy);
            Destroy(fallingHazard, 3f);
            if (tutorialManager != null)
            {
                FindFallTutorialHazard();
            }
            isFalling = true;
        }
    }

    public void SetExplodeImageActive(bool isActive)
    {
        explodeImage.gameObject.SetActive(isActive);
    }

    public void SetAimCircleImageActive(bool isActive)
    {
        aimCircleImage.gameObject.SetActive(isActive);
    }

    public void SetTutorialHitZoneActive(bool isActive)
    {
        tutorialHitZone.SetActive(isActive);
    }

    public void FindFallTutorialHazard()
    {
        if (explodeImage != null)
        {
            if (explodeImage.gameObject.activeInHierarchy)
            {
                SetExplodeImageActive(false);
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

        //TutorialManager.isFallTutorialActive = false;
        if (tutorialManager != null)
        {
            tutorialManager.DeactivateTutorial();
        }
    }

    public bool GetIsFalling()
    {
        return isFalling;
    }
}
