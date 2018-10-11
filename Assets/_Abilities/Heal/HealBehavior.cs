using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
    public class HealBehavior : MonoBehaviour, ISpecialAbility {
        HealConfig config;
        public void Use(AbilityUseParams abilityParams) {
            abilityParams.target.HealDamage(config.AmountToHeal);
        }

        public HealConfig Config { set { config = value; } }

    }
}