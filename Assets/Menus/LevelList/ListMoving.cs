using System;
using UnityEngine;

public class ListMoving : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RB;
    [NonSerialized] private Vector2 previousTouchPos;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void LateUpdate()
    {
        if (Input.touchCount != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                m_RB.velocity = new Vector3();
                previousTouchPos = Input.touches[0].position;
            }

            if (Input.touches[0].phase != TouchPhase.Ended)
            {
                transform.localPosition += new Vector3((previousTouchPos.x - Input.touches[0].position.x) * Time.deltaTime, 0 , 0);
                previousTouchPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                m_RB.velocity = new((previousTouchPos.x - Input.touches[0].position.x) * 0.8f, 0, 0);
                previousTouchPos = Input.touches[0].position;
            }
        }
    }
}
