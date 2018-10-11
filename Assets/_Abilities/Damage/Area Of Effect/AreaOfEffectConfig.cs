using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
    [CreateAssetMenu(menuName = ("RPG/Abilties/Area Of Effect"))]
    public class AreaOfEffectConfig : GenericDamageConfig {
        [Header("Area Of Effect Specific")]
        [SerializeField] float areaRadius;

        public override void AttachComponent(GameObject gameObjectToAttachTo) {
            var behaviorComponent = gameObjectToAttachTo.AddComponent<AreaOfEffectBehavior>();
            behaviorComponent.Config = this;
            behavior = behaviorComponent;
        }
        public float Radius {
            get {  return areaRadius; }
            set { areaRadius = value; }
        }

    }
}
