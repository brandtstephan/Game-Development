﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[CreateAssetMenu(fileName ="DefaultEnemyStats", menuName ="EnemyStats/DefaultEnemyStats")]
public class DefaultEnemyStats : ScriptableObject
{
    public float movSpeed;
    [HideInInspector] public Vector3 enemyDirection;
    public float enemyMaximumHealth;
    public float enemyDamage;
    public float enemyWaitTime;
    public float lookRadius;
    public float attackDistance;
    public float chaseSpeed;
    public float attackRate;
    public EnemyManager.AttackType attackType;
    public LayerMask creatureType;
    public float distanceJumpAction;
    public float jumpForce;
}
