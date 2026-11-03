using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Building : MonoBehaviour
{
    [SerializeField] private GameObject pfExplodingBuilding;
    [SerializeField] private GameObject currentWarningZone;
    [SerializeField] private GameObject pfWarningZone;

    private Rigidbody[] rigidbodies;
    private string explodingBuildingTag = "ExplodingBuilding";
    private string warningZoneTag = "WarningZone";
    private int zombiesKilledCount;
    private bool isExploded;
    private Transform warningzoneTransform;
    private Vector3 warningZoneScale;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag(explodingBuildingTag))
        {
            Invoke(nameof(ShowKillStreak), 3f);
            Invoke(nameof(Destroy), 10f);
        }
        if (currentWarningZone != null)
        {
            warningzoneTransform = currentWarningZone.transform;
            warningZoneScale = warningzoneTransform.localScale;
        }
    }

    public void CreateExplodingBuilding()
    {
        if (pfExplodingBuilding != null && !isExploded)
        {
            Instantiate(pfExplodingBuilding, transform.position, transform.rotation);
            GameObject newWarningzone = Instantiate(pfWarningZone, warningzoneTransform.position, warningzoneTransform.rotation);
            newWarningzone.transform.localScale = warningZoneScale;
            Destroy();
            isExploded = true;
        }
    }

    public void IncreaseZombiesKilledCount()
    {
        zombiesKilledCount++;
    }

    private void ShowKillStreak()
    {
        if (gameObject.CompareTag(explodingBuildingTag))
        {
            if (zombiesKilledCount >= 10 && zombiesKilledCount <= 19)
            {
                FindObjectOfType<LevelUI>().ShowKilltacularTextMesh();
            }
            if (zombiesKilledCount >= 20 && zombiesKilledCount <= 29)
            {
                FindObjectOfType<LevelUI>().ShowKillFrenzyTextMesh();
            }
            if (zombiesKilledCount >= 30)
            {
                FindObjectOfType<LevelUI>().ShowKilltrocityTextMesh();
            }
        }
    }

    private void Destroy()
    {
        LevelUI.hasShownBuildingUI = false;
        if (gameObject.CompareTag(explodingBuildingTag))
        {
            GameObject pfWarningZone = GameObject.FindGameObjectWithTag(warningZoneTag);
            if (pfWarningZone != null)
            {
                Destroy(pfWarningZone);
            }
        }
        Destroy(gameObject);
    }
}
