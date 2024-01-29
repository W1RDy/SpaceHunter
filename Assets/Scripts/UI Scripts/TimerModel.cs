using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerModel : MonoBehaviour
{
    SceneModel scene;
    Text timer;
    int time = 0;
    bool isCount = true;
    Action StopTimer;

    void Awake() => StopTimer = () => isCount = false;

    void Start()
    {
        timer = GetComponentInChildren<Text>();
        scene = GameObject.Find("Canvas").GetComponent<SceneModel>();
        scene.GameOver += StopTimer;
    }


    public IEnumerator WorkTimer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!isCount) break;
            UpdateTimer();
        }
    }

    public void UpdateTimer()
    {
        time++;
        timer.text = time.ToString();
    }

    public int GetTime() => time;
}
