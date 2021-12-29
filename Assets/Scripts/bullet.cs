using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public class bullet : MonoBehaviour
    {
        public float speed;
        public Rigidbody rb;

        // Update is called once per frame
        void Update()
        {
            //rb.MovePosition(rb.position + new Vector3(0, 0, speed * Time.deltaTime));
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject other = collision.gameObject;
            EnemyStats Enemystats = other.GetComponent<EnemyStats>();

          
            //bool samecolor = false;
            //foreach (var item in Enemystats.colorTypes)
            //{
            //    if (item == colorType)
            //    {
            //        GameManager.instance.OnScoredEvent.Invoke();
            //        scoredEffect();
            //        Enemystats.ConsumeEffect();
            //        samecolor = true;
            //    }
            //}

            //if (samecolor == false)
            //{
                //Camera.main.transform.DOShakeRotation(0.25f, 0.75f, 20);
               // TakeDamage(Enemystats.DamageAmount);
              
                if(Enemystats!=null)
                    Enemystats.DeathEffect();
                GameManager.instance.OnScoredEvent.Invoke();
                //GameManager.instance.OnmissedEvent.Invoke();
            //}

        }
    }
}
