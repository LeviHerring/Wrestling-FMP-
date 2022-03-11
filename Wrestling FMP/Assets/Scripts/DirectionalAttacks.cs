using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using System.Diagnostics;
using System.Threading;

public class DirectionalAttacks : MonoBehaviour
{
    PlayerMovementFinal PlayerMovementFinal;
    AnimationEvents animationEvents;
    public DamageManager damageManager;
    public GameObject detector;

    [SerializeField] private InputActionReference actionModifier; 

    //public NarbyDallinHitbox darbyHitbox;
   // public bool isActivatedHere;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementFinal = GetComponent<PlayerMovementFinal>();
        animationEvents = GetComponent<AnimationEvents>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}
