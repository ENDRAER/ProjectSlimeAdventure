using System.Collections;
using UnityEngine;
using System;

public class Steps : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] private GameObject m_MeshScalerGO;
    [NonSerialized] public float CurentSteps = 1;
    [NonSerialized] private int Speed = 10; 

    public IEnumerator SizeChangerBySteps()
    {
        float speedScaler = (0.15f + 0.05f * CurentSteps) - m_MeshScalerGO.transform.localScale.x;
        float targetSize = Mathf.Clamp(m_MeshScalerGO.transform.localScale.x + speedScaler, 0.2f, 0.55f);
        while ((m_MeshScalerGO.transform.localScale.x > targetSize && speedScaler < 0) || (m_MeshScalerGO.transform.localScale.x < targetSize && speedScaler > 0))
        {
            yield return null;
            m_MeshScalerGO.transform.localScale += new Vector3(Speed * speedScaler * Time.deltaTime, Speed * speedScaler * Time.deltaTime, Speed * speedScaler * Time.deltaTime);
        }
        m_MeshScalerGO.transform.localScale = new(targetSize, targetSize, targetSize);
        if(CurentSteps == 0)
            StartCoroutine(gameController.OnSlimeDie());
    }
}
