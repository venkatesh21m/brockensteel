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

        int score = 0;
        // Start is called before the first frame update
        void Start()
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
        Violet
    }
}
