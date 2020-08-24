using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneController : MonoBehaviour
{
    public Camera gameCamera;
    public Player player;
    public Text mainSceneGameText;
    public GameObject[] blockPrefabs;

    private float blockPointer = 0;
    private float safeSpace = 15;
    private bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        blockPointer = -10;
        if( Physics2D.gravity.y < 0 )
        {
            Physics2D.gravity *= -1 ;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ( player != null )
        {
            gameCamera.transform.position = new Vector3(
                player.transform.position.x,
                gameCamera.transform.position.y,
                gameCamera.transform.position.z
            );

            mainSceneGameText.text = "Score : " + Mathf.Floor( player.transform.position.x );

            if ( player.transform.position.x > blockPointer - safeSpace )
            {
                setNewBlockPosition();
            }
        }
        else
        {
            if( !isGameOver )
            {
                isGameOver = true;
                mainSceneGameText.text += "\nGame Over!!!\nPress 'R' to Restart.";
            }
            
            if( Input.GetKeyDown( KeyCode.R ) )
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }


    }

    void setNewBlockPosition()
    {
        int randomIndex = Random.Range(1, blockPrefabs.Length);
        if (blockPointer <= 0) { randomIndex = 0; }

        GameObject blockObj = GameObject.Instantiate(blockPrefabs[randomIndex]);
        blockObj.transform.SetParent(this.transform);
        Block blockRef = blockObj.GetComponent<Block>();
        blockObj.transform.position = new Vector3(
            blockPointer + (blockRef.size / 2),
            0,
            0
        );
        blockPointer += blockRef.size;
    }
}
