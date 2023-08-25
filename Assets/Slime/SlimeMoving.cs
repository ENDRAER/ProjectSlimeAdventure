using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoving : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject m_MeshGO;
    [SerializeField] private FieldGrid fieldGrid;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 51] != null)
        {
            m_Animator.SetTrigger("MoveUp"); 
            StartCoroutine(RotateToDirection(270));
        }
        else if (Input.GetKeyDown(KeyCode.A) && fieldGrid.MovingGrid[(int)transform.position.x + 49, (int)transform.position.z + 50] != null)
        {
            m_Animator.SetTrigger("MoveLeft");
            StartCoroutine(RotateToDirection(180));
        }
        else if (Input.GetKeyDown(KeyCode.S) && fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 49] != null)
        {
            m_Animator.SetTrigger("MoveDown");
            StartCoroutine(RotateToDirection(90));
        }
        else if (Input.GetKeyDown(KeyCode.D) && fieldGrid.MovingGrid[(int)transform.position.x + 51, (int)transform.position.z + 50] != null)
        {
            m_Animator.SetTrigger("MoveRight");
            StartCoroutine(RotateToDirection(0));
        }
    }

    private IEnumerator RotateToDirection(float targetAngle)
    {
        while (m_MeshGO.transform.eulerAngles.y != targetAngle)
        {
            m_MeshGO.transform.rotation = Quaternion.RotateTowards(m_MeshGO.transform.rotation, Quaternion.Euler(new(0, targetAngle, 0)), 1000 * Time.deltaTime);
            yield return null;
        }
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