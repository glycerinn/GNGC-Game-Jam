using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D myrigidbody;
    public float gracetime;
    public float damage;
    public float speed;
    public Vector2 bulletDirection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        myrigidbody.linearVelocity = bulletDirection.normalized * speed;
    }

    // Update is called once per frame
    void Update()
    {
        gracetime -= Time.deltaTime;
        
        if (gracetime < 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit: " + other.name);
        IDamageable damageable = other.GetComponent<IDamageable>();
        if (damageable == null || other.CompareTag("Player")) return;
        Destroy(gameObject);
        damageable.takeDamage(damage);
    }
}