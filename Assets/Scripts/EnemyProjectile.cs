using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    Agent agent;
    public Vector3 veloticy;
    private float lifetime;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dT = Time.deltaTime;
        transform.position += veloticy * dT;
        lifetime += dT;

        if (lifetime > .1f)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = true;
        }
        
        if(lifetime > 20)
        {
            Destroy(this);
        }
    }

    public void Init(Agent agent)
    {
        this.agent = agent;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject != agent.gameObject)
        //{
        //    Destroy(this);
        //}




        if (lifetime > .5f)
        {
            Destroy(gameObject);
        }
        //Debug.Log("Colliding");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (lifetime > .5f)
        {
            Destroy(gameObject);
        }
    }




}
