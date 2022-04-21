using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIEnemy : Enemy
{
    public int health = 10;
    public const float ExplosionStrength = 100;
    public const float ExplosionRadius = 100;
    private GameObject player;
    private NavMeshAgent agent;

    void Start()
    {
        // player = FindObjectOfType<PlayerMovementFPS>().gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    public override void TakeDamage(int damage, Transform hitLocation)
    {
        health -= damage;
        if (health <= 0) {
            Rigidbody SelfRB = gameObject.GetComponent<Rigidbody>();
            SelfRB.isKinematic = false;
            SelfRB.AddExplosionForce(ExplosionStrength, hitLocation.position, ExplosionRadius);
            Destroy(gameObject);
        }
    }
}
