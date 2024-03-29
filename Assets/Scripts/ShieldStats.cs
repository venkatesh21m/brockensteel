﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace RUdrac.BrockenSteel
{
    public class ShieldStats : MonoBehaviour
    {

        public float Health;
        [Space]
        public ColorType colorType;

        MeshRenderer renderer;
        Sequence mySequence;
       
        void Start()
        {
            if(Health == 0)
                Health = 100;

            renderer = GetComponent<MeshRenderer>();

            if(colorType == ColorType.core)
            {
                GameManager.instance.onEnergyBoostEvent.AddListener(HandleEnergyBoostListener);
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
                DeathEffect();
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
            if(colorType == ColorType.core)
            {
                GameManager.instance.GameOver();
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
    }
}
