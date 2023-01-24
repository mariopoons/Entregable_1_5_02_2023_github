using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;

    private float startDelay = 2f;
    private float respawnDelay = 2f;

    private PlayerControllerX playerControllerXScript;

    private void Start()
    {

        // creará un obstaculo cada 2 segundos
        InvokeRepeating("SpawnObstacle", startDelay, respawnDelay);

        playerControllerXScript = FindObjectOfType<PlayerControllerX>();
    }

    // spawneará el obstaculo
    private void SpawnObstacle()
    {
        int randomIdx = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomIdx], new Vector3(25,Random.Range(3f,15f),0), obstaclePrefabs[randomIdx].transform.rotation);
    }

    private void Update()
    {
        if (playerControllerXScript.gameOver)
        {
            CancelInvoke("SpawnObstacle");
        }
    }
}

