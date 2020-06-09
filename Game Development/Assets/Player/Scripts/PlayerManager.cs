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

    public static PlayerManager Instance{ get; set;}

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        //healthBar.transform.position = new Vector3(transform.position.x, transform.position.y + offset, transform.position.z); 
        healthBar.SetMaxHealth((int)stats.playerCurrentHealth);
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
}
