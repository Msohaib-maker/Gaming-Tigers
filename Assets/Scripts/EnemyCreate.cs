using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    public Transform[] points = new Transform[3];
    public GameObject enemyPrefab;
    bool isEnemyExist = false;
    public int count_enemy = 0;

    public static EnemyCreate instance;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;   
    }

    // Update is called once per frame
    void Update()
    {

        if (count_enemy == 0)
        {
            isEnemyExist = false;
        }

        if (!isEnemyExist)
        {
            int randomIndex = UnityEngine.Random.Range(0, points.Length);

            if (randomIndex+1 == 1)
            {
                Transform randomPoint = points[1];
                GameObject enemyInstance = Instantiate(enemyPrefab, randomPoint.position, randomPoint.rotation);

                enemyInstance.transform.rotation = Quaternion.Euler(90, 0, 0);

                randomIndex = 1;
                count_enemy = 1;
            }
            else if (randomIndex + 1 >= 2)
            {
                randomIndex = 1;
                Transform randomPoint = points[0];
                GameObject enemyInstance1 =  Instantiate(enemyPrefab, randomPoint.position, randomPoint.rotation);
                enemyInstance1.transform.rotation = Quaternion.Euler(90, 0, 0);
                randomPoint = points[2];
                GameObject enemyInstance2 = Instantiate(enemyPrefab, randomPoint.position, randomPoint.rotation);
                enemyInstance2.transform.rotation = Quaternion.Euler(90, 0, 0);
                count_enemy = 2;
            }
           

            isEnemyExist
                    = true;

        }


        
        
    }
}
