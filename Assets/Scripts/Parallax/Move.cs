using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move : MonoBehaviour
{
    public Ease ease;
    public float duration;

    public float FinalPoint;
    // Start is called before the first frame update
    void Start()
    {
        DOTween.Init(false, true);
        transform.DOMoveX(FinalPoint, duration).SetEase(ease).SetLoops(-1,LoopType.Restart);
        //DOTween.PauseAll();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
