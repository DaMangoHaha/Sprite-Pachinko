using UnityEngine;
using TMPro;
using System;

public class SeasonTimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;

    // Set the season end date here
    private DateTime seasonEndTime = new DateTime(2025, 5, 14, 23, 59, 0); // May 15, 2025 11:59 PM. In order, it is 2025, May, 15th, 11(hour), 59(minutes), 0(seconds).

    void Update()
    {
        TimeSpan timeRemaining = seasonEndTime - DateTime.Now;

        if (timeRemaining.TotalSeconds > 0)
        {
            timerText.text = FormatTime(timeRemaining);
        }
        else
        {
            timerText.text = "Season Over";
        }
    }

    private string FormatTime(TimeSpan time)
    {
        return string.Format("Season 2: Cosmic Cascade Begins In: {0:D2}d {1:D2}h {2:D2}m {3:D2}s",
            time.Days, time.Hours, time.Minutes, time.Seconds);
    }
}
