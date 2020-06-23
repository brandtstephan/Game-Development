﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    public float proyectileTimeToLive = 3f;

    public void Shoot()
    {
        SetBulletValues();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void Slash()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(PlayerManager.Instance.attackPoint.transform.position, PlayerManager.Instance.stats.attackDistance, LayerMask.GetMask("Enemy"));

        foreach (Collider2D enemy in hitEnemies)
        {
            Vector3 enemyPosition = enemy.GetComponent<Transform>().position;

            Vector3 enemyTranslatedPosition = new Vector3(enemyPosition.x, enemyPosition.y + 0.5f, 0f);

            if (enemy.transform.position.x < transform.position.x)
            {
                enemy.GetComponent<KnockBack>().knockbackDir = true;
                PlayerManager.Instance.hitPopupPrefab.Create(enemyTranslatedPosition, false, -1f);
            }
            else
            {
                enemy.GetComponent<KnockBack>().knockbackDir = false;
                PlayerManager.Instance.hitPopupPrefab.Create(enemyTranslatedPosition, false, 1f);
            }

            enemy.GetComponent<StateController>().enemyManager.TakeDamage((int)PlayerManager.Instance.stats.playerDamage);
            
        }
    }

    public void SetBulletValues()
    {
        Bullet prefab = bulletPrefab.GetComponent<Bullet>();

        prefab?.setBulletDamage((int)PlayerManager.Instance.stats.playerRangeDamage);
        prefab?.setBulletSpeed(bulletSpeed);
        prefab?.setTimeToLive(proyectileTimeToLive);
    }
}
