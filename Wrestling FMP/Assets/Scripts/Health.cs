using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem; 

public class Health : MonoBehaviour
{
    public Text healthText;

    public Image superMetre;
    public float superMetreCharge = 0f; 

    [SerializeField] string playerNo; 

    float health = 0f; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health + "%";  
        if (superMetreCharge > 1)
        {
            superMetreCharge = 1f; 
        }
        superMetre.fillAmount = superMetreCharge;
    }

    public void Damage(float damagePoints, float superMetreChargePoints)
    {
        health += damagePoints;
        superMetreCharge += superMetreChargePoints; 
    }

    public void Finisher(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            if(superMetreCharge == 1)
            {
                Debug.Log("SuperAttack");
            }
            else
            {
                Debug.Log("Do not do Super Attack"); 
            }
        }
    }
}
