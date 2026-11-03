using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class TriggerFallTutorial : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private Hazard_Falling hangingContainer;

    // Analytics.
    private string tutorialFallTriggeredEventName = "tutorialFallTriggered"; // 0 means false, 1 means true
    private string tutorialFallEndedEventName = "tutorialFallEnded";

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponent<ZombieController>();
        if (zombie != null)
        {
            if (!hangingContainer.GetIsFalling())
            {
                TutorialManager.isFallTutorialActive = true;
                hangingContainer.SetExplodeImageActive(true);
                hangingContainer.SetAimCircleImageActive(true);
                hangingContainer.SetTutorialHitZoneActive(true);
                tutorialManager.ActivateTutorial();

                if (PlayerPrefs.GetInt(tutorialFallTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Activated" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialFallTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialFallTriggeredEventName, 1);
                }

                gameObject.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.GetInt(tutorialFallTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Skipped" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialFallTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialFallTriggeredEventName, 1);
                }
                if (PlayerPrefs.GetInt(tutorialFallEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialFallEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialFallEndedEventName, 1);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
