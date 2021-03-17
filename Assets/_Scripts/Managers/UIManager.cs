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
            if(currentState == GameState.GameOver && PreviousState == GameState.JourneyGame)
            {

            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
