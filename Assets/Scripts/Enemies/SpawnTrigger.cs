using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemySpawner[] enemySpawners;
    public bool spawnOnce = true;
    private bool spawned = false;

    public virtual bool SpawnCondition(Collider other)
    {
        return true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && SpawnCondition(other))
        {
            if (!(spawnOnce && spawned))
            {
                foreach (EnemySpawner enemySpawner in enemySpawners)
                {
                    StartCoroutine(enemySpawner.SpawnEnemies());
                }
                spawned = true;
            }
        }
    }
}
