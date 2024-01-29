using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public abstract class BaseEnemy : MonoBehaviour, IRadiated, IMovable, IRotatable
{
    public event Action MoveForward;
    EnemyCounter counter;
    EffectsInitializator effectInitializator;
    Transform player;
    float rotationSpeed = 7;
    Rotator rotator;
    NavMeshAgent agent;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rotator = new Rotator(rotationSpeed);
        effectInitializator = GameObject.Find("EffectSystem").GetComponent<EffectsInitializator>();
        agent = GetComponent<NavMeshAgent>();
        counter = GameObject.Find("Canvas/Counters/EnemyCounter").GetComponent<EnemyCounter>();
    }

    public void Move()
    {
        if (player)
        {
            agent.SetDestination(player.position);
            if (agent.desiredVelocity.magnitude > 0.5f) MoveForward();
        }
    }

    public void Rotate()
    {
        if (player) rotator.RotateTo(transform, player.position);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !effectInitializator.isShield)
        {
            var obj = collision.gameObject;
            obj.GetComponent<PlayerModel>().Death();
            obj.gameObject.GetComponent<ExplosionView>().ActivateExplosion();
        }
    }

    void OnDestroy()
    {
        if (counter) counter.UpdateCounter();
    }
}
