using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : Agent
{
    [Header("Gun Enemy")]
    public float moveSpeed = 20;
    public Vector2 startPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();    
    }

    void ShootLoop()
    {

    }



}
