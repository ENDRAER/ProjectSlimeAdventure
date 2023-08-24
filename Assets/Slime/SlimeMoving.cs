using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoving : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
            m_Animator.SetTrigger("MoveUp");
        else if (Input.GetKeyDown(KeyCode.A))
            m_Animator.SetTrigger("MoveLeft");
        else if (Input.GetKeyDown(KeyCode.S))
            m_Animator.SetTrigger("MoveDown");
        else if (Input.GetKeyDown(KeyCode.D))
            m_Animator.SetTrigger("MoveRight");
    }

    public void TransleteSlimeX(float add)
    {
        transform.Translate(add, 0, 0);
    }
    public void TransleteSlimeZ(float add)
    {
        transform.Translate(0, 0, add);
    }
}