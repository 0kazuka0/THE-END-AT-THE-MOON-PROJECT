using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraforlevel1 : MonoBehaviour
{
    public Transform target;
    public float smoothing;

    Vector3 offset;

    float lowY;

    private void Start()
    {
        offset = transform.position - target.position;
        lowY = transform.position.y;
    }
    private void FixedUpdate()
    {
        Vector3 targetcampos = target.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetcampos, smoothing * Time.deltaTime);
        if(transform.position.y<lowY)
        {
            transform.position = new Vector3(transform.position.x, lowY, transform.position.z);
        }
    }
}
