using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Rudrac.BrockenSteel
{
    public class EnemyStats : MonoBehaviour
    {
        public float DamageAmount;
        public float Health;
        [Space]
        public ColorType[] colorTypes;
        [Space]
        public GameObject[] DeathParticleEffects;
        [Space]
        public bool hasShield;
        [HideInInspector]
        public GameObject shield;
        Movement movement;

        private void Start()
        {
            movement = GetComponentInParent<Movement>();
        }
        public void TakeDamage(float amount)
        {
            Health -= amount;

            if (Health <= 0)
                ConsumeEffect();
            else
                TakeDamageEffect();

        }

        void TakeDamageEffect()
        {

        }

        public void ConsumeEffect()
        {
            if (hasShield)
            {
                movement.MovementSpeed = -movement.MovementSpeed;
                movement.MovementSpeed *= 2;
                Destroy(shield);
                hasShield = false;
                Invoke("resetMovement", 0.15f);
                return;
            }
            transform.DOScale(Vector3.zero, .05f);
            Destroy(transform.parent.gameObject, 0.1f);
        }

        void resetMovement()
        {
            movement.MovementSpeed = -movement.MovementSpeed;
        }

        public void DeathEffect()
        {

            if (hasShield)
            {
                movement.MovementSpeed = -movement.MovementSpeed;
                movement.MovementSpeed *= 2;
                Destroy(shield);
                hasShield = false;
                Invoke("resetMovement", 0.75f);
                return;
            }

            foreach (var item in DeathParticleEffects)
            {
                Destroy(Instantiate(item, transform.position, transform.rotation), 1f);
            }
            ConsumeEffect();
        }

    }
}
