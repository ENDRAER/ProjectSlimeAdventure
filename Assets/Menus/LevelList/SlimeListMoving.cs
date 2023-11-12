using System.Collections;
using UnityEngine;

public class SlimeListMoving : MonoBehaviour
{
    [SerializeField] private Animator SlineAnim;
    [SerializeField] private GameObject LandingParticles;
    [SerializeField] private SpriteRenderer CakeSprite;
    [SerializeField] private Sprite FullCakeSprite;
    [SerializeField] private Sprite EatedCakeSprite;


    public IEnumerator SlimeTranslate(Vector3 position, int selectedLevel)
    {
        SlineAnim.SetTrigger("ChangePos");
        yield return new WaitForSeconds(0.166f);
        SlineAnim.transform.position = position;
        CakeSprite.sprite = PlayerPrefs.GetInt(selectedLevel + "Cake") == 1? EatedCakeSprite : FullCakeSprite;
        yield return new WaitForSeconds(0.038f);
        Instantiate(LandingParticles, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }
}
