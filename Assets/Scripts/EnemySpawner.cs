using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject redBloon;
    [SerializeField] private float spawnRate;
    [SerializeField] private int laneRange;

    private float lastSpawnTime = 0f;

    private void Start()
    {
        spawnBloon();
    }

    private void Update()
    {
        if (Time.time - lastSpawnTime >= spawnRate)
        {
            lastSpawnTime = Time.time;
            spawnBloon();
        }
    }

    private void spawnBloon()
    {
        int lanePos = Random.Range(-2, 3) * laneRange;
        Vector2 spawnPos = new Vector2(transform.position.x, transform.position.y + lanePos);

        Instantiate(redBloon, spawnPos, Quaternion.identity);
    }
}
