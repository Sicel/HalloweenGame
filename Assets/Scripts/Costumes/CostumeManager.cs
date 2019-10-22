using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Costumes
public enum Costume
{
    Bunny,
    Cat,
    Witch
}

/// <summary>
/// Holds a list of all costumes the player can change into
/// </summary>
[CreateAssetMenu(menuName = "Costume Stats/Costume Lookup Table")]
public class CostumeManager : ScriptableObject
{
    // Number of costumes
    public static int numCostumes = Enum.GetNames(typeof(Costume)).Length; 

    // List of costume scripts
    [SerializeField] public List<BaseCostume> costumeScripts = new List<BaseCostume>();
}
