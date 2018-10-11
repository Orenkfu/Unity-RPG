using UnityEngine;

namespace RPG.Abilities {
    public class PowerAttackBehavior : GenericDamageBehavior, ISpecialAbility {
        private PowerAttackConfig config;

        private bool IsTargetInAbilityRange(Vector3 targetPosition, float attackRange) {
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);
            return distanceToTarget <= attackRange;
        }

        public new void Use(AbilityUseParams abilityParams) {
            bool isInRange = IsTargetInAbilityRange(abilityParams.targetPosition, abilityParams.range);
            if (isInRange) {
                float abilityDamage = CalculateAbilityDamage(abilityParams, config);
                abilityParams.target.TakeDamage(abilityDamage);
            }

        }

        public PowerAttackConfig Config { set {  config = value; } }
    }
}
