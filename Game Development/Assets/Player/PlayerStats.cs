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
    public float playerRangeDamage;
    public float lookRadius;
    public float attackDistance;
    public float attackRate;
    public float playerRunSpeed;
    [Range(0, 1)] public float playerCrouchSpeed;
    [Range(0, .3f)] public float playerMovementSmoothing;
    public float playerJumpForce;
    public StateController.AttackType primaryAttackType;
    public StateController.AttackType secondaryAttackType;
    public LayerMask playerType;
}

