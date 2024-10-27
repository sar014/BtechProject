using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSensitivity : MonoBehaviour
{
    public Slider sensitivitySlider;
    public float sensitivity = 1.0f; // Default sensitivity

    void Start()
    {
        // Set default or saved sensitivity value
        sensitivity = PlayerPrefs.GetFloat("MouseSensitivity", sensitivity);
        sensitivitySlider.value = sensitivity;
    }

    public void UpdateSensitivity(float value)
    {
        sensitivity = value;
        Debug.Log("Sensitivity:"+sensitivity);
        PlayerPrefs.SetFloat("MouseSensitivity", sensitivity); // Save sensitivity
    }
}
