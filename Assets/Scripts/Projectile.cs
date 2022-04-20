using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float InflictedDamage = 1;
    public float ExplosionStrength = 1;
    public float ExplosionRadius = 100;

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Enemy")) {
            Rigidbody EnemyRB = other.gameObject.GetComponent<Rigidbody>();
            EnemyRB.isKinematic = false;
            EnemyRB.AddExplosionForce(ExplosionStrength, transform.position, ExplosionRadius);
        }
    }
}
