using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    public float timeLeft = 300.0f;

    public Text text;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        text.text = "Time Left: " + Mathf.Round(timeLeft);
        if (timeLeft < 0)
        {
            Debug.Log("Time is up!");
        }
    }
}

