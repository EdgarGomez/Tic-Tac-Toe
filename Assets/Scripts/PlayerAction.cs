using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAction : MonoBehaviour {

    private GameObject currentBox;
    private int count;

    private Color colorUser1;
    private Color colorUser2;

    /// <summary>
    /// Initialization.
    /// </summary>
    void Start () {
        colorUser1 = Color.blue;
        colorUser2 = Color.magenta;
    }

    /// <summary>
    /// Called once per frame. It will draw the boxes clicked by any user.
    /// </summary>
    void Update () {

        // It will work only if the game is not over.
        if(!isGameOver())
        {
            // Left click simulates the user 1, right click is the user 2 (TO DO).
            if (Input.GetMouseButtonDown(0))
            {
                currentBox = getObjectClicked();
                updateColor(colorUser1);
            }
            else if (Input.GetMouseButtonDown(1))
            {
                currentBox = getObjectClicked();
                updateColor(colorUser2);
            }
        }

        currentBox = null;
    }

    /// <summary>
    /// Updates the color of the current selected box.
    /// If the box is white, any player can paint on it, but if not, only the last player that colored the box, can turn the box to white again.
    /// A counter is incremented or decremented after change the color of a box (just to know how many boxes are selected by any of the users, if there are 9, the game ends).
    /// </summary>
    /// <param name="color"></param>
    private void updateColor(Color color)
    {
        if(currentBox != null)
        {
            if (hasSameColor(currentBox, Color.white))
            {
                changeGameObjectColor(currentBox, color);
                count++;
            }
            else if (hasSameColor(currentBox, color))
            {
                changeGameObjectColor(currentBox, Color.white);
                count--;
            }
        }
    }

    /// <summary>
    /// Checks if the the game object has a certain color.
    /// </summary>
    /// <param name="gameObject">Game object to be compared.</param>
    /// <param name="colorToCompare">Color to compare with.</param>
    /// <returns>True if the colors are the same, false if not.</returns>
    private bool hasSameColor(GameObject gameObject, Color colorToCompare)
    {
        bool result = false;

        if (gameObject != null && colorToCompare != null && gameObject.GetComponent<Renderer>().material.color == colorToCompare)
            result = true;

        return result;
    }

    /// <summary>
    /// Changes the color of a game object.
    /// </summary>
    /// <param name="gameObject">Game object to be edited.</param>
    /// <param name="colorToChange">Color to be applied</param>
    private void changeGameObjectColor(GameObject gameObject, Color colorToChange)
    {
        gameObject.GetComponent<Renderer>().material.color = colorToChange;
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
    /// Checks if all the boxes are selected, if yes, the game ends.
    /// </summary>
    /// <returns>True if the game is over, false if not.</returns>
    private bool isGameOver()
    {
        bool result = false;

        if (count == 9)
        {
            result = true;
            Debug.Log("Oh... Come on! The game is over!");
        }

        return result;
    }

}
