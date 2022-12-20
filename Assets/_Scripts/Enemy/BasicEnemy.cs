using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private int damage;
    private float _damageTimer;
    private bool _canDamage;
    private Animator _animator;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (_damageTimer >= _animator.GetCurrentAnimatorStateInfo(0).length +0.25f)
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
            if (collision.collider.GetComponent<Health>().health > 0)
            {
                _animator.CrossFade("Attack",0.25f,0);
                collision.collider.GetComponent<Animator>().CrossFade("Take Damage",0.25f,0);
            }
            else
            {
                
            }
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
