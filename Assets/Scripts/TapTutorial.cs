using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapTutorial : MonoBehaviour
{
    public RectTransform Thisrect;

    private void OnEnable()
    {
        DOTween.Init(false, true);
        Thisrect.DOScale(0.11f, 1).SetLoops(-1,LoopType.Yoyo);
    }
    private void OnDisable()
    {
        Thisrect.DOScale(0.1f, 0.1f);
    }


   

}
