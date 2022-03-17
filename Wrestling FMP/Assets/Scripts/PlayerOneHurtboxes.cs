using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

public class PlayerOneHurtboxes : MonoBehaviour
{
    public Animator animator;
    public AnimationEvents animationEvents;
    Rigidbody2D rigidbody; 
    public bool isHit;
    public float stopwatch;
    public float stopwatchTime;
    public float disabledTime;
    public GloablVariablesManager globalVariablesManager;
    public bool hasWon;
    public bool isMashingNeeded;
    public float fillAmount;
    public Image metre;
    public int mashingAmountNeeded;
    public int countdownTime;
    public Text countdownDisplay;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        stopwatch = Time.deltaTime; 

        if(stopwatch <= 0 && isHit == true)
        {
            isHit = false;
            //animationEvents.isAttacking = false; 
            Debug.Log("Attacking is false"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hitbox")
        {
            //StartCoroutine(DisablePlayerMovement(disabledTime));


        }

        if(collision.gameObject.tag == "Pin")
        {
            animationEvents.isAttacking = true;
            isMashingNeeded = true;
            StartCoroutine(CountdownToStart(3));
        }
    }


    public void Mashing(InputAction.CallbackContext context)
    {
        if (isMashingNeeded == true)
        {
            if (context.performed)
            {
                globalVariablesManager.player1MashingDone++;
                fillAmount = globalVariablesManager.player1MashingDone / 10;
                metre.fillAmount = fillAmount;


            }
            if (globalVariablesManager.player1MashingDone == mashingAmountNeeded)
            {
                hasWon = true;
                isMashingNeeded = false; 
            }
        }

    }

    public IEnumerator CountdownToStart(int countdownTime2)
    {
        countdownDisplay.gameObject.SetActive(true); 

        while (countdownTime2 > 0 && hasWon == false)
        {
            //if (/*pinningButtonMash.hasWon == true &&*/ countdownTime2 > 0)
            //{
            //    countdownDisplay.text = "Pin broken!";
            //}
            //else
            //{
            countdownDisplay.text = countdownTime2.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime2--;
            //}

            

        }
        if (hasWon == true)
        {
            countdownDisplay.text = "Pin broken!";
            yield return new WaitForSeconds(1f);
            countdownDisplay.gameObject.SetActive(false);
            hasWon = false; 
        }
        else
        {
            countdownDisplay.text = "Pinned!";

            yield return new WaitForSeconds(1f);
            countdownDisplay.gameObject.SetActive(false);
        }

       
    }
    IEnumerator DisablePlayerMovement(float time)
    {
        animator.SetBool("IsHit", true);
        animationEvents.isAttacking = true;

        yield return new WaitForSeconds(time);
        animationEvents.isAttacking = false;
    }
}
