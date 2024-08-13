using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BookStairs : MonoBehaviour
{
    private Rigidbody rb;
    public Transform LandingStairs;
    private bool snapped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    

    // Update is called once per frame
    private void Update()
    {
        if (snapped) return;

        /*f the book has not yet snapped,  check the book's current vertical position (transform.position.y)
         against the vertical position of the LandingStairs (LandingStairs.position.y).*/ 
        if (transform.position.y < LandingStairs.position.y)  
        {
            SnapToLandingPoint(LandingStairs);
        }
    }

    private void SnapToLandingPoint(Transform landingPoint)
    {
        //first, set the book's rb to be kinematic to stops the physics simulation for the Rigidbody, (frreezing the book in place)
       //  then set the book’s position and rotation to match the landing point 
        rb.isKinematic = true;
        transform.position = landingPoint.position;
        transform.rotation = landingPoint.rotation;
        snapped = true;
        Debug.Log("Book snapped and created steepp.");
    }
}