using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private GameObject enemiesPrefab;
    [SerializeField] public List<Transform> Spawnpoints;

    public int enemyCount;
    public int enemyWave = 1;

    private int enemyCountCap = 15;

    public void SpawnWave()
    {
        int enemiesToSpawn = enemyWave * 3;

        Debug.Log($"Spawning Wave {enemyWave}");

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int spawnIndex = Random.Range(0, Spawnpoints.Count);

            Instantiate(
                enemiesPrefab,
                Spawnpoints[spawnIndex].position,
                Quaternion.identity
            );

            enemyCount++;
        }

        enemyWave++;
    }
}