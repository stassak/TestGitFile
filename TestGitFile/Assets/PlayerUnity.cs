using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnity : MonoBehaviour
{
    private Rigidbody playerRB;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRB.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
    }
}
