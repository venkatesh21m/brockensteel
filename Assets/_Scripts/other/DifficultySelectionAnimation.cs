using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

namespace Rudrac.BrockenSteel
{
    public class DifficultySelectionAnimation : MonoBehaviour
    {
        public Transform HolographicHolder;
        public Transform[] arcs;
        public GameObject[] shields;


        private void Start()
        {
            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGameStateChanged);
            foreach (var item in arcs)
            {
                item.localScale = Vector3.zero;
            }
           // DoOpenAnimation();
        }

        private void HandleGameStateChanged(GameState current, GameState previous)
        {
           if(current == GameState.InfiniteGame|| current == GameState.JourneyGame)
            {
                DoOpenAnimation();
            }
        }

        public void DoOpenAnimation()
        {
            foreach (var item in arcs)
            {
                item.localScale = Vector3.zero;
            }
            transform.parent.localScale = Vector3.one;
            if (!transform.parent.gameObject.activeSelf)
            {
                transform.parent.gameObject.SetActive(true);
                GetComponentInParent<Core>().HandleShieldRecovery();
            }
            
            StartCoroutine(OpenAnimation());
        }

        private IEnumerator OpenAnimation()
        {
            foreach (var item in arcs)
            {
                item.DOScale(new Vector3(1, 20, .3f), .5f);
            }

            shields[0].transform.DOScale(Vector3.one, .5f);
            shields[1].transform.DOScale(Vector3.one*1.3f, .5f);
           
            yield return new WaitForSeconds(0.5f);

            foreach (var item in arcs)
            {
                item.DOScale(Vector3.zero, .5f);
            }

        }

        public void DoCloseAnimation()
        {
            StartCoroutine(CloseAnimation());
        }

        private IEnumerator CloseAnimation()
        {
            foreach (var item in arcs)
            {
                item.DOScale(new Vector3(1, 20, .3f), .5f);
            }
            yield return new WaitForSeconds(0.5f);

            foreach (var item in arcs)
            {
                item.DOScale(Vector3.zero, .5f);
            }

            shields[0].transform.DOScale(Vector3.zero, .5f);
            shields[1].transform.DOScale(Vector3.zero, .5f);
           
            yield return new WaitForSeconds(0.5f);
            gameObject.SetActive(false);
        }
    }
}
