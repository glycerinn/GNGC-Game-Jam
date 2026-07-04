using UnityEngine;

public class FriendlyEnemy : EnemyBase, IDamageable
{
    public EnemySO enemyData;
    public float health { get; set; }
    private float timer;

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Debug.Log(enemyData);
        health = enemyData.maxHealth;
        timer = enemyData.lifeTime;

        if (enemyData.sprite != null)
            spriteRenderer.sprite = enemyData.sprite;
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            FreeSpawnSpot();
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            IDamageable playerDamageable = player.GetComponent<IDamageable>();
            if (playerDamageable != null)
            {
                playerDamageable.takeDamage(enemyData.playerDamage);
            }
        }

        health -= damage;

        if (health <= 0)
        {
            FreeSpawnSpot();
            Destroy(gameObject);
        }
    }
}