using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : IGameLogic
{
    public object GetWinner(object player1Hand, object player2Hand, object rule)
    {
        var data = VerifyAndCastData(player1Hand, player2Hand, rule);
        if (data.Item1)
        {
            return DetermineWinner(data.Item2, data.Item3, data.Item4);
        }
        else
        {
            return Result.Undetermined;
        }
    }

    private Result DetermineWinner(RPSLSChoice p1, RPSLSChoice p2, GameRules.Rule rule)
    {
        if (rule.beats.Contains(p2))
        {
            return Result.Player1Win;
        }
        else if (p1 == p2)
        {
            return Result.Draw;
        }
        else
        {
            return Result.Player2Win;
        }
    }

    private (bool, RPSLSChoice, RPSLSChoice, GameRules.Rule) VerifyAndCastData(object player1Hand, object player2Hand, object rule)
    {
        bool castingSuccessful = false;
        RPSLSChoice p1 = RPSLSChoice.None;
        RPSLSChoice p2 = RPSLSChoice.None;
        GameRules.Rule r = null;
        if (player1Hand is RPSLSChoice && player2Hand is RPSLSChoice && rule is GameRules.Rule)
        {
            p1 = (RPSLSChoice)player1Hand;
            p2 = (RPSLSChoice)player2Hand;
            r = (GameRules.Rule)rule;
            castingSuccessful = true;
        }
        return (castingSuccessful, p1, p2, r);
    }
}
