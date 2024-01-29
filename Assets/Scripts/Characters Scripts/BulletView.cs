using System;
using UnityEngine;

public class BulletView : MonoBehaviour
{
    [SerializeField] ObjectType typeBullet;
    [SerializeField] float bulletLifeTime;
    [SerializeField] BossAttackService boss;
    public Action<ObjectType, int> ChangeBullets;
    Action<ObjectConfig> SpawnBullet;
    public int bulletCount;
    GameObject spawner;
    SpawnerModel spawnerModel;
    SpawnerService service;


    void Awake()
    {
        spawner = GameObject.Find("Spawner");
        spawnerModel = spawner.GetComponent<SpawnerModel>();
        service = spawner.GetComponent<SpawnerService>();

        ChangeBullets = (type, count) =>
        {
            spawnerModel.Spawn -= SpawnBullet;
            SpawnBullet = service.GetSpawnAction(type, count, transform, bulletLifeTime);
            spawnerModel.Spawn += SpawnBullet;
        };
    }

    void Start()
    {
        if (boss) boss.ChangeAttack += ChangeBullets;
        SpawnBullet = service.GetSpawnAction(typeBullet, bulletCount, transform, bulletLifeTime);
        spawnerModel.Spawn += SpawnBullet;
    }

    void OnDestroy() => spawnerModel.Spawn -= SpawnBullet;
}
