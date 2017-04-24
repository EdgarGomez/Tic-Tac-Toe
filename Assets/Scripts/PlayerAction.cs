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
    
    // Use this for initialization
    void Start()
    {

    }

    void OnMouseDown()
    {
        GameObject camera = GameObject.Find("Camera");
        BoardLogic boardLogic = camera.GetComponent<BoardLogic>();
        currentBox = getObjectClicked();
        changeBoardPiece(currentBox);
        boardLogic.gameOver();
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

            if (boardLogic.cells[currentBoxTag] == 0)
            {
                Debug.Log("cells[currentBoxTag] = " + boardLogic.cells[currentBoxTag]);
                if (isCross)
                {
                    currentBoxSpriteRenderer.sprite = crossSprite;
                    boardLogic.cells[currentBoxTag] = 1;
                    Debug.Log("cells[currentBoxTag] = " + boardLogic.cells[currentBoxTag]);
                }
                else
                {
                    currentBoxSpriteRenderer.sprite = circleSprite;
                    boardLogic.cells[currentBoxTag] = 2;
                    Debug.Log("cells[currentBoxTag] = " + boardLogic.cells[currentBoxTag]);
                }

                //Must be changed only after click on an empty box.
                boardLogic.setIsCross(isCross);
                isCross = boardLogic.getIsCross();

            }
        }
    }
}
