﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public class Core : MonoBehaviour
    {
        Stats[] stats;
        Stats CoreStats;

        [SerializeField] float energy;
        public float Energy { get { return energy; } set { energy = value; } }

        public float EnergyFillingRate = 1;
        [SerializeField] GameObject menueffect;
        [Space]
        public GameObject deatheffect;
        bool isingame;
        public void Start()
        {
            CoreStats = GetComponent<Stats>();
            stats = GetComponentsInChildren<Stats>(true);

            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGameStateChangeEvent);
            GameManager.instance.OnShieldRecoveryPowerUpusedEvent.AddListener(HandleShieldRecovery);


        }

        public void HandleShieldRecovery()
        {
            foreach (var item in stats)
            {
                item.transform.localScale = Vector3.one;
                item.gameObject.SetActive(true);
                item.Health = item.MaxHealth;
            }
        }

        private void HandleGameStateChangeEvent(GameState curent, GameState previous)
        {
            if (curent == GameState.InfiniteGame || curent == GameState.JourneyGame)
            {
                gameObject.SetActive(true);
                stats = GetComponentsInChildren<Stats>(true);
                foreach (var item in stats)
                {
                    item.transform.localScale = Vector3.one;
                    item.gameObject.SetActive(true);
                    item.Health = item.MaxHealth;
                }
                isingame = true;
            }
            else
            {
                isingame = false;
            }

            if(curent == GameState.GameOver)
            {
                DeathEffect();
            }

            if(curent == GameState.pregame && previous == GameState.GameOver)
            {
                gameObject.SetActive(true);
                menueffect.SetActive(true);
            }
        }

        private void DeathEffect()
        {
            Destroy(Instantiate(deatheffect),3);
            gameObject.SetActive(false);

        }

        private void Update()
        {
            if (!isingame) return;

            foreach (var item in stats)
            {
                if (item.Health < item.MaxHealth)
                {
                    if (Energy > 0)
                    {
                        item.Health += EnergyFillingRate * Time.deltaTime;
                        Energy -= EnergyFillingRate * Time.deltaTime;
                    }
                    if (!item.gameObject.activeSelf && item.Health > 0)
                    {
                        item.gameObject.SetActive(true);
                    }
                }
            }
        }

    }

}
