using System;
using System.Collections;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class EffectsService : MonoBehaviour
{
    [SerializeField] EffectModel[] configs;
    public event Action<BonusType, float, bool> ActivateEffect;

    public void EnableEffect(BonusType type)
    {
        var effect = GetEffect(type);
        effect.SetEffect(ActivateEffect);
        if (effect.isActive == false) effect.isActive = true;
        else effect.isRepeat = true;
        StartCoroutine(EnableAndDisenableEffect(effect));
    }

    EffectModel GetEffect (BonusType type)
    {
        switch (type)
        {
            case BonusType.Shield:
                return configs[0];
            case BonusType.IncreaserSpeed:
                return configs[1];
            case BonusType.DecreaserSpeed:
                return configs[2];
            case BonusType.IncreaserShooting:
                return configs[3];
        }
        throw new InvalidDataException($"Объекта типа {type} не существует");
    }

    IEnumerator EnableAndDisenableEffect(EffectModel effect)
    {
        effect.Activate(true);
        yield return new WaitForSeconds(effect.cooldown);
        if (effect.isRepeat)
        {
            effect.isRepeat = false;
            yield break;
        }
        effect.isActive = false;
        effect.Activate(false);
    }
}
