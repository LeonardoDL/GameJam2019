using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private bool colliding = false;
    private int justSummoned = 4;

    void Update()
    {
        if (justSummoned > 0)
            justSummoned--;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        colliding = true;

        //SummonAnimation sa = gameObject.GetComponent<SummonAnimation>();
        //if (sa != null) sa.Summon();
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        bool wasColliding = colliding;
        colliding = true;

        if (collision.tag == "Checkpoint" && justSummoned > 0)
            return;

        //SummonAnimation sa = gameObject.GetComponent<SummonAnimation>();
        //if (sa != null) sa.Summon();
        Destroy(gameObject);
    }

    void OnCollisionExit2D(Collision2D collision) { colliding = false; }
    void OnTriggerExit2D(Collider2D collision) { colliding = false; }
    void OnCollisionStay2D(Collision2D collision) { colliding = true; }
    void OnTriggerStay2D(Collider2D collision) { colliding = true; }
}
