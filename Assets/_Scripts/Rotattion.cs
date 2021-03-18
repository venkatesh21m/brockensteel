using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public class Rotattion : MonoBehaviour
    {
        public Vector3 rotation;

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(rotation * Time.deltaTime);
        }
    }
}
