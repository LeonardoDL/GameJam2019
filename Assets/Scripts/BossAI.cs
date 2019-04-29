using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAI : MonoBehaviour
{
    public Move hop;
    public Move jump;
    public Move fly;
    public Move shoot;
    public Move slash;
    public GameObject collectible;
    public Transform firePoint;
    public GameObject bullet;
    public Animator slashAnim;

    private Vector2 cFly;
    private bool facingRight;
    [SerializeField] private bool mad;
    private Transform player;

    private float shortVision = 5f;
    private float longVision = 10f;

    void Start()
    {
        facingRight = true;
        if (hop.check)
        {
            InvokeRepeating(      "Hop",                      1f, (1 / hop.rate));
            InvokeRepeating(   "SecHop",     (1 / hop.rate) / 2f, (1 / hop.rate));
            InvokeRepeating(   "MadHop",     (1 / hop.rate) / 4f, (1 / hop.rate));
            InvokeRepeating("SecMadHop", 3 * (1 / hop.rate) / 4f, (1 / hop.rate));
        }
        if (jump.check)
            InvokeRepeating("Jump", (1 / jump.rate), Random.Range((1 / jump.rate) * 0.7f, (1 / jump.rate) * 1.3f));
        if (fly.check)
            InvokeRepeating("Fly", 1f, Random.Range((1 / fly.rate) * 0.7f, (1 / fly.rate) * 1.3f));
        if (shoot.check)
        {
            InvokeRepeating("Shoot", (1 / shoot.rate), Random.Range((1 / shoot.rate) * 0.7f, (1 / shoot.rate) * 1.3f));
            if (firePoint == null) Debug.LogWarning("Um inimigo está sem FirePoint (Transform)!");
            if (bullet == null) Debug.LogWarning("Um inimigo está sem Bullet (Prefab)!");
        }
        if (slash.check)
        {
            InvokeRepeating("Slash", (1 / slash.rate), Random.Range((1 / slash.rate) * 0.7f, (1 / slash.rate) * 1.3f));
            if (slashAnim == null) Debug.LogWarning("Um inimigo está sem Bullet (Prefab)!");
        }

        //    GameObject g = GameObject.Find("Grid");
        //if (g == null)
        //    Debug.Log("Não há um objeto chamado Grid na cena!");
        //else
        //    grid = g.GetComponent<Transform>();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        }

    void FixedUpdate()
    {
        if (!fly.check)
            return;

        Vector2 v = gameObject.GetComponent<Rigidbody2D>().velocity;
        v.x = Mathf.Lerp(v.x, 0f, 5f * Time.deltaTime); v.y = Mathf.Lerp(v.y, 0f, 5f * Time.deltaTime);
        gameObject.GetComponent<Rigidbody2D>().velocity = v;
    }

    private void FixFacing(float f)
    {
        if (f >= 0)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            facingRight = true;
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            facingRight = false;
        }

    //if (facingRight)
    //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    //else
    //    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
}

    private void Hop()
    {
        if (SeePlayer(longVision) && !SeePit(shortVision))
        {
            Vector2 d = new Vector2(facingRight ? 1f : -1f, 1f); d = d.normalized;
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hop.force * d.x, hop.force * d.y), ForceMode2D.Impulse);
        }
        else
        {
            if (!SeePit(shortVision))
            {
                Vector2 d = new Vector2(Random.Range(-1f, 1f), 1f); d = d.normalized; FixFacing(d.x);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hop.force * d.x, hop.force * d.y), ForceMode2D.Impulse);
            }
            else
            {
                Vector2 d = new Vector2(facingRight ? -1f : 1f, 1f); d = d.normalized; FixFacing(d.x);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hop.force * d.x, hop.force * d.y), ForceMode2D.Impulse);
            }
        }
    }

    private void SecHop()
    {
        if (SeePlayer(longVision) && !SeePit(shortVision))
        {
            Vector2 d = new Vector2(facingRight ? 1f : -1f, 1f); d = d.normalized; FixFacing(d.x);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(hop.force * d.x, hop.force * d.y), ForceMode2D.Impulse);
        }
    }

    private void MadHop()
    {
        if (mad && (SeePlayer(longVision) && !SeePit(shortVision)))
        {
            Vector2 d = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y); d = d.normalized; FixFacing(d.x);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4f * hop.force * d.x, 4f * hop.force * d.y), ForceMode2D.Impulse);
        }
    }

    private void SecMadHop()
    {
        if (mad && (SeePlayer(longVision) && !SeePit(shortVision)))
        {
            Vector2 d = new Vector2(player.position.x - transform.position.x, player.position.y - transform.position.y); d = d.normalized; FixFacing(d.x);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(4f * hop.force * d.x, 4f * hop.force * d.y), ForceMode2D.Impulse);
        }
    }

    private void Jump()
    {
        if (mad)
        {
            Vector2 d = new Vector2(facingRight ? 0.2f : -0.2f, 1f); d = d.normalized; FixFacing(d.x);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(2f * jump.force * d.x, 2f * jump.force * d.y), ForceMode2D.Impulse);
            return;
        }

        if (SeePlayer(longVision) && !SeePit(shortVision))
        {
            Vector2 d = new Vector2(facingRight ? 0.5f : -0.5f, 1f); d = d.normalized; FixFacing(d.x);
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jump.force * d.x, jump.force * d.y), ForceMode2D.Impulse);
        }
        else
        {
            if (!SeePit(shortVision))
            {
                Vector2 d = new Vector2(Random.Range(-0.7f, 0.7f), 1f); d = d.normalized; FixFacing(d.x);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jump.force * d.x, jump.force * d.y), ForceMode2D.Impulse);
            }
            else
            {
                Vector2 d = new Vector2( facingRight ? -0.7f : 0.7f, 1f); d = d.normalized; FixFacing(d.x);
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(jump.force * d.x, jump.force * d.y), ForceMode2D.Impulse);
            }
        }
    }

    private void Fly()
    {
        Debug.Log("Fly desativado");
        //Vector2 d = new Vector2(4f * Random.Range(-0.5f, 0.5f), Random.Range(-0.2f, 0.2f));
        //d = d.normalized; FixFacing(d.x);
        //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(fly.force * d.x, fly.force * d.y), ForceMode2D.Impulse);
    }

    private void Shoot()
    {
        //Vector2 d = new Vector2(4f * Random.Range(-0.5f, 0.5f), Random.Range(-0.2f, 0.2f));
        //d = d.normalized;
        GameObject b = Instantiate(bullet, firePoint.transform.position, firePoint.transform.rotation);
        b.GetComponent<BulletMovement>().speed = shoot.force;
    }

    private void Slash()
    {
        if (SeePlayer(shortVision))
        {
            slashAnim.SetTrigger("Slash");
        }
    }

    private bool SeePlayer(float vision)
    {
        if (mad)
            vision *= 2f;

        float dist = (player.position.x - transform.position.x);
        if (Mathf.Abs(dist) < vision)
        {
            if ((dist > 0 && facingRight) || (dist < 0 && !facingRight))
            {
                GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 1f);
                return true;
            }
            else
            {
                GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
                return false;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f);
            return false;
        }
    }

    private bool SeePit(float vision)
    {
        foreach (GameObject go in GameObject.FindGameObjectsWithTag("PitAlert"))
        {
            Transform t = go.transform;

            float dist = (t.position.x - transform.position.x);
            if (Mathf.Abs(dist) < vision)
            {
                if ((dist > 0 && facingRight) || (dist < 0 && !facingRight))
                {
                    GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0f);
                    return true;
                }
            }
        }

        return false;
    }

    public void Die()
    {
        //Instantiate(collectible, gameObject.transform.position, Quaternion.identity, grid);
        Destroy(gameObject);
        Debug.Log("You Win");
    }

    public void BecomeMad(bool b)
    {
        mad = b;
    }
}
