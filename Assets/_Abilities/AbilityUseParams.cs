using UnityEngine;
using RPG.Core;

namespace RPG.Abilities {
    public struct AbilityUseParams {
        public IDamageable target;
        public float baseDamage;
        public float weaponDamage;
        public float range;
        public Vector3 targetPosition;
       

        public AbilityUseParams(IDamageable target, float baseDamage) {
            this.target = target;
            this.baseDamage = baseDamage;
            this.weaponDamage = 0;
            this.range = 0;
            this.targetPosition = Vector3.zero;
        }
        public AbilityUseParams(IDamageable target) {
            this.target = target;
            this.baseDamage = 0;
            this.weaponDamage = 0;
            this.range = 0;
            this.targetPosition = Vector3.zero;
        }

        public AbilityUseParams(IDamageable target, float baseDamage, float weaponDamage) {
            this.target = target;
            this.baseDamage = baseDamage;
            this.weaponDamage = weaponDamage;
            this.range = 0;
            this.targetPosition = Vector3.zero;

        }

        public AbilityUseParams(float baseDamage, float weaponDamage, float range) {
            this.target = null;
            this.baseDamage = baseDamage;
            this.weaponDamage = weaponDamage;
            this.range = range;
            this.targetPosition = Vector3.zero;
        }

        public AbilityUseParams(IDamageable target, float baseDamage, float weaponDamage, float range) {
            this.target = target;
            this.baseDamage = baseDamage;
            this.weaponDamage = weaponDamage;
            this.range = range;
            this.targetPosition = Vector3.zero;

        }

        public AbilityUseParams(IDamageable target, float baseDamage, float weaponDamage, float range, Vector3 targetPosition) {
            this.target = target;
            this.baseDamage = baseDamage;
            this.weaponDamage = weaponDamage;
            this.range = range;
            this.targetPosition = targetPosition;

        }

        public AbilityUseParams(float baseDamage, float weaponDamage, float range,  Ray ray) {
            this.target = null;
            this.baseDamage = baseDamage;
            this.weaponDamage = weaponDamage;
            this.range = range;
            this.targetPosition = Vector3.zero;

        }
}
}
