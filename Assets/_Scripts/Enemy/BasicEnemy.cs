using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float moveSpeed,damageCooldown = 2f;
    [SerializeField] private int damage;
    private float _damageTimer;
    private bool _canDamage;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (_damageTimer >= damageCooldown)
        {
            _damageTimer = 0;
            _canDamage = true;
        }
        _damageTimer += Time.deltaTime;
    }

    private void LateUpdate()
    {
        _rb.velocity = Vector3.left * moveSpeed;
    }

   
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag("Plant")&& _canDamage)
        {
            _canDamage = false;
            collision.collider.GetComponent<Health>().TakeDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadLine"))
        {
            GameManager.instance.Dead();
        }
    }
}