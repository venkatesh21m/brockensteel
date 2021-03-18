using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rudrac.BrockenSteel
{
    public class DifficultyManager : MonoBehaviour
    {
        public GameObject[] Shields;
       // public GameObject[] EnemySpaeners;

        public static int currentIndex
        {
            get;
            set;
        }

        // Start is called before the first frame update
        void Start()
        {
            currentIndex = 0;
            Shields[currentIndex].SetActive(true);
            //EnemySpaeners[currentIndex].SetActive(true);
        }

        public void NextDifficulty()
        {
            StartCoroutine(_NextDifficulty());
        }
        
        public void PreviousDifficulty()
        {
            StartCoroutine(_PreviousDifficulty());
        }

        IEnumerator _NextDifficulty()
        {
            Shields[currentIndex].GetComponent<DifficultySelectionAnimation>().DoCloseAnimation();
            //EnemySpaeners[currentIndex].SetActive(false);
            currentIndex++;
            if(currentIndex >= Shields.Length)
            {
                currentIndex = 0;
            }
            yield return new WaitForSeconds(1);
            Shields[currentIndex].SetActive(true);
           // EnemySpaeners[currentIndex].SetActive(true);



            Shields[currentIndex].GetComponent<DifficultySelectionAnimation>().DoOpenAnimation();
        }
        
         IEnumerator _PreviousDifficulty()
        {
            Shields[currentIndex].GetComponent<DifficultySelectionAnimation>().DoCloseAnimation();
            //EnemySpaeners[currentIndex].SetActive(false);

            currentIndex--;
            if(currentIndex < 0)
            {
                currentIndex = Shields.Length -1;
            }
            yield return new WaitForSeconds(1);
            Shields[currentIndex].SetActive(true);
           // EnemySpaeners[currentIndex].SetActive(true);
            Shields[currentIndex].GetComponent<DifficultySelectionAnimation>().DoOpenAnimation();
        }
    }
}
