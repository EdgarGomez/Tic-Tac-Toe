using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardLogic : MonoBehaviour {

    // A simple boolean to switch between one kind of piece and the other
    public bool isCross = true;

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


}
