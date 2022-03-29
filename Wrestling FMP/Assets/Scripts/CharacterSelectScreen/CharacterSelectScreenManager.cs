using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class CharacterSelectScreenManager : MonoBehaviour
{
    public GameObject playerOne;
    //public GameObject playerTwo; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerOne.GetComponent<CharacterSelectScreenController>().isSelected == true)
        {
            SceneManager.LoadScene("SampleScene"); 
        }
    }
}
