using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass : MonoBehaviour
{
    public Transform target; 
    public float smoothSpeed = 0.125f;

    public Vector3 offset = new Vector3(0, 5, -10);

    void LateUpdate()
    {
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, offset.y, target.position.z + offset.z);
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
