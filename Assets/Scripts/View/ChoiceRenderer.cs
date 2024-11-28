using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoiceRenderer : MonoBehaviour
{
    public List<ChoiceHandler> choiceHandlers;
    public GameRules gameRules;
    public ChoiceHandler choiceHandlerPrefab;
    public ChoicesAnimation choicesAnimation;

    public void SetupChoices()
    {
        DisableAllChoices();
        InstantiateChoices(gameRules.rules.Count);
        AddChoiceHandlersToTheList(gameRules.rules.Count);
        RenderChoices();
        StartTimer();
    }

    private void RenderChoices()
    {
        for (int i = 0; i < choiceHandlers.Count; ++i)
        {
            choiceHandlers[i].gameObject.SetActive(true);
            choiceHandlers[i].RenderChoice(gameRules.rules[i].name, gameRules.rules[i].sprite, gameRules.rules[i].choice);
        }
    }

    private void AddChoiceHandlersToTheList(int numberOfChoices)
    {
        choiceHandlers = new List<ChoiceHandler>();
        for(int i = 0; i < numberOfChoices; ++i)
        {
            choiceHandlers.Add(transform.GetChild(i).GetComponent<ChoiceHandler>());
        }
    }

    private void InstantiateChoices(int numberOfChoices)
    {
        if(transform.childCount < numberOfChoices)
        {
            for(int i = transform.childCount; i < numberOfChoices; ++i)
            {
                Instantiate(choiceHandlerPrefab, transform);
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

    //Not using this because the animation seemed too long, might refine it later
    private IEnumerator ShowAnimation()
    {
        yield return new WaitForEndOfFrame();
        choicesAnimation.ShowChoices(choiceHandlers);
    }

    private void StartTimer()
    {
        Debug.Log("Start Timemr");
        EventManager.TriggerEvent(Events.StartTimer);
    }
}
