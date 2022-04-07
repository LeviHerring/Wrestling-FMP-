using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI; 

public class TrainingMenuOpening : MonoBehaviour
{
    public PlayerInput playerInput;
    public GameObject panel; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MenuOpening(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            panel.gameObject.SetActive(true); 
            playerInput.enabled = false;
        }
    }
}
