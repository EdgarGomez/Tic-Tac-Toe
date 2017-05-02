using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLogic : MonoBehaviour {

    // A simple boolean to switch between one kind of piece and the other
    public bool isCross;
    public bool canStart = false;

    public Dictionary<string, int> cells = new Dictionary<string, int>();

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

    void Update()
    {
        if (PlayerPrefs.HasKey("piece"))
        {
            string piece = PlayerPrefs.GetString("piece");
            if (piece == "cross")
            {
                isCross = true;
            } else
            {
                isCross = false;
            }

            canStart = true;

        }
    }

    public void setIsCross(bool isCross)
    {
        if(isCross)
        {
            this.isCross = false;
        } else
        {
            this.isCross = true;
        }
    }

    public bool getIsCross()
    {
        return this.isCross;
    }

    /// <summary>
    /// Method where is checked who wins.
    /// </summary>
    /// <returns>Void</returns>

    public void gameOver()
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
        }
    }


}
