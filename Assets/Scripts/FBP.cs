using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FBP : Agent
{
    Vector2 currentPos;
    bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector2 netForce = CalcSteeringForces();
        //ApplyForce(netForce);

        //velocity += acceleration * Time.deltaTime;
       // agentPosition += velocity * Time.deltaTime;
       // acceleration = Vector3.zero; //reset acceleration for next loop
        //transform.position = agentPosition;
    }

    /*public override Vector3 CalcSteeringForces()
    {
        //throw new System.NotImplementedException();
        Vector3 netForce = Vector3.zero;

        float horizontal = Input.GetAxis("Horizontal");
        Debug.Log(horizontal);


        if(Mathf.Abs(horizontal) > 0)
        {
            netForce += Vector3.right * accelerationValue * horizontal;
        }
        else
        {
            if(Mathf.Abs(velocity.x) < 0.1f)
            {
                velocity.x = 0;
            }
            else if (velocity.x > 0)
            {
                netForce -= applyFriction(1);
            }
            else if(velocity.x < 0)
            {
                netForce += applyFriction(1);
            }
        }



        
        if (Mathf.Abs(netForce.x) > maxSpeed)
        {
            
            if(netForce.x > 0)
            {
                netForce.x = maxSpeed;
            }
            else
            {
                netForce.x = -maxSpeed;
            }
        }
        return netForce;
        
    }
    */
}
