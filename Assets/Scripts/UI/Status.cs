using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Status : MonoBehaviour
{
    public float startValue;
    public float nowValue;
    public float maxValue;
    public float passiveValue;

    public Image uiBar;

    void Start()
    {
        startValue = nowValue;
    }

    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage() => nowValue / maxValue;

    public void Add(float value) => nowValue = Mathf.Min(nowValue + value, maxValue);
    public void Subtract(float value) => nowValue = Mathf.Max(nowValue - value, 0);
}
