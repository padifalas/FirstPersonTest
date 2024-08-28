using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSequenceController : MonoBehaviour
{
    public GameObject door; // Reference to the door object
    public string[] correctSequence = { "Yellow", "Red", "Green" }; // Correct sequence of colors
    private int currentIndex = 0; // Tracks the current index in the sequence
    public string playerTag = "Player"; // Tag to identify the player
    public GameObject[] sequenceGameObjects; // Array of game objects representing the sequence

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return; // Only proceed if the player steps on the object

        // Get the tag or name of the current game object the player collided with
        string colorTag = other.gameObject.tag;

        if (colorTag == correctSequence[currentIndex])
        {
            // Set the current sequence object inactive
            sequenceGameObjects[currentIndex].SetActive(false);

            currentIndex++;
            if (currentIndex >= correctSequence.Length)
            {
                // Correct sequence achieved
                door.SetActive(false); // Open the door
                Debug.Log("Door opened!");
                currentIndex = 0;

                // Optionally, reactivate all sequence objects for replayability
                ReactivateAllSequenceObjects();
            }
        }
        else
        {
            // Reset sequence on wrong input
            currentIndex = 0;
            Debug.Log("Incorrect sequence!");

            // Reactivate all sequence objects since the sequence was wrong
            ReactivateAllSequenceObjects();
        }
    }

    private void ReactivateAllSequenceObjects()
    {
        foreach (GameObject obj in sequenceGameObjects)
        {
            obj.SetActive(true); // Make all sequence objects reappear
        }
    }
}