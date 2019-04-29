using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D cc;
    //public Animator animator;
    //public AudioSource audioSource;
    //public PlayerLifeController playerLife;
    public float rSpeed = 40f; //Run Speed

    private float hMove = 0f; //Horizontal Move
    private bool jump = false; //Jump
    private bool duck = false; //Duck

    // Update is called once per frame
    void Update()
    {
        //if (!playerLife.GetDead())
        //{
            ClearMovement();
            hMove = Input.GetAxisRaw("Horizontal") * rSpeed;
            if (Input.GetButtonDown("Jump"))
            {
                //SoundManager.SM.PlayTrack("Via_Inferna");
                jump = true;
                //animator.SetBool("Jumping", true);
                //audioSource.Play();
            }
            

        //animator.SetFloat("Speed", Mathf.Abs(hMove));

        /*
        if (Input.GetButtonDown("Duck"))
        { duck = true; } //hMove = 0f; //The temporary character shouldn't move while ducking but the definitive may
        else if (Input.GetButtonUp("Duck"))
            duck = false;
        */
        //}
        //else
        //    ClearMovement();
    }

    void FixedUpdate() {
        cc.Move(hMove * Time.fixedDeltaTime, duck, jump);
        jump = false;
    }

    public void OnLanding() {
        //animator.SetBool("Jumping", false);
    }

    public void OnDucking(bool isDucking) {
        //animator.SetBool("Ducking", isDucking);
    }

    public void ClearMovement()
    {
        hMove = 0f;
    }
}
