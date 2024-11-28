using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIChoiceGenerator : IChoiceGenerator
{
    public object GenerateRandomChoice()
    {
        return Extensions.GetRandomValue<RPSLSChoice>();
    }

    public object SelectComputerChoice(object rule)
    {
        if(rule is GameRules)
        {
            var r = (GameRules)rule;
            var computerChoice = (RPSLSChoice)GenerateRandomChoice();
            Debug.Log(computerChoice);
            var cr = r.GetRuleForChoice(computerChoice);
            EventManager.TriggerEvent(Events.ChoiceSelected, new PlayerChoice { choice = computerChoice, name = cr.name, playerType = PlayerType.Computer, sprite = cr.sprite});
            return computerChoice;
        }
        return null;
    }
}
