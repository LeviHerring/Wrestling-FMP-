using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CharacterSelectScreenManager : MonoBehaviour
{
     GameObject playerOne;
     GameObject playerTwo;
    public GameObject panel; 

    // Start is called before the first frame update
    void Start()
    {
     
    }

    private void Awake()
    {
        //playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
        //playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOne == null)
        {
            playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
            playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        }
        if (playerTwo == null)
        {
            playerOne = GameObject.FindGameObjectWithTag("PlayerOne");
            playerTwo = GameObject.FindGameObjectWithTag("PlayerTwo");
        }


        if (playerOne.GetComponent<CharacterSelectScreenController>().isSelected == true && playerTwo.GetComponent<CharacterSelectScreenController>().isSelected == true)
        {
            panel.SetActive(true); 
        }
    }

    public void StartButton()
    {
        switch (playerOne.GetComponent<CharacterSelectScreenController>().position)
        {
            case 0:
                PlayerPrefs.SetString("playerOne", "Astronaut");
                Debug.Log("Player 1 selected");
                break;

            case 1:
                PlayerPrefs.SetString("playerOne", "RedCircle");
                break;

            case 2:
                PlayerPrefs.SetString("playerOne", "GreenSquare");
                break;

            case 3:
                PlayerPrefs.SetString("playerOne", "NarbyDallin");
                break;
        }
        switch (playerTwo.GetComponent<CharacterSelectScreenController>().position)
        {
            case 0:
                PlayerPrefs.SetString("playerTwo", "Astronaut");
                Debug.Log("Player 2 selected Red circle");
                break;

            case 1:
                PlayerPrefs.SetString("playerTwo", "RedCircle");
                Debug.Log("Player 2 selected Green Square");
                break;

            case 2:
                PlayerPrefs.SetString("playerTwo", "Greensquare");
                break;

            case 3:
                PlayerPrefs.SetString("playerOne", "NarbyDallin");
                break;
        }
        SceneManager.LoadScene("SampleScene");
    }

    public void BackButton()
    {
        playerOne.GetComponent<CharacterSelectScreenController>().isSelected = false;
        playerTwo.GetComponent<CharacterSelectScreenController>().isSelected = false;
        panel.gameObject.SetActive(false); 
    }
}
