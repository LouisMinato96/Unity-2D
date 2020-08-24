using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class mainSceneGameController : MonoBehaviour
{
    public Player player;
    public Text mainSceneTextObj;
    public GameObject enemy;
    public GameObject enemySpawnPosition;

    public float spawningInterval = 2.0f;
    private float spawnTimer;
    private float gameStart;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if( Time.timeScale == 0)
            {
                mainSceneTextObj.text = "You WIN !!! \n Press R to Play Again.";
            }
        }
        else
        {
            if (Time.timeScale == 0)
            {
                mainSceneTextObj.text = "GAME OVER! \n Press R to Restart.";
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {   
            if (player == null || Time.timeScale == 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

        spawnTimer -= Time.deltaTime;
        if (spawnTimer <= 0f)
        {
            spawnTimer = spawningInterval;
            GameObject enemyObg = Instantiate(enemy);
            enemyObg.transform.SetParent( this.transform );
            enemyObg.transform.position = enemySpawnPosition.transform.position;
        }
    }
}
