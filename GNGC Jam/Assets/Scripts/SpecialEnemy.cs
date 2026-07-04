using System.Collections;
using UnityEngine;

public class SpecialEnemy : EnemyBase
{
    [Header("Attack")]
    public Transform firePoint;
    public GameObject enemyBulletPrefab;

    public float shootDelay = 1f;

    private AudioManager audioManager;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    } 

    void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(shootDelay);

        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject bullet = Instantiate(enemyBulletPrefab, firePoint.position, Quaternion.identity);
        Vector2 direction = (player.position - firePoint.position).normalized;
        bullet.GetComponent<EnemyBullet>().Initialize(direction);

        audioManager.playEnemyDieSFX();
        FreeSpawnSpot();
        Destroy(gameObject);
    }
}