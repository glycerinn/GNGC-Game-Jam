using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySO[] enemyTypes;
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 8f;
    public float spawnInterval = 2f;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    public void SpawnEnemy()
    {
        Vector2 spawnPos = player.position;

        switch (Random.Range(0, 4))
        {
            case 0: // Up
                spawnPos += Vector2.up * spawnDistance;
                break;

            case 1: // Down
                spawnPos += Vector2.down * spawnDistance;
                break;

            case 2: // Left
                spawnPos += Vector2.left * (spawnDistance + 1f);
                break;

            case 3: // Right
                spawnPos += Vector2.right * (spawnDistance + 1f);
                break;
        }

        GameObject enemy = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);

        Enemy enemyScript = enemy.GetComponent<Enemy>();
        enemyScript.enemyData = enemyTypes[Random.Range(0, enemyTypes.Length)];
    }
}