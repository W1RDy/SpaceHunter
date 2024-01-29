using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class IconActivator : MonoBehaviour
{
    [SerializeField] GameObject shieldIcon, incrSpeedIcon, decrSpeedIcon, shootingIcon;
    Action<BonusType, float, bool> ActivateIcon;
    EffectsService effects;

    void Awake()
    {
        effects = GameObject.Find("EffectSystem").GetComponent<EffectsService>();
        ActivateIcon = (type, cooldown, isStart) =>
        {
            var icon = GetIconByType(type);
            if (isStart)
            {
                icon.SetActive(true);
                icon.transform.GetChild(0).GetComponent<UIIndicatorModel>().EnableIndicator(cooldown);
            }
            else icon.SetActive(false);
        };
    }

    void Start()
    {
        effects.ActivateEffect += ActivateIcon;    
    }

    GameObject GetIconByType(BonusType type)
    {
        switch (type)
        {
            case BonusType.Shield:
                return shieldIcon;
            case BonusType.IncreaserSpeed:
                return incrSpeedIcon;
            case BonusType.IncreaserShooting:
                return shootingIcon;
            case BonusType.DecreaserSpeed:
                return decrSpeedIcon;
        }
        throw new InvalidDataException($"Объекта типа {type} не существует");
    }
}
