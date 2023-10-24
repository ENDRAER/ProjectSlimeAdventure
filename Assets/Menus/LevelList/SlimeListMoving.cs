using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SlimeListMoving : MonoBehaviour
{
    [SerializeField] private Animator SlineAnim;
    [SerializeField] private GameObject LandingParticles;
    [SerializeField] private GameObject CakeImage;
    [SerializeField] private GameObject CoinImage;


    public IEnumerator SlimeTranslate(Vector3 Position)
    {
        SlineAnim.SetTrigger("ChangePos");
        yield return new WaitForSeconds(0.16f);
        SlineAnim.transform.position = Position;
        
        yield return new WaitForSeconds(0.038f);
        Instantiate(LandingParticles, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }
}
