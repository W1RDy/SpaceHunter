using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObjController : MonoBehaviour
{
    IMovable movable;

    void Start() => movable = GetComponent<IMovable>();    

    void FixedUpdate() => movable.Move();
}
