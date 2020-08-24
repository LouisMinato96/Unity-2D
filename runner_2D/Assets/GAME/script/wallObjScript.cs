using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallObjScript : MonoBehaviour
{
    public float wallVelocity = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if ( this.transform.position.x > -10 )
        {
            this.transform.position -= new Vector3(wallVelocity, 0, 0);
        }
        
    }
}
