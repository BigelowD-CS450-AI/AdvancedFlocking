using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : SteeringBehavior
{
    protected virtual Vector3 getTargetPosition()
    {
        return target.transform.position;
    }
    protected virtual Vector3 getVecDistance(Vector3 targetPosition)
    {
        return targetPosition - character.transform.position;
    }
    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        Vector3 targetPostion = getTargetPosition();
        if (targetPostion == Vector3.positiveInfinity)
        {
            return null;
        }
        //result.linear = target.transform.position - character.transform.position;
        result.linear = getVecDistance(targetPostion);
        Debug.DrawLine(character.transform.position, targetPostion);
        // give full acceleration along this direction
        result.linear.Normalize();
        result.linear *= maxAcceleration;
        //Debug.Log(result.linear);
        result.angular = 0;
        return result;
    }
}
