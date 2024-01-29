using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIIndicatorView : MonoBehaviour
{
    [SerializeField]UIIndicatorModel indicator;
 
    void Update()
    {
        indicator.FillIndicator();
    }
}
