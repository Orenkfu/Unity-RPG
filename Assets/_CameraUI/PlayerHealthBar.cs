using RPG.Characters;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.CameraUI {
    [RequireComponent(typeof(Image))]
public class PlayerHealthBar : MonoBehaviour
{
    Image healthOrb;
    Player player;
    Health playerHealth;

    void Start() {
        player = FindObjectOfType<Player>();
        playerHealth = player.GetComponent<Health>();
        healthOrb = GetComponent<Image>();
    }

   void Update() {
            healthOrb.fillAmount = playerHealth.healthAsPercentage;
    }
  }
}
