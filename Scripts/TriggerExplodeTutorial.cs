using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class TriggerExplodeTutorial : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private Hazard_Exploding explodingBarrel;

    // Analytics.
    private string tutorialExplodeTriggeredEventName = "tutorialExplodeTriggered"; // 0 means false, 1 means true
    private string tutorialExplodeEndedEventName = "tutorialExplodeEnded";

    private void OnTriggerEnter(Collider other)
    {
        //ZombieController zombie = other.GetComponent<ZombieController>();
        RunnerController runnerController = other.GetComponent<RunnerController>();
        if (runnerController != null)
        {
            if (explodingBarrel != null)
            {
                TutorialManager.isExplodeTutorialActive = true;
                explodingBarrel.SetExplodeImageActive(true);
                explodingBarrel.SetAimCircleImageActive(true);
                explodingBarrel.SetTutorialHitZoneActive(true);
                tutorialManager.ActivateTutorial();

                if (PlayerPrefs.GetInt(tutorialExplodeTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Activated" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialExplodeTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialExplodeTriggeredEventName, 1);
                }

                gameObject.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.GetInt(tutorialExplodeTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Skipped" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialExplodeTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialExplodeTriggeredEventName, 1);
                }
                if (PlayerPrefs.GetInt(tutorialExplodeEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialExplodeEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialExplodeEndedEventName, 1);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
