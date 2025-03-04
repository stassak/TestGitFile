using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnGameObjects;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int objectIndex = Random.Range(0, spawnGameObjects.Length);

        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(spawnGameObjects[objectIndex],new Vector3(0,0,0) ,spawnGameObjects[objectIndex].transform.rotation);
        }
    }
}
