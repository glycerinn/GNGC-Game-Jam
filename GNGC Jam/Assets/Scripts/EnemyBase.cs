using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [HideInInspector] public EnemySpawner spawner;
    [HideInInspector] public int spawnIndex;

    protected void FreeSpawnSpot()
    {
        if (spawner != null)
            spawner.FreeSpawnSpot(spawnIndex);
    }
}