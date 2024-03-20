using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateAD : MonoBehaviour
{
    public GameObject splash;

    void Start()
    {
        StartCoroutine(StartSim());
    }

    IEnumerator StartSim()
    {
        Time.timeScale = 0f;
        splash.SetActive(true);
        yield return new WaitForSecondsRealtime(1);
        splash.SetActive(false);
        Time.timeScale = 1f;
    }
}
