using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Agent
{
    public static Rigidbody2D rigidB; // Needed to allow movement

    public static Transform _transform; // Needed to allow movement

    public static bool onGround = false; // Is the player touching the ground?

    public BaseCostume currentCostumeScript = null; // Script of current costume

    [SerializeField]
    int health = 3; // Health points

    SpriteRenderer spriteR; // Player's Sprite rendere (temp)
    int numCostumes = CostumeManager.numCostumes; // Num of total costumes used for iteration in ChangeCostume()

    [SerializeField]
    List<Color32> costumeColors = new List<Color32>(); // Colors for the temp player

    [SerializeField]
    CostumeManager.Costume currentCostume = CostumeManager.Costume.None; // Current costume as enum

    [SerializeField]
    CostumeManager manager; // Used to get a list of all costumes

    public string CurrentCostume { get { return currentCostume.ToString(); } } // Current costume as string

    private void Awake()
    {
        currentCostumeScript = manager.costumeScripts[(int)currentCostume]; // Sets the initial costume
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidB = GetComponent<Rigidbody2D>(); // Gets rigid body component

        _transform = transform;

        spriteR = GetComponent<SpriteRenderer>(); // Gets sprite renderer component
    }

    // Update is called once per frame
    void Update()
    {
        //access current costume - get & set movement values



        ChangeCostume();
        currentCostumeScript.Move(); // Moves using currently equipped costume's movement method
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
            currentCostume = (CostumeManager.Costume)numCostumes - 1;
        }
        else if ((int)currentCostume >= numCostumes)
        {
            currentCostume = 0;
        }

        currentCostumeScript = manager.costumeScripts[(int)currentCostume]; // Sets costume

        spriteR.color = costumeColors[(int)currentCostume]; // Changes color of temp player
    }

    // Displays current costume on screen
    private void OnGUI()
    {
        GUILayout.Box("Current Costume: " + currentCostume);
    }
}
