using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidVelocityMatch : SteeringBehavior
{
    FlockManager fm;
    public override SteeringOutput getSteering()
    {
        if (fm == null)
            fm = target.GetComponent<FlockManager>();
        SteeringOutput result = new SteeringOutput();
        result.linear = fm.GetFlockVelocity();
        result.angular = 0;
        return result;
    }
}
