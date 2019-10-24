using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class SamEnemy : Agent
{
    private float shootInterval = 1;
    private float sTimer = 0;
    public GameObject bullet;
    GameObject player;

    public float range;

    // Start is called before the first frame update
    void Start()
    {
        player = BaseCostume.player.gameObject;
        //player.IsFlying
    }

    new private void Update()
    {
        //do raycast to detect player is clear to shoot
        base.Update();
        Debug.DrawLine(transform.position, transform.position + new Vector3(0,range,0), Color.red);
        //shoots if player is nearby, off the ground, and has witch costume equipped
        if (Vector3.Distance(player.transform.position, transform.position) < range && player.GetComponent<Player>().onGround == false && player.GetComponent<Player>().CurrentCostume == Costume.Witch && player.transform.position.y > transform.position.y - gameObject.GetComponent<BoxCollider2D>().size.y)
        {
            ShootLoop();
            
        }

    }

    void ShootLoop()
    {
        if (sTimer == 0)
        {
            Shoot();
            sTimer += Time.deltaTime;
        }
        else if (sTimer >= .5)
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
        GameObject firedBullet = GameObject.Instantiate(bullet);
        firedBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }
}
