using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ListMoving : MonoBehaviour
{
    [SerializeField] private GameObject[] LevelsGO;
    [SerializeField] private ListSlimeMoving listSlimeMoving;
    [NonSerialized] private int CurentSelectedLevel;
    [NonSerialized] private Vector2 StartTouchPos;
    [NonSerialized] private bool ScrollKD;
    [NonSerialized] private Coroutine SliceCor;
    [NonSerialized] private float ScrollingSmootness = 0.4f;
    [NonSerialized] private float ScrollingSpeed = 15f;

    private void Awake()
    {
        Application.targetFrameRate = 120;
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
                if (SliceCor != null)
                    StopCoroutine(SliceCor);
                SliceCor = StartCoroutine(ScrollToSelectedLevelIE());
            }
        }

        if (Math.Abs(Input.GetAxisRaw("Horizontal")) == 1 && CurentSelectedLevel + (int)Input.GetAxis("Horizontal") >= 0 && CurentSelectedLevel + (int)Input.GetAxis("Horizontal") < LevelsGO.Length && ScrollKD == false)
        {
            CurentSelectedLevel = Math.Clamp(CurentSelectedLevel + (int)Input.GetAxis("Horizontal"), 0, LevelsGO.Length -1);
            if(SliceCor != null)
                StopCoroutine(SliceCor);
            SliceCor = StartCoroutine(ScrollToSelectedLevelIE());
            StartCoroutine(ScrollKD_IE());
        }
    }

    private IEnumerator ScrollToSelectedLevelIE()
    {
        StartCoroutine(listSlimeMoving.SlimeTranslate(LevelsGO[CurentSelectedLevel].transform.position));
        while (Math.Abs(-2 + LevelsGO[CurentSelectedLevel].transform.position.x - transform.position.x) > 0.1) 
        {
            transform.position += new Vector3((-2 + LevelsGO[CurentSelectedLevel].transform.position.x - transform.position.x) * ScrollingSmootness * ScrollingSpeed * Time.deltaTime, 0, 
                (-10 + LevelsGO[CurentSelectedLevel].transform.position.z - transform.position.z) * ScrollingSmootness * ScrollingSpeed * Time.deltaTime);
            yield return null;
        }
    }

    private IEnumerator ScrollKD_IE()
    {
        ScrollKD = true;
        yield return new WaitForSeconds(0.16f);
        ScrollKD = false;
    }
}
