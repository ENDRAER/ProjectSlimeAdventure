using System.Collections;
using UnityEngine;
using System;

public class Steps : MonoBehaviour
{
    [SerializeField] public GameController gameController;
    [SerializeField] private GameObject m_MeshScalerGO;
    [NonSerialized] private float MinScale = 0.1f;
    [NonSerialized] private float MaxScale = 0.4f;
    [NonSerialized] private float ScaleMod = 0.05f;
    [NonSerialized] public float CurentSteps = 1;
    [NonSerialized] private int Speed = 10; 

    public IEnumerator SizeChangerBySteps()
    {
        float speedScaler = ((MinScale - ScaleMod) + ScaleMod * CurentSteps) - m_MeshScalerGO.transform.localScale.x;
        float targetSize = Mathf.Clamp(m_MeshScalerGO.transform.localScale.x + speedScaler, MinScale, MaxScale);
        while ((m_MeshScalerGO.transform.localScale.x > targetSize && speedScaler < 0) || (m_MeshScalerGO.transform.localScale.x < targetSize && speedScaler > 0))
        {
            yield return null;
            m_MeshScalerGO.transform.localScale += new Vector3(Speed * speedScaler * Time.deltaTime, Speed * speedScaler * Time.deltaTime, Speed * speedScaler * Time.deltaTime);
        }
        m_MeshScalerGO.transform.localScale = new(targetSize, targetSize, targetSize);
        if (CurentSteps == 0)
        {
            StartCoroutine(gameController.OnSlimeDie());
            CurentSteps = 1;
        }
    }
}
