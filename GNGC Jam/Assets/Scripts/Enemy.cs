using UnityEngine;

public class Enemy : EnemyBase, IDamageable
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
            GameObject.FindGameObjectWithTag("Player").GetComponent<IDamageable>().takeDamage(enemyData.playerDamage);

            FreeSpawnSpot();
            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        Debug.Log($"Enemy HP before: {health}");
        health -= damage;
        Debug.Log($"Enemy HP after: {health}");
        if (health <= 0)
        {
            FreeSpawnSpot();
            Destroy(gameObject);
        }
    }
}