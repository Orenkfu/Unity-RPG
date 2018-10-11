using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Abilities {

    [CreateAssetMenu(menuName = ("RPG/Abilities/Condition Handler"))]
    [Serializable]
    public class SpecialAbilityConditionHandler : ScriptableObject, SpecialAbilityCondition {
        [SerializeField] AbstractSpecialAbilityCondition[] conditions;
        public ConditionResult Restrict(ConditionParams conditionParams) {
            ConditionResult result = new ConditionResult();
            foreach(SpecialAbilityCondition condition in conditions) {
                result = condition.Restrict(conditionParams);
                if (!result.IsSuccessful) {
                    break;
                }
            }
            return result;
        }
    }
}