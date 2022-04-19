using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectible")) {
            Destroy(other.gameObject);
        }
    }
}
