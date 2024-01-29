using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultModel : MonoBehaviour
{
    [SerializeField] Text[] results;
    [SerializeField] TimerModel timer;

    public void OutputResult()
    {
        foreach (var result in results)
        {
            if (result.gameObject.activeSelf) result.text = "Твоё время: " + timer.GetTime() + " секунд";
        }
    }
}
