using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text counter;
    public int collectibleCounter = 0;
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Collectable")) {
            collectibleCounter += 1;
            counter.text = collectibleCounter.ToString();
            Destroy(other.gameObject);
        }
    }
}
