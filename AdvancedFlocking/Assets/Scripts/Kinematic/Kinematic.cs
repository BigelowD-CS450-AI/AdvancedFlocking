using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kinematic : MonoBehaviour
{
    public Vector3 linearVelocity;
    public float angularVelocity;  // Millington calls this rotation
    // because I'm attached to a gameobject, we also have:
    // rotation <<< Millington calls this orientation
    // position
    public float maxSpeed = 10.0f;
    public float maxAngularVelocity = 145.0f; // degrees
    public float maxAcceleration = 1.0f;
    public float maxAngularAcceleration = 45.0f;
    protected Rigidbody rb;
    public IKinematicMover mover;
    public GameObject target;

    // child classes will get new steering data for use in our update function
    protected SteeringOutput steeringUpdate;

    public MovementBehavior movementBehavior;
    public RotationBehavior rotationBehavior;

    // Start is called before the first frame update
    public virtual void Start()
    {
        steeringUpdate = new SteeringOutput(); // default to nothing. should be overriden by children
        rb = gameObject.GetComponent<Rigidbody>();
        KinematicMoverFactory kmf = new KinematicMoverFactory();
        mover = kmf.Create(movementBehavior, rotationBehavior, target, maxAcceleration, maxAngularAcceleration, this);
    }

    protected virtual void GetSteeringUpdate()
    {
        steeringUpdate = new SteeringOutput();
        steeringUpdate.linear = mover.Accelerate();
        steeringUpdate.angular = mover.AngularAccelerate();
    }

    public virtual void SetTarget(GameObject target)
    {
        this.target = target;
        mover.SetTarget(target);
    }

    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        
        // something is breaking my angular velocity
        // check here and reset it if it broke
        if (float.IsNaN(angularVelocity))
        {
            angularVelocity = 0.0f;
        }

        // update my position and rotation - Millington p. 58, lines 7-9
        //attempted rigidbody solutution
        rb.MovePosition(rb.position + linearVelocity * Time.fixedDeltaTime);
        //old transform solution
        //this.transform.position += linearVelocity * Time.deltaTime;
        if (Mathf.Abs(angularVelocity) > 0.01f)
        {
            Vector3 v = new Vector3(0, angularVelocity, 0);
            //attempted rigidbody solutution
            rb.MoveRotation(rb.rotation * (Quaternion.Euler(new Vector3(0, angularVelocity, 0) * Time.fixedDeltaTime) ) );
            //old transform solution
            //this.transform.eulerAngles += v * Time.deltaTime;
        }

        GetSteeringUpdate();
        // update linear and angular velocities - I might be accelerating or decelerating, etc.
        // Millington p. 58, lines 11-13
        if (steeringUpdate != null)
        {
            linearVelocity += steeringUpdate.linear * Time.deltaTime;
            angularVelocity += steeringUpdate.angular * Time.deltaTime;
        }

        // check for speeding and clip
        // Millington p.58, lines 15-18
        // note that Millington's pseudocode on p.58 does not clip angular velocity, but we do here
        if (linearVelocity.magnitude > maxSpeed)
        {
            linearVelocity.Normalize();
            linearVelocity *= maxSpeed;
        }
        if (Mathf.Abs(angularVelocity) > maxAngularVelocity)
        {
            angularVelocity = maxAngularVelocity * (angularVelocity / Mathf.Abs(angularVelocity));
        }
    }

}
