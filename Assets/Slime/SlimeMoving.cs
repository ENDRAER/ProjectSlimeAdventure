using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMoving : MonoBehaviour
{
    [SerializeField] private FieldGrid fieldGrid;
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject m_MeshGO;
    [SerializeField] private GameObject LandingParticles;

    void Update()
    {
        if (m_Animator.GetCurrentAnimatorStateInfo(0).IsName("SlimeDefaultPose"))
        {
            if (Input.GetKeyDown(KeyCode.W) && fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 51] != null)
                m_Animator.SetTrigger("MoveUp"); 
            else if (Input.GetKeyDown(KeyCode.A) && fieldGrid.MovingGrid[(int)transform.position.x + 49, (int)transform.position.z + 50] != null)
                m_Animator.SetTrigger("MoveLeft");
            else if (Input.GetKeyDown(KeyCode.S) && fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 49] != null)
                m_Animator.SetTrigger("MoveDown");
            else if (Input.GetKeyDown(KeyCode.D) && fieldGrid.MovingGrid[(int)transform.position.x + 51, (int)transform.position.z + 50] != null)
                m_Animator.SetTrigger("MoveRight");
        }
    }

    public IEnumerator RotateToDirection(float targetAngle)
    {
        while (m_MeshGO.transform.eulerAngles.y != targetAngle)
        {
            m_MeshGO.transform.rotation = Quaternion.RotateTowards(m_MeshGO.transform.rotation, Quaternion.Euler(new(0, targetAngle, 0)), 1000 * Time.deltaTime);
            yield return null;
        }
    }

    public void OnTouchCell()
    {
        transform.position = m_MeshGO.transform.position;
        Instantiate(LandingParticles, transform.position, Quaternion.identity);
        fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].GetComponent<CellParameters>().LandingBehaviour(gameObject);
    }
}