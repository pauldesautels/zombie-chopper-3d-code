using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Loading : MonoBehaviour
{
    [SerializeField] Slider slider; 
    private float time;
    private float second;

    // Start is called before the first frame update
    void Start()
    {
        second = 5;
        Invoke(nameof(LoadGame), 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (time < 5)
        {
            time += Time.deltaTime;
            slider.value = time / second;
        }
    }

    public void LoadGame()
    {
        Loader.Load(Loader.Scene.Home);
    }
}
