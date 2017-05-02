using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToPosition : MonoBehaviour {

    private Vector2 a1position = new Vector2(1.81f, 3.88f);
    private Vector2 a2position = new Vector2(3.99f, 3.88f);
    private Vector2 a3position = new Vector2(6.2f, 3.88f);
    private Vector2 b1position = new Vector2(1.81f, 1.65f);
    private Vector2 b2position = new Vector2(4.02f, 1.65f);
    private Vector2 b3position = new Vector2(6.21f, 1.65f);
    private Vector2 c1position = new Vector2(1.81f, -0.56f);
    private Vector2 c2position = new Vector2(4.02f, -0.56f);
    private Vector2 c3position = new Vector2(6.22f, -0.56f);

    public int movespeed = 3;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject camera = GameObject.Find("Camera");
        BoardLogic boardLogic = camera.GetComponent<BoardLogic>();
        if (boardLogic.canStart)
        {
            if (this.transform.tag == "A1")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), a1position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "A2")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), a2position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "A3")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), a3position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "B1")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), b1position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "B2")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), b2position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "B3")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), b3position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "C1")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), c1position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "C2")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), c2position, movespeed * Time.deltaTime);
            }
            else if (this.transform.tag == "C3")
            {
                transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), c3position, movespeed * Time.deltaTime);
            }
        }
    }

}
