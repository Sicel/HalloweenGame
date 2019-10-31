using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

public class SamEnemy : Agent
{
    private float shootInterval = 1;
    private float sTimer = 0;
    public GameObject bullet;
    Player player;

    public float range;

    // Start is called before the first frame update
    void Start()
    {
        player = BaseCostume.player;
    }

    new private void Update()
    {
        //do raycast to detect player is clear to shoot
        RaycastHit2D obs;

        Debug.DrawRay(transform.position, player.transform.position - transform.position);

        base.Update();
        Debug.DrawLine(transform.position, transform.position + new Vector3(0,range,0), Color.red);
        //shoots if player is nearby, off the ground, and has witch costume equipped
        if (Vector3.Distance(player.transform.position, transform.position) < range && player.IsFlying)
        {
            //Physics.Raycast(transform.position, player.transform.position - transform.position, out obs, (int)range);
            int layerMask = ~(1 << 2);
            obs = Physics2D.Raycast(transform.position, player.transform.position - transform.position, (int)range, layerMask);
            Debug.Log(obs.collider.gameObject.name);

            if (obs.collider.gameObject.tag == "Player")
            {
                ShootLoop();
            }
        }

    }

    //private void OnDrawGizmos()
    //{
    //    int layerMask = ~(1 << 2);
    //    RaycastHit2D obs;
    //    Ray ray2D = new Ray(transform.position, player.transform.position - transform.position);
    //    obs = Physics2D.Raycast(transform.position, player.transform.position - transform.position, (int)range, layerMask);
    //    Gizmos.DrawRay(ray2D);
    //}

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
        GameObject firedBullet = Instantiate(bullet);
        firedBullet.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
    }
}
