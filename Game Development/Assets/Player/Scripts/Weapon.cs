using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public Transform meelePoint;
    public GameObject bulletPrefab;
    public PlayerStats stats;
    public float bulletSpeed = 5f;
    public float proyectileTimeToLive = 3f;
    public void Shoot()
    {
        SetBulletValues();
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void Slash()
    {
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Enemy"));
        List<Collider2D> listOfCollisions = new List<Collider2D>();

        if (Physics2D.OverlapCollider(meelePoint.transform.GetComponent<Collider2D>(),filter,listOfCollisions) > 0)
        {
            Debug.Log(listOfCollisions[0].name);
            listOfCollisions[0].GetComponent<StateController>().enemyManager.TakeDamage((int)stats.playerDamage);
        }
    }

    public void SetBulletValues()
    {
        Bullet prefab = bulletPrefab.GetComponent<Bullet>();

        prefab?.setBulletDamage((int)stats.playerRangeDamage);
        prefab?.setBulletSpeed(bulletSpeed);
        prefab?.setTimeToLive(proyectileTimeToLive);
    }

    private void OnDrawGizmosSelected()
    {

        if (meelePoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(meelePoint.position, stats.attackDistance);
    }
}
