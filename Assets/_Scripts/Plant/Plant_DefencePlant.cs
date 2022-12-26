using System;
using UnityEngine;
using DG.Tweening;

public class Plant_DefencePlant : MonoBehaviour
{
   private bool _firstCollision = true;
   private void OnTriggerEnter(Collider other)
   {
    
      if (other.gameObject.CompareTag("Enemy"))
      {
         ClearWave();
         other.gameObject.GetComponent<Health>().TakeDamage(10000);
      }
   }
   private void ClearWave()
   {
      if (_firstCollision)
      {
         _firstCollision = false;
         transform.DOMoveY(transform.position.y + 0.15f, 0.25f).OnComplete(() =>
         {
            transform.DOMoveX(12, 5f).OnComplete(() =>
            {
               Destroy(gameObject);
            });
         });
      }
   }
}
