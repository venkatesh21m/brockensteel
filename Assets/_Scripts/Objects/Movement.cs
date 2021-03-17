﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rudrac.BrockenSteel
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] MovementType movementType;
        public MovementType MovementType { get; set; }

        public float MovementSpeed = 5;
        public float rotationSpeed = 0;
        public float directionchangeTime = 0;

        Transform model;
        LineRenderer LineRenderer;
        private void Start()
        {
            model = transform.GetChild(0);

            LineRenderer = gameObject.AddComponent<LineRenderer>();
            LineRenderer.SetWidth(0.051f, 0.051f);
            LineRenderer.material = transform.GetChild(0).GetComponent<MeshRenderer>() ? transform.GetChild(0).GetComponent<MeshRenderer>().material : transform.GetChild(0).GetChild(0).GetComponent<MeshRenderer>().material;
            if(movementType == MovementType.zigzag) InvokeRepeating("changeDirection", 0f, directionchangeTime);
        }

        void changeDirection()
        {
            rotationSpeed = -rotationSpeed;
        }



        private void Update()
        {
            model.Translate(new Vector3(-MovementSpeed * Time.deltaTime, 0, 0) );

            switch (movementType)
            {
                case MovementType.strait:
                    break;
                case MovementType.rotating:
                    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                    break;
                case MovementType.zigzag:
                    transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
                    break;
                default:
                    break;
            }

        }

        private void LateUpdate()
        {
            Ray ray = new Ray(transform.position, -transform.right);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                LineRenderer.SetPosition(0, transform.position);
                LineRenderer.SetPosition(1, hit.point);
            }
        }

    }
}
