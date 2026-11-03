using UnityEngine;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class AnalyticsInitializer : MonoBehaviour
{
    public static AnalyticsInitializer instance;
    private string newGameStartedEventName = "newGameStarted"; // 0 means false, 1 means true

    async void Awake()
    {
        try
        {
            if (instance == null)
            {
                await UnityServices.InitializeAsync();
                List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
                Debug.Log("Unity Analytics initialization complete.");
                instance = this;
                if (SceneManager.GetActiveScene().name == "Home")
                {
                    if (PlayerPrefs.GetInt(newGameStartedEventName, 0) == 0)
                    {
                        Dictionary<string, object> parameters = new Dictionary<string, object>()
                        {
                        };
                        AnalyticsService.Instance.CustomData(newGameStartedEventName, parameters);
                        PlayerPrefs.SetInt(newGameStartedEventName, 1);
                    }
                }
                if (this != null)
                {
                    DontDestroyOnLoad(this);
                }
            }
        }
        catch (ConsentCheckException e)
        {
            //Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately
        }
    }
}
