using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform firePoints;
    public GameObject bulletPrefab; 

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoints.position, firePoints.rotation);
    }
}
