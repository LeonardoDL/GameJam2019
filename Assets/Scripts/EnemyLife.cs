using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private EnemyAI ai;

    void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            ai.Die();
        }
    }
}
