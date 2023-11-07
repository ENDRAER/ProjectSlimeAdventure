using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StepCounter;
    [SerializeField] private GameObject DiferenceStepsCounter;


    public void ChangeStepCounter(int oldValue, int newValue)
    {
        StepCounter.text = newValue.ToString();
        GameObject DiferenceStepsCounterGO = Instantiate(DiferenceStepsCounter, StepCounter.transform.position, StepCounter.transform.rotation);
        DiferenceStepsCounterGO.transform.SetParent(StepCounter.transform);
        DiferenceStepsCounterGO.transform.localScale = Vector3.one;
        //text
        TextMeshProUGUI DiferenceStepsCounterTMP = DiferenceStepsCounterGO.GetComponent<TextMeshProUGUI>();
        int diference = newValue - oldValue;
        DiferenceStepsCounterTMP.text = (diference > 0 ? "+" : "") + diference;
        DiferenceStepsCounterTMP.color = diference > 0? new Color(0, 0.78f, 0) : diference == 0? new Color(0.78f, 0.78f, 0.78f) : new Color(0.78f, 0, 0);
    }
}
