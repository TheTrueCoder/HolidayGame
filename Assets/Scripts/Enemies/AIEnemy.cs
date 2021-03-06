using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class AIEnemy : Enemy
{
    public int health = 4;
    public int damagePerHit = 1;
    public float explosionStrength = 100;
    public float explosionRadius = 100;
    public float attackWaitSeconds = 2;
    public float deathWaitSeconds = 4;
    public Slider healthBar;
    private GameObject player;
    private NavMeshAgent agent;
    private bool alive = true;

    void Start()
    {
        // player = FindObjectOfType<PlayerMovementFPS>().gameObject;
        agent = gameObject.GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        // Set health bar ranges.
        healthBar.minValue = 0;
        healthBar.maxValue = health;
        healthBar.value = health;
    }
    void Update()
    {
        if (agent.enabled)
        {
            agent.SetDestination(player.transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && alive)
        {
            agent.enabled = false;
            other.GetComponent<PlayerStats>().TakeDamage(damagePerHit);
            StartCoroutine(WaitAfterDamageInfliction(attackWaitSeconds));
        }
    }

    private IEnumerator WaitAfterDamageInfliction(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        // If the enemy has died after running into player, don't re-enable the agent.
        if (alive)
        {
            agent.enabled = true;
        }
    }

    public override void TakeDamage(int damage, Transform hitLocation)
    {
        health -= damage;
        healthBar.value = health;
        // If the enemy is out of health, kill it.
        if (health <= 0)
        {
            alive = false;
            agent.enabled = false;
            Rigidbody SelfRB = gameObject.GetComponent<Rigidbody>();
            SelfRB.isKinematic = false;
            SelfRB.AddExplosionForce(explosionStrength, hitLocation.position, explosionRadius);
            StartCoroutine(WaitDestroy(deathWaitSeconds, gameObject));
        }
    }

    private IEnumerator WaitDestroy(float seconds, GameObject objectToDestroy)
    {
        yield return new WaitForSeconds(seconds);
        Destroy(objectToDestroy);
    }
}
