using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Rudrac.BrockenSteel
{
    public class JourneyManager : MonoBehaviour
    {
        public float MaxScoreValue;
        public Slider slider;
        public GameObject[] JourneyStages;

        static float score;
        static int index = 0;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.OnScoredEvent.AddListener(HandleScored);
            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGameStateCHanged);
            slider.maxValue = MaxScoreValue;
            slider.value = 0;
            index = 0;
        }

        private void HandleGameStateCHanged(GameState current, GameState previous)
        {
            if(current == GameState.JourneyGame && previous == GameState.pregame /*|| current == GameState.JourneyGame && previous == GameState.GameOver*/)
            {
                slider.maxValue = MaxScoreValue;
                slider.value = 0;
                score = 0;
                index = 0;

                foreach (var item in JourneyStages)
                {
                    item.SetActive(false);
                }
            }
            
            if(current == GameState.JourneyGame && previous == GameState.GameOver)
            {
                slider.maxValue = MaxScoreValue;
                slider.value = score;
            }
        }

        private void HandleScored()
        {
            score++;
            slider.value = score;

            if((int)(score%(int)(MaxScoreValue/JourneyStages.Length)) == 0)
            {
                JourneyStages[index].SetActive(true);
                index++;
                if(index == 15)
                {
                    GameManager.instance.OnJourneyFinished.Invoke();
                }
                else
                {
                    GameManager.instance.OnjourneyStageIncrementtrigger.Invoke();
                }
            }
        }
    }
}
