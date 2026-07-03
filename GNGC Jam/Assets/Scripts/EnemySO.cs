using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy Data")]
public class EnemySO : ScriptableObject
{
    [Header("Stats")]
    public float maxHealth;
    public float lifeTime;
    public float playerDamage;

    [Header("Visuals")]
    public Sprite sprite;
}