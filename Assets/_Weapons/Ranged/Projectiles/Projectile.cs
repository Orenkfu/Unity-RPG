using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters;
using RPG.Core;

namespace RPG.Weapons {
    public class Projectile : MonoBehaviour {
        [SerializeField] public float damage;
        [SerializeField] float speed = 5f;
        [SerializeField] public float timeToDestroyAfterImpact = 0.01f;
        [Header("Only for inspecting purposes")]
        [SerializeField] int shooterLayer;
        void Start() {

        }

        public void SetShooterLayer(int shooterLayer) {
            this.shooterLayer = shooterLayer;
        }
        // Update is called once per frame
        void Update() {

        }

        public float GetDefaultLaunchSpeed() {
            return speed;
        }
        void OnCollisionEnter(Collision collider) {
            if (collider.gameObject.layer == shooterLayer) {
                return;
            }
            Health health = collider.gameObject.GetComponent<Health>();
            if (health) {
                (health as IDamageable).TakeDamage(damage);

            }
            Destroy(gameObject, timeToDestroyAfterImpact);
        }
    }
}
