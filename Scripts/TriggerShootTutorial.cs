using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class TriggerShootTutorial : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private PlayerController playerController;

    // Analytics.
    private string tutorialShootTriggeredEventName = "tutorialShootTriggered"; // 0 means false, 1 means true
    private string tutorialShootEndedEventName = "tutorialShootEnded";

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponent<ZombieController>();
        if (zombie != null)
        {
            if (playerController.GetHasTakenShot() == false)
            {
                TutorialManager.isShootingTutorialActive = true;
                zombie.SetShootImageActive(true);
                zombie.SetAimCircleImageActive(true);
                zombie.SetTutorialHitZoneActive(true);
                tutorialManager.ActivateTutorial();

                if (PlayerPrefs.GetInt(tutorialShootTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Activated" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialShootTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialShootTriggeredEventName, 1);
                }

                gameObject.SetActive(false);
            } else
            {
                if (PlayerPrefs.GetInt(tutorialShootTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                            {  "tutorialStatus", "Skipped" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialShootTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialShootTriggeredEventName, 1);
                }
                if (PlayerPrefs.GetInt(tutorialShootEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialShootEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialShootEndedEventName, 1);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
