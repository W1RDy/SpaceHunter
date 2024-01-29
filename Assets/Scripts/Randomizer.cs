using System;
using UnityEngine;
using Random = UnityEngine.Random;

public static class Randomizer
{
    public static ObjectConfig GetRandomObject(ObjectConfig[] config)
    {
        float sum = 0;
        var rand = Random.Range(0, 100);
        for (int j = 0; j < config.Length; j++)
        {
            sum += config[j].chance;
            if (rand <= sum)
            {
                ChangeChances(config, j);
                return config[j];
            }
        }
        throw new NullReferenceException();
    }

    static void ChangeChances(ObjectConfig[] config, int configIndex)
    {
        float step = 2 * (configIndex + 1);
        config[configIndex].chance -= (config.Length - 1) * step;
        AddNewChances(config, configIndex, step);
    }

    static void AddNewChances(ObjectConfig[] config, int configIndex, float step)
    {
        for (int k = 0; k < config.Length; k++)
            if (k != configIndex) config[k].chance += step;
    }

    public static Vector2 GenerateSpawnPosition(ZoneModel zone) =>
        new Vector3(RandomizeCoordinate(zone.center.x, zone.size.x), RandomizeCoordinate(zone.center.y, zone.size.y), 0);

    static float RandomizeCoordinate(float coordinate, float zoneSize) => Random.Range(coordinate - zoneSize, coordinate + zoneSize);
}


