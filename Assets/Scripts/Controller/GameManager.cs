using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameRules rules;
    public GameTurnManager turnManager;

    private IChoiceGenerator choiceGenerator;
    private IGameLogic gameLogic;
    private int userWins;

    private void Start()
    {
        gameLogic = new GameLogic();
        choiceGenerator = new AIChoiceGenerator();

        EventManager.Subscribe<PlayerChoice>(Events.ChoiceSelected, OnChoiceSelected);
        EventManager.Subscribe(Events.TimerEnded, OnTimerEnded);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe<PlayerChoice>(Events.ChoiceSelected, OnChoiceSelected);
        EventManager.Unsubscribe(Events.TimerEnded, OnTimerEnded);
    }

    private void OnChoiceSelected(object choice)
    {
        if(choice is PlayerChoice)
        {
            PlayerChoice playerChoice = (PlayerChoice)choice;
            if(playerChoice.playerType == PlayerType.SinglePlayer)
            {
                DetermineWinnerForSinglePlayerGame(playerChoice.choice);
            }
        }
    }

    private void DetermineWinnerForSinglePlayerGame(RPSLSChoice playerChoice)
    {
        var computerChoice = choiceGenerator.SelectComputerChoice(rules);
        var result = gameLogic.GetWinner(playerChoice, computerChoice, rules.GetRuleForChoice(playerChoice));
        Debug.Log($"Player 1 Choice : {playerChoice} Player 2 Choice : {computerChoice} Result : {result}");
        CheckAndIncreaseUserWins(result);
        EventManager.TriggerEvent(Events.GameResult, new GameResult<Result> { result = (Result)result });
    }

    private void OnTimerEnded()
    {
        Debug.Log("Timer Ended without selecting any choice");
        EventManager.TriggerEvent(Events.GameResult, new GameResult<Result> { result = Result.Undetermined });
    }

    private void CheckAndIncreaseUserWins(object result)
    {
        if(result is Result)
        {
            var res = (Result)result;
            if(res == Result.Player1Win)
            {
                ++userWins;
            }
            int highscore = PlayerPrefs.GetInt("highscore", 0);
            if (userWins > highscore)
            {
                PlayerPrefs.SetInt("highscore", userWins);
            }
        }
    }
}
