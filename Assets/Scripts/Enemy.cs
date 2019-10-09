using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Agent
{
    Vector2 Upper;
    Vector2 Lower;
    public float accelerationValue;
    bool binDirection;
    Vector2 currentPos;
    bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        Upper = transform.position;
        Upper.x += 4;
        Lower = transform.position;
        Lower.x -= 4;
        //rigidB = GetComponent<Rigidbody2D>();
        binDirection = false;
        currentPos = transform.position;
        onGround = false;
        agentPosition = transform.position;
        //maxSpeed = 10f;
       //mass = 5f;
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
        Debug.Log(onGround);
        if (onGround == false)
        {
            netForce.y += -9.81f;
        }
        else
        {
            velocity.y = 0;
        }


        ApplyForce(netForce);


       


        velocity += acceleration * Time.deltaTime;
        agentPosition += velocity * Time.deltaTime;
        acceleration = Vector3.zero;
        transform.position = agentPosition;
        //transform.right = velocity;

        //Move();   
    }

    public override Vector3 CalcSteeringForces()
    {
        

        Vector3 netForce = Vector3.zero;

        if(binDirection == true /*&& velocity.x < 2*/)
        {
            netForce += Vector3.right * accelerationValue;
            
        }
        else /*if(velocity.x > -2)*/
        {
            netForce += Vector3.right * accelerationValue * -1;
            
        }

        

        netForce = netForce.normalized;
        netForce = netForce * maxSpeed;
        //Debug.Log(netForce);
        return netForce;

    }

    void Move()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        int speed = 0;

        if(binDirection == true)
        {
            speed = 4;
        }
        else
        {
            speed = -4;
        }

        //rigidB.velocity = new Vector2(speed, rigidB.velocity.y);


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
