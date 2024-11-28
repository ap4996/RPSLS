public class GameLogic : IGameLogic
{
    public object GetWinner(object player1Hand, object player2Hand, object rule)
    {
        var data = VerifyAndCastData(player1Hand, player2Hand, rule);
        if (data.castingSuccessful)
        {
            return DetermineWinner(data.player1Choice, data.player2Choice, data.rule);
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

    private VerifiedChoiceData<RPSLSChoice, GameRules.Rule> VerifyAndCastData(object player1Hand, object player2Hand, object rule)
    {
        var data = new VerifiedChoiceData<RPSLSChoice, GameRules.Rule>();
        if (player1Hand is RPSLSChoice && player2Hand is RPSLSChoice && rule is GameRules.Rule)
        {
            data.player1Choice = (RPSLSChoice)player1Hand;
            data.player2Choice = (RPSLSChoice)player2Hand;
            data.rule = (GameRules.Rule)rule;
            data.castingSuccessful = true;
        }
        return data;
    }
}
