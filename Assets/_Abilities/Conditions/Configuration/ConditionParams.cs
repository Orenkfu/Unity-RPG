using RPG.Characters;
using UnityEngine;
namespace RPG.Abilities {

    public class ConditionParams {
        Vector3 startPosition;
        Vector3 targetPosition;
        float energyCost;
        Energy energy;
        Health health;
        float range;

        public ConditionParams(Vector3 startPosition, Vector3 targetPosition, float range) {
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.range = range;

        }
        public ConditionParams(Vector3 startPosition, Vector3 targetPosition, float range, Energy energy, float energyCost) {
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.energyCost = energyCost;
            this.energy = energy;
            this.range = range;
        }
        public ConditionParams(Vector3 startPosition, Vector3 targetPosition, float range, Energy energy, float energyCost, Health health) {
            this.startPosition = startPosition;
            this.targetPosition = targetPosition;
            this.energyCost = energyCost;
            this.energy = energy;
            this.range = range;
            this.health = health;
        }
        public ConditionParams(float energyCost, Energy energy) {
            this.energyCost = energyCost;
            this.energy = energy;
        }
        public ConditionParams(Health health) {
            this.health = health;
        }
        public ConditionParams(Health health, Energy energy, float energyCost) {
            this.health = health;
            this.energy = energy;
            this.energyCost = energyCost;
        }

        public float Range { get { return range; }  }
        public Vector3 StartPosition { get { return startPosition; } }
        public Vector3 TargetPosition { get { return targetPosition; } }
        public float EnergyCost { get { return energyCost; } }
        public Energy Energy { get { return energy; } }
        public Health Health { get { return health; } }

    }


}
