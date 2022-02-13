using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBlendedPriorityMoverFactory : KinematicMoverFactory
{
    public Flocker Create(BlendedMoverType moverType, RotationBehavior rotationBehavior, GameObject target, float maxAcceleration, float maxAngularAcceleration, Kinematic character)
    {
        List<BlendedSteeringBehavior> subresult = new List<BlendedSteeringBehavior>();
        Flocker result = new Flocker();
        switch (moverType)
        {
            case BlendedMoverType.Flocker:
                //by placing obstavce avoidance first gves it higher priority
                subresult.Add(new BlendedSteeringBehavior(new ObstacleAvoidance(character), 0.5f));
                subresult.Add(new BlendedSteeringBehavior(new BoidSeparation(), 0.5f));
                subresult.Add(new BlendedSteeringBehavior(new Arrive(), 0.1f));
                result.SetMoveType(subresult);
                subresult = new List<BlendedSteeringBehavior>();
                subresult.Add(new BlendedSteeringBehavior(new BoidSeparation(), 0.7f));
                subresult.Add(new BlendedSteeringBehavior(new Seek(), 0.3f));
                subresult.Add(new BlendedSteeringBehavior(new BoidVelocityMatch(), 0.1f));
                result.SetMoveType(subresult);

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
