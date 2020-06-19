using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoint;
    public Transform meelePoint;
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
        ContactFilter2D filter = new ContactFilter2D();
        filter.SetLayerMask(LayerMask.GetMask("Enemy"));
        List<Collider2D> listOfCollisions = new List<Collider2D>();

        if (Physics2D.OverlapCollider(meelePoint.transform.GetComponent<Collider2D>(),filter,listOfCollisions) > 0)
        {
            listOfCollisions[0].GetComponent<KnockBack>().knockbackCount = listOfCollisions[0].GetComponent<KnockBack>().knockbackLenght;
            if (listOfCollisions[0].transform.position.x < transform.position.x)
            {
                listOfCollisions[0].GetComponent<KnockBack>().knockbackDir = true;
            }
            else
            {
                listOfCollisions[0].GetComponent<KnockBack>().knockbackDir = false;
            }
             listOfCollisions[0].GetComponent<StateController>().enemyManager.TakeDamage((int)PlayerManager.Instance.stats.playerDamage);

        }
    }

    public void SetBulletValues()
    {
        Bullet prefab = bulletPrefab.GetComponent<Bullet>();

        prefab?.setBulletDamage((int)PlayerManager.Instance.stats.playerRangeDamage);
        prefab?.setBulletSpeed(bulletSpeed);
        prefab?.setTimeToLive(proyectileTimeToLive);
    }

    private void OnDrawGizmosSelected()
    {

        if (meelePoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(meelePoint.position, PlayerManager.Instance.stats.attackDistance);
    }
}
