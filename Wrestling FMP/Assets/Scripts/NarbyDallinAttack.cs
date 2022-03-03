using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class NarbyDallinAttack : MonoBehaviour
{

    PlayerMovementFinal PMF;
    AnimationEvents animationEvents;
    public GameObject detector; 
    // Start is called before the first frame update
    void Start()
    {
        PMF = GetComponent<PlayerMovementFinal>();
        animationEvents = GetComponent<AnimationEvents>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PIP(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            animationEvents.isAttacking = true;
            detector.gameObject.SetActive(true); 

        }
        switch (context.phase)
        {
            case InputActionPhase.Performed:
                Debug.Log("Performed");
                break;
            case InputActionPhase.Started:
                Debug.Log("Started");
                break;
            case InputActionPhase.Canceled:
                Debug.Log("Cancelled");
                break; 
        }
    }
}
