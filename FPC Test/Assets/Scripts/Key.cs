using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
   // public Transform playerHand; 
    public float moveSpeed = 5f; 

    private bool isCollected = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true;
            gameObject.SetActive(false); // deactivate key
        }
    }
}