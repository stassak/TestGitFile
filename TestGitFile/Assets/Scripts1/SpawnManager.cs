using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnGameObjects;

    private float spawnRangePosX = 10;
    private float spawnPosZ = 20;

    private float startDelay = 1;
    private float spawnInterval = 2;
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

    void SpawnRandomObjects()
    {
        int enemyIndex = Random.Range(0, spawnGameObjects.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-spawnRangePosX, spawnRangePosX), 1.5f, spawnPosZ);

        Instantiate(spawnGameObjects[enemyIndex], spawnPos, spawnGameObjects[enemyIndex].transform.rotation);
    }
}
