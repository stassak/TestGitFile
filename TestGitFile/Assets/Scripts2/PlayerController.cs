using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public LayerMask groundLayer;
    private Vector3 velocity;
    private bool isGrounded;

    public int maxHealth = 100;
    private int currentHealth;

    public Slider healthBar;

    InputAction movement;
    InputAction jump;

    public GameObject projectilePref;
    public Transform projectilePoint;

    void Start()
    {
        Debug.Log("Start() function has been called!");
        Debug.LogError("This is a test error!");
        currentHealth = maxHealth;

        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }
        else
        {
            Debug.LogError("Health Bar is not assigned in the Inspector!");
        }

        // Input setup for movement and jump
        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        jump = new InputAction("Jump", binding: "<Keyboard>/space");
        jump.AddBinding("<Gamepad>/buttonSouth");

        movement.Enable();
        jump.Enable();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePref, projectilePoint.position, projectilePref.transform.rotation);
        }

        // Movement Input
        Vector2 input = movement.ReadValue<Vector2>();
        Vector3 move = transform.right * input.x + transform.forward * input.y;

        controller.Move(move * speed * Time.deltaTime);

        // Ground Check
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset velocity when grounded
        }

        // Jump
        if (isGrounded && jump.ReadValue<float>() > 0)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.H))
        {
            Healing(10);
        }

        Debug.Log("Update is running..."); // Should print every frame

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        // Press 'T' to simulate taking damage
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    

    public void Healing(int heal)
    {
        Debug.Log("Its A health");
        currentHealth += heal;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
            
    }
    private void Die()
    {
        Debug.Log("Player has died!");
        // Add additional death logic here
    }

}
