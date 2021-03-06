﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float launchForce = 10f;
    public float cooldown;
    //public AudioSource audioSource;
    private GameObject bullet = null;
    private float nextFireTime = 0f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void SpawnBullet(Vector3 position, Quaternion rotation)
    {
        //if (PauseMenu.GameIsPaused == true)
        //{
        //    return;
        //}
        //audioSource.Play();

        if (Time.time > nextFireTime)
        {
            bullet = Instantiate(bulletPrefab, position, rotation);
            Vector3 r = rotation.eulerAngles;
            //bullet.GetComponent<Rigidbody2D>().velocity = rb.velocity * .17f;
            //bullet.GetComponent<Rigidbody2D>().AddForce(
            //    new Vector2(launchForce * r.x, launchForce * r.y),
            //    ForceMode2D.Impulse);
            nextFireTime = Time.time + cooldown;
        }
    }

    //void Update()
    //{
    //    Debug.Log();
    //    Debug.Log(rb.velocity.y);
    //}
}
