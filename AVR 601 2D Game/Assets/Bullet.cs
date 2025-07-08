using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit enemy");
        GameObject other = collision.gameObject;

        if (other.tag == "Enemy") //if bullet hit an enemy
        {
            
            other.GetComponent<EnemyAI>().health -= damage; //subtract damage from health
            if(other.GetComponent<EnemyAI>().health <=0)
                Destroy(other); //destory enemy
        }

        Destroy(gameObject); //destroy bullet
    }
}
