using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    public Text pickupCounterText;
    public Text healthCounterText;
    public GameObject victoryMessage;  // gameObject that is enabled when the user wins.
    public GameObject deathMessage;
    public int health = 1;
    public int requiredCollectables = 1;
    public int collectableCounter = 0;

    void Start()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        pickupCounterText.text = collectableCounter + "/" + requiredCollectables;
        healthCounterText.text = health.ToString();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        UpdateCounter();
        if (health <= 0)
        {
            deathMessage.SetActive(true);
            Time.timeScale = 0;
        }
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
