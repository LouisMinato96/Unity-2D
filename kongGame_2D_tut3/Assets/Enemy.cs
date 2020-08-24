using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveVelocity;
    public int velocityChanges = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(
            moveVelocity,
            this.GetComponent<Rigidbody2D>().velocity.y
        );
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if ( c.gameObject.tag == "Wall" )
        {
            velocityChanges--;
            moveVelocity *= -1;

            if (velocityChanges == 0)
            {
                GameObject.Destroy( this.gameObject );
            }
        }
    }
}
