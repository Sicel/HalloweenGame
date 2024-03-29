﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //apply force directly to transform
        Vector3 SteeringForce = Seek();

        transform.position += SteeringForce * Time.deltaTime;
        transform.right = -SteeringForce;

    }
    /// <summary>
    /// Missle Lock on behavior
    /// </summary>
    /// <returns>returns velocity vector facing player</returns>
    private Vector3 Seek()
    {
        Vector3 SeekDirection;

        SeekDirection = player.transform.position - transform.position;
        SeekDirection.Normalize();
        //Debug.DrawLine(transform.position, SeekDirection);
        SeekDirection *= 20;
        SeekDirection.z = 0;
        return SeekDirection;
    }

}
