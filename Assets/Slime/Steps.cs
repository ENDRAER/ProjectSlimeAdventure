using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Steps : MonoBehaviour
{
    [SerializeField] private int CurentSteps = 1;
    [SerializeField] private GameObject m_MeshScalerGO;

    public IEnumerator SizeChanger()
    {
        print(2);
        float startSize = m_MeshScalerGO.transform.localScale.x;
        float speed = startSize - (0.2f + 0.05f * CurentSteps);
        while ((m_MeshScalerGO.transform.localScale.x <= startSize + speed && speed <= 0) || (m_MeshScalerGO.transform.localScale.x >= startSize + speed && speed >= 0))
        {
            m_MeshScalerGO.transform.localScale = new(m_MeshScalerGO.transform.localScale.x + (speed * Time.deltaTime), m_MeshScalerGO.transform.localScale.x + (speed * Time.deltaTime), m_MeshScalerGO.transform.localScale.x + (speed * Time.deltaTime));
            yield return null;
            print(3);
        }
    }
}
