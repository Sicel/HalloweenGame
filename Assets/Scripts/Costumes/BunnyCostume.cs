using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Costume Type: Bunny
/// Can jump and dig
/// </summary>
[CreateAssetMenu(menuName = "Costumes/Bunny")]
public class BunnyCostume : BaseCostume
{
    [Header("Bunny Stats")]
    public float hopForce = 3;

    protected override void HorizontalMovement()
    {
        base.HorizontalMovement();

        //if (player.onGround)
        //player.RigidBody.AddForce(new Vector2(0, hopForce), ForceMode2D.Impulse);
    }

    public override void Move()
    {
        base.Move();

        // TODO: Let player hide
        // if (player.onGround)
        // {
        //     if (Input.GetKey(KeyCode.S))
        //     {
        // 
        //     }
        // }
    }
}
