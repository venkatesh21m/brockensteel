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
