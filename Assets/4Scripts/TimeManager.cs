using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float timeStart;
    [SerializeField]
    private TextMeshProUGUI timeText;
    [SerializeField]
    private TextMeshProUGUI startPauseText;

    private bool timeActive = false;

    private void Start()
    {
        timeText.text = timeStart.ToString("F2");
    }

    private void Update()
    {
        StartTime();
    }

    private void StartTime()
    {
        if (timeActive)
        {
            timeStart += Time.deltaTime;
            timeText.text = timeStart.ToString("F2");
        }
    }

    public void StartPauseBtn()
    {
        timeActive = !timeActive;
        startPauseText.text = timeActive ? "PAUSE" : "START";
    }

    public void ResetBtn()
    {
        if (timeStart > 0)
        {
            timeStart = 0f;
            timeText.text = timeStart.ToString("F2");
        }
    }
}
