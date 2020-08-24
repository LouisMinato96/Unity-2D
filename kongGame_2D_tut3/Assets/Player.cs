using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpForce;
    public float moveVelocity;
    public float climbVelocity;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InputFunction();
    }

    void InputFunction()
    {
        // JUMP 'Space'
        if( Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce( new Vector2(
                0,
                jumpForce
            ));
        }

        // MOVE RIGHT 'd'
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                moveVelocity,
                this.GetComponent<Rigidbody2D>().velocity.y
            );
        }

        // MOVE LEFT 'a'
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                -moveVelocity,
                this.GetComponent<Rigidbody2D>().velocity.y
            );
        }
    }

    private void OnTriggerStay2D(Collider2D c)
    {
        if( c.tag == "Ladder")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                this.GetComponent<Rigidbody2D>().velocity.x,
                climbVelocity
            );
        }
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if ( c.tag == "Orb" )
        {
            Time.timeScale = 0;
        }   
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if ( c.gameObject.tag == "Enemy" )
        {
            GameObject.Destroy( this.gameObject );
            Time.timeScale = 0;
        }
    }

}
