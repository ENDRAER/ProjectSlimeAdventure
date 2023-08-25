using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FieldGrid))]
public class FieldGridButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("UpdateChildsGOArray"))
        {
            UpdateChildsGOArray();
        }

        if (GUILayout.Button("SortToGrid"))
        {
            SortToGrid();
        }

        if (GUILayout.Button("UpdateCellText"))
        {
            UpdateCellText();
        }

        if (GUILayout.Button("UpdateAll"))
        {
            UpdateChildsGOArray(); 
            SortToGrid(); 
            UpdateCellText();
        }
    }

    public void UpdateChildsGOArray()
    {
        FieldGrid grid = (FieldGrid)target;
        grid.AllCellsOnTheField.Clear();
        foreach (Transform child in grid.transform)
        {
            grid.AllCellsOnTheField.Add(child.gameObject);
        }
    }

    public void SortToGrid()
    {
        FieldGrid grid = (FieldGrid)target;
        foreach (GameObject go in grid.AllCellsOnTheField)
        {
            go.transform.position = new((float)Math.Round(go.transform.position.x, 0), 0, (float)Math.Round(go.transform.position.z, 0));
        }
    }

    public void UpdateCellText()
    {
        FieldGrid grid = (FieldGrid)target;
        foreach (GameObject go in grid.AllCellsOnTheField)
        {
            go.GetComponent<CellParameters>().Restart();
        }
    }
}
