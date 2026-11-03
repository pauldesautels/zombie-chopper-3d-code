using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class TutorialManager : MonoBehaviour
{
    private GameManager gameManager;
    private CameraManager cameraManager;
    private LevelUI levelUI;

    private float tutorialCamBlendTime = .5f;

    public static bool isShootingTutorialActive;
    public static bool isExplodeTutorialActive;
    public static bool isGlassTutorialActive;
    public static bool isFallTutorialActive;
    public static bool isBridgeTutorialActive;

    private bool isTutorialActive;

    // Analytics.
    private string tutorialShootEndedEventName = "tutorialShootEnded";
    private string tutorialExplodeEndedEventName = "tutorialExplodeEnded";
    private string tutorialGlassEndedEventName = "tutorialGlassEnded";
    private string tutorialFallEndedEventName = "tutorialFallEnded";
    private string tutorialBridgeEndedEventName = "tutorialBridgeEnded";

    // Start is called before the first frame update
    void Start()
    {
        ResetTutorials();

        gameManager = FindObjectOfType<GameManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        levelUI = FindObjectOfType<LevelUI>();
    }

    public void ActivateTutorial()
    {
        if (!GameManager.isGameOver)
        {
            //Debug.Log("TUTORIAL ACTIVATED!");
            cameraManager.SetAlertCamPriority(40);
            StartCoroutine(nameof(WaitFreezeTime), tutorialCamBlendTime);
            levelUI.SetGameUIActive(false);
            levelUI.SetCreditsImageActive(false);
            if (gameManager.currentLevel != 1)
            {
                levelUI.SetShieldImageActive(false);
            }
            isTutorialActive = true;
        }
    }

    public void DeactivateTutorial()
    {
        if (isTutorialActive)
        {
            //Debug.Log("TUTORIAL DEACTIVATED!");
            cameraManager.SetAlertCamPriority(0);
            levelUI.SetPauseBtnActive(true);
            gameManager.ResumeTime();
            levelUI.SetGameUIActive(true);
            levelUI.SetCreditsImageActive(true);
            if (gameManager.currentLevel != 1)
            {
                levelUI.SetShieldImageActive(true);
            }

            if (isShootingTutorialActive)
            {
                if (PlayerPrefs.GetInt(tutorialShootEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialShootEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialShootEndedEventName, 1);
                }
            }
            if (isExplodeTutorialActive)
            {
                if (PlayerPrefs.GetInt(tutorialExplodeEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialExplodeEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialExplodeEndedEventName, 1);
                }
                isExplodeTutorialActive = false;
            }
            if (isGlassTutorialActive)
            {
                if (PlayerPrefs.GetInt(tutorialGlassEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialGlassEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialGlassEndedEventName, 1);
                }
                isGlassTutorialActive = false;
            }
            if (isFallTutorialActive)
            {
                if (PlayerPrefs.GetInt(tutorialFallEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialFallEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialFallEndedEventName, 1);
                }
                isFallTutorialActive = false;
            }
            if (isBridgeTutorialActive)
            {
                if (PlayerPrefs.GetInt(tutorialBridgeEndedEventName, 0) == 0)
                {
                    Dictionary<string, object> parameters = new Dictionary<string, object>()
                    {
                    };
                    AnalyticsService.Instance.CustomData(tutorialBridgeEndedEventName, parameters);
                    PlayerPrefs.SetInt(tutorialBridgeEndedEventName, 1);
                }
                isBridgeTutorialActive = false;
            }

            isTutorialActive = false;
        }
    }

    public IEnumerator WaitFreezeTime(float camBlendTime)
    {
        yield return new WaitForSeconds(camBlendTime);

        if (isShootingTutorialActive || isExplodeTutorialActive || isGlassTutorialActive || isFallTutorialActive || isBridgeTutorialActive)
        {
            gameManager.FreezeTime();
        }
    }

    private void ResetTutorials()
    {
        isShootingTutorialActive = false;
        isExplodeTutorialActive = false;
        isGlassTutorialActive = false;
        isFallTutorialActive = false;
        isBridgeTutorialActive = false;
    }
}
