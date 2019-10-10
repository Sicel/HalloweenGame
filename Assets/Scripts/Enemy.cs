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
    // Start is called before the first frame update
    void Start()
    {
        Upper = transform.position;
        Upper.x += 4; // sets upper bound for enemy movement
        Lower = transform.position;
        Lower.x -= 4; // sets lower bound for enemy movement
        binDirection = false;
        currentPos = transform.position;
        onGround = false;
        agentPosition = transform.position;
        //gravity = 9.81f;
        
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
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
        transform.position = agentPosition;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }

    

    
}
