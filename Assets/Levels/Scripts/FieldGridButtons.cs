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
        FieldGrid grid = (FieldGrid)target;

        if (GUILayout.Button("GetAllChildrens"))
        {
            grid.GetAllChildrens();
        }

        if (GUILayout.Button("SortToGrid"))
        {
            grid.SortToGrid();
        }

        if (GUILayout.Button("UpdateCellText"))
        {
            grid.UpdateCellText();
        }

        if (GUILayout.Button("UpdateAll"))
        {
            grid.GetAllChildrens();
            grid.SortToGrid();
            grid.UpdateCellText();
        }
    }
}
