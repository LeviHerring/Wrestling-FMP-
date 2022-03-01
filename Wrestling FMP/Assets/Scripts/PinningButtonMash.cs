using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

public class PinningButtonMash : MonoBehaviour
{
    public Image metre;
    public GameObject text; 
    public float mashDelay = .5f;

    float mash;
    bool pressed;
    bool started;
    public int pressAmount= 1;
    public int havePressed;
    public float fillAmount;
    public int submissionNo;
    public int minrange = 1;
    public int maxrange = 10000;
    int randomSubmit; 


    // Start is called before the first frame update
    void Start()
    {
        minrange = 1;
        maxrange = 10;
        submissionNo = Random.Range(1, 9); 
    }

    // Update is called once per frame
    void Update()
    {
       if(havePressed == pressAmount)
        {
            Debug.Log("You did it");
            text.gameObject.SetActive(true); 
        }
        metre.fillAmount = fillAmount;

    }

    public void Mashing(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            havePressed++;
            fillAmount = havePressed / 10;
            metre.fillAmount = fillAmount;
            
           
        }
    }

    public void submission(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            randomSubmit = Random.Range(minrange, maxrange);
            if (submissionNo == randomSubmit)
            {
                Debug.Log("SUBMIT");
            }
            else
            {
                Debug.Log("DON'T SUBMIT");
            }
        }
      
    }
}
