using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameRules rules;

    private IChoiceGenerator choiceGenerator;
    private IGameLogic gameLogic;

    private void Start()
    {
        gameLogic = new GameLogic();
        choiceGenerator = new AIChoiceGenerator();

        ChoiceHandler.OnChoiceSelect += OnChoiceSelected;
    }

    private void OnDestroy()
    {
        ChoiceHandler.OnChoiceSelect -= OnChoiceSelected;
    }

    private void OnChoiceSelected(object choice, object playerType)
    {
        if(choice is RPSLSChoice && playerType is PlayerType)
        {
            RPSLSChoice playerChoice = (RPSLSChoice)choice;
            PlayerType pType = (PlayerType)playerType;
            if(pType == PlayerType.SinglePlayer)
            {
                DetermineWinnerForSinglePlayerGame(playerChoice);
            }
        }
    }

    private void DetermineWinnerForSinglePlayerGame(RPSLSChoice playerChoice)
    {
        var computerChoice = choiceGenerator.GenerateRandomChoice();
        var result = gameLogic.GetWinner(playerChoice, computerChoice, rules.GetRuleForChoice(playerChoice));
        Debug.Log($"Player 1 Choice : {playerChoice} Player 2 Choice : {computerChoice} Result : {result}");
    }
}
