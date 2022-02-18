using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] bombPrefabs;
    public GameObject[] moneyPrefabs;
    private Vector3 spawnPosition;
    private float yRange = 15f;
    private float xRange = -15f;
    private float startTime = 2f;
    private float repeatRate = 1.5f;
    private float randomY;
    private int randomIndex;

    // Necesitamos esta variable para poder comunicarnos con el script PlayerController
    private PlayerController playerControllerScript;

    void Start()
    {
        // Spawneamos obstáculos cada cierto intervalo de tiempo
        InvokeRepeating("SpawnObstacle", startTime, repeatRate);

        // Llamamos al script del Player
        playerControllerScript = GameObject.Find ("Player").GetComponent<PlayerController>();
    }

    public Vector3 RandomSpawnPosition()
    {
        randomY = Random.Range(1, yRange);
        return new Vector3(xRange, randomY, 0);
    }


    public void SpawnObstacle()
    {
        if (!playerControllerScript.gameOver)
        {

            // Aparezcan las bombas de manera aleatoria
            randomIndex = Random.Range(0, bombPrefabs.Length);
            spawnPosition = RandomSpawnPosition();
            Instantiate(bombPrefabs[randomIndex], spawnPosition,
                bombPrefabs[randomIndex].transform.rotation);

            // Aparezcan las monedas de manera aleatoria
            randomIndex = Random.Range(0, moneyPrefabs.Length);
            spawnPosition = RandomSpawnPosition();
            Instantiate(moneyPrefabs[randomIndex], spawnPosition,
                moneyPrefabs[randomIndex].transform.rotation);
        }
            
    }
}
