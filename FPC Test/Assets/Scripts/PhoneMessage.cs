using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PhoneMessage : MonoBehaviour
{
    public GameObject floatingMessage; 
    public float detectionRadius = 5f; 
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        

        if (floatingMessage != null)
        {
            floatingMessage.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null && floatingMessage != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

           
            if (distanceToPlayer <= detectionRadius)
            {
                floatingMessage.SetActive(true);
                
                floatingMessage.transform.LookAt(player.transform);
                floatingMessage.transform.Rotate(0, 180, 0); 
            }
            else
            {
                floatingMessage.SetActive(false);
            }
        }
    }
    }

