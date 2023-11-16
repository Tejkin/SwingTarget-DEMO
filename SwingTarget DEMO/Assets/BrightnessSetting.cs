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
        if (PlayerPrefs.HasKey("brightness"))
        {
            LoadBrightness();
        }
        else
        {
            ChangeBrightness();
        }
    }


    public void ChangeBrightness()
    {
        Color color = brightnessMaterial.color;
        color.a = brightnessSlider.value;

        brightnessMaterial.color = color;

        PlayerPrefs.SetFloat("brightness", color.a);
    }

    public void LoadBrightness()
    {
        brightnessSlider.value = PlayerPrefs.GetFloat("brightness");

        ChangeBrightness();
    }
}
