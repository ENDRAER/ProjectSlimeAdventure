using UnityEngine;
using UnityEngine.SceneManagement;

public class CellFinish : CellParameters
{
    [SerializeField] private Animator m_Animator;
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject WinScreen;

    public override void LandingBehaviour(GameObject SlimeGO)
    {
        m_Animator.enabled = true;
        PlayerPrefs.SetInt(SceneManager.sceneCount - 1 + "Cake", 1);
        InGameUI.SetActive(false);
        WinScreen.SetActive(true);
    }
}
