using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTemp : MonoBehaviour
{
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
        if (rigidB.position.x > startPos.x + 4 || rigidB.position.x < startPos.x - 4)
            moveSpeed = -moveSpeed;

        rigidB.velocity = new Vector2(moveSpeed, rigidB.velocity.y);
    }
}
