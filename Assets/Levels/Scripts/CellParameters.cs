using System;
using TMPro;
using UnityEngine;

public class CellParameters : MonoBehaviour
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
}
