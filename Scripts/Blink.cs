using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// This toggles a component on and off for an interval to simulate a blinking effect
public class Blink : MonoBehaviour
{
    // This is the UI element you want to toggle
    [SerializeField] private Image image;
    [SerializeField] private TextMeshProUGUI textMesh;

    [Header("Blinking Setup")]
    public float interval = .2f;
    public float startDelay = 0.5f;
    public bool currentState = true;
    public bool defaultState = true;

    // Bools
    private bool isBlinking = false;

    // Start is called before the first frame update
    void Start()
    {
        if (image != null)
        {
            image.enabled = defaultState;
            StartBlink();
        }

        if (textMesh != null)
        {
            textMesh.enabled = defaultState;
            StartBlink();
        }
    }

    public void StartBlink()
    {
        // Do not invoke the blink twice - needed if you need to start the blink from an external object
        if (isBlinking)
        {
            return;
        }

        if (image != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
        }

        if (textMesh != null)
        {
            isBlinking = true;
            InvokeRepeating("ToggleState", startDelay, interval);
        }
    }

    private void ToggleState()
    {
        if (gameObject.activeInHierarchy)
        {
            if (image != null)
            {
                image.enabled = !image.enabled;
            }

            if (textMesh != null)
            {
                textMesh.enabled = !textMesh.enabled;
            }
        }
    }

    public void StopBlink()
    {
        CancelInvoke("ToggleState");
        isBlinking = false;

        if (image != null)
        {
            image.enabled = true;
        }

        if (textMesh != null)
        {
            textMesh.enabled = true;
        }
    }
}
