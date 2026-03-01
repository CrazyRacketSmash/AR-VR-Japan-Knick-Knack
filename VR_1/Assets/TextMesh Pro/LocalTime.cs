using TMPro;
using UnityEngine;
using System;

public class LocalTimeText : MonoBehaviour
{
    TextMeshProUGUI timeText;

    void Awake()
    {
        timeText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        DateTime utc = DateTime.UtcNow;
        DateTime japanTime = utc.AddHours(9);
        if (timeText != null)
            timeText.text = japanTime.ToString("hh:mm:ss tt");
    }
}