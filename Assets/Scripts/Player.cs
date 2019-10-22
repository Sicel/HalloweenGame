using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public bool touchingEnemy = false; //is the player in contact with an enemy

    public GameObject collidingEnemy; //enemy player is colliding with

    public float flightTime = 0; //How long has the player been flying through knockback

    // Public magicRush bool and timer
    public bool magicRush = false;

    public float timer = 2f;

    public BaseCostume currentCostumeScript = null; // Script of current costume

    public bool isAbleToFly = true; // Can the PLAYER fly

    [SerializeField]
    List<Color32> costumeColors = new List<Color32>(); // Colors for the temp player

    [SerializeField]
    Costume currentCostume; // Current costume as enum

    SpriteRenderer spriteR; // Player's Sprite rendere (temp)
    int numCostumes = CostumeManager.numCostumes; // Num of total costumes used for iteration in ChangeCostume()
    Vector3 startingScale;
    Vector3 alteredScale;
    bool altered;

    public string CurrentCostume { get { return currentCostume.ToString(); } } // Current costume as string
    public Rigidbody2D RigidBody { get { return rigidBody; } }

    new private void Awake()
    {
        base.Awake();
        spriteR = GetComponent<SpriteRenderer>(); // Gets sprite renderer component
        currentCostume = Costume.Bunny;
        BaseCostume.player = this;
    }

    new private void Start()
    {
        currentCostumeScript = LevelManager.CostumeList[(int)currentCostume]; // Sets the initial costume
        startingScale = transform.localScale;
        alteredScale = new Vector2(startingScale.y, startingScale.x);
    }

    // Update is called once per frame
    new void Update()
    {
        //Debug.Log(onGround);
        base.Update();
        ChangeCostume();
        currentCostumeScript.Update(); // Moves using currently equipped costume's movement method

        // Player rushes
        if (magicRush)
        {
            MagicRush();
        }

        if(touchingEnemy == true)
        {
            flightTime = Time.deltaTime; //if touching enemy, start knockback
            //put damage here
        }

        if (flightTime > 0 && flightTime < 0.5f) //if player has been flying more than .5 s, stop knockback
        {
            Knockback(20);
            //add to flight time 
            flightTime += Time.deltaTime;
            if(flightTime > 2)
            {
                flightTime = 0;
            }
        }

        if (transform.position.y < -25)
        {
            LevelManager.Reset();
        }

    }

    /// <summary>
    /// Changes costume using ',' and '.' keys
    /// </summary>
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

        // If at the begining or end of the list of costumes
        if (currentCostume < 0)
        {
            currentCostume = (Costume)numCostumes - 1;
        }
        else if ((int)currentCostume >= numCostumes)
        {
            currentCostume = 0;
        }

        if (currentCostume == Costume.Cat)
        {
            if (!altered)
            {
                transform.localScale = alteredScale;
                altered = true;
            }
        }
        else
        {
            transform.localScale = startingScale;
            altered = false;
        }

        currentCostumeScript = LevelManager.CostumeList[(int)currentCostume]; // Sets costume

        spriteR.color = costumeColors[(int)currentCostume]; // Changes color of temp player
    }

    // When player comes into contact with another object
    new protected void OnCollisionEnter2D(Collision2D collision)
    {
        //base.OnCollisionEnter2D(collision);

        switch (collision.gameObject.tag)
        {
            case "Enemy":
                touchingEnemy = true;
                collidingEnemy = collision.gameObject;
                break;
        }
    }

    new protected void OnCollisionExit2D(Collision2D collision)
    {
        //base.OnCollisionExit2D(collision);

        if (collision.gameObject.tag == "Enemy")
        {
            touchingEnemy = false;
            //collidingEnemy = collision.gameObject;
        }
    }

    // Collisions on Triggers for the no fly zone
    // all of it seems pretty self explanatory. 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "noFly":
                Debug.Log("Can't fly");
                isAbleToFly = false;
                break;
            // If the objet collides with the candy object
            case "Candy":
                // Set our MR bool
                magicRush = true;
                Destroy(collision.gameObject);
                break;
            case "Water":
                LevelManager.Reset();
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "noFly")
        {
            isAbleToFly = true;
            Debug.Log("Can fly");
        }
        
    }

    // Displays current costume on screen
    private void OnGUI()
    {
        GUILayout.Box("Current Costume: " + currentCostume + "\nCurrent Resource: " + Mathf.Floor(currentCostumeScript.currentResource));
    }

    // Method for Magic Rush
    private void MagicRush()
    {
        // Start the five second timer
        timer -= Time.deltaTime;

        // Mess with the values to give a rush
        //currentCostumeScript.strength *= 2;
        //currentCostumeScript.sprintMultiplier = 2;
        //currentCostumeScript.jumpForce += 50;
        Debug.Log("In MR method");

        // When the timer reaches zero, reset values and timer
        if(timer <=0)
        {
            magicRush = false;
            ///currentCostumeScript.strength /= 2;
            //currentCostumeScript.sprintMultiplier = 1.5f;
            //currentCostumeScript.jumpForce -= 50;
            timer = 2f;
            Debug.Log("Did MR method");
        }
    }
    /// <summary>
    /// Knocks player back after enemy contact
    /// </summary>
    /// <param name="Speed">How fast the player gets yeeted</param>
    private void Knockback(float Speed)
    {

        rigidBody.velocity = Vector3.zero;

        Vector3 pushVector = transform.position - collidingEnemy.transform.position;

        pushVector.Normalize();

        rigidBody.velocity = pushVector * Speed;
        //pushVector *= 500;

        //rigidB.AddForce(pushVector);

        Debug.Log("pushing");
    }
}
