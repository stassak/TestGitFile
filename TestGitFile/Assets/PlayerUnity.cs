using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnity : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpForce;
    public float gravityModifier;

    public bool isOnGround = true;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
