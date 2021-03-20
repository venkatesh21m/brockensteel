using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public class powerUpManager : MonoBehaviour
    {
        public GameObject[] PowerUps;
        int missedcount;
        public int powerupgivencount = 5;
        public Transform powerupholder;
        public GameObject Impulseprefab;
        public GameObject Holograph;
        public GameObject EnergyBoosteffect;
        public GameObject ShieldRecoveryeffect;
        public GameObject Firewall;

        GameManager GM;

        // Start is called before the first frame update
        void Start()
        {
            GM = GameManager.instance;
            GM.onGameStateChangeEvent.AddListener(HandleGameStateCHanged);

            GM.OnProvidePowerUpEvent.AddListener(HandleGivePowerupEvent);
            GM.OnmissedEvent.AddListener(HandleMissedEvent);

            GM.OnImpulsePowerUpusedEvent.AddListener(HandleImpulsePowerupUsed);
            GM.OnHolographPowerUpusedEvent.AddListener(HandleHoloGraphPowerupUsed);
            GM.OnEnergyBoostPowerUpusedEvent.AddListener(HandleEnergyBoostPowerupUsed);
            GM.OnShieldRecoveryPowerUpusedEvent.AddListener(HandleShieldRecoveryPowerUpUsed);
            GM.OnFirewallPowerUpusedEvent.AddListener(HandleFirewallPowerUpUsed);
        }

        private void HandleShieldRecoveryPowerUpUsed()
        {
            Destroy(Instantiate(ShieldRecoveryeffect), 3);
        }

        private void HandleFirewallPowerUpUsed()
        {
            Destroy(Instantiate(Firewall), 10);
        }

        private void HandleEnergyBoostPowerupUsed()
        {
            HandleImpulsePowerupUsed();
            Destroy(Instantiate(EnergyBoosteffect), 5);
        }

        private void HandleGameStateCHanged(GameState current, GameState previous)
        {
            if(current == GameState.GameOver)
            {
                Holograph.SetActive(false);
                foreach (var item in PowerUps)
                {
                    item.SetActive(false);
                }
            }

            if (current == GameState.InfiniteGame) powerupgivencount = 25;
            else if (current == GameState.JourneyGame) powerupgivencount = 10;
        }

        private void HandleHoloGraphPowerupUsed()
        {
            Holograph.SetActive(true);
            Invoke("DisableHolograph", 15);
        }

        void DisableHolograph()
        {
            Holograph.SetActive(false);
        }

        private void HandleImpulsePowerupUsed()
        {
            for (int i = 0; i < 3; i++)
            {
                Destroy(Instantiate(Impulseprefab), 4);
            }
        }

        private void HandleMissedEvent()
        {
            missedcount++;

            if(missedcount % powerupgivencount == 0)
            {
                GameManager.instance.OnProvidePowerUpEvent.Invoke();
            }
        }
        
        private void HandleGivePowerupEvent()
        {
            int num = Random.Range(0, PowerUps.Length);
            if (!PowerUps[num].activeSelf)
                PowerUps[num].SetActive(true);
        }
        
    }
}
