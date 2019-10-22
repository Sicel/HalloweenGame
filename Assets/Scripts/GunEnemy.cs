using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunEnemy : Agent
{
    [Header("Gun Enemy")]
    public float moveSpeed = 20;
    public Vector2 startPos;

    private float shootInterval = 1;
    private float sTimer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
        ShootLoop();
    }

    void ShootLoop()
    {
        if(sTimer == 0)
        {
            Shoot();
            sTimer += Time.deltaTime;
        }
        else if(sTimer >= 1)
        {
            sTimer = 0;
        }
        else
        {
            sTimer += Time.deltaTime;
        }
    }

    void Shoot()
    {
        Debug.Log("Shooting");
    }



}
