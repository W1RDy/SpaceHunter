using System;
using System.Collections;
using UnityEngine;

public class SpawnerModel : MonoBehaviour
{
    [SerializeField] CategoryObjectsConfig[] categories;
    [SerializeField] SceneModel scene;
    public event Action<ObjectConfig> Spawn;
    Action StopSpawners;
    ObjectConfig playerBulletConfig;

    void Awake()
    {
        foreach (var category in categories)
        {
            if (category.categoryIndex == "Enemies") category.maxCount = scene.countEnemy;
            if (category.categoryIndex == "Bullets")
            {
                foreach (var configs in category.objects) 
                    if (configs.objectType == ObjectType.PlayerBullet) playerBulletConfig = configs;
            }
        }
        StopSpawners = () => StopAllCoroutines();
    }

    void Start()
    {
        scene.GameOver += StopSpawners;
        foreach (var category in categories) StartSpawn(category);
    }

    void StartSpawn(CategoryObjectsConfig category)
    {
        if (category.isConnectedCategory) StartCoroutine(Spawning(category));
        else SpawningUnconnectedObj(category);
    }

    IEnumerator Spawning(CategoryObjectsConfig category)
    {
        for (int i = 1; i <= category.maxCount; i++)
        {
            yield return new WaitForSeconds(category.spawnCooldown);
            var config = Randomizer.GetRandomObject(category.objects);
            MakeObject(config);
        }
    }

    IEnumerator Spawning (ObjectConfig config, float maxCount)
    {
        for (int i = 1; i <= maxCount; i++)
        {
            yield return new WaitForSeconds(config.cooldown);
            MakeObject(config);
        }
    }

    void SpawningUnconnectedObj(CategoryObjectsConfig category)
    {
        foreach (var config in category.objects) StartCoroutine(Spawning(config, category.maxCount));
    }

    void MakeObject(ObjectConfig config)
    {
        if (Spawn != null) Spawn(config);
    }

    public void ChangePlayerBulletCooldown(float newCooldown) =>
        playerBulletConfig.cooldown = newCooldown;
}
