using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour {
    public GameObject circle;
    public Transform circle2;
    public float distance = 10f;
    Vector2 mousePosition, targetPosition;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition   = Input.mousePosition;
        targetPosition  = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, distance));
        circle2.position = targetPosition;

        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(circle2, circle2.transform.position, circle2.transform.rotation);
        }
    }
}
