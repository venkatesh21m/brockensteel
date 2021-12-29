using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Rudrac.BrockenSteel
{
    public class Stats : MonoBehaviour
    {
        public float MaxHealth;
        public float Health;
        [Space]
        public ColorType colorType;

        [Space]
        public bool attackMode;
        public Material LineMaterial;
        public LayerMask LayerMask;
        public GameObject enemyDeathEffect;

        LineRenderer LineRenderer;
        MeshRenderer renderer;
        Sequence mySequence;

        void Start()
        {
            if (Health == 0)
                Health = 100;

            renderer = GetComponent<MeshRenderer>();

            if (colorType == ColorType.core)
            {
               // GameManager.instance.onEnergyBoostEvent.AddListener(HandleEnergyBoostListener);
            }
            if (attackMode)
            {
                LineRenderer = gameObject.AddComponent<LineRenderer>();
                LineRenderer.SetWidth(0.25f, 0.25f);
                LineRenderer.material = LineMaterial;
            }

        }

        GameObject PREVIOUS;
        private void Update()
        {
            if (!attackMode) return;

            Ray ray = new Ray(transform.GetChild(0).position, transform.GetChild(0).right);
            RaycastHit hit;
            if (Physics.SphereCast(ray,1, out hit,5))
            {

                LineRenderer.SetPosition(0, transform.GetChild(0).position);
                LineRenderer.SetPosition(1, hit.point);
                
                GameObject other = hit.collider.gameObject;

                AudioManager.instance.PlayblastSound();
                if (other != PREVIOUS)
                {
                    PREVIOUS = other;
                    EnemyStats Enemystats = other.GetComponent<EnemyStats>();

                    foreach (var item in Enemystats.colorTypes)
                    {
                        if (item == colorType)
                        {
                            GameManager.instance.OnScoredEvent.Invoke();
                            //scoredEffect();
                        }
                    }
                }
                GameObject obj = Instantiate(enemyDeathEffect, other.transform.position, Quaternion.identity);
                obj.GetComponent<ParticleSystem>().GetComponent<Renderer>().material = GetComponent<MeshRenderer>().material;
                Destroy(obj, 4);
                Destroy(other.GetComponentInParent<Movement>().gameObject);
            }
            else
            {
                LineRenderer.SetPosition(0, transform.GetChild(0).position);
                LineRenderer.SetPosition(1, transform.GetChild(0).right * 10);
            }
        }

        private void HandleEnergyBoostListener(bool arg0)
        {
            Health = 50;
        }

        public void TakeDamage(float amount)
        {
            Health -= amount;

            if (Health <= 0)
            {
                DeathEffect();
                if (Health < -8)
                {
                    Health = -8f;
                }
            }
            else
                TakeDamageEffect();

        }

        public void scoredEffect()
        {
            mySequence.Complete();
            transform.localScale = Vector3.one;
            transform.DOPunchScale(Vector3.one * .2f, .25f);
        }

        void TakeDamageEffect()
        {
            Color color = renderer.material.color;
            mySequence = DOTween.Sequence();
            mySequence.Append(renderer.material.DOColor(Color.black, .1f));
            mySequence.Append(renderer.material.DOColor(color, .2f));

            scoredEffect();
        }

        void DeathEffect()
        {
            if (colorType == ColorType.core)
            {
                GameManager.instance.UpdateGameState(GameState.GameOver);
                StopAllCoroutines();
                return;
            }

            mySequence.Complete();
            transform.localScale = Vector3.one;
            transform.DOPunchScale(Vector3.one * 1.2f, .25f);
            //   Destroy(gameObject, 0.1f);
            Invoke("disableSHield", .1f);
        }

        void disableSHield()
        {
            gameObject.SetActive(false);
        }





        private void OnCollisionEnter(Collision collision)
        {
            GameObject other = collision.gameObject;
            EnemyStats Enemystats = other.GetComponent<EnemyStats>();

            if (colorType == ColorType.FireWall)
            {
                if (Enemystats != null) Enemystats.DeathEffect();
                return;
            }

            bool samecolor = false;
            if (Enemystats != null)
            {
                foreach (var item in Enemystats.colorTypes)
                {
                    if (item == colorType)
                    {
                        GameManager.instance.OnScoredEvent.Invoke();
                        scoredEffect();
                        Enemystats.ConsumeEffect();
                        samecolor = true;
                    }
                }
            }

            if (samecolor == false)
            {
                Camera.main.transform.DOShakeRotation(0.25f, 0.75f, 20);
                TakeDamage(Enemystats.DamageAmount);
                if(Enemystats!=null) Enemystats.DeathEffect();
                GameManager.instance.OnmissedEvent.Invoke();
            }

        }


    }
}
