using System.Collections.Generic;
using UnityEngine;

public class ChoiceRenderer : MonoBehaviour
{
    public List<ChoiceHandler> choiceHandlers;
    public GameRules gameRules;
    public ChoiceHandler choiceHandlerPrefab;

    private void Start()
    {
        SetupChoices();
    }

    private void SetupChoices()
    {
        DisableAllChoices();
        InstantiateChoices(gameRules.rules.Count);
        RenderChoices();
    }

    private void RenderChoices()
    {
        for (int i = 0; i < choiceHandlers.Count; ++i)
        {
            choiceHandlers[i].RenderChoice(gameRules.rules[i].name, gameRules.rules[i].sprite, gameRules.rules[i].choice);
        }
    }

    private void InstantiateChoices(int numberOfChoices)
    {
        if(transform.childCount < numberOfChoices)
        {
            for(int i = transform.childCount; i < numberOfChoices; ++i)
            {
                ChoiceHandler handler = Instantiate(choiceHandlerPrefab, transform).GetComponent<ChoiceHandler>();
                if(handler != null)
                {
                    choiceHandlers.Add(handler);
                }
            }
        }
    }

    private void DisableAllChoices()
    {
        for(int i = 0; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }
}
