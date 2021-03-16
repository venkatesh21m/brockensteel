using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUdrac.BrockenSteel
{
    public class RotationScript : MonoBehaviour
    {
        public Vector3 rotation;
        [Header("zigzag")]
        public bool zigzag;
        public float directionchangeTime;

        private void Start()
        {
            if(zigzag)
                InvokeRepeating("changeDirection", 0.2f, directionchangeTime);
        }
        void Update()
        {
            transform.Rotate(rotation * Time.deltaTime);
        }

        void changeDirection()
        {
            rotation.y = -rotation.y;
        }
    }
}
