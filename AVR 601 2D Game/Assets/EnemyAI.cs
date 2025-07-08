using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public int health;
    public float speed;

    public Transform player;

    Vector3 targetPoint;
    //float angle;

    // Start is called before the first frame update
    void Start()
    {
        SetNewTarget();
        //angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = targetPoint - transform.position;
        transform.Translate(direction.normalized * speed *Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint) < 0.05f) //close enough to target
            SetNewTarget(); //set new target
        


        float angle = Mathf.Rad2Deg * Mathf.Atan2(direction.y,direction.x);

        transform.rotation = Quaternion.Euler(0f, 0f, angle - 90f);

    }

    void SetNewTarget() //choose a new target point
    {
        float boundaryLength = Boundary.instance.boundaryLength;
        float boundaryWidth = Boundary.instance.boundaryWidth;

        while(Vector3.Distance(transform.position, targetPoint) < 2f) //chose a new target that's far enough away
        {
            targetPoint = new Vector3(Random.Range(-boundaryLength / 2f, boundaryLength / 2f),
                                        Random.Range(-boundaryWidth / 2f, boundaryWidth / 2f),
                                        0f);
        }

    }
    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(targetPoint, 0.05f);
    }*/
}
