using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text counter;
    public GameObject victoryMessage;  // gameObject that is enabled when the user wins.
    public int requiredCollectables = 1;
    private int collectableCounter = 0;

    void Start()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        counter.text = collectableCounter + "/" + requiredCollectables;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Count collectable pickups.
        if (other.CompareTag("Collectable"))
        {
            collectableCounter += 1;
            UpdateCounter();
            Destroy(other.gameObject);
        }

        // When the player finishes the game.
        if (other.CompareTag("Finish") && collectableCounter >= requiredCollectables)
        {
            victoryMessage.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
