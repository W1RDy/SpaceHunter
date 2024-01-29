using System;
using UnityEngine;

public class EnemyView : MonoBehaviour
{
    GameObject spawner;
    SpawnerModel spawnerModel;
    SpawnerService service;

    void Awake()
    {
        spawner = GameObject.Find("Spawner");
        spawnerModel = spawner.GetComponent<SpawnerModel>();
        service = spawner.GetComponent<SpawnerService>();
    }

    void Start() => spawnerModel.Spawn += service.GetSpawnAction(ObjectType.Enemy, float.PositiveInfinity);
}
