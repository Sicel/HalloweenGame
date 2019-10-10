using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Holds a list of all costumes the player can change into
/// </summary>
[CreateAssetMenu(menuName = "Costume Stats/Costume Lookup Table")]
public class CostumeManager : ScriptableObject
{
    // Number of costumes
    public static int numCostumes = Enum.GetNames(typeof(Costume)).Length; 

    // Costumes
    public enum Costume
    {
        None,
        Cat,
        Witch
    }

    // List of costume scripts
    [SerializeField] public List<BaseCostume> costumeScripts = new List<BaseCostume>();
}
