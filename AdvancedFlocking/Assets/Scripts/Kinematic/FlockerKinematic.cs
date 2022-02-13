using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockerKinematic : BlendedKinematic
{
   // public BlendedMoverType movementBehavior2;

    // Start is called before the first frame update
    public override void Start()
    {
        steeringUpdate = new SteeringOutput(); // default to nothing. should be overriden by children
        rb = gameObject.GetComponent<Rigidbody>();
        KinematicBlendedPriorityMoverFactory kbmf = new KinematicBlendedPriorityMoverFactory();
        mover = kbmf.Create(movementBehavior2, rotationBehavior, target, maxAcceleration, maxAngularAcceleration, this);
    }
}
