using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtboxes : MonoBehaviour
{
    public Animator animator;
    public AnimationEvents animationEvents; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tag == "Hitbox")
        {
            animator.SetBool("IsHit", true);
            animationEvents.isAttacking = true; 
            //wait amount of time which will be from the hitbox variable
            
            
            //do 
        }
    }
}
