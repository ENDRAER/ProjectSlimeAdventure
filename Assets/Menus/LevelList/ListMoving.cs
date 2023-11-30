using System;
using System.Collections;
using UnityEngine;

public class ListMoving : MonoBehaviour
{
    [SerializeField] private GameObject[] LevelsGO;
    [SerializeField] private SlimeListMoving slimeListMoving;
    [SerializeField] private SceneChanger sceneChanger;
    [NonSerialized] private int WhereLevelsStart = 1;
    [NonSerialized] private int CurentSelectedLevel;
    [NonSerialized] private Vector2 StartTouchPos;
    [NonSerialized] private bool ScrollKD;
    [NonSerialized] private Coroutine SlideCor;
    [NonSerialized] private float ScrollingSmootness = 0.4f;
    [NonSerialized] private float ScrollingSpeed = 15f;

    private void Awake()
    {
        Application.targetFrameRate = 120;
        CurentSelectedLevel = PlayerPrefs.GetInt("LastSelectedLevel");
        CurentSelectedLevel = Math.Clamp(CurentSelectedLevel + (int)Input.GetAxis("Horizontal"), 0, LevelsGO.Length - 1);
        SlideCor = StartCoroutine(ScrollToSelectedLevelIE());
    }

    private void LateUpdate()
    {
        if (Input.touchCount != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                StartTouchPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                CurentSelectedLevel = Math.Clamp(CurentSelectedLevel + (Input.touches[0].position.x - StartTouchPos.x < 0? -1 : 1), 0, LevelsGO.Length - 1);
                if (SlideCor != null)
                    StopCoroutine(SlideCor);
                SlideCor = StartCoroutine(ScrollToSelectedLevelIE());
            }
        }

        if (Math.Abs(Input.GetAxisRaw("Horizontal")) == 1 && CurentSelectedLevel + (int)Input.GetAxis("Horizontal") >= 0 && CurentSelectedLevel + (int)Input.GetAxis("Horizontal") < LevelsGO.Length && ScrollKD == false)
        {
            CurentSelectedLevel = Math.Clamp(CurentSelectedLevel + (int)Input.GetAxis("Horizontal"), 0, LevelsGO.Length -1);
            if(SlideCor != null)
                StopCoroutine(SlideCor);
            SlideCor = StartCoroutine(ScrollToSelectedLevelIE());
            StartCoroutine(ScrollKD_IE());
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.KeypadEnter) && Input.GetKeyDown(KeyCode.Joystick1Button0))
        {
            StartCoroutine(sceneChanger.StartNewScene(CurentSelectedLevel + WhereLevelsStart));
            StartCoroutine(slimeListMoving.SlimeTranslate(-50 * Vector3.one, 1));
        }
    }

    private IEnumerator ScrollToSelectedLevelIE()
    {
        StartCoroutine(slimeListMoving.SlimeTranslate(LevelsGO[CurentSelectedLevel].transform.position, CurentSelectedLevel));
        while (Math.Abs(-2 + LevelsGO[CurentSelectedLevel].transform.position.x - transform.position.x) > 0.1) 
        {
            transform.position += new Vector3((-2 + LevelsGO[CurentSelectedLevel].transform.position.x - transform.position.x) * ScrollingSmootness * ScrollingSpeed * Time.deltaTime, 0, 
                (-10 + LevelsGO[CurentSelectedLevel].transform.position.z - transform.position.z) * ScrollingSmootness * ScrollingSpeed * Time.deltaTime);
            yield return null;
        }
        PlayerPrefs.SetInt("LastSelectedLevel", CurentSelectedLevel);
    }

    private IEnumerator ScrollKD_IE()
    {
        ScrollKD = true;
        yield return new WaitForSeconds(0.20f);
        ScrollKD = false;
    }
}
