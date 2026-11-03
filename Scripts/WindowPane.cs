using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowPane : MonoBehaviour
{
    [SerializeField] private GameObject pfBrokenWindow;

    private Transform windowTransform;
    private Vector3 windowScale;
    private bool hasCreatedBrokenWindow;

    // Start is called before the first frame update
    void Start()
    {
        windowTransform = gameObject.transform;
        windowScale = gameObject.transform.localScale;
    }

    public void CreateBrokenWindow()
    {
        if (pfBrokenWindow != null && !hasCreatedBrokenWindow)
        {
            AudioManager.Instance.Play_sfx_impact_glass();
            GameObject brokenWindow = Instantiate(pfBrokenWindow, windowTransform.position, windowTransform.rotation);
            brokenWindow.transform.localScale = windowScale;
            hasCreatedBrokenWindow = true;
            Destroy();
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
