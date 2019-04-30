using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLifeController : MonoBehaviour {

    public float deathYHeight = -30f;
    //public Animator animator;
    //public AudioSource audioSource;

    private Vector2 lastCheckpoint;
    private bool dead;

    // Initialization
    private void Awake() {
        dead = false;
        lastCheckpoint = gameObject.transform.position;
    }

    // Death by height
    private void Update() {
        if (transform.position.y <= deathYHeight) {
            RespawnPlayer();
        }
    }

    // Collision with new checkpoint
    void OnTriggerEnter2D(Collider2D collider) {
        string tag = collider.tag;
       
        
        
        if (tag == "Checkpoint") {
            Checkpoint checkpoint = collider.gameObject.GetComponent<Checkpoint>();

            if (!checkpoint.GetIsOn()) {
                lastCheckpoint = collider.gameObject.GetComponent<Transform>().position;
                checkpoint.Activate();
            }
        } else if (tag == "Enemy" || tag == "Hazard") {
                RespawnPlayer();
            }
            
        
    }

    // Enemies and hazards and stomp
    void OnCollisionEnter2D(Collision2D collision)
    {
        Collider2D collider = collision.collider;
        string tag = collider.tag;

        if (tag == "EnemySlash")
            RespawnPlayer();
    }

    // Plays death animation
    public void RespawnPlayer()
    {
        if (!dead) {
            dead = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 0f);
            //audioSource.Play();
            //animator.SetBool("Died", true);
            gameObject.GetComponent<PlayerMovement>().ClearMovement();
        }
        DiedAnimationEnded();
    }

    // Move player to spawn
    public void DiedAnimationEnded()
    {
        Debug.Log("Morreu");
        Money.Increment();
        transform.position = lastCheckpoint;
        //gameObject.GetComponent<ManageFollowers>().RestartAllFollowers(); //Reseta as posições dos coletáveis seguidores
        dead = false;
        //animator.SetBool("Died", false);

        SceneManager.LoadScene(3);
    }

    // Returns if the player is dead (respawning)
    public bool GetDead() {
        return dead;
    }
}