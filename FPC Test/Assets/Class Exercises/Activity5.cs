using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//SWITCH STATEMENTS //NO 'break' switch will continue to the nect line/case                
//default means it runs that case if the score is neither of the cases
public class Activity5 : MonoBehaviour
{
    private string name = "Mario";
    // Start is called before the first frame update
    void Start()
    {
        switch (name)
        {
           case"Mario": 
               Debug.Log("hey mario");
               break;
           
           default:
               Debug.Log("hey stranger");
               break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
