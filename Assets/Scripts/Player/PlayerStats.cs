using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text counter;
    public int CollectibleCounter = 0;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectible")) {
            CollectibleCounter += 1;
            counter.text = CollectibleCounter.ToString();
            Destroy(other.gameObject);
        }
    }
}
