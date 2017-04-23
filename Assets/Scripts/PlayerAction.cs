using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAction : MonoBehaviour {

    public Sprite circleSprite;
    public Sprite crossSprite;
    private GameObject currentBox;

    public GameObject SelectCircle;
    public GameObject SelectCross;

    Dictionary<string, int> cells = new Dictionary<string, int>();
    
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

    void OnMouseDown()
    {
            gameOver();
            currentBox = getObjectClicked();
            changeBoardPiece(currentBox);
    }

    /// <summary>
    /// Method where is checked who wins.
    /// </summary>
    /// <returns>Void</returns>

    void gameOver()
    {
        Debug.Log("A1 = " + cells["A1"]);
        Debug.Log("A2 = " + cells["A2"]);
        Debug.Log("A3 = " + cells["A3"]);
        Debug.Log("B1 = " + cells["B1"]);
        Debug.Log("B2 = " + cells["B2"]);
        Debug.Log("B3 = " + cells["B3"]);
        Debug.Log("C1 = " + cells["C1"]);
        Debug.Log("C2 = " + cells["C2"]);
        Debug.Log("C3 = " + cells["C3"]);

        if (cells["A1"] == 1 && cells["A2"] == 1 && cells["A3"] == 1 ||
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
        }
        else if (cells["A1"] == 2 && cells["A2"] == 2 && cells["A3"] == 2 ||
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
    void changeBoardPiece (GameObject currentBox)
    {
        GameObject camera = GameObject.Find("Camera");
        BoardLogic boardLogic = camera.GetComponent<BoardLogic>();
        bool isCross = boardLogic.getIsCross();

        if (currentBox.transform.gameObject.layer == 8)
        {
            string currentBoxTag = (string)currentBox.transform.tag;
            Debug.Log("current box tag = " + currentBoxTag);
            SpriteRenderer currentBoxSpriteRenderer = currentBox.transform.gameObject.GetComponent<SpriteRenderer>();

            if (cells[currentBoxTag] == 0)
            {
                Debug.Log("cells[currentBoxTag] = " + cells[currentBoxTag]);
                if (isCross)
                {
                    currentBoxSpriteRenderer.sprite = crossSprite;
                    cells[currentBoxTag] = 1;
                    Debug.Log("cells[currentBoxTag] = " + cells[currentBoxTag]);
                }
                else
                {
                    currentBoxSpriteRenderer.sprite = circleSprite;
                    cells[currentBoxTag] = 2;
                    Debug.Log("cells[currentBoxTag] = " + cells[currentBoxTag]);
                }

                //Must be changed only after click on an empty box.
                boardLogic.setIsCross(isCross);
                isCross = boardLogic.getIsCross();

            }
        }
    }
}
