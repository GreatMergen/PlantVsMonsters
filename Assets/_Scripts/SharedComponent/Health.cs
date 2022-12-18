using System.Collections;
using UnityEngine;

    public class Health : MonoBehaviour
    {
        public int health;

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
            Animator animator = GetComponent<Animator>(); 
            animator.CrossFade("Die",0.25f,0);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length -.3f);
            Destroy(gameObject);
        }
        
      

    }
