using System;
using System.IO;
using UnityEngine;

public class SpawnerService: MonoBehaviour
{
    [SerializeField] GameObject boss;
    ZoneModel zone;
    Collider2D[] colliders;

    void Start()
    {
        zone = GameObject.Find("Map").GetComponent<ZoneModel>();    
    }

    public Action<ObjectConfig> GetSpawnAction(ObjectType type, int spawnCount, Transform point, float time)
    {
        switch (type)
        {
            case ObjectType.Enemy:
            case ObjectType.Bonus:
                return (config) =>
                {
                    if (config.objectType == type)
                    {
                        var obj = Instantiate(config.prefab, GetSpawnPosition(5), Quaternion.identity);
                        if (config.objectType == ObjectType.Bonus) Destroy(obj, time);
                    }              
                };
            case ObjectType.Bullet:
            case ObjectType.SpeedBullet:
            case ObjectType.BossBullet:
            case ObjectType.PlayerBullet:
                return (config) =>
                {
                    if (config.objectType == type)
                    {
                        if (config.objectType == ObjectType.BossBullet) AudioManager.instance.PlaySound("BigLaser");
                        else AudioManager.instance.PlaySound("Laser");
                        var step = 360 / spawnCount;
                        for (int i = 0; i < spawnCount; i++)
                            Destroy(Instantiate(config.prefab, point.position, Quaternion.Euler(0, 0, point.rotation.eulerAngles.z + i * step)), time);
                    }
                };
        }
        throw new InvalidDataException($"Объекта типа {type} не существует");
    }

    public Action<ObjectConfig> GetSpawnAction(ObjectType type, float time) => GetSpawnAction(type, 1, null, time);

    Vector3 GetSpawnPosition(float spawnDistance)
    {
        while (true)
        {
            var position = Randomizer.GenerateSpawnPosition(zone);
            if (CheckSpawnPosition(position, spawnDistance)) return position;
        }
    }

    bool CheckSpawnPosition(Vector3 position, float spawnDistance)
    {
        colliders = Physics2D.OverlapBoxAll(position, new Vector2(spawnDistance, spawnDistance), 0, 1 << 0 | 1 << 3);
        return colliders.Length == 0;
    }

    public void SpawnBoss() =>
        Instantiate(boss, GetSpawnPosition(10f), Quaternion.identity);
}
