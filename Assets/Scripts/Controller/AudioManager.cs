using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip winClip, lossClip;

    private void Start()
    {
        EventManager.Subscribe<GameResult<Result>>(Events.GameResult, PlayResultSound);
    }

    private void OnDestroy()
    {
        EventManager.Unsubscribe<GameResult<Result>>(Events.GameResult, PlayResultSound);
    }

    private void PlayResultSound(object res)
    {
        if(res is GameResult<Result>)
        {
            var result = (GameResult<Result>)res;
            PlayResultSound(result.result == Result.Player1Win);
        }
    }

    private void PlayResultSound(bool isWin)
    {
        audioSource.clip = isWin ? winClip : lossClip;
        audioSource.Play();
    }
}
