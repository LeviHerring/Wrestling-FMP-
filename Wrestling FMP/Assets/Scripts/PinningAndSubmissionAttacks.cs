using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class PinningAndSubmissionAttacks : MonoBehaviour
{
    public GameObject pinHitbox;
    Animator animator;
     AnimationEvents animationEvents;
     PlayerMovementFinal playerMovement;
    public GameObject opponentOne;
     GloablVariablesManager globalVariables;
    Rigidbody2D rigidbody2d; 

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animationEvents = GetComponent<AnimationEvents>();
        playerMovement = GetComponent<PlayerMovementFinal>();
        globalVariables = FindObjectOfType<GloablVariablesManager>(); 


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Pin(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            StartCoroutine(Pinning()); 
        }
    }

    IEnumerator Pinning()
    {
        animationEvents.isAttacking = true; 
        pinHitbox.SetActive(true);
        animator.SetBool("IsGrabbing", true); 
        yield return new WaitForSeconds(0.3f);
        pinHitbox.SetActive(false);
        animator.SetBool("IsGrabbing", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            animationEvents.isAttacking = true; 
            animator.SetBool("IsPinning", true);
            HasOpponentWon(); 

        }
    }

    public void HasOpponentWon()
    {
        while(opponentOne.GetComponent<PlayerOneHurtboxes>().hasWon == false)
        {
            if (opponentOne.GetComponent<PlayerOneHurtboxes>().hasWon == true)
            {
                StartCoroutine(LaunchBack());
            }
            else
            {
                return; 
            }
        }
       
    }

    IEnumerator LaunchBack()
    {
        if(playerMovement.isFacingRight == true)
        {
            rigidbody2d.velocity = new Vector2(5, 5);

            yield return new WaitForSeconds(0.01f);
            animationEvents.isAttacking = false;

        }
        else
        {
            rigidbody2d.velocity = new Vector2(-5, 5);
            yield return new WaitForSeconds(0.01f);
            animationEvents.isAttacking = false;
        }
       
    }
}
