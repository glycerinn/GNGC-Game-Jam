using System.Collections;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class BulletShoot : MonoBehaviour
{
    [Header("Shooting")]
    public GameObject bulletObj;
    public Transform bulletSpawn;
    public float shootCooldown = 0.1f;

    private float currentCooldown;

    [Header("Ammo")]
    public int maxBullets = 10;
    public int currentBullets;
    public float reloadTime = 1f;

    private bool isReloading;
    public Slider ammoSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentBullets = maxBullets;

        ammoSlider.maxValue = maxBullets;
        ammoSlider.value = currentBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !isReloading && currentBullets < maxBullets)
        {
            StartCoroutine(Reload());
            return;
        }

        if (isReloading)
            return;

        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0)
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKeyDown(KeyCode.W))
                direction = Vector2.up;
            else if (Input.GetKeyDown(KeyCode.S))
                direction = Vector2.down;
            else if (Input.GetKeyDown(KeyCode.A))
                direction = Vector2.left;
            else if (Input.GetKeyDown(KeyCode.D))
                direction = Vector2.right;

            if (direction != Vector2.zero)
            {
                if (currentBullets > 0)
                {
                    SpawnBullet(direction);
                    currentBullets--;
                    ammoSlider.value = currentBullets;
                    currentCooldown = shootCooldown;

                    Debug.Log($"Ammo: {currentBullets}/{maxBullets}");
                }
                else
                {
                    Debug.Log("Out of ammo!");
                }
            }
        }
    }

    public IEnumerator Reload()
    {
        isReloading = true;

        Debug.Log("Reloading...");

        yield return new WaitForSeconds(reloadTime);

        currentBullets = maxBullets;
        ammoSlider.value = currentBullets;
        isReloading = false;

        Debug.Log("Reload complete!");
    }

    public void SpawnBullet(Vector2 direction)
    {
        GameObject bullet = Instantiate(bulletObj, bulletSpawn.position, quaternion.identity);
        bullet.GetComponent<Bullet>().bulletDirection = direction;
    }
}