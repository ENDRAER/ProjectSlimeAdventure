using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ass : MonoBehaviour
{
    public GameObject AssGameObject;

    void Update()
    {
        Vector3 a = AssGameObject.transform.position;
        transform.position = new Vector3(a.x - 0.88f, a.y + 17.82f, a.z - 12.59f);
    }
}
