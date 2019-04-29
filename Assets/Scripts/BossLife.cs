using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossLife : MonoBehaviour
{
    public int totalLifePoints = 12;
    public int deathYHeight;
    [SerializeField] private int lifePoints;
    private BossAI ai;

    void Start()
    {
        ai = GetComponent<BossAI>();
        lifePoints = totalLifePoints;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Bullet")
        {
            if (lifePoints <= 0)
            {
                ai.Die();
                Destroy(collider.gameObject);
            }
            else
            {
                Destroy(collider.gameObject);
                //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                lifePoints -= collider.GetComponent<BulletMovement>().damage;
                if (lifePoints < totalLifePoints / 2)
                    ai.BecomeMad(true);
            }
        }
        if (collider.tag == "SlashPlayer")
        {
            if (lifePoints <= 0)
            {
                ai.Die();
                Destroy(collider.gameObject);
            }
            else
            {
                Destroy(collider.gameObject);
                //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
                lifePoints -= 20;
                if (lifePoints < totalLifePoints / 2)
                    ai.BecomeMad(true);
            }
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
