using System.Collections;
using UnityEngine;

public class KillUrSelf : MonoBehaviour
{
    [SerializeField] private float SecToDie;

    void Start()
    {
        StartCoroutine(UShouldKillUeSelfNOW());
    }

    private IEnumerator UShouldKillUeSelfNOW()
    {
        yield return new WaitForSeconds(SecToDie);
        Destroy(gameObject);
    }
}
