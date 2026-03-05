using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipperXR : InteractivePuzzlePieceXR<HingeJoint>
{
    [Range(500f, 2000f)]
    public float power = 700f;
    public float forcepower = 900f;
    public float limitspower = 10f;



    void Awake ()
    {
        JointMotor flipperMotor = physicsComponent.motor;
        flipperMotor.targetVelocity = power;
        physicsComponent.motor = flipperMotor;
    }
    
    protected override void ApplyActiveState ()
    {
        physicsComponent.useMotor = true;
        
    }

    protected override void ApplyInactiveState ()
    {
        physicsComponent.useMotor = false;
    }
}
