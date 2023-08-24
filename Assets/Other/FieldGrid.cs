using System;
using Unity.Mathematics;
using UnityEngine;

public class FieldGrid : MonoBehaviour
{
    [SerializeField] private GameObject[] AllCellsOnTheField;
    [NonSerialized] public CellParameters[,] MovingGrid;

    private void Awake()
    {
        foreach (GameObject go in AllCellsOnTheField)
        {
            print(go.name);
            print(go.GetComponent<CellParameters>());
            MovingGrid[(int)go.transform.position.x, (int)go.transform.position.z] = go.GetComponent<CellParameters>();
        }
    }
}
