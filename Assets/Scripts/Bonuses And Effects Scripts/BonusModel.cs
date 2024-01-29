using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusModel : MonoBehaviour
{
    [SerializeField] BonusType type;
    EffectsService service;

    void Awake()
    {
        service = GameObject.Find("EffectSystem").GetComponent<EffectsService>();
    }

    public void EnableEffect()
    {
        service.EnableEffect(type);
    }
}
