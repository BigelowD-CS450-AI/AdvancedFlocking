using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSeparation : Separation
{
    // the threshold to take action
    float threshold = 5f; // 5

    // the constant coefficient of decay for the inverse square law
    float decayCoefficient = 100f;
    private FlockManager fm;

    public BoidSeparation()
    {
        //fm = target.GetComponent<FlockManager>();
    }



    private void getClosestBoid()
    {
        if (fm==null)
            fm = target.GetComponent<FlockManager>();
        //Debug.Log(fm.boids.Count);
        float closestDist = float.PositiveInfinity;
        float boidDist;
        foreach(BlendedKinematic boid in fm.boids)
        {
            boidDist = Vector3.Distance(character.transform.position, boid.transform.position);
            if (boidDist < closestDist && boidDist > 0.01)
            {
                target = boid.gameObject;
                closestDist = boidDist;
            }
        }
        //Debug.Log(target);
    }

    public override SteeringOutput getSteering()
    {
        getClosestBoid();
        return base.getSteering();
    }
}
