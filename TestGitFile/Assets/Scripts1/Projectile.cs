using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 20.0f;

    public GameObject impactEffect;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
       
      

        //FindObjectOfType<AudioManager>().Play("Explsion");
        GameObject impactProj = Instantiate(impactEffect, transform.position , Quaternion.identity);
        Destroy(impactProj, 2);
        Destroy(gameObject);
    }
}
