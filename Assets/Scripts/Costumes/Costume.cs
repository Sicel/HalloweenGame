using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Costume : Player
{
    [SerializeField]
    int cSpeed;

    [SerializeField]
    [Range(1, 10)]
    int cStrength;

    [SerializeField]
    int cJumpForce;

    [SerializeField]
    bool flight;
}
