using UnityEngine;

public class VerifiedChoiceData<T, Y>
{
    public bool castingSuccessful;
    public T player1Choice;
    public T player2Choice;
    public Y rule;
}

public class PlayerChoice
{
    public RPSLSChoice choice;
    public PlayerType playerType;
    public Sprite sprite;
    public string name;
}

public class GameResult<T>
{
    public T result;
}

public enum RPSLSChoice
{
    None,
    Rock,
    Paper,
    Scissors,
    Lizard,
    Spock
}

public enum Result
{
    Undetermined,
    Player1Win,
    Player2Win,
    Draw
}

public enum PlayerType
{
    Player1,
    Player2,
    SinglePlayer,
    Computer
}