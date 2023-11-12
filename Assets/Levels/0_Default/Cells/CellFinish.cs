using UnityEngine;
using UnityEngine.SceneManagement;

public class CellFinish : CellParameters
{
    [SerializeField] private GameObject InGameUI;
    [SerializeField] private GameObject WinScreen;


    public override void Restart()
    {

    }

    public override void LandingBehaviour(GameObject SlimeGO)
    {
        PlayerPrefs.SetInt(SceneManager.sceneCount - 1 + "Cake", 1);
        InGameUI.SetActive(false);
        WinScreen.SetActive(true);
    }
}
