using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] SceneModel scene;
    [SerializeField] BossActivator activator;
    int count, enemyCount;
    Text counter;

    void Awake()
    {
        enemyCount = scene.countEnemy;
        counter = transform.GetChild(0).GetComponent<Text>();
        counter.text = count + "/" + enemyCount;
    }

    public void UpdateCounter()
    {
        if (counter)
        {
            count++;
            counter.text = count + "/" + enemyCount;
            if (count == enemyCount) StartCoroutine(activator.ActivateBoss());
        }
    }
}
