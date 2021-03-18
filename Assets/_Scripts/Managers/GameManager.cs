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
        GameState previousState;
        #region properties

        public bool SlowMotion
        {
            get;
            set;
        }


        [SerializeField] GameState currentGameState = GameState.pregame;
        public GameState CurrentGameState { get { return currentGameState; } set { currentGameState = value; } }

        [SerializeField] GameMode curentGameMode = GameMode.Defence;
        public GameMode CurentGameMode { get { return curentGameMode; } set { curentGameMode = value; } }
        #endregion

        #region events initialisation

        [HideInInspector] public Events.GameStateChangeEvent onGameStateChangeEvent = new Events.GameStateChangeEvent();
        [HideInInspector] public Events.GameModeChangeEvent onGameModeChangeEvent = new Events.GameModeChangeEvent();
        [HideInInspector] public Events.TriggerEvent OnScoredEvent = new Events.TriggerEvent();
        [HideInInspector] public Events.TriggerEvent OnmissedEvent = new Events.TriggerEvent();
        [HideInInspector] public Events.TriggerEvent OnProvidePowerUpEvent = new Events.TriggerEvent();

        [HideInInspector] public Events.Impulsetrigger OnImpulsePowerUpusedEvent = new Events.Impulsetrigger();
        [HideInInspector] public Events.SlowMotiontrigger OnSlowMotionPowerUpusedEvent = new Events.SlowMotiontrigger();
        [HideInInspector] public Events.Holographtrigger OnHolographPowerUpusedEvent = new Events.Holographtrigger();
        [HideInInspector] public Events.EnergyBoostertrigger OnEnergyBoostPowerUpusedEvent = new Events.EnergyBoostertrigger();
        [HideInInspector] public Events.ShieldRecoverytrigger OnShieldRecoveryPowerUpusedEvent = new Events.ShieldRecoverytrigger();
        [HideInInspector] public Events.FireWalltrigger OnFirewallPowerUpusedEvent = new Events.FireWalltrigger();


        #endregion

        public void Start()
        {
            onGameModeChangeEvent.AddListener(HandleGamemodeChanged);
            OnScoredEvent.AddListener(scored);

            OnSlowMotionPowerUpusedEvent.AddListener(HandleSlowmotionpowerup);
            onGameStateChangeEvent.AddListener(HandleGameStateChangedEvent);
        }

        private void HandleGameStateChangedEvent(GameState current, GameState previous)
        {
            if(current == GameState.InfiniteGame && previous == GameState.GameOver)
            {
                Movement[] enemies = FindObjectsOfType<Movement>();
                //Debug.LogError(enemies.Length);

                foreach (var item in enemies)
                {
                    Destroy(item.gameObject);
                }
            }
        }

        #region EventHanders
        private void HandleGamemodeChanged(GameMode gameMode)
        {
            curentGameMode = gameMode;
        }

        private void HandleSlowmotionpowerup(bool active)
        {
                SlowMotion = active;
        }

        #endregion

        #region functions
        void scored()
        {
            score++;
            scoreText.text = score.ToString();
        }

        public void UpdateGameState(GameState state)
        {
            previousState = currentGameState;
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

        public void StartJourney()
        {
            UpdateGameState(GameState.JourneyGame);
        }

        public void Startinfinite()
        {
            UpdateGameState(GameState.InfiniteGame);
        }

        public void RestartGame()
        {
            Debug.Log(previousState);
            UpdateGameState(previousState);
        }
       
    }
}
