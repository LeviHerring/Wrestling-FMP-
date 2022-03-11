using UnityEngine;

public class Hitbox : MonoBehaviour
{

    [SerializeField] public float damageAmount;
    [SerializeField] public float damageAmountDivide;
    public DamageManager damageManager; 
    [SerializeField] public float superMetreChargeAmount;
    [SerializeField] public float knockback;
    [SerializeField] public float hitstun;

    public GameObject player;
    //public GameObject player2;
    //public GameObject player3;
    //public GameObject player4;



    Health health; 
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<Health>();
        damageAmount = damageManager.damage * damageManager.damageMultiplier; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        //Debug.Log("HIT DETECTED");

        if (collision.gameObject.name == player.gameObject.name)
        {
           

            Debug.Log("DETECTION");
            player.GetComponent<Health>().Damage(damageAmount, superMetreChargeAmount);

            Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
            if (enemy != null)
            {
                enemy.isKinematic = false;
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * knockback;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                enemy.isKinematic = true;
            }
        }
        //if (collision.gameObject.name == player2.gameObject.name)
        //{


        //    Debug.Log("DETECTION");
        //    player2.GetComponent<Health>().Damage(damageAmount, superMetreChargeAmount);

        //    Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
        //    if (enemy != null)
        //    {
        //        enemy.isKinematic = false;
        //        Vector2 difference = enemy.transform.position - transform.position;
        //        difference = difference.normalized * knockback;
        //        enemy.AddForce(difference, ForceMode2D.Impulse);
        //        enemy.isKinematic = true;
        //    }
        //}
        //if (collision.gameObject.name == player3.gameObject.name)
        //{


        //    Debug.Log("DETECTION");
        //    player3.GetComponent<Health>().Damage(damageAmount, superMetreChargeAmount);

        //    Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
        //    if (enemy != null)
        //    {
        //        enemy.isKinematic = false;
        //        Vector2 difference = enemy.transform.position - transform.position;
        //        difference = difference.normalized * knockback;
        //        enemy.AddForce(difference, ForceMode2D.Impulse);
        //        enemy.isKinematic = true;
        //    }
        //}
        //if (collision.gameObject.name == player4.gameObject.name)
        //{


        //    Debug.Log("DETECTION");
        //    player4.GetComponent<Health>().Damage(damageAmount, superMetreChargeAmount);

        //    Rigidbody2D enemy = collision.GetComponent<Rigidbody2D>();
        //    if (enemy != null)
        //    {
        //        enemy.isKinematic = false;
        //        Vector2 difference = enemy.transform.position - transform.position;
        //        difference = difference.normalized * knockback;
        //        enemy.AddForce(difference, ForceMode2D.Impulse);
        //        enemy.isKinematic = true;
        //    }
        //}

        //if(collision.tag == "PictureInPicture")
        //{
        //    Debug.Log("And we'll be back after these messages");

        //}
    }


    //public void Knockback(int x)
    //{

    //}
}
