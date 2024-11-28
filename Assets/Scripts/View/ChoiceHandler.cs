using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceHandler : MonoBehaviour
{
    public Image choiceImage;
    public TMP_Text choiceName;
    public Button button;

    public static event Action<object, object> OnChoiceSelect;

    private RPSLSChoice choice;

    public void RenderChoice(string name, Sprite icon, RPSLSChoice choice)
    {
        SetChoiceImage(icon);
        SetChoiceName(name);
        SetGameObjectName(name);
        SetChoice(choice);
        SetButton();
    }

    private void SetButton()
    {
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(ButtonDelegate);
    }

    private void ButtonDelegate()
    {
        OnChoiceSelect?.Invoke(choice, PlayerType.SinglePlayer);
    }

    private void SetChoice(RPSLSChoice choice)
    {
        this.choice = choice;
    }

    private void SetGameObjectName(string name)
    {
        gameObject.name = name;
    }

    private void SetChoiceName(string name)
    {
        choiceName.text = name;
    }

    private void SetChoiceImage(Sprite icon)
    {
        choiceImage.sprite = icon;
    }
}
