using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    BossModel boss;

    void Start()
    {
        boss = GetComponent<BossModel>();
        boss.StartAttack();
    }
}
