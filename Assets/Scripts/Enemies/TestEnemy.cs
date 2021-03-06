using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnemy : Enemy
{
    public float ExplosionStrength = 100;
    public float ExplosionRadius = 100;
    public override void TakeDamage(int damage, Transform hitLocation) {
        Rigidbody SelfRB = gameObject.GetComponent<Rigidbody>();
        SelfRB.isKinematic = false;
        SelfRB.AddExplosionForce(ExplosionStrength, hitLocation.position, ExplosionRadius);
    }
}
