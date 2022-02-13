using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlendedMoverType
{
    Flocker
}

public class KinematicBlendedMoverFactory : KinematicMoverFactory
{
    public KinematicBlendedMover Create(BlendedMoverType moverType, RotationBehavior rotationBehavior, GameObject target, float maxAcceleration, float maxAngularAcceleration, Kinematic character)
    {
        KinematicBlendedMover result = new KinematicBlendedMover();
        switch (moverType)
        {
            case BlendedMoverType.Flocker:
                result.SetMoveType(new BlendedSteeringBehavior(new BoidSeparation(), 0.2f));
                //result.SetMoveType(new BlendedSteeringBehavior(new BoidSeparation(), 1.0f));
                result.SetMoveType(new BlendedSteeringBehavior(new Arrive(), 0.5f));
                result.SetMoveType(new BlendedSteeringBehavior(new BoidVelocityMatch(), 0.3f));
                //result.SetMoveType(new BlendedSteeringBehavior(new ObstacleAvoidance(character), 15f));
                break;
            default:
                //flocker is the default value
                result.SetMoveType(new BlendedSteeringBehavior(new Separation(), 0.5f));
                break;
        }
        switch (rotationBehavior)
        {
            case RotationBehavior.Align:   
                result.SetRotateType(new Align());
                break;
            case RotationBehavior.Face:
                result.SetRotateType(new Face());
                break;
            case RotationBehavior.LookWhereGoing:
                result.SetRotateType(new LookWhereGoing());
                break;
        }
        //foreach(BlendedSteeringBehavior bsb in result.move)
        result.SetTarget(target);
        result.SetMaxAcceleration(maxAcceleration);
        result.SetMaxAngularAcceleration(maxAngularAcceleration);
        result.SetCharacter(character);
        return result;
    }
}
