using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float InflictedDamage = 1;
    public float ExplosionStrength = 1;
    public float ExplosionRadius = 100;

    void OnCollisionEnter(Collision other)
    {
        Collider OtherCollider = other.collider;
        if (OtherCollider.CompareTag("Enemy"))
        {
            Rigidbody EnemyRB = OtherCollider.gameObject.GetComponent<Rigidbody>();
            EnemyRB.isKinematic = false;
            EnemyRB.AddExplosionForce(ExplosionStrength, transform.position, ExplosionRadius);
            Destroy(gameObject);
        }
    }
}
