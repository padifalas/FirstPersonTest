using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaVacuum : MonoBehaviour
{
    public float speed = 4f; // Speed of the Roomba
    public float detectionRadius = 5f; // Radius in which the Roomba detects the player
    public LayerMask destroyableLayer; // Layer of objects that the Roomba can destroy
    public LayerMask playerLayer; // Layer to detect the player

    public Transform pointA;
    public Transform pointB;

    private GameObject player;
    private bool isChasingPlayer = false;
    private bool isOff = false;
    private Transform currentTarget; // The current target point for the Roomba

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        currentTarget = pointB;
    }

    private void Update()
    {
        if (!isOff)
        {
            DetectPlayer();
            if (isChasingPlayer)
            {
                ChasePlayer();
            }
            else
            {
                MoveAround();
            }
        }
    }

    private void MoveAround()
    {
        // Move towards the current target point
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        // Switch target points when reaching the current target
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
        }

        // Detect and destroy objects in front of the Roomba
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f, destroyableLayer))
        {
            Destroy(hit.collider.gameObject);
            Debug.Log("Roomba destroyed an object.");
        }
    }

    private void DetectPlayer()
    {
        if (Vector3.Distance(transform.position, player.transform.position) <= detectionRadius)
        {
            isChasingPlayer = true;
        }
        else
        {
            isChasingPlayer = false;
        }
    }

    private void ChasePlayer()
    {
        // Calculate the target position only on the X and Z axes (ignore Y axis)
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        // Move towards the player's XZ position
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        // If the player jumps on the Roomba, turn it off
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.contacts[0].normal.y > 0.9f) // Check if the collision is from above
            {
                TurnOffRoomba();
            }
        }
    }

    private void TurnOffRoomba()
    {
        isOff = true;
        speed = 0f; 
        this.enabled = false; //script
        GetComponent<Collider>().enabled = false; 
        GetComponent<Rigidbody>().isKinematic = true;
        
        Debug.Log("Roomba has been turned off by the player.");

        
       
    }
}
