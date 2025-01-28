using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;


public class PLayerController : MonoBehaviour
{
    public CharacterController controller; // Reference to the CharacterController
    public float speed = 10f; // Movement speed
    public float jumpHeight = 2f; // Jump height
    public float gravity = -9.81f; // Gravity strength
    public Transform groundCheck; // A transform to check if the player is on the ground
    public float groundDistance = 0.4f; // Radius of the sphere to detect ground
    public LayerMask groundMask; // Layer for what counts as ground

    private Vector3 velocity; // Stores vertical velocity
    private bool isGrounded; // Whether the player is on the ground

    // Health variables
    public int maxHealth = 100; // Maximum health
    private int currentHealth; // Current health
    public Slider healthSlider; // UI slider to show health

    void Start()
    {
        // Initialize health
        currentHealth = maxHealth;

        // Update health slider if assigned
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

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Reset vertical velocity when grounded
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Small value to keep the player grounded
        }

        // Get input for movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 move = transform.right * x + transform.forward * z;

        // Move the player
        controller.Move(move * speed * Time.deltaTime);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;

        // Apply vertical movement
        controller.Move(velocity * Time.deltaTime);
    }

    // Function to reduce health
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log("Player Health: " + currentHealth);

        // Update health slider if assigned
        if (healthSlider != null)
        {
            healthSlider.value = currentHealth;
        }

        // Check for player death
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Function to handle player death
    private void Die()
    {
        Debug.Log("Player has died!");
        // Add additional death handling logic (e.g., respawn, game over screen)
    }
}
