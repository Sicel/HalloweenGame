using System;
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

    SpriteRenderer spriteR;
    int numCostumes = Enum.GetNames(typeof(Costumes)).Length;

    [SerializeField]
    List<Color32> costumeColors =  new List<Color32>();

    Costumes currentCostume = Costumes.None;

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

        spriteR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        ChangeCostume();
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

    void ChangeCostume()
    {
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            currentCostume--;
        }
        if (Input.GetKeyDown(KeyCode.Period))
        {
            currentCostume++;
        }

        if (currentCostume < 0)
        {
            currentCostume = (Costumes)numCostumes - 1;
        }
        else if ((int)currentCostume >= numCostumes)
        {
            currentCostume = 0;
        }

        switch (currentCostume)
        {
            case Costumes.None:
                break;
            case Costumes.Cat:
                break;
            case Costumes.Witch:
                break;
        }

        spriteR.color = costumeColors[(int)currentCostume];
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

    private void OnGUI()
    {
        GUILayout.Box("Current Costume: " + currentCostume);
    }
}
