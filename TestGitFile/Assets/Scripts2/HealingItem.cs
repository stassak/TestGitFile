using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public Transform player;
    
    // Amount of health restored
   // public int heal = 10;

  

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Healing(15);
            Destroy(gameObject);
        }
    }


   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            if (playerController != null)
            {
                playerController.Healing(heal); // Heal the player
                Debug.Log("Player healed by " + heal + " points!");
                Destroy(gameObject); // Remove the healing item after use
            }
        }
    }*/
}
