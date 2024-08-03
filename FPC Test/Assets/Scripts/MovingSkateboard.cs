using UnityEngine;

public class MovingSkateboards : MonoBehaviour
{
    public Transform[] pathpoints; // points between for the platform to move between
    public float speed = 2f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        if (pathpoints.Length > 0)
        {
            Transform targetWaypoint = pathpoints[currentWaypointIndex];
            Vector3 direction = targetWaypoint.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % pathpoints.Length;
            }
        }
    }

    private void OnTriggerEnter(Collider other) //lol thanks sabs 
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}