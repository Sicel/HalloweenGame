using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector]
    Rigidbody2D rigidbody;

    [SerializeField]
    float speed = 20;

    [SerializeField]
    float jumpForce = 100;

    bool onGround = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");

        rigidbody.velocity = new Vector2(horizontal * speed, rigidbody.velocity.y);

        if (Input.GetKeyDown(KeyCode.W))
            rigidbody.AddForce(new Vector2(0, jumpForce));
    }
}
