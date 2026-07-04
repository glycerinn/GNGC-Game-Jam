using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySO[] enemyTypes;
    private GameObject[] occupiedSpots = new GameObject[4];
    public GameObject[] enemyPrefabs;
    public Transform player;
    public float spawnDistance = 8f;
    public float spawnInterval = 2f;
    public float minimumSpawnInterval = 0.4f;
    public float intervalDecrease = 0.05f;
    public float difficultyIncreaseTime = 10f;
    public int enemiesPerWave = 2;

    private float spawnTimer;
    private float difficultyTimer;
    

    void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnInterval)
        {
            int enemiesToSpawn = Random.Range(2, 5); // 2, 3, or 4

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                SpawnEnemy();
            }

            spawnTimer = 0f;
        }

        difficultyTimer += Time.deltaTime;

        if (difficultyTimer >= difficultyIncreaseTime)
        {
            difficultyTimer = 0f;
            spawnInterval = Mathf.Max(minimumSpawnInterval, spawnInterval - intervalDecrease);
        }
    }

    public void SpawnEnemy()
    {
        List<int> freeSpots = new List<int>();

        for (int i = 0; i < 4; i++)
        {
            if (occupiedSpots[i] == null)
                freeSpots.Add(i);
        }

        if (freeSpots.Count == 0)
            return;

        int side = freeSpots[Random.Range(0, freeSpots.Count)];

        Vector2 spawnPos = player.position;

        switch (side)
        {
            case 0:
                spawnPos += Vector2.up * spawnDistance;
                break;

            case 1:
                spawnPos += Vector2.down * spawnDistance;
                break;

            case 2:
                spawnPos += Vector2.left * (spawnDistance + 1f);
                break;

            case 3:
                spawnPos += Vector2.right * (spawnDistance + 1f);
                break;
        }

        GameObject prefab;

        if (FindObjectsByType<SpecialEnemy>(FindObjectsSortMode.None).Length > 0)
        {
            do
            {
                prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            }
            while (prefab.GetComponent<SpecialEnemy>() != null);
        }
        else
        {
            prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        }

        GameObject enemy = Instantiate(prefab, spawnPos, Quaternion.identity);

        occupiedSpots[side] = enemy;

        EnemyBase enemyBase = enemy.GetComponent<EnemyBase>();
        if (enemyBase != null)
        {
            enemyBase.spawner = this;
            enemyBase.spawnIndex = side;
        }

        Enemy enemyScript = enemy.GetComponent<Enemy>();

        if (enemyScript != null)
        {
            enemyScript.enemyData = enemyTypes[Random.Range(0, enemyTypes.Length)];
        }
    }

    public void FreeSpawnSpot(int index)
    {
        occupiedSpots[index] = null;
    }
}