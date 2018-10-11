using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters;
using System;

namespace RPG.Abilities {
    [Serializable]
    public class EnergyCondition : AbstractSpecialAbilityCondition {

        public override ConditionResult Restrict(ConditionParams conditionParams) {
            if (conditionParams.Energy.IsEnergyAvailable(conditionParams.EnergyCost)) {
            return new ConditionResult(true);
            }
        return new ConditionResult(false, "Not enough energy.");
        }

    }
}