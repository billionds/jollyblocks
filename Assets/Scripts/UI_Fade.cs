using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Fade : MonoBehaviour
{
    public RectTransform rect;
    public CanvasGroup canvas;
    // Start is called before the first frame update
    private void OnEnable()
    {

        DOTween.Init(false, true);
        //rect.DOScale(1.01f, 2f).SetDelay(0.1f).SetLoops(-1, LoopType.Yoyo);
        canvas.DOFade(0.3f, 1f).SetLoops(-1, LoopType.Yoyo);

    }
    private void OnDisable()
    {
        rect.DOScale(1, 1f);
        canvas.DOFade(1, 0.5f);
    }


}
