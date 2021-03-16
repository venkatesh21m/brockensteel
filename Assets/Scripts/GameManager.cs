using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace RUdrac.BrockenSteel
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        public GameObject GameOverPanel;
        public TMPro.TMP_Text scoreText;



        [HideInInspector] public Events.onBooleanEvent onSlowMotionEvent = new Events.onBooleanEvent();
        [HideInInspector] public Events.onBooleanEvent onShieldRecoveryEvent = new Events.onBooleanEvent();
        [HideInInspector] public Events.onBooleanEvent onEnergyBoostEvent = new Events.onBooleanEvent();


        public bool SlowMotion
        {
            get;
            set;
        }

        int score = 0;

        private void OnEnable()
        {
            onSlowMotionEvent.AddListener(HandleSlowMotionEvent);
        }

        #region EventHandles
        void HandleSlowMotionEvent(bool active)
        {
            SlowMotion = active;
        }
        #endregion

        // Start is called before the first frame update
        void Awake()
        {
            instance = this;
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void scored()
        {
            score++;
            scoreText.text = score.ToString();
        }

        public void GameOver()
        {
            GameOverPanel.SetActive(true);
            StopAllCoroutines();
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

    }

    public enum ColorType
    {
        Red,
        Green,
        Blue,
        Yellow,
        Violet,
        core,
        FireWall
    }
}
