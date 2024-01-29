using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossActivator : MonoBehaviour
{
    [SerializeField] GameObject bossHealthBar, enemyCounter;
    [SerializeField] SpawnerService spawnerService;

    public IEnumerator ActivateBoss()
    {
        AudioManager.instance.PlayBossMusic();
        bossHealthBar.SetActive(true);
        yield return new WaitForSeconds(2f);
        spawnerService.SpawnBoss();
        enemyCounter.SetActive(false);
    }
}
