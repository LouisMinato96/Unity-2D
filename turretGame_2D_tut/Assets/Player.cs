using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            Physics2D.gravity *= -1;
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                this.GetComponent<Rigidbody2D>().velocity.x,
                0
            );
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(
            playerSpeed,
            this.GetComponent<Rigidbody2D>().velocity.y
        );
    }

    private void OnCollisionEnter2D(Collision2D c )
    {
        if ( c.gameObject.tag == "rigidObj" )
        {
            GameObject.Destroy( this.gameObject );
        }
    }
}
