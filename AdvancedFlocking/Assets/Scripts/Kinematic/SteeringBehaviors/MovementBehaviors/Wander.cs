using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander : SteeringBehavior
{

    private const float wanderRadius = 2.0f;

    private void GenerateTargetPosition()
    {
        float randomRotation = Random.value * 2 * Mathf.PI;
        if (target != null)
            GameObject.Destroy(target);
        GameObject newTarget = new GameObject("WanderTarget");
        newTarget.transform.position = new Vector3(Mathf.Cos(randomRotation), 0, Mathf.Sin(randomRotation)) * wanderRadius;
        newTarget.transform.position += character.transform.forward * 4;
        newTarget.transform.position = character.transform.position + newTarget.transform.position;
       // target = newTarget;
        character.SetTarget(newTarget);
    }

    public override SteeringOutput getSteering()
    {
        SteeringOutput result = new SteeringOutput();
        if (target == null || (character.transform.position - target.transform.position).magnitude < 2.0f)
            GenerateTargetPosition();

        Debug.DrawLine(character.transform.position, target.transform.position);

        //result.linear = target.transform.position - character.transform.position;
        result.linear = target.transform.position - character.transform.position;

        // give full acceleration along this direction
        result.linear.Normalize();
        result.linear *= maxAcceleration;

        result.angular = 0;
        return result;
    }
}
