using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamagePopUp : MonoBehaviour
{
    public TextMeshPro textMesh;
    public Transform popUp;
    public float disappearTimer = 1f;
    private Color textColor = new Color(227, 246, 124, 255);
    public float textSize = 10f;
    private const float DISAPPEAR_TIMER_MAX = .5f;
    private Vector3 moveVector;

    public void SetUp(bool isCrit)
    {
        if (isCrit)
        {
            textMesh.fontSize = textSize * 1.5f;
            textColor = new Color(227, 246, 124, 255);
        }
        else
        {
            textMesh.fontSize = textSize;
            textColor = new Color(226, 40, 22, 255);
        }

        textMesh.color = textColor;
        disappearTimer = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(1,2) * 30f;
    }

    public void Create(Vector3 position, bool isCrit)
    {
        SetUp(isCrit);
        Instantiate(popUp, position, Quaternion.identity);
    }

    private void Update()
    {
        popUp.transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 8f * Time.deltaTime;

        if (disappearTimer > DISAPPEAR_TIMER_MAX * .5f)
        {
            float increaseScaleAmount = 0.3f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        }
        else
        {
            float increaseScaleAmount = 0.3f;
            transform.localScale -= Vector3.one * increaseScaleAmount * Time.deltaTime;
        }

        disappearTimer -= Time.deltaTime;

        if (disappearTimer < 0)
        {
            float disappearSpeed = 3f;
            textColor.a = disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if(textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

}
