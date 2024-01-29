using Unity.VisualScripting;
using UnityEngine;

public class FreezeEnemyController : MonoBehaviour
{
    FreezeEnemyModel enemy;

    void Start()
    {
        enemy = GetComponent<FreezeEnemyModel>();
        StartCoroutine(enemy.Freezing());
    }
}
