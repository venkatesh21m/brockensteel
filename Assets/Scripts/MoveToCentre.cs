using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUdrac.BrockenSteel
{
    public class MoveToCentre : MonoBehaviour
    {
        public float translationSpeed = 5f;

        public LineRenderer LineRenderer;

        private void Start()
        {

            LineRenderer = gameObject.AddComponent<LineRenderer>();
            LineRenderer.SetWidth(0.051f, 0.051f);
            LineRenderer.material = GetComponent<MeshRenderer>() ? GetComponent<MeshRenderer>().material : transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material;
           
            if (GameManager.instance.SlowMotion) translationSpeed /= 3;
            GameManager.instance.onSlowMotionEvent.AddListener(HandleSlowmotionevent);

        }

        void HandleSlowmotionevent(bool active)
        {
            if (active) translationSpeed /= 3;
            else translationSpeed *= 3;
        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(new Vector3(-translationSpeed * Time.deltaTime, 0, 0));
            
            Ray ray = new Ray(transform.position, -transform.right);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                LineRenderer.SetPosition(0, transform.position);
                LineRenderer.SetPosition(1, hit.point);
            }
        }
    }
}
