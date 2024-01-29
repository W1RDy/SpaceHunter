using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    TimerModel timer;

    void Start()
    {
        timer = GetComponent<TimerModel>();
        StartCoroutine(timer.WorkTimer());
    }
}
