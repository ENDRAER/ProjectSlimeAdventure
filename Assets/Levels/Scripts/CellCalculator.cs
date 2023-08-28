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

    public void ClearText()
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
                ClearText();
            }
        }
    }

    public override void LandingBehaviour(GameObject SlimeGO)
    {
        Steps steps = SlimeGO.GetComponent<Steps>();
        steps.CurentSteps = Math.Max((int)(new DataTable().Compute(steps.CurentSteps.ToString() + calculatorChanged, "")) - 1, 0);
        ClearText();
        if (steps.CurentSteps > 0)
            StartCoroutine(steps.SizeChangerBySteps());
        else
            print("you die :(");
    }
}
