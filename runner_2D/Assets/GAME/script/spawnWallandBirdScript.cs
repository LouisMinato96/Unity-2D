using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnWallandBirdScript : MonoBehaviour
{
    private Queue<GameObject> wallObj_queue = new Queue<GameObject>();
    private long playerScore = 0;
    public GameObject wallObjForSpawn;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerScore % 200 == 0)
        {
            GameObject Instant_wallObj = Instantiate( wallObjForSpawn );
            wallObj_queue.Enqueue(Instant_wallObj);
        }

        foreach(GameObject g in wallObj_queue)
        {
            if( g.transform.position.x <= -10)
            {
                Destroy(g);
                wallObj_queue.Dequeue();
            }
            Debug.Log(g.name);
        }


        playerScore++;
        // Debug.Log("Player Score :- "+ playerScore);
    }
}
