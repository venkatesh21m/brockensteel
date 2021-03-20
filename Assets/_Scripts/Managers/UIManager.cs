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

        [Space]
        public GameObject journeyovertext;
        public GameObject BRockenSteeltext;
        public GameObject RestartButton;
        [Space]
        public TMPro.TMP_Text scoreText;
        public TMPro.TMP_Text HighScoreText;

        private void Awake()
        {
            instance = this;
        }
        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGameStateChanged);
            GameManager.instance.OnJourneyFinished.AddListener(HandleJourneyFinished);

        }

        private void HandleJourneyFinished()
        {
            BRockenSteeltext.SetActive(false);
            journeyovertext.SetActive(true);
            RestartButton.SetActive(false);
        }

        private void HandleGameStateChanged(GameState currentState, GameState PreviousState)
        {
            if(currentState == GameState.GameOver && PreviousState == GameState.JourneyGame || currentState == GameState.GameOver && PreviousState == GameState.InfiniteGame)
            {
                GamePanel.SetActive(false);
                GameOverPanel.SetActive(true);

                if(PreviousState == GameState.InfiniteGame)
                {
                    scoreText.text = GameManager.score.ToString();
                    if(GameManager.score > PersistantManager.HighScore)
                    {
                        PersistantManager.HighScore = GameManager.score;
                    }
                    HighScoreText.text = "HighScore :" + PersistantManager.HighScore.ToString();
                }
                else
                {
                    scoreText.text = "";
                    HighScoreText.text = "";
                }

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

                BRockenSteeltext.SetActive(true);
                journeyovertext.SetActive(false);
                RestartButton.SetActive(true);

            }



        }

        // Update is called once per frame
        void Update()
        {
           
        }

    }
}
