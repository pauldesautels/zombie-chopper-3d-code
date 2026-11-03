using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // References
    [SerializeField] private GameObject healthbarUI;
    [SerializeField] private Slider slider;
    [SerializeField] private Image borderImage;
    [SerializeField] private Image fillImage;
    //[SerializeField] private Transform target;
    //[SerializeField] private Vector3 offset;

    private void Start()
    {
    }

    //private void Update()
    //{
    //    Vector3 direction = (target.position - Camera.main.transform.position).normalized;
    //    bool isBehind = Vector3.Dot(direction, Camera.main.transform.forward) < 0.0f;
    //    borderImage.enabled = !isBehind;
    //    fillImage.enabled = !isBehind;

    //    transform.position = Camera.main.WorldToScreenPoint(target.position + offset);

    //    borderImageColor.a = 1f;
    //    borderImage.color = borderImageColor;

    //    fillImageColor.a = 1f;
    //    fillImage.color = fillImageColor;
    //}

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        slider.value = health;
    }

    public void DrainHealth()
    {
        slider.value = 0;
    }

    public void SetHealthBarUIActive(bool isActive)
    {
        healthbarUI.SetActive(isActive);
    }
}
