using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
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
        Debug.Log("COLLISIOn!");

        if (collision.gameObject.name == "Neutral")
        {
            Debug.Log("I was hit by Neutral");
        }
        if (collision.gameObject.name == "Special")
        {
            Debug.Log("I was hit by SPECIAL");
        }
        if (collision.gameObject.name == "Strong")
        {
            Debug.Log("I was hit by STRONGSTRONGSTRONG");
        }
    }
}
