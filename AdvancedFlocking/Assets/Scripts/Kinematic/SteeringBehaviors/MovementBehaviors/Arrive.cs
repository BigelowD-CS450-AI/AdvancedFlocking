using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// based on Millington pp. 62-63
public class Arrive : SteeringBehavior
{
    // the radius for arriving at the target
    float arriveRadius = 1.5f;

    // the radius for beginning to slow down
    float slowRadius = 3f;

    // the time over which to achieve target speed
    float timeToTarget = 0.1f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        // get the direction to the target
        Vector3 direction = target.transform.position - character.transform.position;
        float distance = direction.magnitude;

        //if (distance < targetRadius)
        //{
        //    return null;
        //}

        // if we are outside the slow radius, then move at max speed
        float targetSpeed = 0f;
        if (distance > slowRadius)
        {
            targetSpeed = maxAcceleration;
            //Debug.Log("over max");
        }
        else // otherwise calculate a scaled speed
        {
            //Debug.Log("under max");
            //targetSpeed = -(maxSpeed * distance / slowRadius); // should slowRadius here instead be targetRadius?
            targetSpeed = maxAcceleration * (distance - arriveRadius) / arriveRadius;
        }

        // the target velocity combines speed and direction
        Vector3 targetVelocity = direction;
        targetVelocity.Normalize();
        targetVelocity *= targetSpeed;

        // acceleration tries to get to the target velocity
        result.linear = targetVelocity - character.linearVelocity;
        result.linear /= timeToTarget;

        // check if the acceleration is too fast
        if (result.linear.magnitude > maxAcceleration)
        {
            result.linear.Normalize();
            result.linear *= maxAcceleration;
        }
        //Debug.Log("hi");
        return result;
    }
}
