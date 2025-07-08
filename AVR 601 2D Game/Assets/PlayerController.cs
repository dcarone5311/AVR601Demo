using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    float speed, jumpSpeed; //define public variables

    Rigidbody2D rb;

    public bool isGrounded; //ground detection
    public int maxJumps; //maximum amount of jumps

    int jumps; //counts jumps

    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
        jumps = maxJumps;
        rb = GetComponent<Rigidbody2D>(); //get reference to rigidbody
    }
    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(input) < 0.5f)
            input = 0f;

        rb.velocity = new Vector2(input * speed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumps > 0)) //press jump and either be grounded or haxe extra jumps
        {
            isGrounded = false;
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            jumps--; //lost one jump
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.GetContact(0).normal.y>0.5f) //land on ground
        {

            isGrounded = true;
            jumps = maxJumps;

        }

    }


}
