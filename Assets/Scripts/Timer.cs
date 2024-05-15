using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 30;
    public bool IsRunning = false;
    public TextMeshProUGUI timerText;

    void Start()
    {

    }
    void DisplayTime(float TimetoDisplay)
    {
        TimetoDisplay += 1;
        float Minutes = Mathf.FloorToInt(TimetoDisplay / 60);
        float Seconds = Mathf.FloorToInt(TimetoDisplay%60);
        timerText.text = string.Format("{0:00}:{1:00}", Minutes, Seconds);
    }
    void Update()
    {
        if (IsRunning == true)
        {
            if (timeRemaining >= 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                IsRunning = false;
                timeRemaining = 0;
            }
        }
    }
}