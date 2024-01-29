using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EffectsInitializator : MonoBehaviour
{
    EffectsService effectSystem;
    Action<BonusType, float, bool> ChangeShield, ChangeSpeed, ChangeShooting;

    public bool isShield;
    GameObject player;
    PlayerModel playerModel;
    SpawnerModel spawner;

    void Awake()
    {
        effectSystem = GetComponent<EffectsService>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerModel = player.GetComponent<PlayerModel>();
        spawner = GameObject.Find("Spawner").GetComponent<SpawnerModel>(); 
        InitializeEffects();    
    }

    void InitializeEffects()
    {
        ChangeShield = (type, cooldown, isStart) =>
        {
            if (type == BonusType.Shield)
            {
                if (isStart) AudioManager.instance.PlaySound("Shield");
                isShield = isStart;
            }
        };

        ChangeSpeed = (type, cooldown, isStart) =>
        {
            if (type == BonusType.IncreaserSpeed || type == BonusType.DecreaserSpeed)
            {
                float speed = 0;
                if (type == BonusType.DecreaserSpeed)
                {
                    if (isStart) AudioManager.instance.PlaySound("Slow");
                    speed = isStart ? 1 : 3;
                }
                if (type == BonusType.IncreaserSpeed)
                {
                    if (isStart) AudioManager.instance.PlaySound("Speed");
                    speed = isStart ? 5 : 3;
                }

                playerModel.ChangeSpeed(speed);
            }
        };

        ChangeShooting = (type, cooldown, isStart) =>
        {
            if (type == BonusType.IncreaserShooting)
            {
                if (isStart) AudioManager.instance.PlaySound("ChargeUp");
                var newCooldown = isStart ? 0.5f : 1.5f;
                spawner.ChangePlayerBulletCooldown(newCooldown);
            }
        };

        AddEffects(ChangeSpeed);
        AddEffects(ChangeShield);
        AddEffects(ChangeShooting);
    }

    void AddEffects(Action<BonusType, float, bool> Effect) =>
        effectSystem.ActivateEffect += Effect;
}
