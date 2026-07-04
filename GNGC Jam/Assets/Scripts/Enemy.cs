using UnityEngine;

public class Enemy : EnemyBase, IDamageable
{
    public EnemySO enemyData;
    public float health { get; set; }
    private float timer;

    private SpriteRenderer spriteRenderer;

    private AudioManager audioManager;
    private Animator animator;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        health = enemyData.maxHealth;
        timer = enemyData.lifeTime;

        if (enemyData.sprite != null)
            spriteRenderer.sprite = enemyData.sprite;

        if (enemyData.animationOverride != null)
            animator.runtimeAnimatorController = enemyData.animationOverride;
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
            audioManager.playEnemyDieSFX();
            FreeSpawnSpot();
            Destroy(gameObject);
        }
    }
}