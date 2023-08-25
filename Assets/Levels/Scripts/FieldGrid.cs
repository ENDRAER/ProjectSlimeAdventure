using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class FieldGrid : MonoBehaviour
{
    [SerializeField] public List<GameObject> AllCellsOnTheField = new List<GameObject>();
    [NonSerialized] public CellParameters[,] MovingGrid = new CellParameters[100,100];

    private void Awake()
    {
        foreach (GameObject go in AllCellsOnTheField)
        {
            MovingGrid[(int)go.transform.position.x + 50, (int)go.transform.position.z + 50] = go.GetComponent<CellParameters>();
        }
    }
}