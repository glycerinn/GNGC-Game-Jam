using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("References")]
    public Transform player;

    [Header("Settings")]
    public float shieldDistance = 1.5f;
    public float rotationOffset = -90f; // Adjust depending on your sprite

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - player.position).normalized;
        transform.position = (Vector2)player.position + direction * shieldDistance;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + rotationOffset);
    }
}