using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BeamView : MonoBehaviour
{
    ParticleSystem beam;
    IRadiated radiatedObj;
    Action ActivateBeam;

    void Awake()
    {
        beam = GetComponent<ParticleSystem>();
        radiatedObj = transform.parent.GetComponent<IRadiated>();
        ActivateBeam = () => beam.Play();
    }

    void Start() => radiatedObj.MoveForward += ActivateBeam;
}
