using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer
{
    public float timeRemaining ;
    public bool timerIsRunning = false;
    public Text timeText;

    public Timer(Text ti,float tim)
    {
        this.timeText = ti;
        this.timeRemaining = tim;
    }
    public void StartTime()
    {
        timerIsRunning = true;
        Time.timeScale = 1;
    }
    public void UpdateTime()
    {
        if(timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                DisplayTime(timeRemaining);
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        //timeToDisplay += 1;
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        float milliSeconds = (timeToDisplay % 1) * 1000;
        //timeText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliSeconds);
    }
}