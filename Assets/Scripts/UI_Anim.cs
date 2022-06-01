using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Anim : MonoBehaviour
{

    public RectTransform Thisrect;
    public Vector2 FinalPos;
    public float Duration;
    public Ease ThisEase;

    private Vector2 initialPos;
    /// <summary>
    /// Responsible for Animation
    /// </summary>
    private void OnEnable()
    {
        DOTween.Init(false, true);
        initialPos = Thisrect.anchoredPosition;
        Thisrect.DOAnchorPos(FinalPos, Duration).SetEase(ThisEase);
    }
    /// <summary>
    /// Responsible for Restting the Position
    /// </summary>
    private void OnDisable()
    {
        Thisrect.DOAnchorPos(initialPos, Duration);

    }
}
