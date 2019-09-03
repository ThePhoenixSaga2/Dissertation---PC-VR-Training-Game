using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {

    private float timer; //How long the tutorial session has been running for

    // Use this for initialization
    void Start() {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime; //Count up the timer for as long as the game runs
    }

    public float GetTimer()
    {
        return timer; //Show the final time when requested
    }
}
