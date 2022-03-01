using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; 

public class Porjectiles : MonoBehaviour
{
    [SerializeField] public GameObject projectile;
    public bool isShooting;

    [SerializeField] Transform bulletSpawnPos; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Projectile(InputAction.CallbackContext context)
    {
        if(context.performed && !isShooting)
        {
            isShooting = true;

            GameObject b = Instantiate(projectile);
            b.GetComponent<Rigidbody2D>().velocity = new Vector2(3, 0);
            b.transform.position = bulletSpawnPos.transform.position; 
            Invoke("ResetShoot", 1f); 
        }
    }

    void ResetShoot()
    {
        isShooting = false; 
    }
}
