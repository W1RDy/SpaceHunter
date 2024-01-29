using System;

[Serializable]
public class CategoryObjectsConfig
{
    public string categoryIndex;
    public ObjectConfig[] objects;
    public float spawnCooldown;
    public float maxCount;
    public bool isConnectedCategory;
}
