﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats stats;

    public HealthBar healthBar;
    public Animator animator;
    [HideInInspector]public bool changeAttackType = false;

    public Weapon weapon;

    public static PlayerManager Instance{ get; set;}

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        ResetCurrentHealth();
        healthBar.SetMaxHealth((int)stats.playerCurrentHealth);
    }
    private void Update()
    {
        SetAttackTyp();
    }
    public void ResetCurrentHealth()
    {
        stats.playerCurrentHealth = stats.playerMaximumHealth;
        healthBar.SetHealth((int)stats.playerCurrentHealth);     
    }

    public void TakeDamage(int damage)
    {
        if ((stats.playerCurrentHealth - damage) < 0)
        {
            stats.playerCurrentHealth = 0;
        }
        else
        {
            stats.playerCurrentHealth -= damage;
        }

        healthBar.SetHealth((int)stats.playerCurrentHealth);
    }
    public void DoDamage(GameObject enemy)
    {
        StateController enemyController;
        enemy.TryGetComponent<StateController>(out enemyController);

        if (enemyController?.enemyStats != null)
        {
            enemyController.TakeDamage((int)stats.playerDamage);
        } 
    }

    public void SetAttackTyp()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeAttackType = !changeAttackType;
            if (changeAttackType)
            {
                stats.primaryAttackType = StateController.AttackType.Ranged;
            }
            else
            {
                stats.primaryAttackType = StateController.AttackType.Melee;
            }
        }
    }
}
