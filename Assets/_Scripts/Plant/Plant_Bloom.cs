using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Plant_Bloom : MonoBehaviour
{
   [SerializeField] private GameObject seedPrefab;
   [SerializeField] private Transform seedSpawnTransform;
   [SerializeField] private float seedSpeed,firstSpawnTime, repeatRate,rayLenght;
   [SerializeField] private LayerMask layerMask;

   private void Start()
   {
      InvokeRepeating(nameof(SpawnSeed),firstSpawnTime,repeatRate);
   }

   private void SpawnSeed()
   {
      if(Physics.Raycast(seedSpawnTransform.position,seedSpawnTransform.forward,out RaycastHit hit,rayLenght,layerMask))
       {
          if (hit.collider.CompareTag("Enemy"))
          {
             var spawnedSeed =  Instantiate(seedPrefab, seedSpawnTransform.position, quaternion.identity);
             spawnedSeed.GetComponent<Rigidbody>().AddForce(seedSpawnTransform.forward * seedSpeed,ForceMode.Impulse);
             Destroy(spawnedSeed,10f);
          }
       }
   }
}
