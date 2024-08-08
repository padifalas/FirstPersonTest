using UnityEngine;

public class MovingSkateboards : MonoBehaviour
{
    public Transform[] pathpoints; // points between for the platform to move between
    public float speed = 2f;

    private int currentPathpointIndex = 0;

    void Update()
    {
        if (pathpoints.Length > 0)
        {
            Transform targetPathpoint = pathpoints[currentPathpointIndex];
            Vector3 direction = targetPathpoint.position - transform.position;
            transform.position += direction.normalized * speed * Time.deltaTime;

            if (Vector3.Distance(transform.position, targetPathpoint.position) < 0.1f)
            {
                currentPathpointIndex = (currentPathpointIndex + 1) % pathpoints.Length;
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