using System;
using UnityEngine;

public class FieldGrid : MonoBehaviour
{
    [SerializeField] private GameObject[,] ObjectsInField;
    [NonSerialized] public CellParameters[,] MovingGrid;

    private void Awake()
    {
        foreach (GameObject go in ObjectsInField)
            MovingGrid[(int)go.transform.position.x, (int)go.transform.position.z] = go.GetComponent<CellParameters>();
    }
}
