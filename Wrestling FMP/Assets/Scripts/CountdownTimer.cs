using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CountdownToStart()
    {
        while(countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--; 
        }

        countdownDisplay.text = "Pinned!";

        yield return new WaitForSeconds(1f);
        countdownDisplay.gameObject.SetActive(false);
    }

}
