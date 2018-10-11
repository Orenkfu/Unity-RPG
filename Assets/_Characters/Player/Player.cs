using UnityEngine;
using UnityEngine.Assertions;
using RPG.CameraUI; //TODO consider moving dependencies
using RPG.Weapons;
using RPG.Abilities;
using System;

namespace RPG.Characters {
    public class Player : MonoBehaviour {
        private const string ATTACK_ANIM_TRIGGER = "Attack";
        private const string DEATH_ANIM_TRIGGER = "Death";

        [SerializeField] float baseDamage = 4;
        [SerializeField] Weapon weaponInUse;
        [SerializeField] AnimatorOverrideController animatorOverrideController;
        [Header("For Debugging")]
        [SerializeField] SpecialAbilityConfig[] abilities;
        CameraRaycaster raycaster;
        PlayerMovement movement;
        ErrorText errorController;
        private Animator animator;
        private float lastHitTime = 0f;
        bool isAttacking;
        void Start () {
           
            RegisterMouseObservers();
            EquipWeapon();
            InitializePlayer();
        }
    
        void InitializePlayer() {
            animator = GetComponent<Animator>();
            movement = GetComponent<PlayerMovement>();
            animator.runtimeAnimatorController = animatorOverrideController;
            animatorOverrideController["DEFAULT_ATTACK"] = weaponInUse.Animation;
            InitializeAbilities();
            GetComponent<Health>().notifyDeathObservers += StartDeathSequence;
            errorController = FindObjectOfType<ErrorText>(); //create an actual error controller together with an error handling system that'll talk to the error text instead of the player..
        }

        void StartDeathSequence() {
            animator.SetTrigger(DEATH_ANIM_TRIGGER);
        }
        void InitializeAbilities() {
            foreach(SpecialAbilityConfig ability in abilities) {
                ability.AttachComponent(gameObject);
            }
        }

        private void RegisterMouseObservers() {
            raycaster = Camera.main.GetComponent<CameraRaycaster>();
            raycaster.notifyEnemyObservers += OnMouseOverEnemy;
        }

        private void OnMouseOverEnemy(Enemy enemy) {
                //TODO: create keyboard configuration script.
            if (Input.GetMouseButton(0) && IsTargetInWeaponRange(enemy.gameObject)) {
                Attack(enemy);
            } else if (Input.GetMouseButtonDown(1)) {
                TryUseSpecialAbility(0, enemy);
            }  
            
        }
        void Update() {
            if (Input.GetKeyDown(KeyCode.Alpha1)) { //TEMPORARY. create ability activation system and keyboard mapping.
                TryHeal(1);
            }
        }

        private void TryUseSpecialAbility(int abilityIndex, Enemy enemy) {
            var energy = GetComponent<Energy>();
            var currentAbility = abilities[abilityIndex];
            var energyToConsume = abilities[abilityIndex].EnergyCost;
       
            ConditionResult result = currentAbility.ConditionHandler.Restrict(
                new ConditionParams(transform.position, enemy.transform.position, currentAbility.Range, energy, energyToConsume));
    
            if (result.IsSuccessful) { 
                var abilityParams = 
                    new AbilityUseParams(enemy.GetComponent<Health>(), baseDamage, weaponInUse.Damage, weaponInUse.WeaponRange, enemy.transform.position);
                energy.ConsumeEnergy(energyToConsume);
                currentAbility.Use(abilityParams);
            } else {
               errorController.ShowError(result.ResultMessage);
            }
        }
        private void TryHeal(int abilityIndex) {
            var energy = GetComponent<Energy>();
            var currentAbility = abilities[abilityIndex];
            var energyToConsume = abilities[abilityIndex].EnergyCost;
            ConditionResult result = currentAbility.ConditionHandler.Restrict(new ConditionParams(GetComponent<Health>(), energy, currentAbility.EnergyCost));
            if (result.IsSuccessful) {
                var abilityParams =
                 new AbilityUseParams(GetComponent<Health>());
                energy.ConsumeEnergy(energyToConsume);
                currentAbility.Use(abilityParams);
            } else {
                errorController.ShowError(result.ResultMessage);
            }
        }

            private bool IsTargetInWeaponRange(GameObject target) {
            float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            return  distanceToTarget <= weaponInUse.WeaponRange;
        }

        void Attack(Enemy enemy) {   
            if (Time.time - lastHitTime >= weaponInUse.SecondsBetweenAttacks) {
                isAttacking = false;
            }

            if (!isAttacking) {
                isAttacking = true;
                lastHitTime = Time.time;
                animator.SetTrigger(ATTACK_ANIM_TRIGGER);
                float damage = baseDamage + weaponInUse.Damage;
                enemy.GetComponent<Health>().TakeDamage(damage);
            }

        }

        private GameObject RequestDominantHand() {
            var dominantHands = GetComponentsInChildren<DominantHand>();
            int numOfHands = dominantHands.Length;
            Assert.AreNotEqual(numOfHands, 0, "No dominant hands on player, please add one.");
            Assert.IsFalse(numOfHands > 1, "Multiple dominant hand scripts on player. make sure there is only one.");
            return dominantHands[0].gameObject;
        }

        private void EquipWeapon() {
            var weaponPrefab = weaponInUse.WeaponPrefab;
            GameObject dominantHand = RequestDominantHand();
            var weapon = Instantiate(weaponPrefab, dominantHand.transform);
            weapon.transform.localPosition = weaponInUse.GripTransform.localPosition;
            weapon.transform.localRotation = weaponInUse.GripTransform.localRotation;
        }
    }
}
