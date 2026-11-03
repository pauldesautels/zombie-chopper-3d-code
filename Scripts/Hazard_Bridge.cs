using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Bridge : MonoBehaviour
{
    [SerializeField] private GameObject launchZone;
    [SerializeField] private GameObject fallZone;
    [SerializeField] private GameObject navMeshBlocker;

    private Animator animator;
    private string bridge_Up_Tag = "Hazard_Bridge_Up";
    private string bridge_Down_Tag = "Hazard_Bridge_Down";
    private string bridge_Raised_First_Tag = "Hazard_Bridge_Raised_First";
    private string bridge_Raised_Tag = "Hazard_Bridge_Raised";
    private string bridge_Up_Trigger_Name = "lift";
    private string bridge_Down_Trigger_Name = "drop";
    private string bridge_Raised_Trigger_Name = "lower";

    private bool isBridgeRaised = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Animate()
    {
        if (gameObject.CompareTag(bridge_Up_Tag))
        {
            animator.SetTrigger(bridge_Up_Trigger_Name);
            SetLaunchZoneActive(true);
        }

        if (gameObject.CompareTag(bridge_Down_Tag))
        {
            animator.SetTrigger(bridge_Down_Trigger_Name);
            SetFallZoneActive(true);
        }

        if (gameObject.CompareTag(bridge_Raised_First_Tag))
        {
            animator.SetTrigger(bridge_Raised_Trigger_Name);
            SetNavMeshBlockerActive(false);
            SetIsBridgeRaised(false);
        }

        if (gameObject.CompareTag(bridge_Raised_Tag))
        {
            animator.SetTrigger(bridge_Raised_Trigger_Name);
            SetNavMeshBlockerActive(false);
            SetIsBridgeRaised(false);
        }
    }

    private void SetLaunchZoneActive(bool isActive)
    {
        launchZone.SetActive(isActive);
    }

    public void MakeBridgeBlock()
    {
        SetLaunchZoneActive(false);
        SetNavMeshBlockerActive(true);
    }

    private void SetFallZoneActive(bool isActive)
    {
        fallZone.SetActive(isActive);
    }

    private void SetNavMeshBlockerActive(bool isActive)
    {
        navMeshBlocker.SetActive(isActive);
    }

    private void SetIsBridgeRaised(bool _isBridgeRaised)
    {
        isBridgeRaised = _isBridgeRaised;
    }

    public bool GetIsBridgeRaised()
    {
        return isBridgeRaised;
    }
}
