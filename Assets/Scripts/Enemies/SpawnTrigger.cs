using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemySpawner enemySpawner;
    public bool spawnOnce = true;
    private bool spawned = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!(spawnOnce && spawned))
            {
                StartCoroutine(enemySpawner.SpawnEnemies());
                spawned = true;
            }
        }
    }
}
