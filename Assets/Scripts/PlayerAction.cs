using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    public GameObject circle;

	// Use this for initialization
	void Start () {
        circle = GameObject.FindGameObjectsWithTag("A1")[1];
        
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        {
            Debug.Log(circle.ToString());
        }
	}
}
