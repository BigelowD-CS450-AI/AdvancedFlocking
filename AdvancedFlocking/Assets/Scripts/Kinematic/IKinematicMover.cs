using UnityEngine;

public interface IKinematicMover
{
    Vector3 Accelerate();
    float AngularAccelerate();
    void SetCharacter(Kinematic character);
    void SetMaxAcceleration(float maxAcceleration);
    void SetMaxAngularAcceleration(float maxAngularAcceleration);
    void SetMoveType(SteeringBehavior moveType);
    void SetRotateType(SteeringBehavior rotateType);
    void SetTarget(GameObject target);
}