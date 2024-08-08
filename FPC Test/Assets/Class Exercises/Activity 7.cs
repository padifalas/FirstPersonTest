using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity7 : MonoBehaviour
{
    public int playerScore = 5; 
    // Start is called before the first frame update
    void Start()
    {
        switch (playerScore)
        {
            case 0:
            case 1:
            case 2:
                Debug.Log("you suck at the game");
                break;
            
            case 3:
                case4:
                Debug.Log("meh"); 
                break; 
                
    }

    // Update is called once per frame
    void Update()
    {
        
    }
} 
    }

