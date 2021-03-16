using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUdrac.BrockenSteel
{
    public class PowerUps : MonoBehaviour
    {
        public GameObject positiveImpulse;
        public GameObject Holograph;
        public GameObject EnergyBoosteffect;
        public GameObject ShieldRecoveryeffect;
        public GameObject FireWall;


        public void positivePowerUp()
        {
            for (int i = 0; i < 3; i++)
            {
                Destroy(Instantiate(positiveImpulse), 4);
            }
        }

        public void ActivateSlowMotion()
        {
            GameManager.instance.onSlowMotionEvent.Invoke(true);
            Invoke("DisableSlowMotion", 10);
        }

        public void ActivateHologram()
        {
            Holograph.SetActive(true);
            Invoke("DisableHolograph", 10);
        }

        public void ActivateEnergyBoost()
        {
            positivePowerUp();
            Destroy(Instantiate(EnergyBoosteffect), 10);
        }


        public void ActivateSHieldRecovery()
        {
            GameManager.instance.onShieldRecoveryEvent.Invoke(true);
            Destroy(Instantiate(ShieldRecoveryeffect), 10);
        }

        public void ActivateFireWall()
        {
            FireWall.SetActive(true);
            Invoke("Disablefirewall", 10);
        }










        void DisableSlowMotion()
        {
            GameManager.instance.onSlowMotionEvent.Invoke(false);
        }

        void DisableHolograph()
        {
            Holograph.SetActive(false);
        } 
        void Disablefirewall()
        {
            FireWall.SetActive(false);
        }
    }
}
