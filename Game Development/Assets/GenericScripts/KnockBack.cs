using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float knockback;
    public float knockbackCount;
    public float knockbackLenght;
    public bool knockbackDir;
    public float knockbackYAxis = 1f;
    // Start is called before the first frame update
    public void ApplyKnockBack(ref Rigidbody2D rigBody)
    {

        if (knockbackDir)
        {
            rigBody.velocity = new Vector2(-knockback, knockback * knockbackYAxis);
        }
        else
        {
            rigBody.velocity = new Vector2(knockback, knockback * knockbackYAxis);
        }
        
        knockbackCount -= Time.deltaTime;
    }
}
