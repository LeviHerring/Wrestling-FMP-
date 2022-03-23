using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

public class PlayerOneHurtboxes : MonoBehaviour
{
    public Animator animator;
    public AnimationEvents animationEvents;
    public Rigidbody2D rigidbody2d; 
    public bool isHit;
    public float stopwatch;
    public float stopwatchTime;
    public float disabledTime;
    public GloablVariablesManager globalVariablesManager;
    public PlayerMovementFinal playerMovement; 
    public bool hasWon;
    public bool hasWonSubmit;
    public bool isMashingNeeded;
    public float fillAmount;
    public Image metre;
    public int mashingAmountNeeded;
    public int countdownTime;
    public int randomSubmit;
    public int submissionNo; 
    public Text countdownDisplay;
    // Start is called before the first frame update
    void Start()
    {
        //rigidbody2d = GetComponent<Rigidbody2D>(); 
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
        if(collision.gameObject.tag == "Submission")
        {
            animationEvents.isAttacking = true;
            randomSubmit = Random.Range(1, globalVariablesManager.maxrange); 
            submissionNo = Random.Range(1, globalVariablesManager.maxrange);
            if (submissionNo == randomSubmit)
            {
                Debug.Log("Submitted");
                hasWonSubmit = false; 
                //go to gave overscreen!!!
            }
            else
            {
              Debug.Log("DON'T SUBMIT");
                KnockBack();
                hasWonSubmit = true; 
            }
        }

        if (collision.gameObject.tag == "RopesRight")
        {
            Debug.Log("Hit Right");
            rigidbody2d.AddForce(transform.right * -10f);
        }
        if (collision.gameObject.tag == "RopesLeft")
        {
            rigidbody2d.AddForce(transform.right * 10f);
            Debug.Log("Hit Left");
        }
        if (collision.gameObject.tag == "RopesUp")
        {
            rigidbody2d.AddForce(transform.up * -10f);
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

    public void KnockBack()
    {
        if (playerMovement.isFacingRight == true)
        {
            rigidbody2d.velocity = new Vector2(5, 5);
            animationEvents.isAttacking = false; 
        }
        else
        {
            rigidbody2d.velocity = new Vector2(-5, -5);
            animationEvents.isAttacking = false;
        }
    }
}
