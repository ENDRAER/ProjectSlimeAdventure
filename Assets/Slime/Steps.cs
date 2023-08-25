using System;
using System.Collections;
using System.Data;
using Unity.Mathematics;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] private GameObject m_MeshScalerGO;
    [SerializeField] private FieldGrid fieldGrid;
    [NonSerialized] private float CurentSteps = 1;
    [NonSerialized] private int Speed = 10;

    public IEnumerator SizeChanger()
    {
        {
            float speedScaler = (0.15f + 0.05f * CurentSteps) - m_MeshScalerGO.transform.localScale.x;
            float targetSize = Mathf.Clamp(m_MeshScalerGO.transform.localScale.x + speedScaler, 0.2f, 0.55f);
            while ((m_MeshScalerGO.transform.localScale.x > targetSize && speedScaler < 0) || (m_MeshScalerGO.transform.localScale.x < targetSize && speedScaler > 0))
            {
                yield return null;
                m_MeshScalerGO.transform.localScale += new Vector3(Speed * speedScaler * Time.deltaTime, Speed * speedScaler * Time.deltaTime, Speed * speedScaler * Time.deltaTime);
            }
            m_MeshScalerGO.transform.localScale = new(targetSize, targetSize, targetSize);
        }
    }

    public void OnTouchCell()
    {
        CurentSteps = (int)(new DataTable().Compute(CurentSteps.ToString() + fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].calculatorChanged, "")) - 1;
        fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].Clear();
        if (CurentSteps > 0)
            StartCoroutine(SizeChanger());
        else
            print("you die :(");
    }
}
