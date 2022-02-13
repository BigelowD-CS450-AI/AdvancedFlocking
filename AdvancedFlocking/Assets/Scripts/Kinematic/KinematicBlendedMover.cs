using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicBlendedMover : KinematicMover
{
    protected new List<BlendedSteeringBehavior> moveType = new List<BlendedSteeringBehavior>();
    ///private Kinematic character;
    //private GameObject target;
      
    public void SetMoveType(BlendedSteeringBehavior moveType)
    {
       this.moveType.Add(moveType);
    }
    public override Vector3 Accelerate()
    {
        Vector3 result = Vector3.zero;
        foreach (BlendedSteeringBehavior bsb in moveType)
        {
            Vector3 subresult = bsb.GetSteering().linear;
            result += subresult;
           // Debug.Log(this + "loop result " + subresult);
        }
        //Debug.Log(this + "result is" + result);
        result = new Vector3(result.x, 0.0f, result.z);
        return result;
    }
    public override void SetCharacter(Kinematic character)
    {
        //this.character = character;
        foreach (BlendedSteeringBehavior bsb in moveType)
            bsb.steeringBehavior.character = character;
        rotateType.character = character;
    }
    public override void SetTarget(GameObject target)
    {
        //this.target = target;
        foreach (BlendedSteeringBehavior bsb in moveType)
            bsb.steeringBehavior.target = target;
        rotateType.target = target;
    }
    public override void SetMaxAcceleration(float maxAcceleration)
    {
        foreach (BlendedSteeringBehavior bsb in moveType)
            bsb.steeringBehavior.maxAcceleration = maxAcceleration;
    }
}
