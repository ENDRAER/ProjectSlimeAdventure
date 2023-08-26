using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using UnityEngine;

public class CellCalculator : CellParameters
{
    [SerializeField] private TextMeshPro m_Text;
    [SerializeField] public string calculator;
    [NonSerialized] public string calculatorChanged;

    public void Clear()
    {
        calculatorChanged = "";
        m_Text.text = "";
    }

    public void Restart()
    {
        calculatorChanged = calculator;
        if (calculator != "")
        {
            if (calculator.Substring(0, 1) == "+" || calculator.Substring(0, 1) == "*")
            {
                m_Text.text = calculator;
                m_Text.color = new Color(0.529f, 1.000f, 0.364f);
            }
            else if (calculator.Substring(0, 1) == "-" || calculator.Substring(0, 1) == "/")
            {
                m_Text.text = calculator;
                m_Text.color = new Color(0.811f, 0.164f, 0.207f);
            }
            else
            {
                Debug.LogError("WrongParameters in - " + gameObject.name);
                Clear();
            }
        }
    }

    public override void LandingBehaviour()
    {
        CurentSteps = (int)(new DataTable().Compute(CurentSteps.ToString() + fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].calculatorChanged, "")) - 1;
        fieldGrid.MovingGrid[(int)transform.position.x + 50, (int)transform.position.z + 50].Clear();
        if (CurentSteps > 0)
            StartCoroutine(SizeChanger());
        else
            print("you die :(");
    }
}
