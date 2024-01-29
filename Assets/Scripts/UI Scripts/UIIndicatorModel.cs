using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIIndicatorModel : MonoBehaviour
{
    [SerializeField] BonusType indicatorType;
    [SerializeField] Image indicatorImage;
    float indicatorCooldown;
    bool isCooldown;

    void Awake()
    {
        indicatorImage = GetComponent<Image>();
    }

    public void EnableIndicator(float cooldown)
    {
        isCooldown = true;
        indicatorCooldown = cooldown;
        indicatorImage.fillAmount = 1;
    }

    public void FillIndicator()
    {
        if (isCooldown)
        {
            indicatorImage.fillAmount -= 1 / indicatorCooldown * Time.deltaTime;
        }
    }
}
