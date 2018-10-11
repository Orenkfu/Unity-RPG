using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace RPG.Abilities {
    public abstract class GenericDamageConfig : SpecialAbilityConfig {

        [Header("Damage Configuration")]
        [SerializeField] float extraDamage;


        public float ExtraDamage {
            get {
                return extraDamage;
            }
            set {
                extraDamage = value;
            }
        }
       
    }
}