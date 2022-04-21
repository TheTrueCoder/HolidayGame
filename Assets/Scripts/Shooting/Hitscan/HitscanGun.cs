using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class HitscanGun : MonoBehaviour
{
    public int damage = 1;
    public float range = 100;
    public bool playSound = true;

    public Camera fpsCam;
    public VisualEffect muzzleFlash;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        muzzleFlash.Play();
        if (playSound)
        {
            gameObject.GetComponent<AudioSource>().Play();
        }

        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage, hit.transform);
            }
        }
    }
}
