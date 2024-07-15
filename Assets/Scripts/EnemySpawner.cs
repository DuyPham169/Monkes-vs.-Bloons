using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject redBloon;
    [SerializeField] private float spawnRate;

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
        Instantiate(redBloon, transform.position, Quaternion.identity);
    }
}
