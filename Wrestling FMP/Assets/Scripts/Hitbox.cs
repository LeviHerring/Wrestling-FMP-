using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{

    [SerializeField] public float damageAmount;

    [SerializeField] public float superMetreChargeAmount;
    [SerializeField] public float knockback;
    [SerializeField] public float hitstun;

    public GameObject player; 

    Health health; 
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        Debug.Log("HIT DETECTED");

        if (collision.gameObject.tag == "Enemy")
        {
            Debug.Log("DETECTION");
            player.GetComponent<Health>().Damage(damageAmount, superMetreChargeAmount);

            //Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            //if(enemy != null)
            //{
            //    enemy.isKinematic = false;
            //    Vector2 difference = enemy.transform.position = transform.position;
            //    difference = difference.normalized * knockback;
            //    enemy.AddForce(difference, ForceMode2D.Impulse);
            //    enemy.isKinematic = true; 
            //}
        }
    }


    //public void Knockback(int x)
    //{

    //}
}
