using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class WeaponAimMouse : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform aimtTransform;
    private void Awake()
    {
        aimtTransform = transform.Find("Aim");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = GetMouseWorldPosition();

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y,aimDirection.x) * Mathf.Rad2Deg;
        aimtTransform.eulerAngles = new Vector3(0, 0, angle);
    }

    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        vec.z = 0f;
        return vec;
    }
}
