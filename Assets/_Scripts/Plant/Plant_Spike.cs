using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Spike : MonoBehaviour
{
    [SerializeField] private int spikeDamage,firstDamageTime,repeatRate;
    [SerializeField] private float damageRadius = .4f;
    [SerializeField] private LayerMask layer;
   
    
    private void Start()
    {
        InvokeRepeating("SpikeDamage",firstDamageTime,repeatRate);
    }

    
    private void SpikeDamage()
    {
        print("Deneme");
       RaycastHit[] enemies =  Physics.SphereCastAll(transform.position, damageRadius, Vector3.up, 1, layer);
       foreach (var raycastHit in enemies)
       {
           raycastHit.collider.GetComponent<Health>().TakeDamage(spikeDamage /2); // iki kere vuruyor ikiye böldük şimdilik :)
       }
       
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,damageRadius);
    }
    
}
