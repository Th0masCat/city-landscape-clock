using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DayNightCycle : MonoBehaviour
{
    Light directionalLight;
    Transform sunTransform;
    
    [SerializeField] Color morningColor;
    [SerializeField] Color afternoonColor;
    [SerializeField] Color eveningColor;
    [SerializeField] Color nightColor;

    [SerializeField] Color morningBgColor;
    [SerializeField] Color afternoonBgColor;
    [SerializeField] Color eveningBgColor;
    [SerializeField] Color nightBgColor;

    [SerializeField] Camera mainCamera;

    private void Start() {
        directionalLight = GetComponent<Light>();
        sunTransform = GetComponent<Transform>();
    }

    private void Update() {
    
        // Get the current system time
        DateTime currentTime = DateTime.Now;

        // Determine the current time of day
        if (currentTime.Hour >= 6 && currentTime.Hour < 12)
        {
            // Morning
            UpdateLighting(morningColor, 1f, 90f, morningBgColor);
        }
        else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
        {
            // Afternoon
            UpdateLighting(afternoonColor, 1f, 180f, afternoonBgColor);
        }
        else if (currentTime.Hour >= 18 && currentTime.Hour < 22)
        {
            // Evening
            UpdateLighting(eveningColor, 0.8f, 270f, eveningBgColor);
        }
        else
        {
            // Night
            UpdateLighting(nightColor, 0.1f, 0f, nightBgColor);
        }
    }

    private void UpdateLighting(Color color, float intensity, float rotationY, Color bgColor)
    {
        directionalLight.color = color;
        directionalLight.intensity = intensity;
        sunTransform.rotation = Quaternion.Euler(50f, rotationY, 0f);
        mainCamera.backgroundColor = bgColor;
    }
}
