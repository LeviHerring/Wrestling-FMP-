using UnityEngine;
using System.Collections; 
using UnityEngine.InputSystem;

public class PlayerMovementFinal : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private float horizontal;
    private float speed = 10f;
    private float baseSpeed = 10f; 
    private float jumpingPower = 10f;
    private bool isFacingRight = true;
    private float dashSpeed = 30f;
    private float dashTime = 0.2f;
    public float startDashTime;
    private int direction;
    private bool isDashing = false;
    bool canDoubleJump;
    AnimationEvents animationEvents;
    Animator animator; 
    Vector3 lastVelocity;

    [SerializeField] public GameObject neutral;

    [SerializeField] GameObject special;

    [SerializeField] GameObject strong;

    void Start()
    {
        animationEvents = GetComponent<AnimationEvents>();
        animator = GetComponent<Animator>(); 
    }

    void Update()
    {
        lastVelocity = rb.velocity; 

        if (!isFacingRight && horizontal > 0f)
        {
            Flip();
        }
        else if (isFacingRight && horizontal < 0f)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canDoubleJump = true; 
        }
        else if (context.performed && !IsGrounded() && canDoubleJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            canDoubleJump = false; 
        }

        if (context.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
    }

    public void AirDash(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Pressed");
        }
        if(!IsGrounded() && context.performed && !isDashing)
        {
            if(isFacingRight)
            {
                Debug.Log("Pressed in air and looking right");
                StartCoroutine(Dash()); 
                //rb.AddForce(transform.forward * dashSpeed);
                //rb.velocity = Vector2.left * dashSpeed; 
                //StartCoroutine(Dash(1f)); 

            }
            else
            {
                Debug.Log("Pressed in air and looking left");
                StartCoroutine(Dash());
                //rb.AddForce(transform.forward * -dashSpeed);
                //rb.velocity = Vector2.right * dashSpeed;
                //StartCoroutine(Dash(-1f));
            }
           
        }
    }

    public void Neutral(InputAction.CallbackContext context)
    {

        if(context.performed && GetComponent<AnimationEvents>().isAttacking == false && IsGrounded())
        {
            neutral.gameObject.SetActive(true); 
            animator.SetBool("isNeutral", true);
            Debug.Log("Pressed neutral button"); 
        }
    }

    public void Special(InputAction.CallbackContext context)
    {
        if (context.performed && GetComponent<AnimationEvents>().isAttacking == false && IsGrounded())
        {
            special.gameObject.SetActive(true);
            animator.SetBool("isSpecial", true);
            Debug.Log("Pressed Special button");
        }
    }

    public void Strong(InputAction.CallbackContext context)
    {
        if (context.performed && GetComponent<AnimationEvents>().isAttacking == false && IsGrounded())
        {
            strong.gameObject.SetActive(true); 
            animator.SetBool("isStrong", true);
            Debug.Log("Pressed Strong button");
        }
    }


    IEnumerator Dash()
    {
        isDashing = true; 
        speed = dashSpeed;

        yield return new WaitForSeconds(dashTime);

        speed = baseSpeed;
        isDashing = false; 
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(tag == "Ropes")
        {
            var speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f); 
        }
       

    }
}