using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUdrac.BrockenSteel
{
    public class PowerUps : MonoBehaviour
    {
        public GameObject positiveImpulse;
        public GameObject Holograph;

        public void positivePowerUp()
        {
            for (int i = 0; i < 3; i++)
            {
                Destroy(Instantiate(positiveImpulse), 4);
            }
        }

        public void ActivateSlowMotion()
        {

        }

        public void ActivateHologram()
        {
            Holograph.SetActive(true);
            Invoke("DisableHolograph", 10);
        }



        void DisableHolograph()
        {
            Holograph.SetActive(false);
        }

    }

}
