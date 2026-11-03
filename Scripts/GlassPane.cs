using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlassPane : MonoBehaviour
{
    [SerializeField] private Transform pfGlassPaneBroken;
    [SerializeField] private Image breakImage;
    [SerializeField] private Image aimCircleImage;
    [SerializeField] private GameObject tutorialHitZone;
    [SerializeField] private TutorialManager tutorialManager;

    public void ShowBrokenGlassPane()
    {
        AudioManager.Instance.Play_sfx_impact_glass();

        
        if (TutorialManager.isGlassTutorialActive)
        {
            FindObjectOfType<TutorialManager>().DeactivateTutorial();
            TutorialManager.isGlassTutorialActive = false;
        }
        Transform brokenGlassTransform = Instantiate(pfGlassPaneBroken, transform.position, transform.rotation);
        brokenGlassTransform.SetParent(transform.parent);
        brokenGlassTransform.localPosition = transform.localPosition;
        brokenGlassTransform.localScale = transform.localScale;
        if (tutorialManager != null)
        {
            FindGlassTutorialHazard();
        }
        Destroy(gameObject);
    }

    public void SetBreakImageActive(bool isActive)
    {
        breakImage.gameObject.SetActive(isActive);
    }

    public void SetAimCircleImageActive(bool isActive)
    {
        aimCircleImage.gameObject.SetActive(isActive);
    }

    public void SetTutorialHitZoneActive(bool isActive)
    {
        tutorialHitZone.SetActive(isActive);
    }

    public void FindGlassTutorialHazard()
    {
        if (breakImage != null)
        {
            if (breakImage.gameObject.activeInHierarchy)
            {
                SetBreakImageActive(false);
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

        //TutorialManager.isGlassTutorialActive = false;
        if (tutorialManager != null)
        {
            tutorialManager.DeactivateTutorial();
        }
    }
}
