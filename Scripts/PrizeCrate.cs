using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeCrate : MonoBehaviour
{
    [SerializeField] private GameObject fx_credit;

    public void ShowCreditFX()
    {
        fx_credit.SetActive(true);
    }
}
