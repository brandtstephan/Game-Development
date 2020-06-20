using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    private TextMeshPro textMesh;
    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }
    public void SetUp(bool isCrit)
    {
        
    }
}
