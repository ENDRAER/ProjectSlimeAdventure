using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField] private Animator LoadingSplashScreen;

    public void StartCorutineSceneCHanger(int scene)
    {
        StartCoroutine(StartNewScene(scene));
    }

    public IEnumerator StartNewScene(int scene)
    {
        LoadingSplashScreen.SetTrigger("ChangeScene");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }
}
