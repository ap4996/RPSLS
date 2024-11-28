using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTurnManager : MonoBehaviour
{
    public Slider timerBar;
    public float timeForMakingChoice;

    private bool isTimerRunning;
    private float turnTimer;

    private void Awake()
    {
        EventManager.Subscribe<PlayerChoice>(Events.ChoiceSelected, StopTimer);
        EventManager.Subscribe(Events.StartTimer, StartTimer);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe<PlayerChoice>(Events.ChoiceSelected, StopTimer);
        EventManager.Unsubscribe(Events.StartTimer, StartTimer);
    }

    public void InitTimer()
    {
        UpdateUI();
    }

    public void StartTimer()
    {
        gameObject.SetActive(true);
        turnTimer = timeForMakingChoice;
        isTimerRunning = true;
    }

    public void StopTimer(object choice)
    {
        if(choice is PlayerChoice)
        {
            var c = (PlayerChoice)choice;
            if(c.playerType == PlayerType.SinglePlayer)
            {
                isTimerRunning = false;
                turnTimer = timeForMakingChoice;
                gameObject.SetActive(false);
                UpdateUI();
            }
        }
    }

    private void Update()
    {
        if(isTimerRunning)
        {
            RunTimer();
            UpdateUI();
        }
    }

    private void RunTimer()
    {
        turnTimer -= Time.deltaTime;
        if (turnTimer <= 0)
        {
            isTimerRunning = false;
            Debug.Log("Timer ended");
            EventManager.TriggerEvent(Events.TimerEnded);
        }
    }

    private void UpdateUI()
    {
        timerBar.value = turnTimer / timeForMakingChoice;
    }
}
