using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    // Start is called before the first frame update
    private float length;
    private float startPos;
    public GameObject cam;
    public Vector2 parallaxEffect;
    private float textureUnitSizeX;

    private Vector3 lastCameraPosition;

    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        lastCameraPosition = cam.transform.position;
        textureUnitSizeX = GetComponent<SpriteRenderer>().sprite.texture.width / GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
    }

    private void LateUpdate()
    {
        Vector3 deltaMovement = cam.transform.position - lastCameraPosition;
        transform.position += new Vector3(deltaMovement.x * parallaxEffect.x, deltaMovement.y * parallaxEffect.y, transform.position.z);

        lastCameraPosition = cam.transform.position;

        if (Mathf.Abs(cam.transform.position.x - transform.position.x) >= (textureUnitSizeX*3))
        {
            float offsetPositionX = (cam.transform.position.x - transform.position.x) % textureUnitSizeX;
            
            transform.position = new Vector3(cam.transform.position.x + offsetPositionX, transform.position.y);
        }

    }
}
