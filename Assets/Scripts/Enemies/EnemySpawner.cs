using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int numberOfEnemies = 3;
    public float secondsBetweenSpawns = 0.5f;
    public bool spawnOnStart = true;
    public bool playLightAnimation = true;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (spawnOnStart)
        {
            StartCoroutine(SpawnEnemies());
        }
    }

    public IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
        {
            Instantiate(enemyPrefab, transform);
            gameObject.GetComponent<Animator>().Play("EnemySpawn");
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
    }
}
