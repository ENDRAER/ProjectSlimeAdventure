using System;
using System.Collections;
using UnityEngine;

public class ListMoving : MonoBehaviour
{
    [SerializeField] private Rigidbody m_RB;
    [SerializeField] private GameObject[] LevelsGO;
    [SerializeField] private ListSlimeMoving listSlimeMoving;
    [NonSerialized] private Vector2 previousTouchPos;
    [NonSerialized] private int CurentSelectedLevel = 1;
    [NonSerialized] private bool ScrollKD;
    [NonSerialized] private Coroutine SliceCor;
    [NonSerialized] private float ScrollingSmootness = 0.4f;
    [NonSerialized] private float ScrollingSpeed = 15f;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }

    private void LateUpdate()
    {
        if (Input.touchCount != 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                if (SliceCor != null)
                    StopCoroutine(SliceCor);
                m_RB.velocity = new Vector3();
                previousTouchPos = Input.touches[0].position;
            }

            if (Input.touches[0].phase != TouchPhase.Ended)
            {
                transform.localPosition += new Vector3((previousTouchPos.x - Input.touches[0].position.x) * Time.deltaTime, 0 , 0);
                previousTouchPos = Input.touches[0].position;
            }
            if (Input.touches[0].phase == TouchPhase.Ended)
            {
                m_RB.velocity = new((previousTouchPos.x - Input.touches[0].position.x) * 0.8f, 0, 0);
                previousTouchPos = Input.touches[0].position;
            }
        }

        if (Math.Abs(Input.GetAxisRaw("Horizontal")) == 1 && ScrollKD == false)
        {
            CurentSelectedLevel = Math.Clamp(CurentSelectedLevel + (int)Input.GetAxis("Horizontal"), 0, LevelsGO.Length -1);
            if(SliceCor != null)
                StopCoroutine(SliceCor);
            SliceCor = StartCoroutine(ScrollToSelectedLevelIE());
        }
    }

    private IEnumerator ScrollToSelectedLevelIE()
    {
        StartCoroutine(ScrollKD_IE());
        StartCoroutine(listSlimeMoving.SlimeTranslate(LevelsGO[CurentSelectedLevel].transform.position));
        while (Math.Abs(-2 + LevelsGO[CurentSelectedLevel].transform.position.x - transform.position.x) > 0.1) 
        {
            transform.position += new Vector3((-2 + LevelsGO[CurentSelectedLevel].transform.position.x - transform.position.x) * ScrollingSmootness * ScrollingSpeed * Time.deltaTime, 0, 0);
            yield return null;
        }
    }

    private IEnumerator ScrollKD_IE()
    {
        ScrollKD = true;
        yield return new WaitForSeconds(0.2f);
        ScrollKD = false;
    }
}
