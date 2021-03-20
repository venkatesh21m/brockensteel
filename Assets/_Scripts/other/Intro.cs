using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
namespace Rudrac.BrockenSteel.Intro
{
    public class Intro : MonoBehaviour
    {

        public TMP_Text dialouguetext;
        public GameObject spirit;
        public GameObject spiritEffect;
        public GameObject Game;
        public GameObject[] prewarmbgs;
        public GameObject[] bgs;

        [Space]
        public string[] dialouges;

        Color fadeoutcolor;
        // Start is called before the first frame update
        void Start()
        {
            if(PersistantManager.Intro == 1)
            {
                Game.SetActive(true);
                spirit.transform.localScale = Vector3.one;
                spiritEffect.SetActive(true);
                foreach (var item in prewarmbgs)
                {
                    item.SetActive(true);
                } 
                foreach (var item in bgs)
                {
                    item.SetActive(false);
                }
                gameObject.SetActive(false);
                return;
            }
            foreach (var item in prewarmbgs)
            {
                item.SetActive(false);
            }
            foreach (var item in bgs)
            {
                item.SetActive(true);
            }
            StartCoroutine(intro());
            fadeoutcolor = Color.white;
            fadeoutcolor.a = 0;
        }

       IEnumerator intro()
        {
            yield return new WaitForSeconds(2.5f);
           
            dialouguetext.DOColor(Color.white,1f);
            dialouguetext.text = dialouges[0];
            yield return new WaitForSeconds(4);
           
            dialouguetext.DOColor(fadeoutcolor, 1f);
            spirit.transform.localScale = Vector3.zero;
            spirit.transform.DOScale(Vector3.one,5);
            yield return new WaitForSeconds(4);
           
            dialouguetext.DOColor(Color.white, 1f);
            dialouguetext.text = dialouges[1];
            yield return new WaitForSeconds(5);
           

            for (int i = 2; i < dialouges.Length; i++)
            {
                dialouguetext.DOColor(fadeoutcolor, 1);
                yield return new WaitForSeconds(1.25f);
                dialouguetext.DOColor(Color.white, .2f);
                dialouguetext.text = dialouges[i];
                yield return new WaitForSeconds(5);
            }

            yield return new WaitForSeconds(5);
            dialouguetext.DOColor(fadeoutcolor, .2f);
            PersistantManager.Intro = 1;
            yield return new WaitForSeconds(0.5f);
            spiritEffect.SetActive(true);
            Game.SetActive(true);

        }
    }
}