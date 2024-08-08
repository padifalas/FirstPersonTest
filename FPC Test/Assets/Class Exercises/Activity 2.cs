using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activity2 : MonoBehaviour
{
    public int a = 8;

    public int b = 12;
    // Start is called before the first frame update
    void Start()
    {
        if (a > b)
        {
            Debug.Log("A is larger than B");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
