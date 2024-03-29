﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Agent : MonoBehaviour
{
    [Header("Agent")]
    public int health = 3; // Health points
    public bool onGround = false;
    public AttackBox attackBox;
    public TextMeshProUGUI healthDisplay;

    //movement vectors
    public Vector3 agentPosition; //current position of agent
    public Vector3 acceleration; //value to be added (or subtracted) to velocity
    public Vector3 direction; //normalized direction vector
    public Vector3 velocity; //speed and direction
    public float maxSpeed; //maximum speed the agent can move at, defaluted to 10
    public float accelerationValue; //magnitude of acceleration, independent of maxSpeed
    public float mass; //mass of the agent, defaulted to 1
    public float gravity;

    protected Rigidbody2D rigidBody;
    protected Collider2D collisionBox;

    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if (health <= 0)
                Die();
        }
    }

    protected void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collisionBox = GetComponent<Collider2D>();
    }

    //protected void Start(){}

    // Update is called once per frame
    protected virtual void Update()
    {
        healthDisplay.text = Health.ToString();
    }


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

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    // When agent comes into contact with another object
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            case "Platform":
                onGround = true;
                break;
        }
    }

    // When player leaves contact with another object
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            case "Platform":
                onGround = false;
                break;
        }
    }
}
