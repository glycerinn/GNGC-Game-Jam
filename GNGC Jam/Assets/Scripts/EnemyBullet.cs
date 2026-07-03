using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public Rigidbody2D rb;

    public float speed = 10f;
    public float damage = 1f;
    public float lifeTime = 5f;

    private Vector2 direction;

    public void Initialize(Vector2 dir)
    {
        direction = dir.normalized;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * speed;

        Destroy(gameObject, lifeTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Shield"))
        {
            Destroy(gameObject);
            return;
        }
        if (other.CompareTag("Player"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.takeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}