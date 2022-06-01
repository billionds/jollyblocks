using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UiPopup : MonoBehaviour
{
    public RectTransform Rect;
    public float finalscale;
   
    public float Duration;
    public Ease ThisEase;
    // Start is called before the first frame update
    private void OnEnable()
    {
        DOTween.Init(false, true);
        Rect.DOScale(finalscale, Duration).SetEase(ThisEase);
    }
    private void OnDisable()
    {
        Rect.DOScale(0, 0.1f).SetEase(ThisEase);

    }
}
