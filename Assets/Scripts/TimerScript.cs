using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{
    [SerializeField] Transform hourHand;
    [SerializeField] Transform minuteHand;
    [SerializeField] Transform secondHand;

    [SerializeField] TextMeshProUGUI timeText;

    void Update()
    {
        // Get the current system time
        DateTime currentTime = DateTime.Now;

        // Extract the hours, minutes, and seconds from the current time
        int hours = currentTime.Hour;
        int minutes = currentTime.Minute;
        int seconds = currentTime.Second;

        // Calculate the rotation angles for the clock hands
        float hourAngle = 360f * ((hours % 12) + minutes / 60f) / 12f;
        float minuteAngle = 360f * ((minutes % 60) + seconds / 60f) / 60f;
        float secondAngle = 360f * (seconds % 60) / 60f;

        // Apply the rotations to the clock hands
        hourHand.localRotation = Quaternion.Euler(0f, hourAngle, 0f);
        minuteHand.localRotation = Quaternion.Euler(0f, minuteAngle, 0f);
        secondHand.localRotation = Quaternion.Euler(0f, secondAngle, 0f);

        // Update the text label
        timeText.text = currentTime.ToString("h:mm:ss tt");
    }
}
