using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowDistance : MonoBehaviour
{
    public int _ShadowDistance ;
    
    void Start()
    {
        QualitySettings.shadowDistance = _ShadowDistance;
    }
}
