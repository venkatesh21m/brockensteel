using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Rudrac.BrockenSteel
{
    public class EnemySpawnManager : MonoBehaviour
    {
        public GameObject[] basicEnemies;
        public GameObject[] twoColouredEnemies;
        public GameObject[] threeColouredEnemies;

        [Space]
        [SerializeField] float MaxRotationSpeed = 10;
        [SerializeField] float minRotationSpeed = 60;
        [SerializeField] float maxDirectionChange=0.7f;
        [SerializeField] float MinDirectionchange=1.5f;
        [SerializeField] bool canSpawnDouble;
        [SerializeField] bool canspawnShielded;

        public float journeyTimeGap;

        private void Start()
        {
            GameManager.instance.onGameStateChangeEvent.AddListener(HandleGaneStateChageEvent);
            GameManager.instance.OnjourneyStageIncrementtrigger.AddListener(HandleJourneyStageIncrementTrigger);
            GameManager.instance.OnJourneyFinished.AddListener(HandleJourneyFinished);
        }

        private void HandleJourneyFinished()
        {
            StopCoroutine(Journey());
            StopAllCoroutines();
        }

        private void HandleJourneyStageIncrementTrigger()
        {
            journeyIndex++;
            if (journeyIndex == 5) canSpawnDouble = true;
            if (journeyIndex == 10) canspawnShielded = true;
        }

        private void HandleGaneStateChageEvent(GameState current, GameState previous)
        {
            if(current == GameState.JourneyGame && previous == GameState.pregame || current == GameState.JourneyGame && previous == GameState.GameOver)
            {
                //journeyIndex = 0;
                canSpawnDouble = false;
                canspawnShielded = false;
                StartCoroutine(Journey());
            }
            if (current == GameState.GameOver && previous == GameState.JourneyGame)
            {
                StopCoroutine(Journey());
                StopAllCoroutines();
            } 
            
            if(current == GameState.InfiniteGame && previous == GameState.pregame || current == GameState.InfiniteGame && previous == GameState.GameOver)
            {
                StartCoroutine(Endless());
            }
            
            if (current == GameState.GameOver && previous == GameState.InfiniteGame)
            {
                StopCoroutine(Endless());
                StopAllCoroutines();
            }
        }

        int journeyIndex = 0;
      
        IEnumerator Journey()
        {
            while (true)
            {
                switch (journeyIndex)
                {
                    case 0:
                        SpawnstraitEnemy();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                    case 1:
                        spawnEnemyColorPattern();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                    case 2:
                        int totalStreakNumber = Random.Range(5, 20);
                        StartCoroutine(SpawnEnemyStreak(totalStreakNumber, journeyTimeGap/2)); ;
                        yield return new WaitForSeconds(journeyTimeGap/2 * totalStreakNumber);
                        break;
                    case 3:
                        int totalStreakNumber_ = Random.Range(5, 20);
                        StartCoroutine(SpawnEnemyStreakRotation(totalStreakNumber_, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * totalStreakNumber_ + 2);
                        break;
                    case 4:
                        int totalStreakNumber__ = Random.Range(5, 20);
                        StartCoroutine(SpawnEnemyStreakzigzag(totalStreakNumber__, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * totalStreakNumber__ + 2);
                        break;
                    case 5:
                        SpawnRotatingEnemy();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                    case 6:
                        SpawnRotatingEnemyColorPattern();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                    case 7:
                        int _totalStreakNumber = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingEnemyStrak(_totalStreakNumber, journeyTimeGap/2));
                        yield return new WaitForSeconds(journeyTimeGap/2 * _totalStreakNumber);
                        break;
                    case 8:
                        int _totalStreakNumber_ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingEnemyStrakRotation(_totalStreakNumber_, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * _totalStreakNumber_ + 5);
                        break;
                    case 9:
                        int __totalStreakNumber__ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingEnemyStrakZigZag(__totalStreakNumber__, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * __totalStreakNumber__ + 5);
                        break;
                    case 10:
                        SpawnRotatingZigZagEnemy();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                    case 11:
                        SpawnRotatingzigzagEnemyColorPattern();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                    case 12:
                        int __total_StreakNumber = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingzigzagEnemyStrak(__total_StreakNumber, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * __total_StreakNumber + 5);
                        break;
                    case 13:
                        int _total_StreakNumber_ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingzigzagEnemyStrakRotation(_total_StreakNumber_, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * _total_StreakNumber_ + 5);
                        break;
                    case 14:
                        int __total_StreakNumber__ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingzigzagEnemyStrakRotationzigzag(__total_StreakNumber__, journeyTimeGap));
                        yield return new WaitForSeconds(journeyTimeGap * __total_StreakNumber__ + 5);
                        break;
                    default:
                        SpawnstraitEnemy();
                        yield return new WaitForSeconds(journeyTimeGap);
                        break;
                }
            }
        }

        public IEnumerator Endless()
        {
            for (int i = 0; i < 1000; i++)
            {
                int value = Random.Range(0, 15);

                switch (value)
                {
                    case 0:
                        SpawnstraitEnemy();
                        yield return new WaitForSeconds(2.5f);
                        break;
                    case 1:
                        spawnEnemyColorPattern();
                        yield return new WaitForSeconds(2.5f);
                        break;
                    case 2:
                        int totalStreakNumber = Random.Range(5, 20);
                        StartCoroutine(SpawnEnemyStreak(totalStreakNumber, 0.75f)); ;
                        yield return new WaitForSeconds(1f * totalStreakNumber);
                        break;
                    case 3:
                        int totalStreakNumber_ = Random.Range(5, 20);
                        StartCoroutine(SpawnEnemyStreakRotation(totalStreakNumber_, 1f));
                        yield return new WaitForSeconds(1f * totalStreakNumber_ + 2);
                        break;
                    case 4:
                        int totalStreakNumber__ = Random.Range(5, 20);
                        StartCoroutine(SpawnEnemyStreakzigzag(totalStreakNumber__, 1f));
                        yield return new WaitForSeconds(1f * totalStreakNumber__ + 2);
                        break;
                    case 5:
                        SpawnRotatingEnemy();
                        yield return new WaitForSeconds(2.5f);
                        break;
                    case 6:
                        SpawnRotatingEnemyColorPattern();
                        yield return new WaitForSeconds(2.5f);
                        break;
                    case 7:
                        int _totalStreakNumber = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingEnemyStrak(_totalStreakNumber, 0.5f));
                        yield return new WaitForSeconds(0.75f * _totalStreakNumber);
                        break;
                    case 8:
                        int _totalStreakNumber_ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingEnemyStrakRotation(_totalStreakNumber_, 1f));
                        yield return new WaitForSeconds(1 * _totalStreakNumber_ + 5);
                        break;
                    case 9:
                        int __totalStreakNumber__ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingEnemyStrakZigZag(__totalStreakNumber__, 1f));
                        yield return new WaitForSeconds(1 * __totalStreakNumber__ + 5);
                        break;
                    case 10:
                        SpawnRotatingZigZagEnemy();
                        yield return new WaitForSeconds(2.5f);
                        break;
                    case 11:
                        SpawnRotatingzigzagEnemyColorPattern();
                        yield return new WaitForSeconds(2.5f);
                        break;
                    case 12:
                        int __total_StreakNumber = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingzigzagEnemyStrak(__total_StreakNumber, 1f));
                        yield return new WaitForSeconds(1 * __total_StreakNumber+5);
                        break;
                    case 13:
                        int _total_StreakNumber_ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingzigzagEnemyStrakRotation(_total_StreakNumber_, 1));
                        yield return new WaitForSeconds(1 * _total_StreakNumber_ + 5);
                        break;
                    case 14:
                        int __total_StreakNumber__ = Random.Range(5, 20);
                        StartCoroutine(SpawnRotatingzigzagEnemyStrakRotationzigzag(__total_StreakNumber__, 1));
                        yield return new WaitForSeconds(1 * __total_StreakNumber__ + 5);
                        break;
                    default:
                        SpawnstraitEnemy();
                        yield return new WaitForSeconds(2f);
                        break;
                }
            }
     
        }

        #region helpers
        float GetRotationSpeed()
        {
            return Random.Range(minRotationSpeed, MaxRotationSpeed); ;
        }
        Vector3 GetRandomEulerAngles()
        {
            return new Vector3(0, Random.Range(0, 360), 0);
        }

        GameObject SpawnEnemy()
        {
            if (canspawnShielded)
            {
                if (canSpawnDouble)
                {
                    if (Random.value > .5f)
                    {
                        GameObject obj1 = Instantiate(twoColouredEnemies[Random.Range(0, twoColouredEnemies.Length)]);
                        obj1.GetComponent<Movement>().shielded = true;
                        return obj1;
                    }
                }
                GameObject obj = Instantiate(basicEnemies[Random.Range(0, basicEnemies.Length)]);
                obj.GetComponent<Movement>().shielded = true;
                return obj;
            }

            if (canSpawnDouble)
            {
                if (Random.value > .5f)
                {
                    return Instantiate(twoColouredEnemies[Random.Range(0, twoColouredEnemies.Length)]);
                }
            }
            return Instantiate(basicEnemies[Random.Range(0, basicEnemies.Length)]); 
        } 
        
        GameObject SpawnEnemy(int i)
        {
            if (canspawnShielded)
            {
                
                    if (Random.value > .75f)
                    {
                        // return Instantiate(basicEnemies[i]);
                        GameObject obj1 = Instantiate(basicEnemies[i]);
                        obj1.GetComponent<Movement>().shielded = true;
                        return obj1;
                    }
            }

            return Instantiate(basicEnemies[i]); 

        }

        #endregion
       
        #region strait
        public void SpawnstraitEnemy()
        {
            GameObject enemy = SpawnEnemy();
            enemy.transform.eulerAngles = GetRandomEulerAngles();
        }


        void spawnEnemyColorPattern()
        {
            float additionalAngle = Random.Range(0, 360);
            for (int i = 0; i < basicEnemies.Length; i++)
            {
                if (Random.value > .5f)
                {
                    GameObject enemy = SpawnEnemy(i);
                    enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * i) + additionalAngle, 0);
                }
            }
        }

        IEnumerator SpawnEnemyStreak(int totalStreakNumber,float eachstreakGap)
        {
            float additionalAngle = Random.Range(0, 360);

            for (int i = 0; i < totalStreakNumber; i++)
            {
                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle + Random.Range(-20,20), 0);
                    //}
                }

                yield return new WaitForSeconds(eachstreakGap);
            }
        }
         IEnumerator SpawnEnemyStreakRotation(int totalStreakNumber,float eachstreakGap)
        {
            float additionalAngle = Random.Range(0, 360);
            float RotationAngle = Random.Range(0, 360 / 5);
            for (int i = 0; i < totalStreakNumber; i++)
            {
                additionalAngle += RotationAngle;
                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                    //}
                }

                yield return new WaitForSeconds(eachstreakGap);
            }
        }
         IEnumerator SpawnEnemyStreakzigzag(int totalStreakNumber,float eachstreakGap)
        {
            float additionalAngle = Random.Range(0, 360);
            float RotationAngle = Random.Range(0, 360 / 5);
            for (int i = 0; i < totalStreakNumber; i++)
            {
                int direction = 1;
                if (i % totalStreakNumber / 5 == 0)
                    direction = direction == 1 ? 2 : 1;

                if(direction==1)
                    additionalAngle += RotationAngle;
                else
                    additionalAngle -= RotationAngle;

                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                    //}
                }

                yield return new WaitForSeconds(eachstreakGap);
            }
        }

        #endregion

        #region Rotation

        public void SpawnRotatingEnemy()
        {
            GameObject enemy = SpawnEnemy();
            enemy.transform.eulerAngles = GetRandomEulerAngles();
            Movement enemyMovement = enemy.GetComponent<Movement>();
            enemyMovement.MovementType = MovementType.rotating;
            enemyMovement.rotationSpeed = GetRotationSpeed();
            
            if(Random.value > .5f)
            {
                enemyMovement.rotationSpeed = -enemyMovement.rotationSpeed;
            }
        }

        public void SpawnRotatingEnemyColorPattern()
        {
            
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);

            for (int i = 0; i < basicEnemies.Length; i++)
            {
                if (Random.value > .5f)
                {
                    GameObject enemy = SpawnEnemy(i);
                    enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * i) + additionalAngle, 0);
                    Movement enemyMovement = enemy.GetComponent<Movement>();
                    enemyMovement.MovementType = MovementType.rotating;
                    enemyMovement.rotationSpeed = rotationspeed;
                }
            }
        }


        IEnumerator SpawnRotatingEnemyStrak(int totalStreakNumber, float eachstreakGap)
        {
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);

            for (int i = 0; i < totalStreakNumber; i++)
            {
                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                        Movement enemyMovement = enemy.GetComponent<Movement>();
                        enemyMovement.MovementType = MovementType.rotating;
                        enemyMovement.rotationSpeed = rotationspeed;
                    //}
                }
                yield return new WaitForSeconds(eachstreakGap);
            }
        } 
        
        
        IEnumerator SpawnRotatingEnemyStrakRotation(int totalStreakNumber, float eachstreakGap)
        {
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);
            float rotationangle = Random.Range(0, 360 / 5);
            
            for (int i = 0; i < totalStreakNumber; i++)
            {
                additionalAngle += rotationangle;
                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                        Movement enemyMovement = enemy.GetComponent<Movement>();
                        enemyMovement.MovementType = MovementType.rotating;
                        enemyMovement.rotationSpeed = rotationspeed;
                    //}
                }
                yield return new WaitForSeconds(eachstreakGap);
            }
        }
         IEnumerator SpawnRotatingEnemyStrakZigZag(int totalStreakNumber, float eachstreakGap)
        {
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);
            float rotationangle = Random.Range(0, 360 / 5);
            
            for (int i = 0; i < totalStreakNumber; i++)
            {
                int direction = 1;
                if (i % totalStreakNumber / 5 == 0)
                    direction = direction == 1 ? 2 : 1;

                if (direction == 1)
                    additionalAngle += rotationangle;
                else
                    additionalAngle -= rotationangle;

                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                        Movement enemyMovement = enemy.GetComponent<Movement>();
                        enemyMovement.MovementType = MovementType.rotating;
                        enemyMovement.rotationSpeed = rotationspeed;
                    //}
                }
                yield return new WaitForSeconds(eachstreakGap);
            }
        }

        #endregion

        #region Zigzag

        public void SpawnRotatingZigZagEnemy()
        {
            GameObject enemy = SpawnEnemy();
            enemy.transform.eulerAngles = GetRandomEulerAngles();
            Movement enemyMovement = enemy.GetComponent<Movement>();
            enemyMovement.MovementType = MovementType.zigzag;
            enemyMovement.rotationSpeed = GetRotationSpeed();
            enemyMovement.directionchangeTime = Random.Range(MinDirectionchange, maxDirectionChange);
            if (Random.value > .5f)
            {
                enemyMovement.rotationSpeed = -enemyMovement.rotationSpeed;
            }
        }

        public void SpawnRotatingzigzagEnemyColorPattern()
        {

            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);
            float DirectionChangeTime = Random.Range(MinDirectionchange, maxDirectionChange);

            for (int i = 0; i < basicEnemies.Length; i++)
            {
                if (Random.value > .5f)
                {
                    GameObject enemy = SpawnEnemy(i);
                    enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * i) + additionalAngle, 0);
                    Movement enemyMovement = enemy.GetComponent<Movement>();
                    enemyMovement.MovementType = MovementType.zigzag;
                    enemyMovement.rotationSpeed = rotationspeed;
                    enemyMovement.directionchangeTime = DirectionChangeTime;

                }
            }
        }


        IEnumerator SpawnRotatingzigzagEnemyStrak(int totalStreakNumber, float eachstreakGap)
        {
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);
            float DirectionChangeTime = Random.Range(MinDirectionchange, maxDirectionChange);

            for (int i = 0; i < totalStreakNumber; i++)
            {
                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                        Movement enemyMovement = enemy.GetComponent<Movement>();
                        enemyMovement.MovementType = MovementType.zigzag;
                        enemyMovement.rotationSpeed = rotationspeed;
                        enemyMovement.directionchangeTime = DirectionChangeTime;
                    //}
                }
                yield return new WaitForSeconds(eachstreakGap);
            }
        }


        IEnumerator SpawnRotatingzigzagEnemyStrakRotation(int totalStreakNumber, float eachstreakGap)
        {
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);
            float DirectionChangeTime = Random.Range(MinDirectionchange, maxDirectionChange);
            float Rotatingangle = Random.Range(20, 360 / 5);
            for (int i = 0; i < totalStreakNumber; i++)
            {
                additionalAngle += Rotatingangle;

                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                        Movement enemyMovement = enemy.GetComponent<Movement>();
                        enemyMovement.MovementType = MovementType.zigzag;
                        enemyMovement.rotationSpeed = rotationspeed;
                        enemyMovement.directionchangeTime = DirectionChangeTime;
                    //}
                }
                yield return new WaitForSeconds(eachstreakGap);
            }
        }
        IEnumerator SpawnRotatingzigzagEnemyStrakRotationzigzag(int totalStreakNumber, float eachstreakGap)
        {
            float rotationspeed = GetRotationSpeed();
            if (Random.value > .5f)
            {
                rotationspeed = -rotationspeed;
            }
            float additionalAngle = Random.Range(0, 360);
            float DirectionChangeTime = Random.Range(MinDirectionchange, maxDirectionChange);
            float Rotatingangle = Random.Range(25, 360 / 5);
            for (int i = 0; i < totalStreakNumber; i++)
            {
                int direction = 1;
                if (i % totalStreakNumber / 5 == 0)
                    direction = direction == 1 ? 2 : 1;

                if (direction == 1)
                    additionalAngle += Rotatingangle;
                else
                    additionalAngle -= Rotatingangle;

                for (int j = 0; j < basicEnemies.Length; j++)
                {
                    //if (Random.value > .5f)
                    //{
                        GameObject enemy = SpawnEnemy(j);
                        enemy.transform.eulerAngles = new Vector3(0, ((360 / basicEnemies.Length) * j) + additionalAngle, 0);
                        Movement enemyMovement = enemy.GetComponent<Movement>();
                        enemyMovement.MovementType = MovementType.zigzag;
                        enemyMovement.rotationSpeed = rotationspeed;
                        enemyMovement.directionchangeTime = DirectionChangeTime;
                    //}
                }
                yield return new WaitForSeconds(eachstreakGap);
            }
        }
        #endregion

    }
}