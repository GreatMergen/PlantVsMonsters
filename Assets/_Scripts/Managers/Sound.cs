using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.Audio;

[System.Serializable]
public class Sound
{
   public AudioClip clip;
   public string name;
   [Range(0f,1f)] public float volume = 0.3f;
   [Range(0f, 1f)] public float pitch = 1f;
   [HideInInspector] public AudioSource source;
   public bool loop;
  
}
