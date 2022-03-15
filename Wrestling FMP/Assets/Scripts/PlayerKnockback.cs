using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    AnimationEvents animationEvents; 
    PlayerMovementFinal playerMovement;
    FacingDirection facingDirection; 
    Rigidbody2D rigidbody2d;
    //public Hitbox hitbox; 

    //[SerializeField] float knockbackLength = 0.01f;
    //[SerializeField] float knockbackForce = 1f; 
    // Start is called before the first frame update
    void Start()
    {
        facingDirection = GetComponent<FacingDirection>(); 
        playerMovement = GetComponent<PlayerMovementFinal>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        animationEvents = GetComponent<AnimationEvents>(); 
    }

    public void DoKnockBack(float knockbackLength, float knockbackForce, float verticalKnockbackForce)
    {
        StartCoroutine(DisablePlayerMovement(knockbackLength)); 
        rigidbody2d.velocity = new Vector2(knockbackForce, verticalKnockbackForce); 

    }

    IEnumerator DisablePlayerMovement(float time)
    {
        animationEvents.isAttacking = true;

        yield return new WaitForSeconds(time);
        animationEvents.isAttacking = false; 
    }


}
