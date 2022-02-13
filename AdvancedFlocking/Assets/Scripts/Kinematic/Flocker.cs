using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flocker : KinematicBlendedMover
{
    protected new List<List<BlendedSteeringBehavior>> moveType = new List<List<BlendedSteeringBehavior>>();
    private float threshold = 0.2f;
    ///private Kinematic character;
    //private GameObject target;

    public void SetMoveType(List<BlendedSteeringBehavior> moveType)
    {
        this.moveType.Add(moveType);
    }
    public override Vector3 Accelerate()
    {
        Vector3 result = Vector3.zero;
        foreach (List<BlendedSteeringBehavior> lbsb in moveType)
        {
            result = Vector3.zero;
            foreach (BlendedSteeringBehavior bsb in lbsb)
            {
                Vector3 subresult = bsb.GetSteering().linear;
                //Debug.Log(bsb.GetType());
                result += subresult;
            }
            //Debug.Log("finished section");
            if (result.magnitude > threshold)
                return new Vector3(result.x, 0.0f, result.z);
        }
        return new Vector3(result.x, 0.0f, result.z);
    }
    public override void SetCharacter(Kinematic character)
    {
        //this.character = character;
        foreach (List<BlendedSteeringBehavior> lbsb in moveType)
        {
            foreach (BlendedSteeringBehavior bsb in lbsb)
                bsb.steeringBehavior.character = character;
        }
        rotateType.character = character;
    }
    public override void SetTarget(GameObject target)
    {
        //this.target = target;
        foreach (List<BlendedSteeringBehavior> lbsb in moveType)
        {
            foreach (BlendedSteeringBehavior bsb in lbsb)
                bsb.steeringBehavior.target = target;
        }
        rotateType.target = target;
    }
    public override void SetMaxAcceleration(float maxAcceleration)
    {
        foreach (List<BlendedSteeringBehavior> lbsb in moveType)
        {
            foreach (BlendedSteeringBehavior bsb in lbsb)
                bsb.steeringBehavior.maxAcceleration = maxAcceleration;
        }
    }
}
