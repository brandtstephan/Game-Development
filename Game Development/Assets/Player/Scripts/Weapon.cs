using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoints;
    public GameObject bulletPrefab;
    public PlayerStats stats;
    public float bulletSpeed = 5f;
    public float proyectileTimeToLive = 3f;
    public void Shoot()
    {
        SetBulletValues();
        Instantiate(bulletPrefab, firePoints.position, firePoints.rotation);
    }

    public void SetBulletValues()
    {
        Bullet prefab = bulletPrefab.GetComponent<Bullet>();

        prefab?.setBulletDamage((int)stats.playerRangeDamage);
        prefab?.setBulletSpeed(bulletSpeed);
        prefab?.setTimeToLive(proyectileTimeToLive);
    }
}
