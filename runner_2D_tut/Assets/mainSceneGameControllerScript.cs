using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainSceneGameControllerScript : MonoBehaviour
{
    public playerJump player;
    public Camera cam;
    public Text gameScoreText;

    public GameObject[] blockPrefabs;

    private float blockPointer = 0;
    private float safeSpace = 21;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        blockPointer = -12;
    }

    void generateNewBlock()
    {
        int blockIndex = Random.Range(1, blockPrefabs.Length);
        if(blockPointer < 0)
        {
            blockIndex = 0;
        }

        GameObject blockObj = Instantiate(blockPrefabs[blockIndex]);
        blockObj.transform.SetParent(this.transform);
        Scr_block block = blockObj.GetComponent<Scr_block>();

        blockObj.transform.position = new Vector3(
            blockPointer + block.size/2,
            0,
            0
            );
        blockPointer += (block.size);
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            cam.transform.position = new Vector3(
                player.transform.position.x,
                0,
                -10
            );

            gameScoreText.text = "Score : " + Mathf.Floor(player.transform.position.x);

            if (player.transform.position.x > blockPointer - safeSpace)
            {
                generateNewBlock();
            }
        }
        else
        {
            if (!isGameOver)
            {
                isGameOver = true;
                gameScoreText.text += "\n GAME OVER \nPress R to Restart";
            }

            if ( Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
