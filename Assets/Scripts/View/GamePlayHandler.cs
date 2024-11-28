using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayHandler : MonoBehaviour
{
    public ChoiceRenderer choiceRenderer;
    public GameTurnManager turnManager;
    public PlayerSectionRenderer userSectionRenderer, opponentSectionRenderer;

    private void Start()
    {
        EventManager.Subscribe(Events.StartGame, StartGame);
        EventManager.Subscribe(Events.RestartGame, RestartGame);
        EventManager.Subscribe<PlayerChoice>(Events.ChoiceSelected, OnChoiceSelected);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(Events.StartGame, StartGame);
        EventManager.Unsubscribe(Events.RestartGame, RestartGame);
        EventManager.Unsubscribe<PlayerChoice>(Events.ChoiceSelected, OnChoiceSelected);
    }

    private void StartGame()
    {
        EnableGameComponents(true);
        turnManager.InitTimer();
        choiceRenderer.SetupChoices();
    }

    private void RestartGame()
    {
        EnableGameComponents(false);
    }

    private void EnableGameComponents(bool enable)
    {
        choiceRenderer.gameObject.SetActive(enable);
        turnManager.gameObject.SetActive(enable);
        userSectionRenderer.gameObject.SetActive(enable);
        opponentSectionRenderer.gameObject.SetActive(enable);
    }

    private void OnChoiceSelected(object choice)
    {
        if(choice is PlayerChoice)
        {
            var pc = (PlayerChoice)choice;
            if(pc.playerType == PlayerType.SinglePlayer)
            {
                choiceRenderer.gameObject.SetActive(false);
            }
        }
    }
}
