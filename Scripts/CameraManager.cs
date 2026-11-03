using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    [Header("Level Cams")]
    [SerializeField] private CinemachineVirtualCameraBase thirdPersonAlertCam;
    [SerializeField] private CinemachineVirtualCameraBase gameOverCam;
    [SerializeField] private CinemachineVirtualCameraBase levelCompleteCam;
    [SerializeField] private CinemachineVirtualCameraBase virtualCam;

    [Header("Tracks")]
    [SerializeField] private CinemachineSmoothPath startTransitionTrack;
    [SerializeField] private CinemachineSmoothPath cameraAssistTrack;
    [SerializeField] private CinemachineSmoothPath cameraAssistCheckpointTrack;
    [SerializeField] private CinemachineDollyCart startTransitionCart;
    [SerializeField] private CinemachineDollyCart cameraAssistCart;

    [Header("Target Groups")]
    [SerializeField] private CinemachineTargetGroup targetGroup;

    public void EnableGameOverCam()
    {
        gameOverCam.Priority = 100;
    }

    public void SetAlertCamPriority(int _priority)
    {
        thirdPersonAlertCam.Priority = _priority;
    }

    public void EnableLevelCompleteCam()
    {
        levelCompleteCam.Priority = 100;
    }

    public void SetVirtualCamPriority(int _priority)
    {
        virtualCam.Priority = _priority;
    }

    public void ClearTargetGroup()
    {
        targetGroup.m_Targets = new CinemachineTargetGroup.Target[0];
    }

    public void HideStartTransitionTrack()
    {
        startTransitionTrack.gameObject.SetActive(false);
        startTransitionCart.gameObject.SetActive(false);
    }

    public void HideCameraAssistNormalTrack()
    {
        cameraAssistTrack.gameObject.SetActive(false);
    }

    public void UseCameraAssistCheckpointTrack()
    {
        cameraAssistCheckpointTrack.gameObject.SetActive(true);
        cameraAssistCart.m_Path = cameraAssistCheckpointTrack;
        GameManager.isReadyToShoot = true;
    }
}
