using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerJump : MonoBehaviour
{   
    // Public Variable
    public long jumpForce;
    public int playerSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Space))
        {
            this.GetComponent<Rigidbody2D>().AddForce( new Vector2(0,jumpForce) );
        }

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(
                playerSpeed,
                this.GetComponent<Rigidbody2D>().velocity.y
            );
    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log( c.tag);
        if (c.tag == "obstacle")
        {
            GameObject.Destroy(this.gameObject);
        }
    }
}
