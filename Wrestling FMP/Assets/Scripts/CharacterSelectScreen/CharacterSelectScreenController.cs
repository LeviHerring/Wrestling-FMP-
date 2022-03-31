using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class CharacterSelectScreenController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; 

    [SerializeField] public int position = 2;

    [SerializeField] public int[] bounds;

    public bool isSelected; 
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Left(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(!(position <= bounds[0]))
            {
                position = position - 1;
                transform.position += new Vector3(-7, 0, 0);
            }
                
        }
    }
    public void Right(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Debug.Log("Pressed right"); 
            if(!(position >= bounds[1]))
            {
                position = position + 1;
                transform.position += new Vector3(7, 0, 0);
            }
          
        }
    }

    public void Select(InputAction.CallbackContext context)
    {
        Debug.Log("Pressed"); 
        if (context.performed)
        {
            isSelected = true;
            spriteRenderer.enabled = false; 
        }
      
    }
}
