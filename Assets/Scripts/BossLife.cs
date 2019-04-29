using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int totalLifePoints = 12;
    private int lifePoints;
    private BossAI ai;

    void Start()
    {
        ai = GetComponent<BossAI>();
        lifePoints = totalLifePoints;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Bullet")
        {
            if (lifePoints <= 0)
                ai.Die();
            else
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                lifePoints--;
                if (lifePoints < totalLifePoints / 2)
                    ai.BecomeMad(true);
            }
        }
    }
}
