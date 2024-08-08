using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity6 : MonoBehaviour
{
    public int a = 5; 
    // Start is called before the first frame update
    void Start()
    {
        switch (a)
        {
            case 1:
                Debug.Log("One");
                break;
            
            case 2:
                Debug.Log("Two");
                break;
            
            case 3:
                Debug.Log("three");
                break;
            
            case 4:
                Debug.Log("four");
                break;
            
            case 5:
                Debug.Log("five");
                break;
            
            default:
                Debug.Log("unknownnnn");
                break; 
                
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
