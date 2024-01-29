using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatableObjController : MonoBehaviour
{
    IRotatable rotatable;

    void Start() => rotatable = GetComponent<IRotatable>();

    void Update() => rotatable.Rotate();
}
