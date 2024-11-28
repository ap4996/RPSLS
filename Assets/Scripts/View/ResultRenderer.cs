using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultRenderer : MonoBehaviour
{
    public TMP_Text winner;
    public Button nextButton;

    private void Start()
    {
        EventManager.Subscribe<GameResult<Result>>(Events.GameResult, ShowResult);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe<GameResult<Result>>(Events.GameResult, ShowResult);
    }

    private void ShowResult(object result)
    {
        if(result is GameResult<Result>)
        {
            var res = (GameResult<Result>)result;
            SetWinnerText(res.result);
            SetButton(res.result);
            EnableResult(true);
        }
    }

    private void SetWinnerText(Result result)
    {
        switch (result)
        {
            case Result.Undetermined:
                winner.text = "Turn Missed! :(";
                break;
            case Result.Player1Win:
                winner.text = "You Win! :D";
                break;
            case Result.Player2Win:
                winner.text = "Computer Wins! :(";
                break;
            case Result.Draw:
                winner.text = "It's a Draw! :v";
                break;
        }
    }

    private void SetButton(Result result)
    {
        nextButton.onClick.RemoveAllListeners();
        nextButton.onClick.AddListener(() => NextButtonDelegate(result));
    }

    private void NextButtonDelegate(Result result)
    {
        if(result == Result.Player1Win || result == Result.Draw)
        {
            GoToNextRound();
        }
        else
        {
            RestartGame();
        }
        EnableResult(false);
    }

    private void GoToNextRound()
    {
        EventManager.TriggerEvent(Events.StartGame);
    }

    private void RestartGame()
    {
        EventManager.TriggerEvent(Events.RestartGame);
    }

    private void EnableResult(bool enable)
    {
        winner.gameObject.SetActive(enable);
        nextButton.gameObject.SetActive(enable);
    }
}
