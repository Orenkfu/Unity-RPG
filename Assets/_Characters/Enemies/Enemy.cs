using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Weapons;

namespace RPG.Characters {
    public class Enemy : MonoBehaviour {
        [SerializeField] bool enableDrawGizmos;
        [SerializeField] float aggroRadius;
        [SerializeField] float attackRadius;

        Transform startPosition;
        private AICharacterControl aiControl;
        private Transform player = null;
        [SerializeField] private GameObject projectile;
        [SerializeField] private GameObject projectileSocket;
        [SerializeField] private float baseDamage;
        [SerializeField] private float secondsBetweenShots;
        [SerializeField] AnimatorOverrideController animatorOverrideController;

        private bool isAttacking;

        void Start() {
            isAttacking = false;
            player = GameObject.FindGameObjectWithTag("Player").transform;
            aiControl = GetComponent<AICharacterControl>();
        }

        // Update is called once per frame
        void Update() {
            DestroyOnPlayerDeath();
            float distanceToPlayer = DistanceToPlayer();
            Attack(distanceToPlayer);
            Aggro(distanceToPlayer);
        }
        float DistanceToPlayer() {
            return Vector3.Distance(player.position, transform.position);
        }
        void Aggro(float distanceToPlayer) {
            if (distanceToPlayer <= aggroRadius) {
                aiControl.SetTarget(player);
            } else {
                aiControl.SetTarget(transform);
            }
        }

        void DestroyOnPlayerDeath() {
            if (player.gameObject.GetComponent<Health>().IsDead) {
                StopAllCoroutines();
                Destroy(this);
            }
        }

        void Attack(float distanceToPlayer) {

            if (distanceToPlayer < attackRadius && !isAttacking) {
                isAttacking = true;
                print(gameObject + "invoking shootprojectile with seconds between shots: " + secondsBetweenShots);

                InvokeRepeating("ShootProjectile", secondsBetweenShots, secondsBetweenShots);
                ShootProjectile();
            }
            if (distanceToPlayer >= attackRadius) {
                isAttacking = false;
                CancelInvoke();
            }

        }
        //TODO seperate character shooting logic from enemy
        void ShootProjectile() {
            GameObject p = Instantiate(projectile, projectileSocket.transform.position, Quaternion.identity);
            Projectile projectileComponent = p.GetComponent<Projectile>();
            projectileComponent.SetShooterLayer(gameObject.layer);
            projectileComponent.damage += baseDamage;


            Vector3 unitVectorToPlayer = (player.transform.GetChild(2).position - projectileSocket.transform.position);
            p.GetComponent<Rigidbody>().velocity = unitVectorToPlayer * projectileComponent.GetDefaultLaunchSpeed();
        }

        void OnDrawGizmos() {
            if (!enableDrawGizmos) { return;  }
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, aggroRadius);
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(transform.position, attackRadius);
        }

    }
}