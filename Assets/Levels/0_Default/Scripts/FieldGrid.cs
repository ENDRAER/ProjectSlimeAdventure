using System.Collections.Generic;
using UnityEngine;

public class FieldGrid : MonoBehaviour
{
    [SerializeField] public List<GameObject> AllCellsOnTheField = new List<GameObject>();
    [SerializeField] public GameObject[,] MovingGrid = new GameObject[100, 100];

    public void Awake()
    {
        foreach (GameObject go in AllCellsOnTheField)
        {
            MovingGrid[(int)go.transform.position.x + 50, (int)go.transform.position.z + 50] = go;
            go.GetComponent<CellParameters>().Restart();
        }
    }
}