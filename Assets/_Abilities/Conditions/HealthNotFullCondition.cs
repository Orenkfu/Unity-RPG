using RPG.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Abilities { 
public class HealthNotFullCondition : AbstractSpecialAbilityCondition {

    public override ConditionResult Restrict(ConditionParams conditionParams) {
        if (!conditionParams.Health.IsFull()) {
            return new ConditionResult(true);
        }
        return new ConditionResult(false, "Your health is full."); //TODO: change error if health is applicable to different targets..
    }
    }

}