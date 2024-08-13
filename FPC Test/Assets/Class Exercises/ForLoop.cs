using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForLoop : MonoBehaviour
{
    
   
    // Start is called before the first frame update
    void Start()
    {
        /*string[] names = { "Mario", "Luigi", "Toad" }; 
        for (int i = 0; i < 3; i++)
        {
            Debug.Log(names[i]);
        }
        */
        string[] names = { "Mario", "Luigi", "Toad" };
        for (int k = 2; k < 3; k--) 
        {
            Debug.Log(names[k]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
