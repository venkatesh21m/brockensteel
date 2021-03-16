using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUdrac.BrockenSteel
{
    public class PlayerControl : MonoBehaviour
    {
        public float RotationSpeed;

        // Start is called before the first frame update
        void Start()
        {
            GameManager.instance.onShieldRecoveryEvent.AddListener(HandleshieldRecoveryEvent);
        }

        private void HandleshieldRecoveryEvent(bool active)
        {
            var shields = GetComponentsInChildren<ShieldStats>(true);
            Debug.Log(shields.Length);
            foreach (var item in shields)
            {
                if (item.colorType != ColorType.FireWall)
                {
                    item.Health = 50;
                    if (!item.gameObject.activeSelf)
                    {
                        item.transform.localScale = Vector3.one;
                        item.gameObject.SetActive(true);
                    }
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            float lh = Input.GetAxis("Horizontal");
            if(Input.touchCount > 0)
            {
               Touch Touch = Input.GetTouch(0);
                if(Touch.position.x > Screen.width / 2)
                {
                    lh = 1;
                }
                else if(Touch.position.x < Screen.width / 2)
                {
                    lh = -1;
                }
                else
                {
                    lh = 0;
                }
            }
            transform.Rotate(new Vector3(0, lh * RotationSpeed * Time.deltaTime, 0));
        }
    }
}
