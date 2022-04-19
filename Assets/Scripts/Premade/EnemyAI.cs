using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAI : MonoBehaviour
{
    private Player player;
    private NavMeshAgent agent;

    void Start()
    {
        player = FindObjectOfType<Player>();
        agent = gameObject.GetComponent<NavMeshAgent>();
        
    }
    void Update()
    {      
        agent.SetDestination(player.gameObject.transform.position);       
    }

}



