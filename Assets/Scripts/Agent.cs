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
    public float mass; //mass of the agent, defaulted to 1

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
    public abstract Vector3 CalcSteeringForces();
    /// <summary>
    /// Calculates final acceleration on an agent
    /// </summary>
    /// <param name="force">Net force acting on an agent</param>
    public void ApplyForce(Vector3 force)
    {
        
        Debug.Log("apply force force" + force);
        Vector3 Accel = force / mass;
        Debug.Log("apply force result" + Accel);
        acceleration += Accel;
        Debug.Log("apply force acceleration" + acceleration);
        //acceleration = acceleration + (force / mass);
    }
}
