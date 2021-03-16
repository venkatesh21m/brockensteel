using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


namespace RUdrac.BrockenSteel
{
    public class CollisionDetection : MonoBehaviour
    {
        ShieldStats stats;
        // Start is called before the first frame update
        void Start()
        {
            stats = GetComponent<ShieldStats>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void OnCollisionEnter(Collision collision)
        {
            GameObject other = collision.gameObject;
            EnemyStats Enemystats = other.GetComponent<EnemyStats>();
            
            if (stats.colorType == ColorType.FireWall)
            {
                Enemystats.DeathEffect();
                return;
            }
           
                bool samecolor = false;
                foreach (var item in Enemystats.colorTypes)
                {
                    if(item == stats.colorType)
                    {
                        GameManager.instance.scored();
                        stats.scoredEffect();
                        Enemystats.ConsumeEffect();
                        samecolor = true;
                    }
                }

            if(samecolor == false)
            {
                Camera.main.transform.DOShakeRotation(0.25f, 0.75f,20);
                stats.TakeDamage(Enemystats.DamageAmount);
                Enemystats.DeathEffect();
            }

        }
    }
}