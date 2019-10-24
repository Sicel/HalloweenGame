using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Costume Tyoe: Witch
/// </summary>
[CreateAssetMenu(menuName = "Costumes/Witch")]
public class WitchCostume : BaseCostume
{
    [Header("Witch Costume")]
    [SerializeField]
    GameObject projectile; // Projectile that will be fired

    public bool flyMode = false; // Is the player flying?

    public bool isAbleToFly = true; // Is the COSTUME able to fly?

    public override void Move()
    {
        base.Move();

        if (currentResource <= 0)
        {
            currentResource = 0;
            isAbleToFly = false;
        }
        else
        {
            isAbleToFly = true;
        }

        // If both player and costume are to fly they can
        if (isAbleToFly && player.isAbleToFly)
        {
            if (flyMode)
            {
                Fly();

                if (player.onGround)
                    flyMode = false;
            }
            else
            {
                Jump();

                if (!player.onGround && Input.GetKeyDown(KeyCode.W))
                    flyMode = true;
            }
        }
    }

    /// <summary>
    /// Allows the player to fly
    /// </summary>
    void Fly()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        player.RigidBody.velocity = new Vector2(horizontal * baseSpeed, vertical * baseSpeed);

        currentResource -= resourceConsumptionRate * Time.deltaTime;
    }

    public override void Attack()
    {
        GameObject bullet = Instantiate(projectile);
        bullet.GetComponent<Projectile>().Init(player, new Vector2(1, 0));
    }
}
