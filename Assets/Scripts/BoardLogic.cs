using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLogic : MonoBehaviour {

    public GameObject circle;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(circle, new Vector2(Input.mousePosition.x, Input.mousePosition.y), Quaternion.identity);
        }
	}

    void CreatePiece () {
         Vector2 mousePosition = Input.mousePosition;
         
    }
}
