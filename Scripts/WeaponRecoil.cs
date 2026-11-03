using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRecoil : MonoBehaviour
{
    [HideInInspector] public Animator rigController;

    public void GenerateRecoil(string weaponName)
    {
        rigController.Play("weapon_recoil_" + weaponName, 0, 0.0f);
    }
}
