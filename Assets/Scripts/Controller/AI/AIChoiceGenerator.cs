using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChoiceGenerator : IChoiceGenerator
{
    public object GenerateRandomChoice()
    {
        return Extensions.GetRandomValue<RPSLSChoice>();
    }
}
