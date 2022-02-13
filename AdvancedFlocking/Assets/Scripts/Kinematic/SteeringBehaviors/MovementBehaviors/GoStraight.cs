using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoStraight : SteeringBehavior
{
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        result.linear = character.transform.forward*maxAcceleration;
        result.angular = 0;
        return result;
    }
}
