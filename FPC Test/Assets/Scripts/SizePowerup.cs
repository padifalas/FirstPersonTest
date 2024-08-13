using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizePowerUp : MonoBehaviour
{
    public enum PowerUpType { Grow, Shrink }
    public PowerUpType powerUpType;
    public float sizeMultiplier = 2f; 
    public float duration = 5f; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ApplyPowerUp(other.gameObject));
        }
    }

    private IEnumerator ApplyPowerUp(GameObject player)
    {
        Vector3 originalScale = player.transform.localScale;

       
        if (powerUpType == PowerUpType.Grow)
        {
            player.transform.localScale = originalScale * sizeMultiplier;
            Debug.Log("player has grown!");
        }
        else if (powerUpType == PowerUpType.Shrink)
        {
            player.transform.localScale = originalScale / sizeMultiplier;
            Debug.Log("player  shrunk!");
        }

    
        gameObject.SetActive(false);

       
        yield return new WaitForSeconds(duration);

       
        player.transform.localScale = originalScale;
        Debug.Log("size powerup  ended ");

      
        Destroy(gameObject);
    }
}