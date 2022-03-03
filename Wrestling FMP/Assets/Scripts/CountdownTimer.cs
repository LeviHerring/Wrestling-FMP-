using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;
    public PinningButtonMash buttonMash; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart(3));
        buttonMash.isMashingNeeded = true; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator CountdownToStart(int countdownTime2)
    {
        while(countdownTime2 > 0)
        {
            if (buttonMash.hasWon == true && countdownTime2 > 0)
            {
                countdownDisplay.text = "Pin broken!";
            }
            else
            {
                countdownDisplay.text = countdownTime2.ToString();

                yield return new WaitForSeconds(1f);

                countdownTime2--;
            }
           

           
        }

        countdownDisplay.text = "Pinned!";

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }

}
