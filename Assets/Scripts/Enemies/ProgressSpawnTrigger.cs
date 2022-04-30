using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressSpawnTrigger : SpawnTrigger
{
    public override bool SpawnCondition(Collider other)
    {
        PlayerStats playerStats = other.GetComponent<PlayerStats>();
        return playerStats.collectableCounter >= playerStats.requiredCollectables;
    }
}
