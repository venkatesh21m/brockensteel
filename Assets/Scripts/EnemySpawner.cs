using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RUdrac.BrockenSteel
{
    public class EnemySpawner : MonoBehaviour
    {
        public GameObject[] Enemies;
        public float SpawnRate = 2.5f;

        void Start()
        {
             //StartCoroutine(SpawnEnemies());
            // StartCoroutine(RadialSpawningStreak(25,0.75f));
           // StartCoroutine(StraitSpawningStreak(25,1.75f));
            //InvokeRepeating("ZigZagSPawn", 6, 2.5f);
            StartCoroutine("SpawnPattern");
        }

        IEnumerator SpawnPattern()
        {
            for (int i = 0; i < 5; i++)
            {
                GameObject objtoInstantiate = Enemies[Random.Range(0, Enemies.Length)];
                float rotation = Random.Range(0, 360);
                GameObject obj = Instantiate(objtoInstantiate, objtoInstantiate.transform.position, Quaternion.identity);
                obj.transform.eulerAngles = new Vector3(0, rotation, 0);
                
                yield return new WaitForSeconds(2);
            }
            yield return new WaitForSeconds(2);

            for (int i = 0; i < 5; i++)
            {
                GameObject objtoInstantiate = Enemies[Random.Range(0, Enemies.Length)];
                float rotation = Random.Range(0, 360);
                GameObject obj = Instantiate(objtoInstantiate, objtoInstantiate.transform.position, Quaternion.identity);
                obj.transform.eulerAngles = new Vector3(0, rotation, 0);

                obj.AddComponent<RotationScript>();
                float rotationspeed = Random.Range(25, 50);
                obj.GetComponent<RotationScript>().rotation = new Vector3(0, Random.value > .5 ? rotationspeed : -rotationspeed, 0);

                yield return new WaitForSeconds(1.5f);
            }
            yield return new WaitForSeconds(2);
          
            for (int i = 0; i < 5; i++)
            {
                ZigZagSPawn();
                yield return new WaitForSeconds(1.5f);

            }
            yield return new WaitForSeconds(2);
           
            StartCoroutine(RadialSpawningStreak(25, 0.75f));
            yield return new WaitForSeconds(0.75f*27);

            StartCoroutine(StraitSpawningStreak(25,0.75f));

        }

        IEnumerator SpawnEnemies()
        {
            //yield return new WaitForSeconds(SpawnRate);

            int count = 0;

            while(true)
            {
                GameObject objtoInstantiate = Enemies[Random.Range(0, Enemies.Length)];
                float rotation =  Random.Range(0, 360);
                GameObject obj = Instantiate(objtoInstantiate, objtoInstantiate.transform.position, Quaternion.identity);
                obj.transform.eulerAngles = new Vector3(0, rotation, 0);

                if (Random.value > 0.3f) 
                { 
                    obj.AddComponent<RotationScript>();
                    float rotationspeed = Random.Range(25, 50);
                    obj.GetComponent<RotationScript>().rotation = new Vector3(0, Random.value > .5 ? rotationspeed : -rotationspeed, 0);
                }

                count++;

                if(count % 5 == 0)
                {
                    SpawnRate -= 0.2f;
                    if(SpawnRate < .75f)
                    {
                        SpawnRate = .752f;
                    }
                }

                yield return new WaitForSeconds(SpawnRate);

            }
        }
        
        IEnumerator RadialSpawningStreak(int totalStreak, float spawnRate)
        {
            int count = 0;

            yield return new WaitForSeconds(2f);

            float rotationspeed = Random.Range(25, 50);
            rotationspeed = Random.value > .5 ? rotationspeed : -rotationspeed;

            float additionAngle = Random.Range(0, 360);

            while (count <= totalStreak)
            {
                for (int i = 0; i < Enemies.Length; i++)
                {
                    GameObject obj = Instantiate(Enemies[i], Enemies[i].transform.position, Quaternion.identity);
                    obj.transform.eulerAngles = new Vector3(0, ((360/Enemies.Length) * i) + additionAngle , 0);
                    obj.AddComponent<RotationScript>();
                    obj.GetComponent<RotationScript>().rotation = new Vector3(0, rotationspeed, 0);
                }
                count++;
                yield return new WaitForSeconds(spawnRate);
            }
        }

        IEnumerator StraitSpawningStreak(int totalStreak, float spawnRate)
        {

            int count = 0;

            //yield return new WaitForSeconds(2f);

            float additionAngle = Random.Range(0, 360);

            while (count <= totalStreak)
            {
                for (int i = 0; i < Enemies.Length; i++)
                {
                    GameObject obj = Instantiate(Enemies[i], Enemies[i].transform.position, Quaternion.identity);
                    float angle = ((360 / Enemies.Length) * i);
                    obj.transform.eulerAngles = new Vector3(0, angle + additionAngle + Random.Range(-25,25), 0);
                    //obj.transform.GetChild(0).transform.localPosition = new Vector3(30, 1, Random.Range(-5, 5));  
                }
                count++;
                yield return new WaitForSeconds(spawnRate);
            }
        }
   
        void ZigZagSPawn()
        {
            GameObject objtoInstantiate = Enemies[Random.Range(0, Enemies.Length)];
            float rotation = Random.Range(0, 360);
            GameObject obj = Instantiate(objtoInstantiate, objtoInstantiate.transform.position, Quaternion.identity);
            obj.transform.eulerAngles = new Vector3(0, rotation, 0);

            RotationScript rotscript = obj.AddComponent<RotationScript>();
            float rotationspeed = Random.Range(20, 50);
            rotscript.rotation = new Vector3(0, Random.value > .5 ? rotationspeed : -rotationspeed, 0);
            rotscript.zigzag = true;
            rotscript.directionchangeTime = 1f;

        }

    }
}
