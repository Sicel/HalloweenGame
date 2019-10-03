using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rigidB; // Needed to allow movement

    [SerializeField]
    float speed = 20;

    [SerializeField]
    float jumpForce = 100; 

    [SerializeField]
    bool onGround = false;

    enum Costumes
    {
        None,
        Cat,
        Witch
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rigidB.velocity = new Vector2(horizontal * speed, rigidB.velocity.y);

        // Allows jumping only if player is on ground
        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.W))
                rigidB.AddForce(new Vector2(0, jumpForce));
        }
    }

    // When player comes into contact with another object
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
