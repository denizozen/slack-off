using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static Action OnMinuteChanged;
    public static Action OnHourChanged;

    public static int minute;
    public static int hour;

    private float minuteToRealTime = 3f;
    private float timer;
    void Start()
    {
        minute = 0;
        hour = 15;
        timer = minuteToRealTime;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            minute++;
            OnMinuteChanged?.Invoke();
            if (minute >= 60)
            {
                hour++;
                minute = 0;
                OnHourChanged?.Invoke();
            }
            timer = minuteToRealTime;
        }

        if (hour == 17)
        {
            SceneManager.LoadScene("Successful finish");
        }
    }
}
