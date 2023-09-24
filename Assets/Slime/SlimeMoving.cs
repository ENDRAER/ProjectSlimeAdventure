using System;
using System.Collections;
using UnityEngine;

public class SlimeMoving : MonoBehaviour
{
    [SerializeField] private FieldGrid fieldGrid;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject m_AnimationGO;
    [SerializeField] public GameObject m_ScalerGO;
    [NonSerialized] private Vector2 StartTouchPos;

    void Update()
    {
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("SlimeDefaultPose"))
        {
            if (Input.touchCount != 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    StartTouchPos = Input.touches[0].position;
                }
                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    float Angle = Mathf.Atan2(Input.touches[0].position.x - StartTouchPos.x, Input.touches[0].position.y - StartTouchPos.y) * Mathf.Rad2Deg;
                    m_Animator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
                    m_Animator.SetFloat("MoveY", Input.GetAxis("Vertical"));
                }
            }

            if ((Input.GetAxis("Horizontal") == -1 || Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Vertical") == -1 || Input.GetAxis("Vertical") == 1) 
                && fieldGrid.MovingGrid[(int)transform.position.x + 50 + (int)Input.GetAxis("Horizontal"), (int)transform.position.z + 50 + (int)Input.GetAxis("Vertical")] != null)
            {
                m_Animator.SetFloat("MoveX", Input.GetAxis("Horizontal"));
                m_Animator.SetFloat("MoveY", Input.GetAxis("Vertical"));
            }
        }
    }

    public IEnumerator RotateToDirection(float targetAngle)
    {
        while (m_ScalerGO.transform.eulerAngles.y != targetAngle)
        {
            m_ScalerGO.transform.rotation = Quaternion.RotateTowards(m_ScalerGO.transform.rotation, Quaternion.Euler(new(0, targetAngle, 0)), 1000 * Time.deltaTime);
            yield return null;
        }
    }

    public void OnTouchCell()
    {
        m_Animator.SetFloat("MoveX", 0);
        m_Animator.SetFloat("MoveY", 0);
        transform.position = new Vector3((float)Math.Round(m_AnimationGO.transform.position.x, 0), 0, (float)Math.Round(m_AnimationGO.transform.position.z, 0));
        fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].GetComponent<CellParameters>().LandingBehaviour(gameObject);
    }
}