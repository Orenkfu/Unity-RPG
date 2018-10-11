using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
    [CreateAssetMenu(menuName = ("RPG/Abilties/Power Attack"))]
    public class PowerAttackConfig : GenericDamageConfig {



        public override void AttachComponent(GameObject gameObjectToAttachTo) {
            var behaviorComponent = gameObjectToAttachTo.AddComponent<PowerAttackBehavior>();
            behaviorComponent.Config = this;
            behavior = behaviorComponent;
        
        }
    }
}
