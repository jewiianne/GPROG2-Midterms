using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Vector3 startPosition = new Vector3(-10, 0, 0);
    public float spawnRadius = 5f;
    public float spawnInterval = 5f;

    private List<GameObject> activeEnemies = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, enemyPrefabs.Length);
            Vector3 randomOffset = Random.insideUnitSphere * spawnRadius; 
            Vector3 spawnPosition = startPosition + randomOffset;

            GameObject enemy = Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            activeEnemies.Add(enemy);

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    public List<GameObject> GetActiveEnemies()
    {
        return activeEnemies;
    }
}
