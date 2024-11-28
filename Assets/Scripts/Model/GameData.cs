using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    
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