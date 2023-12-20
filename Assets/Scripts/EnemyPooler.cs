using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPooler : MonoBehaviour
{
    public static EnemyPooler SharedInstance;
    private List<GameObject> pooledEnemies;
    public GameObject enemyToPool;
    public int amountToPool;

    void Awake()
    {
        SharedInstance = this; //creates an instance other scripts can refer to
    }

    void Start()
    {
        pooledEnemies = new List<GameObject>(); //creates a list that holds the enemies
        GameObject tmp;
        for(int i = 0; i < amountToPool; i++) //counter for how many enemies have been made
        {
            //Creates enemy, makes them inactive and adds into the list
            tmp = Instantiate(enemyToPool);
            tmp.SetActive(false);
            pooledEnemies.Add(tmp);
        }
    }

    public GameObject GetPooledEnemy()
    {
        for(int i = 0; i < amountToPool; i++)
        {
            //Checks for inactive objects
            if(!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
