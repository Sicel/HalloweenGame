using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    Vector2 Upper;
    Vector2 Lower;
    //public float accelerationValue; //how fast the enemy should accelerate
    bool binDirection; // determines which direction the enemy should move
    Vector2 currentPos;
    bool onGround;
    Rigidbody2D rigidB;
    public float moveSpeed = 20;
    public Vector2 startPos;

    private void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
        startPos = transform.position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        //move speed was switching each frame, causing the jitter
        //if (rigidB.position.x > startPos.x + 4 || rigidB.position.x < startPos.x - 4)
        //{
        //    moveSpeed = -moveSpeed;
        //}
        if(rigidB.position.x > startPos.x + 4)
        {
            moveSpeed = -5;
        }
        if(rigidB.position.x < startPos.x - 4)
        {
            moveSpeed = 5;
        }
        
        //Debug.Log("rigidb " + rigidB.position.x);
        //Debug.Log("transform " + transform.position.x);





        rigidB.velocity = new Vector2(moveSpeed, rigidB.velocity.y);
    }

    /*
    // Update is called once per frame
    void Update()
    {
       // currentPos = transform.position;
        if(currentPos.x >= Upper.x)
        {
            binDirection = false;
        }
        if (currentPos.x <= Lower.x)
        {
            binDirection = true;
        }

        Vector2 netForce = CalcSteeringForces();
        //Debug.Log(onGround);
        //gravity application - move to calc steering forces
        if (onGround == false)
        {
            netForce.y += -gravity;
        }
        else
        {
            velocity.y = 0;
        }


        ApplyForce(netForce);


       


        velocity += acceleration * Time.deltaTime; 
        agentPosition += velocity * Time.deltaTime;
        acceleration = Vector3.zero; //reset acceleration for next loop
       // transform.position = agentPosition;
        //transform.right = velocity;

        //Move();   
    }

    public override Vector3 CalcSteeringForces()
    {
        

        Vector3 netForce = Vector3.zero;
        //current movement has enemy accelerate to a certian velocity, then slide to a stop
        if (binDirection == true && velocity.x < 2) //move to the right
        {
            netForce += Vector3.right * accelerationValue;

        }
        else if (velocity.x > -2) //move to the left
        {
            netForce += Vector3.right * accelerationValue * -1;

        }
        else //apply friction
        {
            if(velocity.x > Mathf.Abs(0.1f))
            {
                applyFriction(1);
            }


        }

       



        if(Mathf.Abs(netForce.x) > maxSpeed)
        {
            netForce.x = maxSpeed;
        }

        //netForce = netForce.normalized;
        //netForce = netForce * maxSpeed;
        return netForce;

    }
    */
    
}
