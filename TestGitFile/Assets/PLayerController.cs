using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PLayerController : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider; // Reference to the health slider

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; // Initialize player's health

        // Ensure the slider reflects the player's starting health
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
        else
        {
            Debug.LogError("Health Slider is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0

        Debug.Log("Player Health: " + currentHealth);

        // Update the slider's value
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!");
        // Add death logic here
    }
}
