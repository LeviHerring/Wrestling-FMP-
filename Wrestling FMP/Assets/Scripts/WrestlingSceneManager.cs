using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WrestlingSceneManager : MonoBehaviour
{

    public int countdownTime;
    public Text countdownDisplay;
    //public PinningButtonMash pinningButtonMash;
    public GameObject playerOne;
    public GameObject playerTwo;
    //public GameObject playerThree;
    //public GameObject playerFour;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart(5));
        //pinningButtonMash.isMashingNeeded = true; 
        playerOne.GetComponent<AnimationEvents>().isAttacking = true;
        playerTwo.GetComponent<AnimationEvents>().isAttacking = true;

        //playerThree.GetComponent<AnimationEvents>().isAttacking = true;
        //playerFour.GetComponent<AnimationEvents>().isAttacking = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOne.GetComponent<PinningButtonMash>().hasWon == true)
        {
            Debug.Log("WINNER!");
            StartCoroutine(Winner());

        }
        //if(playerTwo.GetComponent<PinningButtonMash>().hasWon == true)
        //{
        //    Debug.Log("Winner!");
        //}
    }

    public IEnumerator CountdownToStart(int countdownTime2)
    {
        while (countdownTime2 > 0)
        {
            countdownDisplay.text = countdownTime2.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime2--;



        }

        countdownDisplay.text = "FIGHT!";
        //bell sound rings here
        playerOne.GetComponent<AnimationEvents>().isAttacking = false;
        playerTwo.GetComponent<AnimationEvents>().isAttacking = false;
        //playerThree.GetComponent<AnimationEvents>().isAttacking = false;
        //playerFour.GetComponent<AnimationEvents>().isAttacking = false;

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }

    IEnumerator Winner()
    {
         yield return new WaitForSeconds(5f);
        playerOne.GetComponent<PinningButtonMash>().hasWon = false;
    }
}
