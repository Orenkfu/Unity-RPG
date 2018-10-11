using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Characters;
using UnityEngine.UI;

namespace RPG.CameraUI {
    [RequireComponent(typeof(Image))]
    public class PlayerEnergyBar : MonoBehaviour {

    Image energyOrb;
    Energy playerEnergy;

    void Start () {
            energyOrb = GetComponent<Image>();
            var player = FindObjectOfType<Player>();
            playerEnergy = player.GetComponent<Energy>();
        }

        void Update() {
            energyOrb.fillAmount = playerEnergy.energyAsPercentage;
           
        }

    }
}
