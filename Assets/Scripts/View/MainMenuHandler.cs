using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuHandler : MonoBehaviour
{
    public Button playButton;
    public TMP_Text highscoreText;

    private void Start()
    {
        SetButton();
        SetupMainMenu();

        EventManager.Subscribe(Events.RestartGame, SetupMainMenu);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe(Events.RestartGame, SetupMainMenu);
    }

    private void SetButton()
    {
        playButton.onClick.RemoveAllListeners();
        playButton.onClick.AddListener(PlayButtonDelegate);
    }

    private void SetupMainMenu()
    {
        EnableMainMenuComponents(true);
        SetHighscore();
    }

    private void PlayButtonDelegate()
    {
        EnableMainMenuComponents(false);
        EventManager.TriggerEvent(Events.StartGame);
    }

    private void EnableMainMenuComponents(bool enable)
    {
        playButton.gameObject.SetActive(enable);
        highscoreText.gameObject.SetActive(enable);
    }

    private void SetHighscore()
    {
        int highscore = PlayerPrefs.GetInt("highscore", 0);
        if (highscore > 0)
        {
            highscoreText.text = $"Highscore: {highscore}";
            highscoreText.gameObject.SetActive(true);
        }
        else
        {
            highscoreText.gameObject.SetActive(false);
        }
    }
}
