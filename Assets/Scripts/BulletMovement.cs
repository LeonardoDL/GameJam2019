using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 4f;
    public float lifetime = 10f;
    public int damage = 1;
    //public float damage = 10f;
    //private bool firstTime = true;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity += new Vector2(transform.right.x, transform.right.y) * speed;
    }

    void Awake()
    { Destroy(gameObject, lifetime); }

    void Update()
    {
        //rb.MovePosition(new Vector2(transform.position.x, transform.position.y) + (new Vector2(transform.right.x, transform.right.y) * speed * Time.deltaTime));

        //if (firstTime)
        //{
        //    WaitForSecondsRealtime wait = new WaitForSecondsRealtime(1);
        //    firstTime = false;
        //}

        
    }

    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Destroy(gameObject);
    //}

    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    Destroy(gameObject);
    //}
}