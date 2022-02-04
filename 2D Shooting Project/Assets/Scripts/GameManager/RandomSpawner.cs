using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject gamePrefab;
    [SerializeField] private Vector2 minSpawn;
    [SerializeField] private Vector2 maxSpawn;
    [SerializeField] private int[] numList;
    public float spawnRate = 2f;
    private float nextSpawn;

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            SpawnObjectAtRandom();
        }
    }

    private void SpawnObjectAtRandom()
    {
        float randX = numList[Random.Range(0, numList.Length)] * Random.Range(minSpawn.x, maxSpawn.x);
        float randY = numList[Random.Range(0, numList.Length)] * Random.Range(minSpawn.y, maxSpawn.y);
        Vector3 randomPos = new Vector3(randX, randY, 0) + GameObject.FindGameObjectWithTag("Player").transform.position;

        Instantiate(gamePrefab, randomPos, Quaternion.identity);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(minSpawn, maxSpawn);
    }
}
