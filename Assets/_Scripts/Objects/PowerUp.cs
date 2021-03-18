using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace Rudrac.BrockenSteel
{
    public class PowerUp : MonoBehaviour
    {

        public PowerUps poweruptype;

        // Start is called before the first frame update
        void Start()
        {
           // GetComponent<Button>().onClick.AddListener(onbuttonClick);
        }

        public void onbuttonClick(int poweruptype)
        {
            switch (poweruptype)
            {
                case 1:
                    GameManager.instance.OnImpulsePowerUpusedEvent.Invoke();
                    break;
                case 2:
                    GameManager.instance.OnSlowMotionPowerUpusedEvent.Invoke(true);
                    Invoke("disblepowerup", 7);
                    break;
                case 3:
                    GameManager.instance.OnHolographPowerUpusedEvent.Invoke();

                    break;
                case 4:
                    GameManager.instance.OnEnergyBoostPowerUpusedEvent.Invoke();

                    break;
                case 5:
                    GameManager.instance.OnShieldRecoveryPowerUpusedEvent.Invoke();

                    break;
                case 6:
                    GameManager.instance.OnFirewallPowerUpusedEvent.Invoke();

                    break;
                default:
                    break;
            }
            gameObject.SetActive(false);
        }

        void disblepowerup()
        {
            GameManager.instance.OnSlowMotionPowerUpusedEvent.Invoke(false);
        }
    }
}
