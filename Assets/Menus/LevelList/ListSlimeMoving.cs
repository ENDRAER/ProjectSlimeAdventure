using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ListSlimeMoving : MonoBehaviour
{
    [SerializeField] private Animator LoadingSplashScreen;
    [SerializeField] private Animator SlineAnim;
    [SerializeField] private GameObject LandingParticles;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(StartNewScene(1));
        }
    }

    public IEnumerator StartNewScene(int scene)
    {
        LoadingSplashScreen.SetTrigger("ChangeScene");
        SlineAnim.SetTrigger("ChangePos");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(scene);
    }

    public IEnumerator SlimeTranslate(Vector3 Position)
    {
        SlineAnim.SetTrigger("ChangePos");
        yield return new WaitForSeconds(0.16f);
        SlineAnim.transform.position = Position;
        yield return new WaitForSeconds(0.038f);
        Instantiate(LandingParticles, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }
}
