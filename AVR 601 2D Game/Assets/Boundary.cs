using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{
    static public Boundary instance; //only one instance

    public float boundaryWidth, boundaryLength;

    Vector2 topRight, topLeft, bottomRight, bottomLeft;

    // Start is called before the first frame update
    void Awake()
    {
        if(instance == null)
            instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        topRight = new Vector2(boundaryLength / 2f, boundaryWidth / 2f);
        topLeft = new Vector2(-boundaryLength / 2f, boundaryWidth / 2f);
        bottomRight = new Vector2(boundaryLength / 2f, -boundaryWidth / 2f);
        bottomLeft = new Vector2(-boundaryLength / 2f, -boundaryWidth / 2f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red; //set color
        //draw lines
        Gizmos.DrawLine(topRight, topLeft); //top
        Gizmos.DrawLine(bottomRight, bottomLeft); //bottom
        Gizmos.DrawLine(topRight, bottomRight); //right
        Gizmos.DrawLine(topLeft, bottomLeft); //left
    }
}
