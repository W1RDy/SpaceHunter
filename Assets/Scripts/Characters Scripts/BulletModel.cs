using System;
using Unity.VisualScripting;
using UnityEngine;

public class BulletModel : MonoBehaviour, IMovable
{
    float speed = 20;
    public Transform shooter;
    EffectsInitializator effects;
    Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        effects = GameObject.Find("EffectSystem").GetComponent<EffectsInitializator>();
        if (player.position == transform.position) gameObject.layer = 8;
        else gameObject.layer = 7;
    }

    public void Move() => transform.Translate(Vector2.up * speed * Time.deltaTime);

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" || (collision.tag == "Player" && !effects.isShield))
        {
            if (collision.tag == "Player") collision.GetComponent<PlayerModel>().Death();
            collision.GetComponent<ExplosionView>().ActivateExplosion();
        }
        if (collision.tag == "Boss")
            collision.GetComponent<BossModel>().DecreaseHp();
        Destroy(gameObject);
    }
}