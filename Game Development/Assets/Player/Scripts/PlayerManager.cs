using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerStats stats;

    public HealthBar healthBar;
    public float offset;
    public Attack playerAttack;
    void Start()
    {
        //healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z); 
        healthBar.SetMaxHealth((int)stats.playerCurrentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ResetCurrentHealth()
    {
        stats.playerCurrentHealth = stats.playerMaximumHealth;
        healthBar.SetHealth((int)stats.playerCurrentHealth);
    }

    void TakeDamage(int damage)
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
    void DoDamage(int damage, DefaultEnemyStats enemyStats)
    {

    }
    void Attack() {
        
    }
}
