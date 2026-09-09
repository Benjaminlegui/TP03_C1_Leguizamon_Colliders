using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UISettings : MonoBehaviour
{
    [SerializeField] private PlayerSettings settings;
    
    [Header("Speed Slider")]
    [SerializeField] private TMP_Text speedSliderText;
    [SerializeField] private Slider speedSlider;
    
    [Header("Size Slider")]
    [SerializeField] private TMP_Text sizeSliderText;
    [SerializeField] private Slider sizeSlider;
    
    void Awake()
    {
        speedSlider.SetValueWithoutNotify(settings.PlayerSpeed);
        speedSliderText.text = settings.PlayerSpeed.ToString("F1");
        sizeSlider.SetValueWithoutNotify(settings.PlayerSize);
        sizeSliderText.text = settings.PlayerSize.ToString("F1");
        
        speedSlider.onValueChanged.AddListener(OnSpeedChange);
        sizeSlider.onValueChanged.AddListener(OnSizeChange);
    }

    private void OnDestroy()
    {
        speedSlider.onValueChanged.RemoveAllListeners();
        sizeSlider.onValueChanged.RemoveAllListeners();
    }

    private void OnSpeedChange(float value)
    {
        settings.SetPlayerSpeed(value);
        speedSliderText.text = value.ToString("F1");
    }

    private void OnSizeChange(float value)
    {
        settings.SetPlayerSize(value);
        sizeSliderText.text = value.ToString("F1");
    }
}
