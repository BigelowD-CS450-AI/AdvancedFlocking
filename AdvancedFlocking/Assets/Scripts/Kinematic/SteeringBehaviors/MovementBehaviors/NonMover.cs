 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonMover : SteeringBehavior
{
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        // give full acceleration along this direction
        result.linear = Vector3.zero;
        result.angular = 0;
        return result;
    }
}
