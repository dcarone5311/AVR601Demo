using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed,turnSpeed;

    Vector2 input;

    public GameObject bullet;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //read input
        if (Mathf.Abs(input.x) < 0.4f)
            input.x = 0;
        
        transform.Translate(Vector2.up * input.y * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0f,0f, -input.x * turnSpeed * Time.deltaTime));

        float boundaryLength = Boundary.instance.boundaryLength;
        float boundaryWidth = Boundary.instance.boundaryWidth;

        transform.position = new Vector2(   Mathf.Clamp(transform.position.x, -boundaryLength / 2f, boundaryLength / 2f),
                                            Mathf.Clamp(transform.position.y, -boundaryWidth / 2f, boundaryWidth / 2f));


        if(Input.GetKeyDown(KeyCode.Space)) //press space bar
        {
            Shoot(); //shoot
        }
    }

    void Shoot()
    {
        GameObject spawnedBullet = Instantiate(bullet);
        spawnedBullet.transform.position = transform.position; //spawn where player is
        spawnedBullet.transform.rotation = transform.rotation;
        Destroy(spawnedBullet, 1f); //destory bullet after 2 seconds
    }


}
