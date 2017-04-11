using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAction : MonoBehaviour {

    public Sprite circleSprite;
    public Sprite crossSprite;
    private GameObject currentBox;
    Dictionary<string, int> cells = new Dictionary<string, int>();

    // A simple boolean to switch between one kind of piece and the other
    public bool isCross = true;
    
    // Use this for initialization
    void Start()
    {   
        cells["A1"] = 0;
        cells["A2"] = 0;
        cells["A3"] = 0;
        cells["B1"] = 0;
        cells["B2"] = 0;
        cells["B3"] = 0;
        cells["C1"] = 0;
        cells["C2"] = 0;
        cells["C3"] = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if(cells["A1"] == 1 && cells["A2"] == 1 && cells["A3"] == 1 ||
            cells["A1"] == 1 && cells["B1"] == 1 && cells["C1"] == 1 ||
            cells["A1"] == 1 && cells["B2"] == 1 && cells["C3"] == 1 ||
            cells["A2"] == 1 && cells["B2"] == 1 && cells["C2"] == 1 ||
            cells["A3"] == 1 && cells["B3"] == 1 && cells["C3"] == 1 ||
            cells["A3"] == 1 && cells["B2"] == 1 && cells["C1"] == 1 ||
            cells["B1"] == 1 && cells["B2"] == 1 && cells["B3"] == 1 ||
            cells["C1"] == 1 && cells["C2"] == 1 && cells["C3"] == 1)
        {
            Debug.Log("Cross Wins");
            Time.timeScale = 0;
        } else if (cells["A1"] == 2 && cells["A2"] == 2 && cells["A3"] == 2 ||
            cells["A1"] == 2 && cells["B1"] == 2 && cells["C1"] == 2 ||
            cells["A1"] == 2 && cells["B2"] == 2 && cells["C3"] == 2 ||
            cells["A2"] == 2 && cells["B2"] == 2 && cells["C2"] == 2 ||
            cells["A3"] == 2 && cells["B3"] == 2 && cells["C3"] == 2 ||
            cells["A3"] == 2 && cells["B2"] == 2 && cells["C1"] == 2 ||
            cells["B1"] == 2 && cells["B2"] == 2 && cells["B3"] == 2 ||
            cells["C1"] == 2 && cells["C2"] == 2 && cells["C3"] == 2)
        {
            Debug.Log("Circle Wins");
            Time.timeScale = 0;
        }
        // When left click of the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
                currentBox = getObjectClicked();
                changeBoardPiece(currentBox);
        }
    }

    /// <summary>
    /// Select the object that was clicked.
    /// </summary>
    /// <returns>Game object that was selected.</returns>
    private GameObject getObjectClicked()
    {
        GameObject result = null;

        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            Debug.Log(hit.transform.name);
            result = hit.transform.gameObject;
        }

        return result;
    }

    /// <summary>
    /// Changes the sprite image from a blank board piece to a cross or circle piece depending on the isCross boolean.
    /// </summary>
    /// <param name="currentBox"></param>
    /// <returns>void</returns>
    void changeBoardPiece (GameObject currentBox)
    {
        if (currentBox.transform.gameObject.layer == 8)
        {
            if (cells[(string)currentBox.transform.tag] == 0)
            {
                if (isCross)
                {
                    currentBox.transform.gameObject.GetComponent<SpriteRenderer>().sprite = crossSprite;
                    cells[(string)currentBox.transform.tag] = 1;
                }
                else
                {
                    currentBox.transform.gameObject.GetComponent<SpriteRenderer>().sprite = circleSprite;
                    cells[(string)currentBox.transform.tag] = 2;
                }
            } 
            isCross = !isCross; 
        }
    }
}
