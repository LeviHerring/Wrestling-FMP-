using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtboxes : MonoBehaviour
{
    public Animator animator;
    public AnimationEvents animationEvents;
    public bool isHit;
    public float stopwatch;
    public float stopwatchTime; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        stopwatch = Time.deltaTime; 

        if(stopwatch < 0 && isHit == true)
        {
            isHit = false;
            animationEvents.isAttacking = false; 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(tag == "Hitbox")
        {
            animator.SetBool("IsHit", true);
            isHit = true; 
            animationEvents.isAttacking = true;
            stopwatchTime = stopwatchTime; 
            //wait amount of time which will be from the hitbox variable
            
            
            //do 
        }
    }
}
