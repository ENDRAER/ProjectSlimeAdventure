using System.Collections;
using UnityEngine;

public class KillUrSeld : MonoBehaviour
{
    [SerializeField] private float SecToDIe;

    void Start()
    {
        StartCoroutine(UShouldKillUeSelfNOW());
    }

    private IEnumerator UShouldKillUeSelfNOW()
    {
        yield return new WaitForSeconds(SecToDIe);
        Destroy(gameObject);
    }
}
