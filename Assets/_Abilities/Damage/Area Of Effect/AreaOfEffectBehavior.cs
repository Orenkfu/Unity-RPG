using System;
using RPG.Abilities;
using RPG.Core;
using UnityEngine;

public class AreaOfEffectBehavior : GenericDamageBehavior, ISpecialAbility {
    private AreaOfEffectConfig config;
    private const float PARTICLE_Y_OFFSET = 1f;
    // Params: basedamage, weapondamage, range, 
    public new void Use(AbilityUseParams abilityParams) {

        RaycastHit[] hitInfo = GetSphereCastInfo();
        EmitParticles(abilityParams.targetPosition);
        DamageTargets(hitInfo, abilityParams);
    }

    private void EmitParticles(Vector3 targetPosition) {
        Debug.Log("aoe particles triggered..");
        ParticleSystem particles = Instantiate(config.ParticleEffect);
        particles.transform.position = new Vector3(targetPosition.x, targetPosition.y + PARTICLE_Y_OFFSET, targetPosition.z);
        particles.Play();
        config.ParticleEffect.Play();
    }

    protected void DamageTargets(RaycastHit[] hitInfo, AbilityUseParams abilityParams) {
        foreach (RaycastHit hit in hitInfo) {
            if (!hit.collider) { return; }
            IDamageable damageable = hit.collider.gameObject.GetComponent<IDamageable>();
            if (damageable != null) {
                float damage = CalculateAbilityDamage(abilityParams, config);
                damageable.TakeDamage(damage);

            }
        }
    }

    RaycastHit[] GetSphereCastInfo() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        return Physics.SphereCastAll(ray, config.Radius);
    }

    public AreaOfEffectConfig Config {
        set {
            config = value;
        }
    }

}
