using System.Collections;
using UnityEngine;

public class SlimeListMoving : MonoBehaviour
{
    [SerializeField] private Animator SlineAnim;
    [SerializeField] private GameObject LandingParticles;
    [SerializeField] private SpriteRenderer CakeImage;
    [SerializeField] private SpriteRenderer CoinImage;


    public IEnumerator SlimeTranslate(Vector3 position, int selectedLevel)
    {
        SlineAnim.SetTrigger("ChangePos");
        yield return new WaitForSeconds(0.166f);
        SlineAnim.transform.position = position;
        CakeImage.material.SetFloat("_GrayscaleAmount", PlayerPrefs.GetInt(selectedLevel + "Cake"));
        CoinImage.material.SetFloat("_GrayscaleAmount", PlayerPrefs.GetInt(selectedLevel + "Coin"));
        yield return new WaitForSeconds(0.038f);
        Instantiate(LandingParticles, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }
}
