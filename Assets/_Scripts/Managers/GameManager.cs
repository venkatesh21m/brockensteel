using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rudrac.BrockenSteel
{
    public class GameManager : MonoBehaviour
    {

        #region singleton
        public static GameManager instance;

        private void Awake()
        {
            instance = this;
        }

        #endregion

        public TMPro.TMP_Text scoreText;
        
        int score = 0;

        #region properties
        [SerializeField] GameState currentGameState;
        public GameState CurrentGameState { get { return currentGameState; } set { currentGameState = value; } }

        [SerializeField] GameMode curentGameMode;
        public GameMode CurentGameMode { get { return curentGameMode; } set { curentGameMode = value; } }
        #endregion

        #region events initialisation

        [HideInInspector] public Events.GameStateChangeEvent onGameStateChangeEvent = new Events.GameStateChangeEvent();
        [HideInInspector] public Events.GameModeChangeEvent onGameModeChangeEvent = new Events.GameModeChangeEvent();

        #endregion

        public void Start()
        {
            onGameModeChangeEvent.AddListener(HandleGamemodeChanged);
        }

        #region EventHanders
        private void HandleGamemodeChanged(GameMode gameMode)
        {
            curentGameMode = gameMode;
        }
        #endregion


        #region functions
        public void scored()
        {
            score++;
            scoreText.text = score.ToString();
        }

        public void UpdateGameState(GameState state)
        {
            GameState previousState = currentGameState;
            currentGameState = state;
            switch (state)
            {
                case GameState.pregame:
                    break;
                case GameState.JourneyGame:
                    break;
                case GameState.InfiniteGame:
                    break;
                case GameState.Paused:
                    break;
                case GameState.GameOver:
                    break;
                default:
                    break;
            }

            onGameStateChangeEvent.Invoke(CurrentGameState, previousState);
        }

        #endregion
    }
}
