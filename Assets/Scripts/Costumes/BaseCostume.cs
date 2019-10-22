using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Basis for all other costumes
/// Cannot be called
/// **Made these values public for the Magic Rush movement,
/// **we can discuss how we want to implement it at a meeting.
/// **However, I feel this is best for our current setup
/// **-Anthony
/// </summary>
public abstract class BaseCostume : ScriptableObject
{
    [Header("Base Costume Stats")]
    public float strength = 5; // Costume strength

    public float baseSpeed = 20; // Speed

    public float jumpForce = 8; // Force of jump

    public static Player player;

    public float maxResource = 100;

    public float currentResource = 100;

    public float prevResource;

    public float resourceConsumptionRate = 2f;

    public float resourceRegenRate = 1f;

    public float timeUntilResourceRegen = 1.5f;

    [SerializeField]
    float currentTime = 0;


    /// <summary>
    /// Allows movement and sprinting on the horizontal axis 
    /// </summary>
    protected virtual void HorizontalMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");

        player.RigidBody.velocity = new Vector2(horizontal * baseSpeed, player.RigidBody.velocity.y);
        
    }

    public virtual void Update()
    { 
        Move();
        if (prevResource <= currentResource)
        {
            if (currentResource < maxResource && currentTime >= timeUntilResourceRegen)
            {
                RegenResource();
            }
        }
        else
        {
            currentTime = 0;
        }

        currentTime += Time.deltaTime;
        prevResource = currentResource;

        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
    }

    public virtual void Attack()
    {

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
            player.RigidBody.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);

    }

    /// <summary>
    /// All of the costume's movement abilities
    /// </summary>
    public virtual void Move()
    {
        HorizontalMovement();

        // Allows jumping only if player is on ground
        if (player.onGround)
            Jump();
    }

    void RegenResource()
    {
        currentResource += resourceRegenRate * Time.deltaTime;
    }
}
