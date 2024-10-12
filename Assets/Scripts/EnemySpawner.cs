using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minimumSpawnTime = 5f;
    [SerializeField] private float maximumSpawnTime = 10f;

    // Array of colors for the enemies
    private Color[] enemyColors = { Color.red, Color.green, Color.blue };

    private float timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        Color randomColor = enemyColors[Random.Range(0, enemyColors.Length)];
        enemy.GetComponent<Renderer>().material.color = randomColor; 

        Debug.Log("Spawned Enemy Color: " + randomColor);
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
