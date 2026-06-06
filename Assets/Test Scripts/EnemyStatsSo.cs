using UnityEngine;

[CreateAssetMenu(fileName ="EnemyStats",menuName ="Stats SO/EnemyStats")]
public class EnemyStatsSo : ScriptableObject
{
    public float moveSpeed = 3f;
    public float chaseRange = 5f;

    [Header("Attack Settings")]
    public float attackDamage = 10f;
    public float attackRange = 1.5f;
    public float attackCooldown = 2f;
}
