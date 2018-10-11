using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
    [CreateAssetMenu(menuName = ("RPG/Abilties/Heal"))]
    public class HealConfig : SpecialAbilityConfig {

        [Header("Heal Specific")]
        [SerializeField] float amountToHeal;

        public override void AttachComponent(GameObject gameObjectToAttachTo) {
            var behaviorComponent = gameObjectToAttachTo.AddComponent<HealBehavior>();
            behaviorComponent.Config = this;
            behavior = behaviorComponent;
        }
        public float AmountToHeal { get { return amountToHeal; } }
    }
}