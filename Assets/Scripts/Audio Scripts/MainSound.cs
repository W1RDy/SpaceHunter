using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSound : MonoBehaviour
{

    void Start()
    {
        AudioManager.instance.PlayBackgroundMusic();  
    }
}
