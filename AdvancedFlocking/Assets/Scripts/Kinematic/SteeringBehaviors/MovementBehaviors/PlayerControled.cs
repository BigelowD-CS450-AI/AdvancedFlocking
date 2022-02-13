using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlled : SteeringBehavior
{    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        result.linear = character.transform.forward * Input.GetAxisRaw("Vertical") + character.transform.right * Input.GetAxisRaw("Horizontal");
        result.linear.Normalize();
        result.linear *= maxAcceleration;
        //Debug.Log(result.linear);
        result.angular = 0;
        return result;
    }
}
