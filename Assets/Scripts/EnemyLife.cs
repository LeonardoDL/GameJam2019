using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    private EnemyAI ai;
    public int deathYHeight;

    void Start()
    {
        ai = GetComponent<EnemyAI>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            ai.Die();
            Destroy(collider.gameObject);
        }
        if (collider.tag == "SlashPlayer")
        {
            ai.Die();
        }
    }

    void Update()
    {
        if (transform.position.y <= deathYHeight)
        {
            ai.Die();
        }
    }
}
