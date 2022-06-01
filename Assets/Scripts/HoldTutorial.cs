using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldTutorial : MonoBehaviour
{
    public RectTransform Thisrect;
    private Vector2 initialPos;

    private void OnEnable()
    {
        DOTween.Init(false, true);
        initialPos = Thisrect.anchoredPosition;
        Thisrect.DOAnchorPosX(100, 1).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InSine);
    }
    private void OnDisable()
    {
        Thisrect.DOAnchorPos(initialPos, 0.1f);

    }
}
