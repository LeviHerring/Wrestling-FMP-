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
        if (context.performed && GetComponent<PlayerMovementFinal>().IsGrounded())
        {
            Debug.Log("Down and A");
        }
        else
        {
            Debug.Log("Down and A and Aerial");
        }
    }
    public void DownStrong(InputAction.CallbackContext context)
    {
        if (context.performed && GetComponent<PlayerMovementFinal>().IsGrounded())
        {
            Debug.Log("Up and A");
        }
        else
        {
            Debug.Log("Down and X and Aerial");
        }
    }
    public void DownSpecial(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Up and A");
        }
        else
        {
            Debug.Log("Down and B and Aerial");
        }
    }

    public void UpTilt(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Up and A");
        }
        else
        {
            Debug.Log("Up and A and Aerial"); 
        }
    }
    public void UpStrong(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Up and A");
        }
        else
        {
            Debug.Log("Up and X and Aerial");
        }
    }
    public void UpSpecial(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Up and A");
        }
        else
        {
            Debug.Log("Up and B and Aerial");
        }
    }
  



}
