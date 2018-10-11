using UnityEngine;
using RPG.Core;

namespace RPG.Weapons {
[CreateAssetMenu(menuName = "RPG/ Weapon")]
public class Weapon : ScriptableObject {

    [SerializeField] GameObject weaponPrefab;
    [SerializeField] Transform gripTransform;
    [SerializeField] AnimationClip animation;
    [SerializeField] float damage;
    [SerializeField] float secondsBetweenAttacks;
    [SerializeField] float weaponRange;

    public GameObject WeaponPrefab {
        get {
            return weaponPrefab;
        }
        set {
            weaponPrefab = value;
        }
    }
     public float WeaponRange {
            get {
                return weaponRange;
            }
            set {
                weaponRange = value;
            }
        }

        public Transform GripTransform {
        get {
            return gripTransform;
        }
        set {
            gripTransform = value;
        }
    }

        public float Damage {
            get {
                return damage;
            }
            set {
                damage = value;
            }
        }

        public float SecondsBetweenAttacks {
            get {
                return secondsBetweenAttacks;
            }
            set {
                secondsBetweenAttacks = value;
            }
        }

        public AnimationClip Animation {
        get {
            RemoveAnimationEvents();
            return animation;
        }
        set {
            animation = value;
        }
    }
        //so asset packs dont cause bugs..
    private void RemoveAnimationEvents() {
            animation.events = new AnimationEvent[0];
        }
   }
  }
