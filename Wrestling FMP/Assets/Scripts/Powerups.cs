using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour
{

    public GameObject pickupEffect;
    Hitbox hitbox;


    public void Start()
    {
        hitbox = GetComponent<Hitbox>(); 
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            StartCoroutine(Pickup());
        }
    }

     IEnumerator Pickup()
    {
        Instantiate(pickupEffect, transform.position, transform.rotation); 

        Debug.Log("Picked Up!");

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false; 

        yield return new WaitForSeconds(3f);
        //GetComponent<Hitbox>().damageAmount = GetComponent<Hitbox>().damageAmount * 3; 
        Debug.Log("UNUNUNUNUPicked Up!");
        Destroy(gameObject);
    }
}
