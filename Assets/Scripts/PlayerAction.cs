using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {

    // Circle object and transform properties
    public GameObject circle;
    public Transform circlePiece;

    // Cross object and transform properties
    public GameObject cross;
    public Transform crossPiece;

    // Setting a distance to calculate the position in the visible area
    // Defining the mousePosition and the spot We want to show the object
    public float distance = 10f;
    Vector2 mousePosition, spotPosition;

    // A simple boolean to switch between one kind of piece and the other
    public bool isCross = true;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Setting the mouse position
        // Setting the spot position in the visible area
        mousePosition   = Input.mousePosition;
        spotPosition  = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));

        // Setting circle and cross positions
        circlePiece.position = spotPosition;
        crossPiece.position = spotPosition;

        // When left click of the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // We check which piece moves
            if(isCross)
            {
                // If its the cross time, set it to false for the next move and create a cross piece
                isCross = false;
                createPiece(circlePiece);
            } else
            {
                // If its the cricle time, set it to true for the next move and create a circle piece
                isCross = true;
                createPiece(crossPiece);
            }
            
        }
    }

    // Simple function to instantiate a piece
    void createPiece (Transform piece)
    {
        Instantiate(piece, piece.transform.position, piece.transform.rotation);
    }
}
