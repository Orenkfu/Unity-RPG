using UnityEngine;
using RPG.Core;
using System.Collections;
using UnityEngine.SceneManagement;

namespace RPG.Characters {
    public class Health : MonoBehaviour, IDamageable {

        [SerializeField] float maxHealth;
        [SerializeField] float currentHealth;
        private bool isDead = false;

        public delegate void OnDamageTaken(float damage);
        public event OnDamageTaken notifyDamageObservers;

        public delegate void OnCharacterDeath();
        public event OnCharacterDeath notifyDeathObservers;


        public void TakeDamage(float damage) {
            currentHealth = Mathf.Clamp(currentHealth - damage, 0f, maxHealth);
            if (currentHealth <= 0) {
                Die();
            } else if (GetComponent<Player>()) {     //TODO: replace temporary code to better apply to enemies..      
            notifyDamageObservers(damage);
            }
        }
        void Die() {
            isDead = true;
                //TODO: replace this shit with real code
            if (GetComponent<Player>())  {
                notifyDeathObservers();
            } else {
                Destroy(gameObject);
            }
        }
        public void KillPlayer() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

        public void HealDamage(float amount) {
            currentHealth = Mathf.Clamp(currentHealth + amount, 0f, maxHealth);
        }

        public bool IsFull() {
            return currentHealth >= maxHealth;
        }
        public bool IsDead {
            get { return isDead; }  }
        void Start() {
        
            currentHealth = maxHealth;
        }


        public float healthAsPercentage {
            get {
                return currentHealth / maxHealth;
            }
        }

    }
}
