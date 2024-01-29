using System;

[Serializable]
class EffectModel
{
    public float cooldown;
    public BonusType type;
    public Action<BonusType, float, bool> Effect;
    public bool isActive;
    public bool isRepeat;

    public void SetEffect(Action<BonusType, float, bool> Action) =>
        Effect = Action;

    public void Activate(bool isStart) =>
        Effect(type, cooldown, isStart);
}
