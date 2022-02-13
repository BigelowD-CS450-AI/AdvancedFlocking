using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendedKinematic : Kinematic
{
    //private Rigidbody rb;
    //public List<GameObject> targets;
    //public new KinematicBlendedMover mover;

    public BlendedMoverType movementBehavior2;

    // Start is called before the first frame update
    public override void Start()
    {
        steeringUpdate = new SteeringOutput(); // default to nothing. should be overriden by children
        rb = gameObject.GetComponent<Rigidbody>();
        KinematicBlendedMoverFactory kbmf = new KinematicBlendedMoverFactory();
        mover = kbmf.Create(movementBehavior2, rotationBehavior, target, maxAcceleration, maxAngularAcceleration, this);
    }
    protected override void GetSteeringUpdate()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = mover.Accelerate();
        Debug.Log(mover + " getSteer");
        steeringUpdate.angular = mover.AngularAccelerate();
    }
}
