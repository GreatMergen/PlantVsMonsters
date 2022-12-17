using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour
{
    public int sunValue = 100;
    [SerializeField] private float destroyTime =5f;
    private void Start()
    {
        Destroy(gameObject,destroyTime);
    }

    public void CollectSun()
    {
        //Effect ve sesler burada olacak, animasyonlar (dotween)
        GameManager.instance.sun += sunValue;
        UIManager.instance.UpdateCurrentSunText();
        Destroy(gameObject);
    }
}
