using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public static Rigidbody2D rigidB; // Needed to allow movement

    public static Transform _transform; // Needed to allow movement

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
    Costume currentCostume = Costume.None; // Current costume as enum

    [SerializeField]
    CostumeManager manager; // Used to get a list of all costumes

    public string CurrentCostume { get { return currentCostume.ToString(); } } // Current costume as string

    private void Awake()
    {
        rigidB = GetComponent<Rigidbody2D>(); // Gets rigid body component
        currentCostumeScript = manager.costumeScripts[(int)currentCostume]; // Sets the initial costume
        spriteR = GetComponent<SpriteRenderer>(); // Gets sprite renderer component
        _transform = transform;
        BaseCostume.player = this;
    }

    // Update is called once per frame
    new void Update()
    {
        //access current costume - get & set movement values



        ChangeCostume();
        currentCostumeScript.Move(); // Moves using currently equipped costume's movement method

        // Player rushes
        if (magicRush)
        {
            MagicRush();
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

        currentCostumeScript = manager.costumeScripts[(int)currentCostume]; // Sets costume

        spriteR.color = costumeColors[(int)currentCostume]; // Changes color of temp player
    }

    // When player comes into contact with another object
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);

        // If the objet collides with the candy object
        if(collision.gameObject.tag == "Candy")
        {
            // Set our MR bool
            magicRush = true;
        }
    }

    // Displays current costume on screen
    private void OnGUI()
    {
        GUILayout.Box("Current Costume: " + currentCostume);
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
}
