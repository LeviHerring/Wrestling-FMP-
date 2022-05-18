using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmissionHitbox : MonoBehaviour
{
    public GameObject player; 

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
        if (collision.gameObject.tag == player.GetComponent<SubmissionInput>().opponentOne.tag)
        {
            player.GetComponent<AnimationEvents>().isAttacking = true;
            player.GetComponent<Animator>().SetBool("IsPinning", true);
            player.GetComponent<SubmissionInput>().HasOpponentWon();

        }
    }
}
