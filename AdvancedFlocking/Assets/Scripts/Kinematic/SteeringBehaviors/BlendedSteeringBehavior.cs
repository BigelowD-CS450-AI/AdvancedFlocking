using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendedSteeringBehavior
{
    public SteeringBehavior steeringBehavior;
    //0-1 float for percentage strength
    public float strength;
    public SteeringOutput GetSteering()
    {
        SteeringOutput result = steeringBehavior.getSteering();
        //Debug.Log(this + "steerBej " + result);
        result.linear *= strength;
        //Debug.Log(this + "steerBej lin  " + result);
        result.angular *= strength;
        //result.linear = Vector3.zero;
        return result;
    }
    public BlendedSteeringBehavior(SteeringBehavior steeringBehavior, float strength)
    {
        this.steeringBehavior = steeringBehavior;
        this.strength = strength;
        //Debug.Log("str " + this.strength);
    }
}
