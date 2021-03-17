using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rudrac.BrockenSteel
{
    public class Core : MonoBehaviour
    {
        Stats[] stats;
        Stats CoreStats;

        [SerializeField] float energy;
        public float Energy { get; set; }

        public float EnergyFillingRate = 1;

        public void Start()
        {
            CoreStats = GetComponent<Stats>();
            stats = GetComponentsInChildren<Stats>(true);
        }

        private void Update()
        {
            foreach (var item in stats)
            {
                if (item.Health < item.MaxHealth)
                {
                    if (Energy > 0)
                    {
                        item.Health += EnergyFillingRate * Time.deltaTime;
                        Energy -= EnergyFillingRate * Time.deltaTime;
                    }
                    if(!item.gameObject.activeSelf && item.Health > 0)
                    {
                        item.gameObject.SetActive(true);
                    }
                }
            }
        }


        private void OnCollisionEnter(Collision collision)
        {
            
        }


    }
}
