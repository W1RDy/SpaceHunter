using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackService : MonoBehaviour
{
    public event Action<ObjectType, int> ChangeAttack;

    public void SetBossAttacks(AttackConfig[] attacks)
    {
        attacks[0].SetAttack(() => ChangeAttack(ObjectType.BossBullet, 1));
        attacks[1].SetAttack(() => ChangeAttack(ObjectType.Bullet, 10));
        attacks[2].SetAttack(() => ChangeAttack(ObjectType.SpeedBullet, 6));
    }
}
