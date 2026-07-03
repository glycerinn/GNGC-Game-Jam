using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
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
            GameObject.FindGameObjectWithTag("Player")
                .GetComponent<IDamageable>()
                .takeDamage(enemyData.playerDamage);

            Destroy(gameObject);
        }
    }

    public void takeDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
            Destroy(gameObject);
    }
}