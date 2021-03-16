using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace RUdrac.BrockenSteel
{
    public class EnemyStats : MonoBehaviour
    {
        public float DamageAmount;
        public float Health;
        [Space]
        public ColorType[] colorTypes;
        [Space]
        public GameObject[] DeathParticleEffects;


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
            transform.DOScale(Vector3.zero, .05f);
            Destroy(transform.parent.gameObject,0.1f);
        }

        public void DeathEffect()
        {
            foreach (var item in DeathParticleEffects)
            {
                Destroy(Instantiate(item, transform.position, transform.rotation), 1f);
            }
            ConsumeEffect();
        }
       
    }
}
 