using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public int sunValue = 100;
    [SerializeField] private float destroyTime, scaleTime;
    [SerializeField] private Ease ease;
    private Tween _destroyTween;
    private void Start()
    {
        Invoke(nameof(DestroySun),destroyTime);
    }

    public void CollectSun()
    {
        //Effect ve sesler burada olacak, animasyonlar (dotween)
        GameManager.instance.sun += sunValue;
        UIManager.instance.UpdateCurrentSunText();
        Destroy(gameObject);
    }

    private void DestroySun()
    {
       _destroyTween= transform.DOScale(0, scaleTime).SetEase(ease).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }

    private void OnDestroy()
    {
        _destroyTween.Kill();
    }
}
