using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rules", menuName = "GameRules")]
public class GameRules : ScriptableObject
{
    public List<Rule> rules;

    public Rule GetRuleForChoice(RPSLSChoice choice)
    {
        return rules.Find(x => x.choice == choice);
    }

    [Serializable]
    public class Rule
    {
        public string name;
        public Sprite sprite;
        public RPSLSChoice choice;
        public List<RPSLSChoice> beats;
    }
}
