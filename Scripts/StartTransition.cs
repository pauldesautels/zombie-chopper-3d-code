using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTransition : MonoBehaviour
{
    [SerializeField] private CameraManager cameraManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "End")
        {
            cameraManager.SetVirtualCamPriority(0);
            GameManager.isReadyToShoot = true;
        }
    }
}
