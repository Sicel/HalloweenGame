using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class GunEnemy : Agent
{
    [Header("Gun Enemy")]
    public float moveSpeed = 20;
    public Vector2 startPos;

    private float shootInterval = 1;
    private float sTimer = 0;
    public GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    new private void Update()
    {
        base.Update();
        ShootLoop();
        RaycastHit hit;
        // Does the ray intersect any objects excluding the player layer
        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.right), out hit, 50))
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * hit.distance, Color.yellow);
        //    Debug.Log("Did Hit");
        //}
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.right) * 1000, Color.white);
        //    Debug.Log("Did not Hit");
        //}

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
        //Debug.Log("Shooting");
        GameObject firedBullet = GameObject.Instantiate(bullet);
        Vector3 bDirection = Vector3.right;
        float displacement = gameObject.GetComponent<BoxCollider2D>().size.x;
       //firedBullet.transform.position = transform.position + (bDirection * .8f);
        firedBullet.transform.position = transform.position;
        firedBullet.GetComponent<EnemyProjectile>().veloticy = bDirection * 10;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyProjectile")
        {
            Physics.IgnoreCollision(collision.collider, gameObject.GetComponent<Collider>());
        }
    }

}
