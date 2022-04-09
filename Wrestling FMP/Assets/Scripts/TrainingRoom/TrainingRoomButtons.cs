using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; 

public class TrainingRoomButtons : MonoBehaviour
{
    public GameObject enemy;
    public Health health;
    public GameObject playerOne;
    public GameObject playerOneHitbox; 
    public GameObject playerTwo;
    public GameObject playerTwoHitbox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetScene()
    {
        SceneManager.LoadScene("TrainingRoom"); 
    }

    public void AddEnemyPercent()
    {
        health.health += 10; 
    }


    public void MinusEnemyPercent()
    {
        health.health -= 10;
    }

    public void addKnockbackX()
    {
        string Player1 = PlayerPrefs.GetString("playerOne");

        switch (Player1)
        {
            case "PlayerOne":
                playerOne.GetComponentInChildren<DamageManager>().knockbackMultiplierX += 1;
                break;
            case "PlayerTwo":
                playerTwo.GetComponentInChildren<DamageManager>().knockbackMultiplierX += 1;
                break;
                //case "PlayerThree":
                //    playerThreeHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
                //case "PlayerFour":
                //     playerFourHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
        }


    }

    public void MinusKnockbackX()
    {
        string Player1 = PlayerPrefs.GetString("playerOne");

        switch (Player1)
        {
            case "PlayerOne":
                playerOne.GetComponentInChildren<DamageManager>().knockbackMultiplierX -= 1;
                break;
            case "PlayerTwo":
                playerTwo.GetComponentInChildren<DamageManager>().knockbackMultiplierX -= 1;
                break;
                //case "PlayerThree":
                //    playerThreeHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
                //case "PlayerFour":
                //     playerFourHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
        }


    }

    public void AddKnockbackY()
    {
        string Player1 = PlayerPrefs.GetString("playerOne");

        switch (Player1)
        {
            case "PlayerOne":
                playerOne.GetComponentInChildren<DamageManager>().knockbackMultiplierY += 1;
                break;
            case "PlayerTwo":
                playerTwo.GetComponentInChildren<DamageManager>().knockbackMultiplierY += 1;
                break;
                //case "PlayerThree":
                //    playerThreeHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
                //case "PlayerFour":
                //     playerFourHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
        }


    }

    public void MinusKnockbackY()
    {
        string Player1 = PlayerPrefs.GetString("playerOne");

        switch (Player1)
        {
            case "PlayerOne":
                playerOne.GetComponentInChildren<DamageManager>().knockbackMultiplierY -= 1;
                break;
            case "PlayerTwo":
                playerTwo.GetComponentInChildren<DamageManager>().knockbackMultiplierY -= 1;
                break;
                //case "PlayerThree":
                //    playerThreeHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
                //case "PlayerFour":
                //     playerFourHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
        }


    }

    public void AddSpeed()
    {
        string Player1 = PlayerPrefs.GetString("playerOne");

        switch (Player1)
        {
            case "PlayerOne":
                playerOne.GetComponent<PlayerMovementFinal>().horizontal += 1; 
                break;
            case "PlayerTwo":
                playerTwo.GetComponent<PlayerMovementFinal>().horizontal += 1;
                break;
                //case "PlayerThree":
                //    playerThreeHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
                //case "PlayerFour":
                //     playerFourHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
        }


    }

    public void MinusSpeed()
    {
        string Player1 = PlayerPrefs.GetString("playerOne");

        switch (Player1)
        {
            case "PlayerOne":
                playerOne.GetComponent<PlayerMovementFinal>().horizontal -= 1;
                break;
            case "PlayerTwo":
                playerTwo.GetComponent<PlayerMovementFinal>().horizontal -= 1;
                break;
                //case "PlayerThree":
                //    playerThreeHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
                //case "PlayerFour":
                //     playerFourHitbox.GetComponent<DamageManager>().knockbackMultiplierX += 1; 
                //    break;
        }


    }
}
