using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMover : IKinematicMover
{
    protected SteeringBehavior moveType;
    protected SteeringBehavior rotateType;
    ///private Kinematic character;
    //private GameObject target;

    public virtual void SetMoveType(SteeringBehavior moveType)
    {
        this.moveType = moveType;
    }

    public virtual void SetRotateType(SteeringBehavior rotateType)
    {
        this.rotateType = rotateType;
    }
    public virtual void SetCharacter(Kinematic character)
    {
        //this.character = character;
        moveType.character = character;
        rotateType.character = character;
    }
    public virtual void SetTarget(GameObject target)
    {
        //this.target = target;
        moveType.target = target;
        rotateType.target = target;
    }
    public virtual void SetMaxAcceleration(float maxAcceleration)
    {
        moveType.maxAcceleration = maxAcceleration;
    }
    public virtual void SetMaxAngularAcceleration(float maxAngularAcceleration)
    {
        rotateType.maxAcceleration = maxAngularAcceleration;
    }

    public virtual Vector3 Accelerate()
    {
        return moveType.getSteering().linear;
    }
    public virtual float AngularAccelerate()
    {
        return rotateType.getSteering().angular;
    }
}
