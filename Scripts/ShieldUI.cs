using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldUI : MonoBehaviour
{
    public void Disable()
    {
        RunnerController.isUsingShield = false;
        gameObject.SetActive(false);
    }
}
