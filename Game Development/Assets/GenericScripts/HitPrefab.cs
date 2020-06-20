using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPopUp : MonoBehaviour
{
    [SerializeField] private Transform hitPopUp;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(hitPopUp, Vector3.zero, Quaternion.identity);
    }

}
