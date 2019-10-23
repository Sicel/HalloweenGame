using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class GroundDetector : MonoBehaviour
{
    [SerializeField]
    Collider2D feet;

    [SerializeField]
    Agent parent;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            case "Platform":
                feet.enabled = true;
                parent.onGround = true;
                break;
        }
        //Debug.Log(collision.gameObject.tag);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            case "Platform":
                feet.enabled = true;
                parent.onGround = true;
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            case "Platform":
                feet.enabled = false;
                parent.onGround = false;
                break;
        }
    }
}
