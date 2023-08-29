using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FieldGrid : MonoBehaviour
{
    [SerializeField] public List<GameObject> AllCellsOnTheField = new List<GameObject>();
    [NonSerialized] public GameObject[,] MovingGrid = new GameObject[100, 100];


    private void Awake()
    {
        foreach (GameObject go in AllCellsOnTheField)
        {
            MovingGrid[(int)go.transform.position.x + 50, (int)go.transform.position.z + 50] = go;
            go.GetComponent<CellCalculator>().Restart();
        }
    }

    public void GetAllChildrens()
    {
        AllCellsOnTheField.Clear();
        foreach (Transform go in transform)
        {
            AllCellsOnTheField.Add(go.gameObject);
        }
    }

    public void SortToGrid()
    {
        transform.position = new Vector3(0, transform.position.y, 0);
        foreach (GameObject go in AllCellsOnTheField)
        {
            go.transform.localPosition = new((float)Math.Round(go.transform.position.x, 0), 0, (float)Math.Round(go.transform.position.z, 0));
        }
    }

    public void UpdateCellText()
    {
        foreach (GameObject go in AllCellsOnTheField)
        {
            go.GetComponent<CellCalculator>().Restart();
        }
    }
}