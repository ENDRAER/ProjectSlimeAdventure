using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private FieldGrid fieldGrid;
    [SerializeField] private GameObject SlimeGO;
    [SerializeField] private Animator SlimeAnimator;

    private void Awake()
    {
        
    }

    public IEnumerator OnSlimeDie()
    {
        SlimeAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(0.07f);
        SlimeGO.transform.position = new(fieldGrid.AllCellsOnTheField[0].transform.position.x, SlimeGO.transform.position.y, fieldGrid.AllCellsOnTheField[0].transform.position.z);
    }
}
