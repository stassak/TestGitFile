using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public Transform player;
    // public float healAmount = 10;
    public int heal = 10;

   /* private void HealPlayer()
    {
        Debug.Log("Player healing!!!!!");

        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.Healing(heal);
        }
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Healing(15);
            Destroy(gameObject);
        }
    }
}
