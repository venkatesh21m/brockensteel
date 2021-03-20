using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel 
{ 
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager instance;

        [SerializeField] AudioSource Asource;
        [SerializeField] AudioSource BGAsource;

        [SerializeField] AudioClip scored;
        [SerializeField] AudioClip Negative;
        [SerializeField] AudioClip GameOver;
        [SerializeField] AudioClip PowerUp;
        [SerializeField] AudioClip Blast;

        private void Awake()
        {
            instance = this;
        }

        private void Start()
        {

            GameManager.instance.OnScoredEvent.AddListener(playScoredSound);
            GameManager.instance.OnmissedEvent.AddListener(PlayNegativeSound);
            GameManager.instance.OnProvidePowerUpEvent.AddListener(PlayPowerUpusedSound);
            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGameStateChange);

        }

        private void HandleGameStateChange(GameState curent, GameState previous)
        {
            if(curent == GameState.InfiniteGame || curent == GameState.JourneyGame)
            {
                BGAsource.Stop();
                BGAsource.Play();
            }
        }

        public void playScoredSound()
        {
            Asource.PlayOneShot(scored);
        }

        public void PlayNegativeSound()
        {
            Asource.PlayOneShot(Negative);
        }
        
        public void PlayGameOVerSound()
        {
            Asource.PlayOneShot(GameOver);
        }

        public void PlayPowerUpusedSound()
        {
            Asource.PlayOneShot(PowerUp);
        }

        public void PlayblastSound()
        {
            Asource.PlayOneShot(Blast);
        }
    }
}
