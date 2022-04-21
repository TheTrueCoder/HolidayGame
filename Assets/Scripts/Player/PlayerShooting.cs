using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject Projectile;
    public Transform BulletLocation;
    public float FireSpeed = 3000;
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(Projectile, BulletLocation, false);
            bullet.transform.SetParent(null);
            bullet.gameObject.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(FireSpeed, 0, 0));
        }
    }
}
