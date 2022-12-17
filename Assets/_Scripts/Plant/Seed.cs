using System;
using UnityEngine;

    public class Seed : MonoBehaviour
    {
        private int _currentDamage;
        [SerializeField] private int seedDamage = 5;
        [SerializeField] private int poweredSeedDamage = 15;

        private void Start()
        {
            _currentDamage = seedDamage;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Enemy"))
            {
                //çarpma effecktleri burada oynayacak!!!!
                other.GetComponent<Health>().TakeDamage(_currentDamage);
                Destroy(gameObject);
            }
            else if(other.gameObject.CompareTag("SeedPowerUp"))
            {
                print("Power up aldın");
                _currentDamage = poweredSeedDamage;
                transform.GetComponent<MeshRenderer>().material.color = new Color(0.6f, 0, 0.7f);

            }
        }
    } 