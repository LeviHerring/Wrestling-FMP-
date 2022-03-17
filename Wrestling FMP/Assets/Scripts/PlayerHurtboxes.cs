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
    public float disabledTime;
    public GloablVariablesManager globalVariablesManager;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        stopwatch = Time.deltaTime; 

        if(stopwatch <= 0 && isHit == true)
        {
            isHit = false;
            //animationEvents.isAttacking = false; 
            Debug.Log("Attacking is false"); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hitbox")
        {
            //StartCoroutine(DisablePlayerMovement(disabledTime));


        }

        if(collision.gameObject.tag == "Pin")
        {
            animationEvents.isAttacking = true; 
        }
    }



    IEnumerator DisablePlayerMovement(float time)
    {
        animator.SetBool("IsHit", true);
        animationEvents.isAttacking = true;

        yield return new WaitForSeconds(time);
        animationEvents.isAttacking = false;
    }
}
