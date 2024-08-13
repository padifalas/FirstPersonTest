using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhileLoop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int num = 0;

        while (num < 10)
        {
            num++;
        }
        
        Debug.Log(num);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
