using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; 

public class PlayerAttachedMultiplayer : MonoBehaviour
{
    public GameObject redCircle;
    public GameObject greenSquare;
    public int playerNo; 
    // Start is called before the first frame update
    void Start()
    {
      

       
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void Awake()
    {
        string player2 = PlayerPrefs.GetString("playerTwo");
        switch (player2)
        {
            case "RedCircle":
                FindObjectOfType<PlayerInputManager>().playerPrefab = redCircle;
                Debug.Log("Spawned player 2 as red circle");
                break;
            case "GreenSquare":
                FindObjectOfType<PlayerInputManager>().playerPrefab = greenSquare;
                Debug.Log("Spawned player 2 as green square");
                break;
                //case "PlayerThree":
                //    Instantiate(playerThree, spawnPosition.transform.position, Quaternion.identity);
                //    break;
                //case "PlayerFour":
                //    Instantiate(playerFour, spawnPosition.transform.position, Quaternion.identity);
                //    break;
        }

        FindObjectOfType<GloablVariablesManager>().playersJoined++;

        if (FindObjectOfType<GloablVariablesManager>().playersJoined == 1)
        {
            playerNo = 1;
            gameObject.tag = "PlayerOne";
            gameObject.transform.position = FindObjectOfType<GloablVariablesManager>().playerOneSpawn.transform.position; 
        }
        else
        {
            playerNo = 2;
            gameObject.tag = "PlayerTwo";
            gameObject.transform.position = FindObjectOfType<GloablVariablesManager>().playerTwoSpawn.transform.position;
        }

    }
}
