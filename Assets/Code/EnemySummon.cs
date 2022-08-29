using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySummon : MonoBehaviour
{
    public GameObject EnemyFast;
    public GameObject EnemyMedium;
    public GameObject EnemySlow;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int enemyChoice = Random.Range(1, 4);
        int enemyLoc = Random.Range(1, 6);
        if (enemyChoice == 1)
        {
            Instantiate(EnemyFast, new Vector3(11.5f, enemyLoc - 4.5f, 0), Quaternion.identity);
        }
        if (enemyChoice == 2)
        {
            Instantiate(EnemyMedium, new Vector3 (11.5f, enemyLoc - 4.5f, 0), Quaternion.identity);
        }
        if (enemyChoice == 3)
        {
            Instantiate(EnemySlow, new Vector3(11.5f, enemyLoc - 4.5f, 0), Quaternion.identity);
        }
    }
}
