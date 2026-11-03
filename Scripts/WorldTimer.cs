using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Services.Analytics;

public class WorldTimer : MonoBehaviour
{
    // Static References
    public static WorldTimer instance;

    // Used for adding time;
    private int timeCollected = 0; // seconds.
    private int secondsCollected = 0;
    private int minutesCollected = 0;
    private int hoursCollected = 0;

    // Used for subtracting time;
    private int timeLeft; // seconds.
    private int secondsLeft = 0;
    private int minutesLeft = 0;
    private int hoursLeft = 0;

    private PackManager packManager;
    private HomeUI homeUI;
    private HomeManager homeManager;

    private bool isSubtractingTimerRunning;

    // Analytics.
    private int playTime;
    private int secondsIn1Mins = 120;
    private int secondsIn2Mins = 120;
    private int secondsIn3Mins = 180;
    private int secondsIn4Mins = 240;
    private int secondsIn5Mins = 300;
    private int secondsIn10Mins = 600;
    private int secondsIn15Mins = 900;
    private int secondsIn20Mins = 1200;
    private int secondsIn25Mins = 1500;
    private int secondsIn30Mins = 1800;
    private int secondsIn35Mins = 2100;
    private int secondsIn40Mins = 2400;
    private int secondsIn45Mins = 2700;
    private int secondsIn50Mins = 3000;
    private int secondsIn55Mins = 3300;
    private int secondsIn60Mins = 3600;
    private string playTimePlayerPrefsName = "playTime";
    private string playTime1MinsEventName = "playTime1Mins"; // 0 means false, 1 means true
    private string playTime2MinsEventName = "playTime2Mins";
    private string playTime3MinsEventName = "playTime3Mins";
    private string playTime4MinsEventName = "playTime4Mins";
    private string playTime5MinsEventName = "playTime5Mins";
    private string playTime10MinsEventName = "playTime10Mins";
    private string playTime15MinsEventName = "playTime15Mins";
    private string playTime20MinsEventName = "playTime20Mins";
    private string playTime25MinsEventName = "playTime25Mins";
    private string playTime30MinsEventName = "playTime30Mins";
    private string playTime35MinsEventName = "playTime35Mins";
    private string playTime40MinsEventName = "playTime40Mins";
    private string playTime45MinsEventName = "playTime45Mins";
    private string playTime50MinsEventName = "playTime50Mins";
    private string playTime55MinsEventName = "playTime55Mins";
    private string playTime60MinsEventName = "playTime60Mins";

    private void Awake()
    {
        if (instance == null)
        {
            //First run, set the instance
            instance = this;
            DontDestroyOnLoad(gameObject);

        }
        else if (instance != this)
        {
            //Instance is not the same as the one we have, destroy old one, and reset to newest one
            Destroy(instance.gameObject);
            isSubtractingTimerRunning = false;
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        packManager = FindObjectOfType<PackManager>();
        homeUI = FindObjectOfType<HomeUI>();
        homeManager = FindObjectOfType<HomeManager>();

        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0 && packManager.GetIsStarterPackPurchased() == 0)
        {
            timeLeft = packManager.GetStarterPackOfferTimeRemaining();
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0 && packManager.GetIsSecondPackPurchased() == 0)
        {
            timeLeft = packManager.GetSecondPackOfferTimeRemaining();
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0 && packManager.GetIsThirdPackPurchased() == 0)
        {
            timeLeft = packManager.GetThirdPackOfferTimeRemaining();
        }
        secondsLeft = (timeLeft % 60);
        minutesLeft = (timeLeft / 60) % 60;
        hoursLeft = (timeLeft / 3600) % 24;
        if (hoursLeft <= 0 && minutesLeft <= 0 && secondsLeft <= 0)
        {
            if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0 && packManager.GetIsStarterPackPurchased() == 0)
            {
                packManager.SetIsStarterPackLastChance(true);
            }
            if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0 && packManager.GetIsSecondPackPurchased() == 0)
            {
                packManager.SetIsSecondPackLastChance(true);
            }
            if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0 && packManager.GetIsThirdPackPurchased() == 0)
            {
                packManager.SetIsThirdPackLastChance(true);
            }
        }
    }

    private void Start()
    {
        playTime = PlayerPrefs.GetInt(playTimePlayerPrefsName);
        StartAddTimer();
        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0
            && !packManager.GetIsStarterPackMenuShowing() && packManager.GetIsStarterPackPurchased() == 0
            && homeManager.GetIsShowingGunTrial() == false && homeManager.GetIsShowingShieldPack() == false)
        {
            if (packManager.GetIsStarterPackLastChance())
            {
                packManager.SetStarterPackOfferMenuActive(true);
            }
            else
            {
                homeUI.SetStarterPackBtnActive(true);
            }
        }

        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0
            && !packManager.GetIsSecondPackMenuShowing() && packManager.GetIsSecondPackPurchased() == 0
            && homeManager.GetIsShowingGunTrial() == false && homeManager.GetIsShowingShieldPack() == false)
        {
            if (packManager.GetIsSecondPackLastChance())
            {
                packManager.SetSecondPackOfferMenuActive(true);
            }
            else
            {
                homeUI.SetSecondPackBtnActive(true);
            }
        }

        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0
          && !packManager.GetIsThirdPackMenuShowing() && packManager.GetIsThirdPackPurchased() == 0
          && homeManager.GetIsShowingGunTrial() == false && homeManager.GetIsShowingShieldPack() == false)
        {
            if (packManager.GetIsThirdPackLastChance())
            {
                packManager.SetThirdPackOfferMenuActive(true);
            }
            else
            {
                homeUI.SetThirdPackBtnActive(true);
            }
        }
    }

    private IEnumerator AddTime()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(1);
            timeCollected += 1;
            secondsCollected = (timeCollected % 60);
            minutesCollected = (timeCollected / 60) % 60;
            hoursCollected = (timeCollected / 3600) % 24;
            playTime += 1;
            PlayerPrefs.SetInt(playTimePlayerPrefsName, playTime);
            if (playTime >= secondsIn1Mins && PlayerPrefs.GetInt(playTime1MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime1MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime1MinsEventName, 1);
            }
            if (playTime >= secondsIn2Mins && PlayerPrefs.GetInt(playTime2MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime2MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime2MinsEventName, 1);
            }
            if (playTime >= secondsIn3Mins && PlayerPrefs.GetInt(playTime3MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime3MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime3MinsEventName, 1);
            }
            if (playTime >= secondsIn4Mins && PlayerPrefs.GetInt(playTime4MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime4MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime4MinsEventName, 1);
            }
            if (playTime >= secondsIn5Mins && PlayerPrefs.GetInt(playTime5MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime5MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime5MinsEventName, 1);
            }
            if (playTime >= secondsIn10Mins && PlayerPrefs.GetInt(playTime10MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime10MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime10MinsEventName, 1);
            }
            if (playTime >= secondsIn15Mins && PlayerPrefs.GetInt(playTime15MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime15MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime15MinsEventName, 1);
            }
            if (playTime >= secondsIn20Mins && PlayerPrefs.GetInt(playTime20MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime20MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime20MinsEventName, 1);
            }
            if (playTime >= secondsIn25Mins && PlayerPrefs.GetInt(playTime25MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime25MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime25MinsEventName, 1);
            }
            if (playTime >= secondsIn30Mins && PlayerPrefs.GetInt(playTime30MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime30MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime30MinsEventName, 1);
            }
            if (playTime >= secondsIn35Mins && PlayerPrefs.GetInt(playTime35MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime35MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime35MinsEventName, 1);
            }
            if (playTime >= secondsIn40Mins && PlayerPrefs.GetInt(playTime40MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime40MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime40MinsEventName, 1);
            }
            if (playTime >= secondsIn45Mins && PlayerPrefs.GetInt(playTime45MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime45MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime45MinsEventName, 1);
            }
            if (playTime >= secondsIn50Mins && PlayerPrefs.GetInt(playTime50MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime50MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime50MinsEventName, 1);
            }
            if (playTime >= secondsIn55Mins && PlayerPrefs.GetInt(playTime55MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime55MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime55MinsEventName, 1);
            }
            if (playTime >= secondsIn60Mins && PlayerPrefs.GetInt(playTime60MinsEventName, 0) == 0)
            {
                Dictionary<string, object> parameters = new Dictionary<string, object>()
                {
                };
                AnalyticsService.Instance.CustomData(playTime60MinsEventName, parameters);
                PlayerPrefs.SetInt(playTime60MinsEventName, 1);
            }
        }
    }

    private IEnumerator SubtractTime(int totalTime)
    {
        SetIsSubtractingTimerRunning(true);
        timeLeft = totalTime;
        secondsLeft = (timeLeft % 60);
        minutesLeft = (timeLeft / 60) % 60;
        hoursLeft = (timeLeft / 3600) % 24;
        if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0 && packManager.GetIsStarterPackPurchased() == 0)
        {
            packManager.SetStarterPackTimeLeftText(hoursLeft, minutesLeft, secondsLeft);
        }
        if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0 && packManager.GetIsSecondPackPurchased() == 0)
        {
            packManager.SetSecondPackTimeLeftText(hoursLeft, minutesLeft, secondsLeft);
        }
        if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0 && packManager.GetIsThirdPackPurchased() == 0)
        {
            packManager.SetThirdPackTimeLeftText(hoursLeft, minutesLeft, secondsLeft);
        }
        if (hoursLeft <= 0 && minutesLeft <= 0 && secondsLeft <= 0)
        {
            if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0 && packManager.GetIsStarterPackPurchased() == 0)
            {
                packManager.SetStarterPackLastChanceText();
            }
            if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0 && packManager.GetIsSecondPackPurchased() == 0)
            {
                packManager.SetSecondPackLastChanceText();
            }
            if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0 && packManager.GetIsThirdPackPurchased() == 0)
            {
                packManager.SetThirdPackLastChanceText();
            }
            SetIsSubtractingTimerRunning(false);
        }

        while (GetIsSubtractingTimerRunning())
        {
            yield return new WaitForSecondsRealtime(1);
            timeLeft -= 1;
            secondsLeft = (timeLeft % 60);
            minutesLeft = (timeLeft / 60) % 60;
            hoursLeft = (timeLeft / 3600) % 24;
            if (packManager.GetIsStarterPackOffered() == 1 && packManager.GetIsStarterPackExpired() == 0 && packManager.GetIsStarterPackPurchased() == 0)
            {
                packManager.SaveStarterPackTimeRemaining(timeLeft);
            }
            if (packManager.GetIsSecondPackOffered() == 1 && packManager.GetIsSecondPackExpired() == 0 && packManager.GetIsSecondPackPurchased() == 0)
            {
                packManager.SaveSecondPackTimeRemaining(timeLeft);
            }
            if (packManager.GetIsThirdPackOffered() == 1 && packManager.GetIsThirdPackExpired() == 0 && packManager.GetIsThirdPackPurchased() == 0)
            {
                packManager.SaveThirdPackTimeRemaining(timeLeft);
            }
            if (packManager.GetIsStarterPackMenuShowing() || packManager.GetIsStarterPackTabShowing())
            {
                packManager.SetStarterPackTimeLeftText(hoursLeft, minutesLeft, secondsLeft);

                if (hoursLeft <= 0 && minutesLeft <= 0 && secondsLeft <= 0)
                {
                    packManager.SetStarterPackLastChanceText();
                    SetIsSubtractingTimerRunning(false);
                }
            }
            if (packManager.GetIsSecondPackMenuShowing() || packManager.GetIsSecondPackTabShowing())
            {
                packManager.SetSecondPackTimeLeftText(hoursLeft, minutesLeft, secondsLeft);

                if (hoursLeft <= 0 && minutesLeft <= 0 && secondsLeft <= 0)
                {
                    packManager.SetSecondPackLastChanceText();
                    SetIsSubtractingTimerRunning(false);
                }
            }
            if (packManager.GetIsThirdPackMenuShowing() || packManager.GetIsThirdPackTabShowing())
            {
                packManager.SetThirdPackTimeLeftText(hoursLeft, minutesLeft, secondsLeft);

                if (hoursLeft <= 0 && minutesLeft <= 0 && secondsLeft <= 0)
                {
                    packManager.SetThirdPackLastChanceText();
                    SetIsSubtractingTimerRunning(false);
                }
            }
        }
    }

    public void StartAddTimer()
    {
        StartCoroutine(nameof(AddTime));
    }

    public void StartSubtractTimer(int totalTime)
    {
        StartCoroutine(nameof(SubtractTime), totalTime);
    }

    public void SetOfferTimeLeft(int timeLeft)
    {
        this.timeLeft = timeLeft;
    }

    public void SetIsSubtractingTimerRunning(bool isStarted)
    {
        isSubtractingTimerRunning = isStarted;
    }

    public bool GetIsSubtractingTimerRunning()
    {
        return isSubtractingTimerRunning;
    }

    public int GetCollectedSeconds()
    {
        return secondsCollected;
    }

    public int GetCollectedMinutes()
    {
        return minutesCollected;
    }

    public int GetCollectedHours()
    {
        return hoursCollected;
    }

    public int GetSecondsLeft()
    {
        return secondsLeft;
    }

    public int GetMinutesLeft()
    {
        return minutesLeft;
    }

    public int GetHoursLeft()
    {
        return hoursLeft;
    }
}
