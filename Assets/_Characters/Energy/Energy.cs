using RPG.CameraUI;
using UnityEngine;

namespace RPG.Characters {
    public class Energy : MonoBehaviour {
        [SerializeField] float maxEnergyPoints = 100f;
        [SerializeField] float energyPerSecond = 0f;
        private PlayerEnergyBar energyBarUI;
        private float currentEnergyPoints;

        void Start() {
         currentEnergyPoints = maxEnergyPoints;
         energyBarUI = FindObjectOfType<PlayerEnergyBar>();
        }

        public bool IsEnergyAvailable(float energyAmount) {
            return currentEnergyPoints >= energyAmount;
        }

        public void ConsumeEnergy(float energyToUse) {
            currentEnergyPoints = Mathf.Clamp(currentEnergyPoints - energyToUse, 0f, maxEnergyPoints);
            Debug.Log("Consuming energy. Current energy: " + currentEnergyPoints);
           // energyBarUI.UpdateEnergyBar();
        }

        public void GainEnergy(float energyToGain) {
            if (currentEnergyPoints >= maxEnergyPoints) return;

            currentEnergyPoints = Mathf.Clamp(currentEnergyPoints + energyToGain, 0f, maxEnergyPoints);
         //   energyBarUI.UpdateEnergyBar();
        }
        void Update() {
            GainEnergy(energyPerSecond * Time.deltaTime);
        }
        public float energyAsPercentage {
            get {

                return currentEnergyPoints / maxEnergyPoints;
            }
        }
    }

}