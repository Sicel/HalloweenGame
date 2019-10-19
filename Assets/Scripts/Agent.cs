using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Agent : MonoBehaviour
{
    [Header("Agent")]

    public int health = 3; // Health points
    public bool onGround = false;
    public bool isFalling = false;
    protected Vector3 prevLocation;

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
    public float rayDistance = 0.5f;

    protected void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        collisionBox = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    protected void Start()
    {
       //maxSpeed = 10;
        //mass = 5f;
    }

    // Update is called once per frame
    protected void Update()
    {
        DetectGround();
        prevLocation = transform.position;
    }

    // Trying to detect the ground using raycast
    void DetectGround()
    {
        float bottomEdge = transform.position.y - collisionBox.bounds.extents.y;
        float leftEdge = transform.position.x - collisionBox.bounds.extents.x;
        float rightEdge = transform.position.x + collisionBox.bounds.extents.x;

        Ray2D leftRay = new Ray2D(new Vector2(leftEdge, bottomEdge), new Vector2(-transform.position.x, bottomEdge - 0.5f));
        Ray2D rightRay = new Ray2D(new Vector2(rightEdge, bottomEdge), new Vector2(transform.position.x, bottomEdge - 0.5f));

        //RaycastHit2D thingHit = Physics2D.Raycast(new Vector2(transform.position.x, bottomEdge), Vector2.down);
        //switch (thingHit.collider.gameObject.tag)
        //{
        //    case "Ground":
        //        onGround = true;
        //}
    }

    // Draws the raycast
    private void OnDrawGizmos()
    {
        //float bottomEdge = transform.position.y - collisionBox.bounds.extents.y;
        //float leftEdge = transform.position.x - collisionBox.bounds.extents.x;
        //float rightEdge = transform.position.x + collisionBox.bounds.extents.x;
        //
        //Ray2D leftRay = new Ray2D(new Vector2(leftEdge, bottomEdge), new Vector2(1, -1));
        //Ray2D rightRay = new Ray2D(new Vector2(rightEdge, bottomEdge), new Vector2(-1, -1));
        //
        //Gizmos.DrawRay(leftRay.origin, leftRay.direction);
        //Gizmos.DrawRay(rightRay.origin, rightRay.direction);
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
