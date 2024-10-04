using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemy;

    [SerializeField] private float minimumSpawnTime = 5;
    [SerializeField] private float maximumSpawnTime = 10;

    private float timeUntilSpawn;

    // Start is called before the first frame update
    void Awake()
    {
        setTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if(timeUntilSpawn <= 0 )
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            setTimeUntilSpawn();
        }
    }

    void setTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
