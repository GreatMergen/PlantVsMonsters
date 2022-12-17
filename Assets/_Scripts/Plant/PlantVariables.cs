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
   
   public void DeathSequance()
   {
      StartCoroutine(DeathSeq());
   }

   private IEnumerator DeathSeq()
   {
      yield break;
   }
}
