using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlantVariables : MonoBehaviour
{
   public int buyValue;
   public int sellValue;
   public AudioClip buyAudioClip;
   public AudioClip sellAudioClip;
   public GameObject buyParticleEffect;
   public GameObject sellParticleEffect;
   public Animator animator;

   private void Start()
   {
      animator = GetComponent<Animator>();
      Invoke(nameof(SpawnedPlant),3f);
   }

   private void SpawnedPlant()
   {
      animator.SetBool("isSpawned", true);
   }

   public bool CalculateAndBuyPlant()
   {
      if (GameManager.instance.sun >= buyValue)
      {
         GameManager.instance.sun -= buyValue;
         UIManager.instance.UpdateCurrentSunText();
       //  AudioManager.instance.PlaySoundEffect(buyAudioClip);
      //   Instantiate(buyParticleEffect, transform.position, quaternion.identity);
         return true;
      }
      return false;
   }

   public void SellPlant()
   {
      GameManager.instance.sun += sellValue;
      UIManager.instance.UpdateCurrentSunText();
     // AudioManager.instance.PlaySoundEffect(sellAudioClip);
    //  Instantiate(sellParticleEffect, transform.position, quaternion.identity);
      Destroy(gameObject);
   }
   

}
