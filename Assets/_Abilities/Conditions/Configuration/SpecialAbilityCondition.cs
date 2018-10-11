using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Abilities {
    public interface SpecialAbilityCondition {

    ConditionResult Restrict(ConditionParams conditionParams);
    }
    
    public abstract class AbstractSpecialAbilityCondition : MonoBehaviour, SpecialAbilityCondition {
        public abstract ConditionResult Restrict(ConditionParams conditionParams);
    }
}
