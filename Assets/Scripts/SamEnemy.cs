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

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    new private void Update()
    {
        base.Update();

        if (Vector3.Distance(player.transform.position, transform.position) < 50 && player.GetComponent<Player>().onGround == false && player.GetComponent<Player>().CurrentCostume == "Witch")
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
