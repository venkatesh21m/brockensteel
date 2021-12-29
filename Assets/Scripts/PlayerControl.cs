using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rudrac.BrockenSteel
{
    public class PlayerControl : MonoBehaviour
    {
        public float RotationSpeed;

        [Space]
        public bool FiringGame;
        public GameObject bullet;
        public Transform firePoint;
        // Start is called before the first frame update
        void Start()
        {
           // GameManager.instance.onShieldRecoveryEvent.AddListener(HandleshieldRecoveryEvent);
        }

        //private void HandleshieldRecoveryEvent(bool active)
        //{
        //    var shields = GetComponentsInChildren<ShieldStats>(true);
        //    Debug.Log(shields.Length);
        //    foreach (var item in shields)
        //    {
        //        if (item.colorType != ColorType.FireWall)
        //        {
        //            item.Health = 50;
        //            if (!item.gameObject.activeSelf)
        //            {
        //                item.transform.localScale = Vector3.one;
        //                item.gameObject.SetActive(true);
        //            }
        //        }
        //    }
        //}

        Vector3 previous = new(0, 0, 1);
        Vector2 touchstart;
        // Update is called once per frame
        void Update()
        {
            if (FiringGame)
            {
#if UNITY_Editor || !UNITY_ANDROID
                float lh = Input.GetAxis("Horizontal");
                float lv = Input.GetAxis("Vertical");
                Vector3 direction = new(lh, 0, lv);
                direction.Normalize();
                if (direction.magnitude == 0)
                    direction = previous;
               
                var targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, (RotationSpeed/4) * Time.deltaTime);
                Vector3 rot = transform.eulerAngles;
                rot.x = 0;
                transform.eulerAngles = rot;
                previous = direction;

                if (Input.GetButtonDown("Fire1"))
                {
                    GameObject _bullet = Instantiate(bullet, firePoint.transform.position, transform.rotation);
                    Destroy(_bullet,5);
                }
#elif UNITY_ANDROID
                if (Input.touchCount > 0)
                {
                    Vector3 direction = new(0, 0, 1);
                    Touch Touch1 = Input.GetTouch(0);
                    if (Touch1.position.x < Screen.width / 2)
                    {
                        if(Touch1.phase == TouchPhase.Began)
                        {
                            touchstart = Touch1.position;
                        }
                        else if(Touch1.phase == TouchPhase.Moved||Touch1.phase == TouchPhase.Stationary)
                        {
                            direction = Touch1.position - touchstart;
                            direction.z = direction.y;
                            direction.y = 0;
                        }
                        else if(Touch1.phase == TouchPhase.Ended)
                        {
                            touchstart = Vector3.zero;
                        }
                    }
                    if (Input.touchCount > 1)
                    {
                        Touch Touch2 = Input.GetTouch(1);
                        if (Touch2.position.x < Screen.width / 2)
                        {
                            if (Touch2.phase == TouchPhase.Began)
                            {
                                touchstart = Touch2.position;
                            }
                            else if (Touch2.phase == TouchPhase.Moved || Touch2.phase == TouchPhase.Stationary)
                            {
                                direction = Touch2.position - touchstart;
                                direction.z = direction.y;
                                direction.y = 0;
                            }
                            else if (Touch2.phase == TouchPhase.Ended)
                            {
                                touchstart = Vector3.zero;
                            }
                        }
                        
                        if(Touch2.position.x > Screen.width / 2)
                        {
                            FireButtlet();
                        }
                    }

                    transform.LookAt(direction);
                    //var targetRotation = Quaternion.LookRotation(direction);
                    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, /*(RotationSpeed / 4) **/ Time.deltaTime);
                    Vector3 rot = transform.eulerAngles;
                    rot.x = 0;
                    transform.eulerAngles = rot;
                    previous = direction;

                    if (Touch1.position.x > Screen.width / 2)
                    {
                        FireButtlet();
                    }
                }
#endif
            }
            else
            {
                float lh = Input.GetAxis("Horizontal");
                if (Input.touchCount > 0)
                {
                    Touch Touch = Input.GetTouch(0);
                    if (Touch.position.x > Screen.width / 2)
                    {
                        lh = 1;
                    }
                    else if (Touch.position.x < Screen.width / 2)
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
        float time;
        void FireButtlet()
        {
            if (Time.time < time + 0.25f) return;
            GameObject _bullet = Instantiate(bullet, firePoint.transform.position, transform.rotation);
            Destroy(_bullet, 5);
            time = Time.time;
        }
    }
}
