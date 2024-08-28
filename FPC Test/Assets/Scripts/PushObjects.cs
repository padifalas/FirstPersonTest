using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushObjects : MonoBehaviour
{
    public float pushForce = 1f; // You can adjust this value in the inspector

    private void OnControllerColliderHit(ControllerColliderHit hit) 
    {
        Rigidbody rb = hit.collider.attachedRigidbody; // Gets the Rigidbody of the collided object

        if (rb != null && (hit.collider.CompareTag("RedObject") || hit.collider.CompareTag("BlueObject") || hit.collider.CompareTag("GreenObject"))) 
        {
            // Calculate the force direction
            Vector3 forceDirection = hit.gameObject.transform.position - transform.position;   
            forceDirection.y = 0; // Keep the force horizontal
            forceDirection.Normalize(); // Normalize the direction vector

            // Apply force to the Rigidbody at the point of contact
            rb.AddForceAtPosition(forceDirection * pushForce, transform.position, ForceMode.Impulse);
        }
    }
}


