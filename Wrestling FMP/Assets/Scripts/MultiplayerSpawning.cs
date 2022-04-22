using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class MultiplayerSpawning : MonoBehaviour
{
    PlayerInputManager playerInput;
    public GameObject playerOne;
    public GameObject playerTwo;
    Transform playerOneSpawn;
    Transform playerTwoSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInputManager>();
        string player1 = PlayerPrefs.GetString("playerOne");
        string player2 = PlayerPrefs.GetString("playerTwo");
        PlayerOne(player1);
        PlayerTwo(player2); 

    }

    private void Awake()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerOne(string player1)
    {
        
        

        switch (player1)
        {
            case "PlayerOne":
                playerInput.playerPrefab = playerTwo;
                playerInput.JoinPlayer(0);
                break;
            case "PlayerTwo":
                playerInput.playerPrefab = playerTwo;
                playerInput.JoinPlayer(0);
                break;
                //case "PlayerThree":
                //    Instantiate(playerThree, spawnPosition.transform.position, Quaternion.identity);
                //    break;
                //case "PlayerFour":
                //    Instantiate(playerFour, spawnPosition.transform.position, Quaternion.identity);
                //    break;
        }
    }

    public void PlayerTwo(string player2)
    {
        switch (player2)
        {
            case "PlayerOne":
                playerInput.playerPrefab = playerOne;
                playerInput.JoinPlayer(1);
                break;
            case "PlayerTwo":
                playerInput.playerPrefab = playerTwo;
                playerInput.JoinPlayer(0);
                break;
                //case "PlayerThree":
                //    Instantiate(playerThree, spawnPosition.transform.position, Quaternion.identity);
                //    break;
                //case "PlayerFour":
                //    Instantiate(playerFour, spawnPosition.transform.position, Quaternion.identity);
                //    break;
        }
    }

}
