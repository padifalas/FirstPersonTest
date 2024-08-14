using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoombaVacuum : MonoBehaviour
{
    public float speed = 1.4f;
    public float detectionRadius = 5f; 
   //public LayerMask destroyableLayer; //otherthings roomba can destroyy
    public LayerMask playerLayer; //which layer player is

    public Transform pointA;   //points the roomba will move between
    public Transform pointB; 

    private GameObject player;
    private bool isChasingPlayer = false;
    private bool isOff = false;
    private Transform currentTarget; 
    public int jumpCount = 0; 

    // Start is called before the first frame update
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
        
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, speed * Time.deltaTime);

        
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
        {
            currentTarget = currentTarget == pointA ? pointB : pointA;
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

    private void ChasePlayer() //follows player obnly along x n y axis and doesnt go up when player jumps (had that issue initially)
    {
        
        Vector3 targetPosition = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

       
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isOff) return; // Ignore collisions if the Roomba is off

        if (collision.collider.CompareTag("Player") && collision.contacts[0].normal.y > 0.5f)
        {
            jumpCount++;
           // Debug.Log("Player jumped on Roomba " + jumpCount + " times");

            if (jumpCount >= 2)
            {
                TurnOffRoomba();
            }
        }
    }

    private void TurnOffRoomba()
    {
        isOff = true;
        speed = 0f; 
        
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            rb.isKinematic = true;
        }
        Debug.Log("Roomba off.");
    }
}
