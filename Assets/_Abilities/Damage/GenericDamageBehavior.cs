using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Abilities {
    public abstract class GenericDamageBehavior : MonoBehaviour, ISpecialAbility {
   

        public void Use(AbilityUseParams abilityParams) {
            throw new System.Exception("Using ability on abstract class, please override this method.");
        }

        protected float CalculateAbilityDamage(AbilityUseParams abilityParams, GenericDamageConfig config) {
            return (abilityParams.baseDamage + abilityParams.weaponDamage + config.ExtraDamage) * config.DamageMultiplier;
        }
    }
}