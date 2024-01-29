using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class BossModel : MonoBehaviour, IRadiated, IMovable, IRotatable
{
    [SerializeField] int health;
    [SerializeField] AttackConfig[] attacks;
    [SerializeField] BossAttackService attacksService;
    [SerializeField] HealthBarModel healthBar;
    [SerializeField] SceneModel scene;
    List<AttackConfig> activeAttacks;
    Transform player;
    NavMeshAgent agent;
    Rotator rotator;
    float rotationSpeed = 1;
    public event Action MoveForward;

    void Awake()
    {
        attacksService.SetBossAttacks(attacks);
        rotator = new Rotator(rotationSpeed);
        activeAttacks = new List<AttackConfig>(attacks);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        healthBar = GameObject.Find("Canvas/HealthBar").GetComponent<HealthBarModel>();
        scene = GameObject.Find("Canvas").GetComponent<SceneModel>();
    }

    public void Move()
    {
        if (player) agent.SetDestination(player.position);
        if (agent.desiredVelocity.magnitude > 0.5f) MoveForward();
    }

    public void Rotate()
    {
        if (player) rotator.RotateTo(transform, player.position);
    }

    public void StartAttack() => StartCoroutine(MakeAttack());

    IEnumerator MakeAttack()
    {
        yield return new WaitForSeconds(1);
        while (true)
        {
            var attack = ChooseAttack();
            attack.Attack();
            yield return new WaitForSeconds(attack.cooldown);
        }
    }

    AttackConfig ChooseAttack()
    {
        var attack = activeAttacks[Random.Range(0, activeAttacks.Count-1)];
        activeAttacks.Remove(attack);
        if (activeAttacks.Count == 0) activeAttacks = attacks.ToList();
        return attack;
    }

    public void DecreaseHp()
    {
        AudioManager.instance.PlaySound("Damage");
        health--;
        healthBar.UpdateHealthBar(health);
        if (health == 0)
        {
            GetComponent<ExplosionView>().ActivateExplosion();
            scene.EndGame(true);
        }
    }
}

[Serializable]
public class AttackConfig
{
    public float cooldown;
    public int attackIndex;
    public Action Attack;

    public void SetAttack(Action action)
    {
        Attack = action;
    }
}
