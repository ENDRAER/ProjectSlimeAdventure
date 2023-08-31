using System;
using UnityEditor;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

[CustomEditor(typeof(FieldGrid))]
public class FieldGridButtons : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("GetAllChildrens"))
        {
            GetAllChildrens();
        }

        if (GUILayout.Button("SortToGrid"))
        {
            SortToGrid();
        }

        if (GUILayout.Button("UpdateAll"))
        {
            GetAllChildrens();
            SortToGrid();
        }
    }

    public void GetAllChildrens()
    {
        FieldGrid grid = (FieldGrid)target;
        grid.AllCellsOnTheField.Clear();
        grid.MovingGrid = new GameObject[100, 100];
        foreach (Transform go in grid.transform)
        {
            grid.AllCellsOnTheField.Add(go.gameObject);
            grid.MovingGrid[(int)go.transform.position.x + 50, (int)go.transform.position.z + 50] = go.gameObject;
        }
        PrefabUtility.RecordPrefabInstancePropertyModifications(grid);
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
    }

    public void SortToGrid()
    {
        FieldGrid grid = (FieldGrid)target;
        grid.transform.position = new Vector3(0, grid.transform.position.y, 0);
        foreach (GameObject go in grid.AllCellsOnTheField)
        {
            go.transform.localPosition = new((float)Math.Round(go.transform.position.x, 0), 0, (float)Math.Round(go.transform.position.z, 0));
            EditorUtility.SetDirty(go.transform);
        }
        EditorSceneManager.SaveScene(SceneManager.GetActiveScene());
    }
}
