using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListSlimeMoving : MonoBehaviour
{
    [SerializeField] private Animator SlineAnim;
    [SerializeField] private GameObject LandingParticles;

    public IEnumerator SlimeTranslate(Vector3 Position)
    {
        SlineAnim.SetTrigger("ChangePos");
        yield return new WaitForSeconds(0.16f);
        SlineAnim.transform.position = Position;
        yield return new WaitForSeconds(0.038f);
        Instantiate(LandingParticles, new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z), Quaternion.identity);
    }
}
