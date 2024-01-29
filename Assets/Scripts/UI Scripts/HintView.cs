using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintView : MonoBehaviour
{
    HintModel hint;

    void Start()
    {
        hint = GetComponent<HintModel>();
        hint.ShowHint();
    }
}
