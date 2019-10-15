using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    //movement vectors
    public Vector3 agentPosition; //current position of agent
    public Vector3 acceleration; //value to be added (or subtracted) to velocity
    public Vector3 direction; //normalized direction vector
    public Vector3 velocity; //speed and direction
    public float maxSpeed; //maximum speed the agent can move at, defaluted to 10
    public float accelerationValue; //magnitude of acceleration, independent of maxSpeed
    public float mass; //mass of the agent, defaulted to 1
    public float gravity;
    public bool onGround = false;

    // Start is called before the first frame update
    protected void Start()
    {
       //maxSpeed = 10;
        //mass = 5f;
    }

    // Update is called once per frame
    protected void Update()
    {
        
    }

    /// <summary>
    /// Implemented by each agent, calculates net velocity and direction
    /// </summary>
    //public abstract Vector3 CalcSteeringForces();

    /// <summary>
    /// Calculates final acceleration on an agent
    /// </summary>
    /// <param name="force">Net force acting on an agent</param>
    public void ApplyForce(Vector3 force)
    {
        acceleration += force / mass;
    }

    /// <summary>
    /// Applied friction to an object based on gravity and coefficient of friction
    /// </summary>
    /// <param name="mu">The coefficient of friction</param>
    /// <returns>Frictional force</returns>
    public Vector3 applyFriction(float mu)
    {
        Vector3 frictionForce = Vector3.zero;

        frictionForce.x = (gravity*mass) * mu;

        return frictionForce;
    }

    // When player comes into contact with another object
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    // When player leaves contact with another object
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
