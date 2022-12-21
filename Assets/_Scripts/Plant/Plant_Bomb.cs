using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEngine;

public class Plant_Bomb : MonoBehaviour
{
    [SerializeField] private int bombDamage = 20;
    [SerializeField] private BoxCollider bombCollider;
    [SerializeField] private GameObject explodeEffect;
    void Start()
    {
        bombCollider.enabled = false;
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + .5f);
        bombCollider.enabled = true;
        yield return new WaitForSeconds(.1f);
        //Effectler oynyacak
        Destroy(Instantiate(explodeEffect , transform.position , quaternion.identity),1); 
        transform.parent.gameObject.tag = "EmptyLand";
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.GetComponent<Health>().TakeDamage(bombDamage);
        }
    }
}
