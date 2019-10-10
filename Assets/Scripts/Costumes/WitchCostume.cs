using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Costume Tyoe: Witch
/// </summary>
[CreateAssetMenu(menuName = "Costume Stats/Witch Stats")]
public class WitchCostume : BaseCostume
{
    [SerializeField]
    GameObject projectile; // Projectile that will be fired

    [SerializeField]
    bool flyMode = false; // Is the player flying?

    public override void Move()
    {
        base.Move();

        if (flyMode)
        {
            Fly();

            if (Player.onGround)
                flyMode = !flyMode;
        }
        else
        {
            Jump();

            if (!Player.onGround && Input.GetKeyDown(KeyCode.W))
                flyMode = !flyMode;
        }
    }

    /// <summary>
    /// Allows the player to fly
    /// </summary>
    void Fly()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Player.rigidB.velocity = new Vector2(horizontal * baseSpeed, vertical * baseSpeed);
    }
}
