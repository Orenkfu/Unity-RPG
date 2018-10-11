using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
public class RangeCondition : AbstractSpecialAbilityCondition {

    public override ConditionResult Restrict(ConditionParams conditionParams) {
            float distance = CalculateDistance(conditionParams.StartPosition, conditionParams.TargetPosition);
        if (distance <= conditionParams.Range) {
            return new ConditionResult(true);
        }
        return new ConditionResult(false, "Target is too far.");
        }

        private float CalculateDistance(Vector3 startPosition, Vector3 targetPosition) {
            return Vector3.Distance(startPosition, targetPosition);
        }
    }
}
