using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddySensor : MonoBehaviour
{
    public GameObject blueSensor, redSensor, greenSensor; 
    public GameObject drawer; 

    private bool blueMatched = false;
    private bool redMatched = false;
    private bool greenMatched = false;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("BlueObject") && gameObject == blueSensor)
        {
            blueMatched = true;
            Debug.Log("Correct Blue teddy is on blue sensor");
        }
        
        else if (other.gameObject.CompareTag("RedObject") && gameObject == redSensor)
        {
            redMatched = true;
            Debug.Log("Correct Red teddy is on red sensor");
        }
      
        else if (other.gameObject.CompareTag("GreenObject") && gameObject == greenSensor)
        {
            greenMatched = true;

            Debug.Log("Correct Green teddy is on green sensor");
        }
        else
        {
            Debug.Log("wrong; they dont match");
        }

        // check  all sensors are correctly matched
        if (blueMatched && redMatched && greenMatched)
        {
            Debug.Log("draweer opens.");
            drawer.SetActive(false); // deactivate the drawerfor now
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //start again if u move teddy away/past sensor
        if (other.gameObject.CompareTag("BlueObject") && gameObject == blueSensor)
        {
            blueMatched = false;
            Debug.Log("blue teddy removed from blue sensor");
        }
        else if (other.gameObject.CompareTag("RedObject") && gameObject == redSensor)
        {
            redMatched = false;
            Debug.Log("ed teddy removed from red sensor");
        }
        else if (other.gameObject.CompareTag("GreenObject") && gameObject == greenSensor)
        {
            greenMatched = false;
            Debug.Log("greeen teddy removed from green sensor");
        }
    }       

    
}

