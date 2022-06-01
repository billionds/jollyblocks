using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoatAnim : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnEnable()
    {
        DOTween.Init(false, true);
        transform.DOLocalRotate(new Vector3(0, 0, -2), 1f, RotateMode.Fast).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        
    }
    private void OnDisable()
    {
        transform.DOLocalRotate(Vector3.zero, 0.5f, RotateMode.Fast);
    }
}
