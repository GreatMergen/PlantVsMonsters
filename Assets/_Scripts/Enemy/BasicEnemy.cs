using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    private Rigidbody _rb;
    public float moveSpeed;
    [SerializeField] private int damage;
    private float _damageTimer;
    private bool _canDamage;
    private Animator _animator;
    [SerializeField] private String attackSound;
    
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
              // Bir tane attack sesi olduğu için kapatıyorum her düşmanın kendi sesi olmalı AudioManager'ı  AudioManager.instance.Play(attackSound);
                collision.collider.GetComponent<Animator>().CrossFade("Take Damage",0.25f,0);
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

    private void OnDestroy()
    {
        if (EnemySpawnManager.instance.enemySpawnDone == true)
        {
            BasicEnemy[] enemies = UnityEngine.Object.FindObjectsOfType<BasicEnemy>() ;

            if (enemies.Length == 0)
            {
                 GameManager.instance.Win();
            }
        }
    }
}
