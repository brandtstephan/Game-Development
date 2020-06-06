using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName ="DefaultEnemyStats", menuName ="EnemyStats/DefaultEnemyStats")]
public class DefaultEnemyStats : ScriptableObject
{
    public float movSpeed;
    [Range(1f, -1f)]
    public float enemyDirection;
    public float enemyHealth;
    public float enemyAttack;
    public float enemyWaitTime;
    public float lookRadius;
}
