using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float InflictedDamage = 1;

    // void Start()
    // {
    //     new WaitForSeconds(5);
    //     Destroy(gameObject);
    // }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Hit!");
        Collider OtherCollider = other.collider;
        if (OtherCollider.CompareTag("Enemy"))
        {
            OtherCollider.GetComponent<Enemy>().TakeDamage(1, gameObject.transform);
        }
        Destroy(gameObject);
    }
}