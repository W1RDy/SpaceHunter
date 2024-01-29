using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusView : MonoBehaviour
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

    void Start() => spawnerModel.Spawn += service.GetSpawnAction(ObjectType.Bonus, 10f);
}
