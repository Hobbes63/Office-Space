using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    /*To Do List: 
        
    */
    [SerializeField] GameObject enemiesPrefab;

    int enemyCount;
    int enemyCountCap;
    int enemyMaxCapacity;
    int enemyWave;

    bool shouldEnemySpawn;

    int enemiesDefeated;
    [SerializeField] public List<Transform> Spawnpoints;
    int currSpawnPoint;

    void Start()
    {
        enemyCountCap = 15;
    }

    void Update()
    {
        spawnEnemy();
    }

    public void spawnEnemy()
    {
        if(enemyCount < enemyCountCap)
        {
            currSpawnPoint = Random.Range(0, 3);
            GameObject newEnemy = Instantiate(
                enemiesPrefab,
                Spawnpoints[currSpawnPoint].transform.position,
                Quaternion.identity
            );
            
            enemyCount++;
        }
    }


}
