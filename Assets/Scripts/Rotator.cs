using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator
{
    float RotationSpeed { get; set; }
    Vector2 currentDirection = new Vector2(0, 1);

    public Rotator(float rotationSpeed) => RotationSpeed = rotationSpeed;

    public void RotateTo(Transform currentObject, Vector3 target)
    {
        target = target - currentObject.position;
        target.Normalize();
        currentDirection = Vector2.Lerp(currentDirection, target, Time.deltaTime * RotationSpeed);
        currentObject.up = currentDirection;
    }
}
