using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ToggleInstructions : MonoBehaviour
{
    public GameObject toTurnOff;
    public GameObject toTurnOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (toTurnOff)
        {
            toTurnOff.SetActive(false);
        }

        if (toTurnOn)
        {
            toTurnOn.SetActive(true);
        }
    }
}
