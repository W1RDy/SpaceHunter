using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeEnemyModel : BaseEnemy
{
    [SerializeField] float freezeCooldown;
    EffectsService effectService;
    bool isFreeze = true;
    SceneModel scene;
    Action StopFreezing;

    void Awake()
    {
        StopFreezing = () => isFreeze = false;    
    }

    public override void Start()
    {
        base.Start();
        effectService = GameObject.Find("EffectSystem").GetComponent<EffectsService>();
        scene = GameObject.Find("Canvas").GetComponent<SceneModel>();
        scene.GameOver += StopFreezing;
    }

    public IEnumerator Freezing()
    {
        while (true)
        {
            yield return new WaitForSeconds(freezeCooldown);
            if (!isFreeze) break;
            effectService.EnableEffect(BonusType.DecreaserSpeed);
        }
    }
}
