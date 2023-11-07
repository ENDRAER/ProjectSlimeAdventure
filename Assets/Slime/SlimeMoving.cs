using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class SlimeMoving : MonoBehaviour
{
    [SerializeField] private FieldGrid fieldGrid;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject m_AnimationGO;
    [SerializeField] public GameObject m_ScalerGO;
    [NonSerialized] private Vector2 StartTouchPos;
    [NonSerialized] private bool SlimeMoveKD;

    void Update()
    {
        #region Touch
        if (Input.touchCount != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                StartTouchPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Ended && !SlimeMoveKD)
            {
                float angle = Mathf.Atan2(Input.touches[0].position.x - StartTouchPos.x, Input.touches[0].position.y - StartTouchPos.y) * Mathf.Rad2Deg;
                switch (angle < 0 ? 360 + angle : angle) 
                {
                    case >= 0 and <= 60:
                        m_Animator.SetFloat("MoveY", 1);
                        break;
                    case > 60 and <= 150:
                        m_Animator.SetFloat("MoveX", 1);
                        break;
                    case > 150 and <= 240:
                        m_Animator.SetFloat("MoveY", -1);
                        break;
                    case > 240 and <= 330:
                        m_Animator.SetFloat("MoveX", -1);
                        break;
                    case > 330 and <= 360:
                        m_Animator.SetFloat("MoveY", 1);
                        break;
                }
                StartCoroutine(ScrollKD_IE());
            }
        }
        #endregion

        if (((Math.Abs(Input.GetAxisRaw("Horizontal")) == 1 || Math.Abs(Input.GetAxisRaw("Vertical")) == 1)
            && fieldGrid.MovingGrid[(int)transform.position.x + 50 + (int)Input.GetAxisRaw("Horizontal"), (int)transform.position.z + 50 + (int)Input.GetAxisRaw("Vertical")] != null) && !SlimeMoveKD)
        {
            StartCoroutine(ScrollKD_IE());
            m_Animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            m_Animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
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
        transform.position = new Vector3((float)Math.Round(m_AnimationGO.transform.position.x, 0), 0, (float)Math.Round(m_AnimationGO.transform.position.z, 0));
        fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].GetComponent<CellParameters>().LandingBehaviour(gameObject);
    }

    private IEnumerator ScrollKD_IE()
    {
        SlimeMoveKD = true;
        yield return null;
        m_Animator.SetFloat("MoveX", 0);
        m_Animator.SetFloat("MoveY", 0);
        yield return new WaitForSeconds(0.3f);
        SlimeMoveKD = false;
    }
}