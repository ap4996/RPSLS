using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System.Threading.Tasks;

public class ChoicesAnimation : MonoBehaviour
{
    public Image animatedChoiceImage;
    public Transform initialPosition;
    public Vector3 initialScale, finalScale;

    private const float animTime = 0.75f;

    public async void ShowChoices(List<ChoiceHandler> choices)
    {
        for(int i = 0; i < choices.Count; ++i)
        {
            SetInitialImagePositionAndScale();
            RenderChoiceImage(choices[i].choiceImage.sprite);
            MoveChoiceToActualPosition(choices[i].choiceImage.transform);
            await Task.Delay(1000);
        }
    }

    private void RenderChoiceImage(Sprite sprite)
    {
        animatedChoiceImage.sprite = sprite;
    }

    private void SetInitialImagePositionAndScale()
    {
        animatedChoiceImage.transform.position = initialPosition.position;
        animatedChoiceImage.transform.localScale = initialScale;
    }

    private void MoveChoiceToActualPosition(Transform pos)
    {
        animatedChoiceImage.gameObject.SetActive(true);
        animatedChoiceImage.transform.DOMove(pos.position, animTime).SetEase(Ease.OutCubic).OnComplete(() => { 
            pos.gameObject.SetActive(true);
        });
        animatedChoiceImage.transform.DOScale(finalScale, animTime).SetEase(Ease.OutBack).OnComplete(OnAnimationComplete);
    }

    private void OnAnimationComplete()
    {
        animatedChoiceImage.gameObject.SetActive(false);
        SetInitialImagePositionAndScale();
    }
}
