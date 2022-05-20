using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{

    public bool isAttacking;
    public Animator animator;
    public bool isMoving;
    PlayerMovementFinal playerController;


    [SerializeField] GameObject neutral;

    [SerializeField] GameObject special;

    [SerializeField] GameObject strong;

    [SerializeField] GameObject pinHitbox; 
    [SerializeField] GameObject submitHitbox;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerMovementFinal>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AnimationEnd()
    {
        animator.SetBool("isNeutral", false);
        animator.SetBool("isStrong", false);
        animator.SetBool("isSpecial", false);
        animator.SetBool("isUp", false);
        animator.SetBool("isDown", false);
        animator.SetBool("IsGrabbing", false);

        isAttacking = false; 
    }

    public void HitboxClose()
    {
        //neutral.gameObject.SetActive(false);
        special.gameObject.SetActive(false);
        strong.gameObject.SetActive(false);
        GetComponent<PlayerMovementFinal>().neutral.gameObject.SetActive(false);
        pinHitbox.SetActive(false);
        submitHitbox.SetActive(false);
    }

    public void Histun()
    {
        animator.SetBool("IsHit", false);

        isAttacking = false; 
    }
}
