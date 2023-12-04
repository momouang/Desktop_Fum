using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    [SerializeField]
    float currentTime;
    public float targetTime;
    public TMP_Text text;
    public bool isCounting;

    [SerializeField]
    UnityEvent triggerEvent;
    public bool timeUp = false;

    private void Start()
    {
        currentTime = targetTime;
    }

    private void Update()
    {
        if(isCounting)
        {
            CountDownTimer();
        }
        else
        {
            NormalTimer();
        }
    }

    void NormalTimer()
    {
        string realtime = System.DateTime.Now.Hour.ToString() + ":" + System.DateTime.Now.Minute.ToString();
        displayTime(realtime);
    }

    void CountDownTimer()
    {
        if(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
        }
        else
        {
            currentTime = 0;
        }

        displayTime(currentTime);
    }

    void displayTime(string realTime)
    {
        text.text = realTime;
    }

    void displayTime(float timetoDisplay)
    {
        if(timetoDisplay <= 0 && !timeUp)
        {
            timetoDisplay = 0;
            timeUp = true;
            triggerEvent.Invoke();
        }

        float minutes = Mathf.FloorToInt(timetoDisplay / 60);
        float seconds = Mathf.FloorToInt(timetoDisplay % 60);

        text.text = string.Format("{0:00}:{1:00}",minutes,seconds + " " +"Left");

    }
}
