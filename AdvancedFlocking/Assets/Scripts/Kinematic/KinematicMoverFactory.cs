using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicMoverFactory : MonoBehaviour
{

    public virtual KinematicMover Create(MovementBehavior movementBehavior, RotationBehavior rotationBehavior, GameObject target, float maxAcceleration, float maxAngularAcceleration, Kinematic character)
    {
        KinematicMover result = new KinematicMover();
        switch (movementBehavior)
        {
            case MovementBehavior.Arrive:
                result.SetMoveType( new Arrive() );
                break;
            case MovementBehavior.Flee:
                result.SetMoveType (new Flee() );
                break;
            case MovementBehavior.NonMover:
                result.SetMoveType(new NonMover());
                break;
            case MovementBehavior.PlayerControlled:
                result.SetMoveType(new PlayerControlled());
                break;
            case MovementBehavior.Pursue:
                result.SetMoveType( new Pursue() );
                break;
            case MovementBehavior.Seek:
                result.SetMoveType( new Seek() );
                break;
            case MovementBehavior.Seperation:
                result.SetMoveType( new Separation() );
                break;
            case MovementBehavior.Wander:
                result.SetMoveType(new Wander());
                break;
            default:
                result.SetMoveType(new GoStraight());
                break;
        }
        switch (rotationBehavior)
        {
            case RotationBehavior.Align:
                result.SetRotateType( new Align() );
                break;
            case RotationBehavior.Face:
                result.SetRotateType(new Face() );
                break;
            case RotationBehavior.LookWhereGoing:
                result.SetRotateType(new LookWhereGoing() );
                break;
        }
        result.SetTarget(target);
        result.SetMaxAcceleration(maxAcceleration);
        result.SetMaxAngularAcceleration(maxAngularAcceleration);
        result.SetCharacter(character);
        return result;
    }
}
