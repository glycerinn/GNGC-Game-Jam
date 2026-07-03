using System.Collections;
using UnityEngine;

public class SpecialEnemy : MonoBehaviour
{
    [Header("Attack")]
    public Transform firePoint;
    public GameObject enemyBulletPrefab;

    public float shootDelay = 2f;

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

        Destroy(gameObject);
    }
}