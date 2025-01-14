using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.InputSystem;


public class PLayerController : MonoBehaviour
{

    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthSlider; // Reference to the health slider

    public CharacterController controller; // Reference to the CharacterController component
    public float speed = 10f; // Movement speed
    public float jumpHeight = 3f; // Jump height
    public float gravity = -9.81f; // Gravity force
    public Transform groundCheck; // Empty GameObject to check if the player is grounded
    public LayerMask groundLayer; // Layer to detect the ground

    private Vector3 velocity; // Store velocity for jumping and gravity
    private bool isGrounded; // Check if the player is grounded
    private InputAction movement; // For handling player movement input
    private InputAction jump; // For handling jump input

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

        // Set up input actions
        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
           .With("Up", "<keyboard>/w")
           .With("Up", "<keyboard>/upArrow")
           .With("Down", "<keyboard>/s")
           .With("Down", "<keyboard>/downArrow")
           .With("Left", "<keyboard>/a")
           .With("Left", "<keyboard>/leftArrow")
           .With("Right", "<keyboard>/d")
           .With("Right", "<keyboard>/rightArrow");

        jump = new InputAction("Jump", binding: "<keyboard>/space");
        jump.AddBinding("<Gamepad>/a");

        movement.Enable();
        jump.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement input
        Vector2 input = movement.ReadValue<Vector2>();
        float x = input.x;
        float z = input.y;

        // Move player
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.3f, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset downward velocity when grounded
        }

        // Jumping logic
        if (isGrounded && jump.ReadValue<float>() > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
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
