using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EenemyCo : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public int damage = 10;

    private float attackCooldown = 2f;
    private float lastAttackTime = 0f;

    void Update()
    {
        // Move towards the player
        if (player != null)
        {
            float distance = Vector3.Distance(transform.position, player.position);

            if (distance > attackRange)
            {
                // Move closer to the player
                Vector3 direction = (player.position - transform.position).normalized;
                transform.position += direction * moveSpeed * Time.deltaTime;
            }
            else
            {
                // Attack the player
                if (Time.time >= lastAttackTime + attackCooldown)
                {
                    AttackPlayer();
                    lastAttackTime = Time.time;
                }
            }
        }
    }

    private void AttackPlayer()
    {
        Debug.Log("Enemy attacks the player!");

        // Check if player has the PlayerController script
        PlayerController playerController = player.GetComponent<PlayerController>();
        if (playerController != null)
        {
            playerController.TakeDamage(damage);
        }
    }
}
