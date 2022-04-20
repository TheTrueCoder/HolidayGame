using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float InflictedDamage = 1;

    void OnCollisionEnter(Collision other)
    {
        Collider OtherCollider = other.collider;
        if (OtherCollider.CompareTag("Enemy"))
        {
            OtherCollider.GetComponent<Enemy>().TakeDamage(1, gameObject);
            Destroy(gameObject);
        }
    }
}
