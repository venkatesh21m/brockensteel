using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Rudrac.BrockenSteel
{
    public class PositiveImpulse : MonoBehaviour
    {

        private void Start()
        {
            transform.localScale = Vector3.zero;
            Invoke("Animate", Random.Range(0, 1.5f));
        }

        void Animate()
        {
            Sequence positiveImpulseSequence = DOTween.Sequence();
            positiveImpulseSequence.Append(transform.DOScale(Vector3.one * 1.5f, 1.5f));
            positiveImpulseSequence.Append(transform.DOScale(Vector3.one * 0, 2.5f));
        }

        private void OnCollisionEnter(Collision collision)
        {
            collision.collider.GetComponent<EnemyStats>().DeathEffect();
            AudioManager.instance.PlayblastSound();
        }

    }
}
