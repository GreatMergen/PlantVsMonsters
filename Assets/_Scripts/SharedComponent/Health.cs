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
            GetComponent<CapsuleCollider>().enabled = false;
            Animator animator = GetComponent<Animator>(); 
            animator.CrossFade("Die",0.25f,0);
            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length );
            if (gameObject.GetComponent<PlantVariables>() != null)
            {
                gameObject.transform.parent.tag = "EmptyLand";
            }

         /*Düşman sesleri düzgün çalışmıyor her düşman kendi sesini yaratnmalı şimdilik kapatıyorum
            if (gameObject.GetComponent<BasicEnemy>() != null)
            {
                if (gameObject.GetComponent<Enemy_Snake>() != null)
                {
                    AudioManager.instance.Play("MediumEnemyDeath");
                }
                else if (gameObject.GetComponent<Enemy_Snakelet>() != null)
                {
                    AudioManager.instance.Play("EasyEnemyDeath");
                }
                else if (gameObject.GetComponent<Enemy_WolfPup>() != null)
                {
                    AudioManager.instance.Play("HardEnemyDeath");
                }
               
            }
            */
         
            Destroy(gameObject);
            
        }
    }
