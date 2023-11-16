using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessSetting : MonoBehaviour
{
    [SerializeField] private Material brightnessMaterial;
    [SerializeField] private Slider brightnessSlider;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeBrightness()
    {
        Color color = brightnessMaterial.color;
        color.a = brightnessSlider.value;

        brightnessMaterial.color = color;

        Debug.Log("Changed brightness");
    }
}
