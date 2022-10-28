using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[DefaultExecutionOrder(-1)]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text textDisplay;
    
    private Slider _healthBar;

    private int _maxValue;

    private void Awake()
    {
        _healthBar = GetComponent<Slider>();
    }

    public void Setup(int maxValue)
    {
        _maxValue = maxValue;
        
        _healthBar.maxValue = maxValue;
        
        SetValue(maxValue);
    }

    public void SetValue(int value)
    {
        _healthBar.value = value;

        string a = $"HP: {value} / {_maxValue}";
        
        textDisplay.text = a;

        //textDisplay.text = $"HP: {value} / {_maxValue}";
        //textDisplay.text = value + "/" + _maxValue;
    }
}
