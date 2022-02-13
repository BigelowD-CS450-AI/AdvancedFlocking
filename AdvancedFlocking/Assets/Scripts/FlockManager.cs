using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public List<BlendedKinematic> boids;
    public Vector3 curFlockPosition;
    public Vector3 curFlockVelocity;

    public void Start()
    {
        GameObject[] boidObjs = GameObject.FindGameObjectsWithTag("Boid");
        foreach (GameObject boidObj in boidObjs)
            boids.Add(boidObj.GetComponent<BlendedKinematic>());
    }

    private void CalcFlockPosition()
    {
        curFlockPosition = Vector3.zero;
        foreach (BlendedKinematic boid in boids)
        {
            curFlockPosition += boid.transform.position;
        }
        curFlockPosition /= boids.Count;
        transform.position = curFlockPosition;
    }

    private void CalcFlockVelocity()
    {
        curFlockVelocity = Vector3.zero;
        foreach(BlendedKinematic boid in boids)
        {
            curFlockVelocity += boid.linearVelocity;
        }
        curFlockVelocity /= boids.Count;
    }

    public Vector3 GetFlockPosition()
    {
        return curFlockPosition;
    }

    public Vector3 GetFlockVelocity()
    {
        return curFlockPosition;
    }

    public void FixedUpdate()
    {
        CalcFlockPosition();
        CalcFlockVelocity();
    }
}
