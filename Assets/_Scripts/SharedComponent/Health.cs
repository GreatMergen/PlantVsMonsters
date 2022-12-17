using System.Collections;
using UnityEngine;

    public class Health : MonoBehaviour
    {
        [SerializeField] private int health;

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                DeathSequance();
            }
        }
        
        
        public void DeathSequance()
        {
            StartCoroutine(DeathSeq());
        }

        private IEnumerator DeathSeq()
        {
            yield return new WaitForSeconds(0.2f);
            Destroy(gameObject);
        }

    }
