using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : SteeringBehavior
{
    // the threshold to take action
    float threshold = 2.5f; // 5

    // the constant coefficient of decay for the inverse square law
    float decayCoefficient = 100f;

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();

        Vector3 direction = character.transform.position - target.transform.position;
        float distance = direction.magnitude;

        if (distance < threshold)
        {
            // calculate the strength of repulsion
            float strength = Mathf.Min(decayCoefficient / (distance * distance), maxAcceleration);
            direction.Normalize();
            result.linear += strength * direction;
        }
        //Debug.Log(result.linear);
        return result;
    }
}
