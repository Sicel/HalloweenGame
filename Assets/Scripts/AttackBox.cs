using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBox : MonoBehaviour
{
    Agent agent;
    Collider2D collider;
    public List<Agent> attackList = new List<Agent>();
    public bool Active { get { return collider.enabled; } }

    private void Start()
    {
        collider = GetComponent<Collider2D>();
    }

    public void Activate(Agent agent)
    {
        this.agent = agent;
        collider.enabled = true;
    }

    public void DeActivate()
    {
        collider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != agent.gameObject && collision.gameObject.GetComponent<Agent>() != null)
        {
            Agent other = collision.gameObject.GetComponent<Agent>();
            if (!attackList.Contains(other))
            {
                attackList.Add(other);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
