using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    private int CollectibleCounter = 0;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectible")) {
            CollectibleCounter += 1;
            Destroy(other.gameObject);
        }
    }
}
