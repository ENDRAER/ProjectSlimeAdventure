using System;
using System.Data;
using TMPro;
using UnityEngine;

public class CellCalculator : CellParameters
{
    [SerializeField][Delayed] public string calculator;
    [Space]
    [SerializeField] public Color BadColor;
    [SerializeField] public Color GoodColor;
    [SerializeField] private TextMeshPro m_Text;
    [SerializeField] private Animator m_Animator;
    [NonSerialized] public string calculatorChanged;

    public void ClearText()
    {
        calculatorChanged = "";
        m_Text.text = "";
    }

    public override void Restart()
    {
        calculatorChanged = calculator;
        if (calculator != "")
        {
            if (m_Text.text != calculator)
                m_Animator.SetTrigger("Restart");
            if (calculator.Substring(0, 1) == "+" || calculator.Substring(0, 1) == "*")
            {
                m_Text.text = calculator;
                m_Text.color = GoodColor;
            }
            else if (calculator.Substring(0, 1) == "-" || calculator.Substring(0, 1) == "/")
            {
                m_Text.text = calculator;
                m_Text.color = BadColor;
            }
            else
            {
                Debug.LogError("WrongParameters in - " + gameObject.name);
                ClearText();
            }
        }
        else
            m_Text.text = "";
    }
    private void OnValidate()
    {
        Restart();
    }

    public override void LandingBehaviour(GameObject SlimeGO)
    {
        Steps steps = SlimeGO.GetComponent<Steps>();
        steps.ChangeStepsCount(Math.Max((int)(new DataTable().Compute(steps.CurentSteps.ToString() + calculatorChanged, "")) - 1, 0));
        ClearText();
    }
}
