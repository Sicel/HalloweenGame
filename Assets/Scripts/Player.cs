using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rigidB;

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

        if (onGround)
        {
            if (Input.GetKeyDown(KeyCode.W))
                rigidB.AddForce(new Vector2(0, jumpForce));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "Ground")
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            onGround = false;
        }
    }
}
