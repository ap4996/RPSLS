using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSectionRenderer : MonoBehaviour
{
    public Image bgImage;
    public Image choiceImage;
    public TMP_Text choiceNameText;
    public TMP_Text playerNameText;
    public Color bgColor;
    public GameObject choiceGO;
    public string playerName;
    public PlayerType playerType;

    private void Start()
    {
        EventManager.Subscribe<PlayerChoice>(Events.ChoiceSelected, OnChoiceSelected);
        EventManager.Subscribe(Events.StartGame, SetUpSection);
    }

    private void OnEnable()
    {
        SetUpSection();
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe<PlayerChoice>(Events.ChoiceSelected, OnChoiceSelected);
        EventManager.Subscribe(Events.StartGame, SetUpSection);
    }

    private void SetUpSection()
    {
        SetBGColor();
        SetPlayerName();
        EnableChoice(false);
        EnablePlayerName(false);
    }

    private void OnChoiceSelected(object choice)
    {
        if(choice is PlayerChoice)
        {
            var c = (PlayerChoice)choice;
            if(c.playerType == playerType)
            {
                SetSelectedChoice(c);
            }
        }
    }

    private void SetSelectedChoice(PlayerChoice c)
    {
        SetChoiceImage(c.sprite);
        SetChoiceName(c.name);
        EnableChoice(true);
        EnablePlayerName(true);
    }

    private void SetBGColor()
    {
        bgImage.color = bgColor;
    }

    private void SetChoiceImage(Sprite sprite)
    {
        choiceImage.sprite = sprite;
    }

    private void SetChoiceName(string choiceName)
    {
        choiceNameText.text = choiceName;
    }

    private void SetPlayerName()
    {
        playerNameText.text = playerName;
    }

    private void EnableChoice(bool enable)
    {
        choiceGO.SetActive(enable);
    }

    private void EnablePlayerName(bool enable)
    {
        playerNameText.gameObject.SetActive(enable);
    }
}
