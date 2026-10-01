using UnityEngine;
using System.Collections.Generic;

public class EnemyManager
{
    int enemyCount;
    int enemyCountCap;
    int enemyMaxCapacity;
    int enemyWave;


    int enemiesDefeated;
    [SerializeField] public List<Transform> Spawnpoints;

    public void spawnEnemy()
    {
        if(enemyCount < enemyCountCap)
        {
            
            
            
            enemyCount++;
        }
    }


}
