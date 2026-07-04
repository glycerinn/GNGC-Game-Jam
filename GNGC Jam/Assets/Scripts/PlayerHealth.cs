using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    public float maxHealth = 5;
    public GameOverPanel GamePanel;
    public BulletShoot bulletShoot;
    public EnemySpawner enemySpawner;
    public Shield shieldController;
    public float health { get; set; }

    public Slider healthSlider;

    void Start()
    {
        health = maxHealth;

        healthSlider.maxValue = maxHealth;
        healthSlider.value = health;
        UpdateHealthUI();
    }


    public void takeDamage(float damage)
    {
        health -= damage;
        healthSlider.value = health;
        UpdateHealthUI();

        if (health <= 0)
        {
            bulletShoot.enabled = false;
            shieldController.enabled = false;
            enemySpawner.enabled = false;
            GamePanel.ShowLose();
            Time.timeScale = 0f;
            Debug.Log("Player Died");
        }
    }

    void UpdateHealthUI()
    {
        healthSlider.value = health;
    }
}