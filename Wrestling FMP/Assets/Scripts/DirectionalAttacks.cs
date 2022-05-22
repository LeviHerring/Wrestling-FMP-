using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using System.Diagnostics;
using System.Threading;

public class DirectionalAttacks : MonoBehaviour
{
    PlayerMovementFinal PlayerMovementFinal;
    AnimationEvents animationEvents;
    public Animator animator; 
    //public DamageManager damageManager;
    //public GameObject detector;

    //[SerializeField] private InputActionReference actionModifier; 

    //public NarbyDallinHitbox darbyHitbox;
   // public bool isActivatedHere;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementFinal = GetComponent<PlayerMovementFinal>();
        animationEvents = GetComponent<AnimationEvents>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DownTilt(InputAction.CallbackContext context)
    {
        if (context.performed && GetComponent<PlayerMovementFinal>().IsGrounded() && animationEvents.isAttacking == false)
        {
            Debug.Log("Down and A");
            //animator.SetBool("isJumping", true);
            animator.SetBool("isNeutral", true);
            animator.SetBool("isDown", true);

        }
        else if (context.performed && GetComponent<PlayerMovementFinal>().IsGrounded() == false && animationEvents.isAttacking == false)
        {
            Debug.Log("Down and A and Aerial");
            animator.SetBool("isNeutral", true);
            animator.SetBool("isDown", true);
        }
    }
    public void DownStrong(InputAction.CallbackContext context)
    {
        if (context.performed && GetComponent<PlayerMovementFinal>().IsGrounded() && animationEvents.isAttacking == false)
        {
            Debug.Log("Up and A");
            animator.SetBool("isStrong", true);
            animator.SetBool("isDown", true);
        }
        else
        {
            Debug.Log("Down and X and Aerial");
            animator.SetBool("isStrong", true);
            animator.SetBool("isDown", true);
        }
    }
    public void DownSpecial(InputAction.CallbackContext context)
    {
        if (context.performed && animationEvents.isAttacking == false)
        {
            Debug.Log("Up and A");
            animator.SetBool("isSpecial", true);
            animator.SetBool("isDown", true);
        }
        else
        {
            Debug.Log("Down and B and Aerial");
            animator.SetBool("isSpecial", true);
            animator.SetBool("isDown", true);
        }
    }

    public void UpTilt(InputAction.CallbackContext context)
    {
        if (context.performed && animationEvents.isAttacking == false)
        {
            Debug.Log("Up and A");
            animator.SetBool("isUp", true);
            animator.SetBool("isNeutral", true); 

        }
        else
        {
            Debug.Log("Up and A and Aerial");
            animator.SetBool("isUp", true);
            animator.SetBool("isNeutral", true);
        }
    }
    public void UpStrong(InputAction.CallbackContext context)
    {
        if (context.performed && GetComponent<PlayerMovementFinal>().IsGrounded() && animationEvents.isAttacking == false)
        {
            Debug.Log("Up and A");
            animator.SetBool("isUp", true);
            animator.SetBool("isStrong", true);
        }
        else
        {
            Debug.Log("Up and X and Aerial");
            animator.SetBool("isUp", true);
            animator.SetBool("isStrong", true);
        }
    }
    public void UpSpecial(InputAction.CallbackContext context)
    {
        if (context.performed && animationEvents.isAttacking == false)
        {
            Debug.Log("Up and A");
            animator.SetBool("isUp", true);
            animator.SetBool("isSpecial", true);
        }
        else
        {
            Debug.Log("Up and B and Aerial");
            animator.SetBool("isUp", true);
            animator.SetBool("isSpecial", true);
        }
    }
  



}
