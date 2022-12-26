using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMusic : MonoBehaviour
{
    private void Start()
    {
        AudioManager.instance.Play("MainMusic");
        AudioManager.instance.Stop("LevelMusic");
    }

}
