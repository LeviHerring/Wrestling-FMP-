using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class SubmissionInput : MonoBehaviour
{
    GameObject submitHitbox;
    Animator animator;
    public AnimationEvents animationEvents;
    public PlayerMovementFinal playerMovement;
    public GameObject opponentOne;
    public GloablVariablesManager globalVariables;
    Rigidbody2D rigidbody2d;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pin(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            StartCoroutine(Pinning());
        }
    }

    IEnumerator Pinning()
    {
        animationEvents.isAttacking = true;
        submitHitbox.SetActive(true);
        animator.SetBool("IsGrabbing", true);
        yield return new WaitForSeconds(0.3f);
        submitHitbox.SetActive(false);
        animator.SetBool("IsGrabbing", false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animationEvents.isAttacking = true;
            animator.SetBool("IsPinning", true);
            HasOpponentWon();

        }
    }

    public void HasOpponentWon()
    {
        while (opponentOne.GetComponent<PlayerOneHurtboxes>().hasWonSubmit == false)
        {
            if (opponentOne.GetComponent<PlayerOneHurtboxes>().hasWonSubmit == true)
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
        if (playerMovement.isFacingRight == true)
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
