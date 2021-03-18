using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rudrac.BrockenSteel
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager instance;

        public GameObject GameOverPanel;
        public GameObject PausPanel;
        public GameObject GamePanel;
        public GameObject JourneyIndicator;
        public GameObject DifficultySelection;
        public GameObject MainMenu;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGameStateChanged);
        }

        private void HandleGameStateChanged(GameState currentState, GameState PreviousState)
        {
            if(currentState == GameState.GameOver && PreviousState == GameState.JourneyGame || currentState == GameState.GameOver && PreviousState == GameState.InfiniteGame)
            {
                GamePanel.SetActive(false);
                GameOverPanel.SetActive(true);
            }

            if(currentState == GameState.InfiniteGame && PreviousState == GameState.GameOver || currentState == GameState.JourneyGame && PreviousState == GameState.GameOver)
            {
                GameOverPanel.SetActive(false);
            }

            if (currentState == GameState.JourneyGame || currentState == GameState.InfiniteGame)
                GamePanel.SetActive(true);
            else GamePanel.SetActive(false);

            if(currentState == GameState.JourneyGame || currentState == GameState.GameOver && PreviousState == GameState.JourneyGame)
            {
                JourneyIndicator.SetActive(true);
            }
            else
            {
                JourneyIndicator.SetActive(false);
            }

            if(currentState == GameState.pregame && PreviousState == GameState.GameOver)
            {
                GameOverPanel.SetActive(false);
                MainMenu.SetActive(true);
            }
        }

        // Update is called once per frame
        void Update()
        {
           
        }

    }
}
