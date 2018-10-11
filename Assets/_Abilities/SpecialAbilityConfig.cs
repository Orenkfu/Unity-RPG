using UnityEngine;
using RPG.Core;
using System.Reflection;

namespace RPG.Abilities {

    public abstract class SpecialAbilityConfig : ScriptableObject {
        [Header("Special Ability Meta")]
        [SerializeField] float energyCost = 10f;
        [SerializeField] float damageMultiplier = 1f;
        [SerializeField] SpecialAbilityConditionHandler conditionHandler;
        [SerializeField] float range;
        [SerializeField] ParticleSystem particleSystem;

        protected ISpecialAbility behavior;
        abstract public void AttachComponent(GameObject gameObjectToAttachTo);

        public float Range { get { return range; } }
        public float EnergyCost { get { return energyCost; } }
        public float DamageMultiplier { get { return damageMultiplier; } }
        public ParticleSystem ParticleEffect { get { return particleSystem; } }
        public SpecialAbilityConditionHandler ConditionHandler { get { return conditionHandler; } }


        public void Use(AbilityUseParams abilityParams) {
            behavior.Use(abilityParams);
        }


    }
}