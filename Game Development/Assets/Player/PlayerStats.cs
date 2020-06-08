using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DefaultPlayerStats", menuName = "PlayerStats/DefaultPlayerStats")]
public class PlayerStats : ScriptableObject
{
    [HideInInspector] public Vector3 playerDirection;
    public float playerCurrentHealth;
    public float playerMaximumHealth;
    public float playerDamage;
    public float lookRadius;
    public float attackDistance;
    public float chaseSpeed;
    public float attackRate;
    public StateController.AttackType attackType;
    public LayerMask playerType;
    //public Attack playerAttack;
}

