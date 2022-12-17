using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant_Bomb : MonoBehaviour
{
    [SerializeField] private int waitBeforeExplode = 3;
    [SerializeField] private int bombDamage = 20;
    [SerializeField] private BoxCollider bombCollider;
    void Start()
    {
        bombCollider.enabled = false;
        StartCoroutine(Explode());
    }

    private IEnumerator Explode()
    {
        yield return new WaitForSeconds(waitBeforeExplode);
        bombCollider.enabled = true;
        yield return new WaitForSeconds(.1f);
        //Effectler oynyacak
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
