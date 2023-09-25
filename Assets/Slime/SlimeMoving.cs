using System;
using System.Collections;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

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
                    float angle = Mathf.Atan2(Input.touches[0].position.x - StartTouchPos.x, Input.touches[0].position.y - StartTouchPos.y) * Mathf.Rad2Deg;
                    switch (angle) 
                    {
                        case >= 0 and <= 5:
                            m_Animator.SetFloat("MoveY", 1);
                            break;
                        case > 5 and <= 95:
                            m_Animator.SetFloat("MoveX", 1);
                            break;
                        case > 95 and <= 185:
                            m_Animator.SetFloat("MoveY", -1);
                            break;
                        case > 185 and <= 275:
                            m_Animator.SetFloat("MoveX", -1);
                            break;
                        case > 275 and <= 360:
                            m_Animator.SetFloat("MoveY", 1);
                            break;
                    }
                }
            }

            if ((Math.Abs(Input.GetAxisRaw("Horizontal")) == 1 || Math.Abs(Input.GetAxisRaw("Vertical")) == 1) 
                && fieldGrid.MovingGrid[(int)transform.position.x + 50 + (int)Input.GetAxisRaw("Horizontal"), (int)transform.position.z + 50 + (int)Input.GetAxisRaw("Vertical")] != null)
            {
                m_Animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
                m_Animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
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