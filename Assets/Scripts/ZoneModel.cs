using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneModel : MonoBehaviour
{
    [SerializeField] public Vector2 size = new Vector2(30, 30);
    [SerializeField] public Vector2 center = Vector2.zero;
    [SerializeField] SceneModel scene;

    void Awake() => size = scene.zoneSize;    
}
