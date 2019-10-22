using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Costume Type: Cat
/// </summary>
[CreateAssetMenu(menuName = "Costumes/Cat")]
public class CatCostume : BaseCostume
{
    [Header("Cat Costume")]
    [Range(1.0f, 2.0f)]
    public float sprintMultiplier = 1.5f; // Sprint speed (must be a value between 1 and 2)

    public float sprintSpeed { get { return baseSpeed * sprintMultiplier; } }

    protected override void HorizontalMovement()
    {
        base.HorizontalMovement();

        float horizontal = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftShift))
        {
            player.RigidBody.velocity = new Vector2(horizontal * sprintSpeed, player.RigidBody.velocity.y);
        }
    }
}
