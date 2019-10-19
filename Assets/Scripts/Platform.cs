using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public GameObject platformTop;

    private void Awake()
    {
        platformTop = GetComponentInChildren<GameObject>();
    }
}
