using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeddySensor : MonoBehaviour
{
    public GameObject drawer; 
    
    private bool blueMatched = false;
    private bool redMatched = false;
    private bool greenMatched = false;

    private void OnTriggerEnter(Collider other)
    {
        // check  the object matches the correct sensor by comparing tags
        if (other.gameObject.CompareTag("BlueObject") && gameObject.CompareTag("BlueSensor"))
        {
            blueMatched = true;
            Debug.Log("Correct blue  teddy is on blue sensor");
        }
        else if (other.gameObject.CompareTag("RedObject") && gameObject.CompareTag("RedSensor"))
        {
            redMatched = true;
            Debug.Log("Correct red teddy is on red sensor");
        }
        else if (other.gameObject.CompareTag("GreenObject") && gameObject.CompareTag("GreenSensor"))
        {
            greenMatched = true;
            Debug.Log("Correct green teddy is on green sensor");
        }
        else
        {
            Debug.Log("wrong; teddy not on correct sensor");
        }

        // Check if all sensors are correctly matched
        if (blueMatched && redMatched && greenMatched)
        {
            Debug.Log("Drawer open.");
            drawer.SetActive(false); // Deactivate the drawer for now
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the matching state if an object is removed from the sensor
        if (other.gameObject.CompareTag("BlueObject") && gameObject.CompareTag("BlueSensor"))
        {
            blueMatched = false;
            Debug.Log("Blue teddy removed from blue sensor");
        }
        else if (other.gameObject.CompareTag("RedObject") && gameObject.CompareTag("RedSensor"))
        {
            redMatched = false;
            Debug.Log("Red teddy removed from red sensor");
        }
        else if (other.gameObject.CompareTag("GreenObject") && gameObject.CompareTag("GreenSensor"))
        {
            greenMatched = false;
            Debug.Log("Green teddy removed from green sensor");
        }
    }
}
