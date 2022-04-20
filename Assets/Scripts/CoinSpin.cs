using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpin : MonoBehaviour
{
    public float SpinSpeed = 12;
    public float BounceSpeed = 1;
    public float BounceScale = 1;
    private Vector3 InitialLocation;

    void Start()
    {
        InitialLocation = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Slowly turn the coin depending on how much time passed.
        transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * SpinSpeed);
        // Move the coin up and down in a sine wave.
        float NewPos = Mathf.Sin(Time.fixedTime * BounceSpeed) * BounceScale;
        transform.position = new Vector3(0, NewPos, 0) + InitialLocation;
    }
}
