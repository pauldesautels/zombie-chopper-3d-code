using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinAnimation : MonoBehaviour
{
    public float rotationSpeed = 90;

    // Update is called once per frame
    void Update()
    {
        // Spin
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotation.z += rotationSpeed * Time.unscaledDeltaTime;
        transform.localRotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
    }
}
