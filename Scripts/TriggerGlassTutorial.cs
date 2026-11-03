using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class TriggerGlassTutorial : MonoBehaviour
{
    [SerializeField] private TutorialManager tutorialManager;
    [SerializeField] private GlassPane glassPane;

    // Analytics.
    private string tutorialGlassTriggeredEventName = "tutorialGlassTriggered"; // 0 means false, 1 means true
    private string tutorialGlassEndedEventName = "tutorialGlassEnded";

    private void OnTriggerEnter(Collider other)
    {
        ZombieController zombie = other.GetComponent<ZombieController>();
        if (zombie != null)
        {
            if (glassPane != null)
            {
                TutorialManager.isGlassTutorialActive = true;
                glassPane.SetBreakImageActive(true);
                glassPane.SetAimCircleImageActive(true);
                glassPane.SetTutorialHitZoneActive(true);
                tutorialManager.ActivateTutorial();

                if (PlayerPrefs.GetInt(tutorialGlassTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Activated" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialGlassTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialGlassTriggeredEventName, 1);
                }

                gameObject.SetActive(false);
            }
            else
            {
                if (PlayerPrefs.GetInt(tutorialGlassTriggeredEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                        {  "tutorialStatus", "Skipped" },
                    };
                    AnalyticsService.Instance.CustomData(tutorialGlassTriggeredEventName, parameters);
                    PlayerPrefs.SetInt(tutorialGlassTriggeredEventName, 1);
                }
                if (PlayerPrefs.GetInt(tutorialGlassEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialGlassEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialGlassEndedEventName, 1);
                }

                gameObject.SetActive(false);
            }
        }
    }
}
