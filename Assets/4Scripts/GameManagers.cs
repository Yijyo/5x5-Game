using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManagers : MonoBehaviour
{
    public float timeStart;
    [SerializeField]
    private TextMeshProUGUI timeText;

    public bool timeActive = false;

    private void Start()
    {
        timeActive = true;
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
}
