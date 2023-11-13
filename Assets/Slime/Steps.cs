using System.Collections;
using UnityEngine;
using System;
using TMPro;

public class Steps : MonoBehaviour
{
    [SerializeField] private GameObject m_MeshScalerGO;
    [SerializeField] private GameObject LandingParticles;
    [SerializeField] public GameController gameController;
    [SerializeField] public InGameUI inGameUI_CS;
    [SerializeField] private TextMeshProUGUI StepCounterText;
    [NonSerialized] public int CurentSteps = 1;
    [NonSerialized] private float MinScale = 0.1f;
    [NonSerialized] private float MaxScale = 0.4f;
    [NonSerialized] private float ScaleMod = 0.05f;
    [NonSerialized] private float MinParticleScale = 0.1f;
    [NonSerialized] private float MaxParticleScale = 0.2f;
    [NonSerialized] private float ScaleParticleMod = 0.02f; 
    [NonSerialized] private int Speed = 10;

    public IEnumerator SizeChangerBySteps()
    {
        GameObject Particles = Instantiate(LandingParticles, transform.position, Quaternion.identity);
        Particles.transform.localScale = (Vector3.one * MinParticleScale) + (Vector3.one * Mathf.Min(CurentSteps * ScaleParticleMod, MaxParticleScale));

        float speedScaler = (MinScale + ScaleMod * CurentSteps) - m_MeshScalerGO.transform.localScale.x;
        float targetSize = Mathf.Min(m_MeshScalerGO.transform.localScale.x + speedScaler, MaxScale);

        while ((m_MeshScalerGO.transform.localScale.x > targetSize && speedScaler < 0) || (m_MeshScalerGO.transform.localScale.x < targetSize && speedScaler > 0))
        {
            yield return null;
            m_MeshScalerGO.transform.localScale += Vector3.one * Speed * speedScaler * Time.deltaTime;
        }
        m_MeshScalerGO.transform.localScale = Vector3.one * targetSize;
        if (CurentSteps == 0)
        {
            StartCoroutine(gameController.OnSlimeDie());
            CurentSteps = 1;
            StepCounterText.text = CurentSteps.ToString();
        }
        else
            StepCounterText.text = CurentSteps.ToString();
    }

    public void ChangeStepsCount(int newValue)
    {
        inGameUI_CS.ChangeStepCounter(CurentSteps, newValue);
        CurentSteps = newValue;
        StartCoroutine(SizeChangerBySteps());
    }
}
