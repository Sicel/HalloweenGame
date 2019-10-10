using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis for all other costumes
/// Cannot be called
/// </summary>
public abstract class BaseCostume : ScriptableObject
{
    [SerializeField]
    protected float strength = 5; // Costume strength

    [SerializeField]
    protected float baseSpeed = 20; // Speed

    [SerializeField]
    [Range(1.0f, 2.0f)]
    protected float sprintMultiplier = 1.5f; // Sprint speed (must be a value between 1 and 2)

    [SerializeField]
    protected float jumpForce = 100; // Force of jump

    [SerializeField]
    protected bool isAbleToFly = false;

    //public float maxSpeed { get { return baseSpeed; } } 
    public float sprintSpeed { get { return baseSpeed * sprintMultiplier; } }

    /// <summary>
    /// Allows movement and sprinting on the horizontal axis 
    /// </summary>
    protected void HorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Player.rigidB.velocity = new Vector2(horizontal * sprintSpeed, Player.rigidB.velocity.y);
        }
        else
        {
            Player.rigidB.velocity = new Vector2(horizontal * baseSpeed, Player.rigidB.velocity.y);
        }
    }

    /*
    public override Vector3 CalcSteeringForces()
    {
        //throw new System.NotImplementedException();
        Vector3 netForce = Vector3.zero;

        float horizontal = Input.GetAxis("Horizontal");
        //Debug.Log(horizontal);


        if (Mathf.Abs(horizontal) > 0)
        {
            netForce += Vector3.right * horizontal * maxSpeed;
        }
        else
        {
            if (Mathf.Abs(velocity.x) < 1f)
            {
                velocity.x = 0;
            }
            else if (velocity.x > 0)
            {
                netForce -= applyFriction(accelerationValue);
            }
            else if (velocity.x < 0)
            {
                netForce += applyFriction(accelerationValue);
            }
        }

        //if (Mathf.Abs(netForce.x) > maxSpeed)
        //{

        //    if (netForce.x > 0)
        //    {
        //        netForce.x = baseSpeed;
        //    }
        //    else
        //    {
        //        netForce.x = -baseSpeed;
        //    }
        //}
        return netForce;

    }
    */

    /// <summary>
    /// Applys a force that allows the player to jump
    /// </summary>
    protected void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W))
            Player.rigidB.AddForce(new Vector2(0, jumpForce));

    }

    /// <summary>
    /// All of the costume's movement abilities
    /// </summary>
    public virtual void Move()
    {

        //Vector2 netForce = CalcSteeringForces();
        //ApplyForce(netForce);
        //
        //velocity += acceleration * Time.deltaTime;
        //if (Mathf.Abs(velocity.x) > baseSpeed)
        //{
        //
        //    if (velocity.x > 0)
        //    {
        //        velocity.x = baseSpeed;
        //    }
        //    else
        //    {
        //        velocity.x = -baseSpeed;
        //    }
        //}
        //agentPosition += velocity * Time.deltaTime;
        //
        //acceleration = Vector3.zero; //reset acceleration for next loop
        //Player._transform.position = agentPosition;


        HorizontalMovement();

        // Allows jumping only if player is on ground
        if (Player.onGround)
            Jump();
    }
}
