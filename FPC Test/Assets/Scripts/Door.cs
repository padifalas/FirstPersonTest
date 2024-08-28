using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform player;
    public float openDoorDistance = 3f; 
    public Animator doorAnimator;
    public GameObject key; 

    private bool isDoorOpened = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);

        if (distanceToPlayer < openDoorDistance && !isDoorOpened)
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
        {
            isDoorOpened = true;
            doorAnimator.SetTrigger("OpenDoor"); 
            Debug.Log("Door is opening.");
        }
    }



