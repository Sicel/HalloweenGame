using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 5;

    Agent agent;
    Vector3 velocity = Vector3.zero;
    Collider2D collider;
    private float lifetime;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = agent.gameObject.transform.position;
        collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
        lifetime += Time.deltaTime;
    }

    public void Init(Agent agent, Vector2 direction = Vector2.zero)
    {
        this.agent = agent;
        velocity = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(string.Format("{0}, {1}", collision.gameObject, agent.gameObject));
        if (collision.gameObject != agent.gameObject)
        {
            if (collision.gameObject.GetComponent<Agent>() != null)
            {
                Agent other = collision.gameObject.GetComponent<Agent>();
                other.Health--;
            }
            Destroy(gameObject);
        }

        // I'm not sure if this is needed
        //if (lifetime > .5f)
        //{
        //    Destroy(gameObject);
        //}
        Debug.Log("Colliding");
    }

    


}
