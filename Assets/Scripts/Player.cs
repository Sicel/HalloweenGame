using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public static Rigidbody2D rigidB; // Needed to allow movement

    public static Transform _transform; // Needed to allow movement

    //public static bool onGround = false; // Is the player touching the ground?

    public bool touchingEnemy = false; //is the player in contact with an enemy

    public GameObject collidingEnemy; //enemy player is colliding with

    public float flightTime = 0; //How long has the player been flying through knockback

    // Public magicRush bool and timer
    public bool magicRush = false;

    public float timer = 2f;

    public BaseCostume currentCostumeScript = null; // Script of current costume

    [SerializeField]
    int health = 3; // Health points

    SpriteRenderer spriteR; // Player's Sprite rendere (temp)
    int numCostumes = CostumeManager.numCostumes; // Num of total costumes used for iteration in ChangeCostume()

    [SerializeField]
    List<Color32> costumeColors = new List<Color32>(); // Colors for the temp player

    [SerializeField]
    Costume currentCostume; // Current costume as enum

    [SerializeField]
    CostumeManager costumeManager; // Used to get a list of all costumes

    public string CurrentCostume { get { return currentCostume.ToString(); } } // Current costume as string

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>(); // Gets rigid body component
        spriteR = GetComponent<SpriteRenderer>(); // Gets sprite renderer component
        currentCostume = Costume.None;
        _transform = transform;
        BaseCostume.player = this;
    }

    new private void Start()
    {
        currentCostumeScript = LevelManager.CostumeList[(int)currentCostume]; // Sets the initial costume
    }

    // Update is called once per frame
    new void Update()
    {
        ChangeCostume();
        currentCostumeScript.Move(); // Moves using currently equipped costume's movement method

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

        currentCostumeScript = LevelManager.CostumeList[(int)currentCostume]; // Sets costume

        spriteR.color = costumeColors[(int)currentCostume]; // Changes color of temp player
    }

    // When player comes into contact with another object
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        switch (collision.gameObject.tag)
        {
            // If the objet collides with the candy object
            case "Candy":
                // Set our MR bool
                magicRush = true;
                break;
            case "Enemy":
                touchingEnemy = true;
                collidingEnemy = collision.gameObject;
                break;
        }
    }

    protected override void OnCollisionExit2D(Collision2D collision)
    {
        base.OnCollisionExit2D(collision);

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
                if (CurrentCostume == "Witch")
                {
                    WitchCostume witch = currentCostumeScript as WitchCostume;
                    witch.isAbleToFly = false;
                    Debug.Log("Can't fly");
                }
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
            if (CurrentCostume == "Witch")
            {
                WitchCostume witch = currentCostumeScript as WitchCostume;
                witch.isAbleToFly = true;
                Debug.Log("Can fly");
            }
        }
        
    }

    // Displays current costume on screen
    private void OnGUI()
    {
        GUILayout.Box("Current Costume: " + currentCostume + "\nCurrent Mana: " + currentCostumeScript.currentMana);
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

        rigidB.velocity = Vector3.zero;

        Vector3 pushVector = transform.position - collidingEnemy.transform.position;

        pushVector.Normalize();

        rigidB.velocity = pushVector * Speed;
        //pushVector *= 500;

        //rigidB.AddForce(pushVector);

        Debug.Log("pushing");
    }
}
