using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector2 Upper;
    Vector2 Lower;
    Rigidbody2D rigidB;
    bool direction;
    Vector2 currentPos;
    bool onGround;
    // Start is called before the first frame update
    void Start()
    {
        Upper = transform.position;
        Upper.x += 4;
        Lower = transform.position;
        Lower.x -= 4;
        rigidB = GetComponent<Rigidbody2D>();
        direction = false;
        currentPos = transform.position;
        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = transform.position;
        if(currentPos.x >= Upper.x)
        {
            direction = false;
        }
        if (currentPos.x <= Lower.x)
        {
            direction = true;
        }


        Move();   
    }

    void Move()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        int speed = 0;

        if(direction == true)
        {
            speed = 4;
        }
        else
        {
            speed = -4;
        }

        rigidB.velocity = new Vector2(speed, rigidB.velocity.y);


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    // When player leaves contact with another object
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
