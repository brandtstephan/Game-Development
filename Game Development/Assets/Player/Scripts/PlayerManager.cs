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
    public Animator animator;
    [HideInInspector]public bool changeAttackType = false;
    public ParticleSystem dust;
    public Rigidbody2D playerRigidBody;
    public Weapon weapon;
    public Transform attackPoint;
    public static PlayerManager Instance{ get; set;}

    public bool isAttacking = false;
    private void Awake()
    {
        Instance = this;
        stats.playerInitialSpeed = stats.playerRunSpeed;
    }
    private void Start()
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

    public void SetAttackTyp()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            changeAttackType = !changeAttackType;
            if (changeAttackType)
            {
                stats.primaryAttackType = AttackType.Ranged;
            }
            else
            {
                stats.primaryAttackType = AttackType.Melee;
            }
        }
    }

    public enum AttackType
    {
        Ranged,
        Melee,
        MagicRanged,
        MagicMelee
    }

    public void CreateDust()
    {
        dust.Play();
    }

    private void OnDrawGizmos()
    {
        /*Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(m_GroundCheck.position, k_GroundedRadius);

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(m_CeilingCheck.position, k_CeilingRadius);
		*/
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, stats.attackDistance);
        
    }
}
