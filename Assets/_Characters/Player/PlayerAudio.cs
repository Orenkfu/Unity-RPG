using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Characters {
    public class PlayerAudio : MonoBehaviour {
        [SerializeField] AudioClip[] damageSounds;
        [SerializeField] AudioClip deathSound;
        private AudioSource audioSource;
        private Health health;
        private bool isDead;


        void Start () {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            health = GetComponent<Health>();
            health.notifyDamageObservers += OnDamageTaken;
            health.notifyDeathObservers += OnDeath;
        }

        void OnDeath() {
            if (isDead) return;
            isDead = true;
            StartCoroutine(PlayDeathSound());
        }

        private IEnumerator PlayDeathSound() {
            RequestDeathClip();
            yield return new WaitForSecondsRealtime(deathSound.length);
            health.KillPlayer();
        }

        void OnDamageTaken(float damage) {
            int randomSound = Random.Range(0, damageSounds.Length);
            RequestPlayAudioClip(damageSounds[randomSound]);
        }
        void RequestDeathClip() {
                audioSource.Stop();
                audioSource.clip = deathSound;
                audioSource.Play();
        }
        
        void RequestPlayAudioClip(AudioClip clip) {
             if (!audioSource.isPlaying && !isDead) {
                audioSource.clip = clip;
                audioSource.Play();
            }
        }
    }
}
