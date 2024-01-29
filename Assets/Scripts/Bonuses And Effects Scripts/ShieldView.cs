using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldView : MonoBehaviour
{
    [SerializeField] EffectsService effects;
    [SerializeField] GameObject shield;
    Action<BonusType, float, bool> ActivateShield;

    void Awake()
    {
        ActivateShield = (type, cooldown, isStart) => 
        {
            if (type == BonusType.Shield)
            {
                if (isStart) shield.SetActive(true);
                else shield.SetActive(false);
            }
        };     
    }

    void Start()
    {
        effects.ActivateEffect += ActivateShield;
    }
}
