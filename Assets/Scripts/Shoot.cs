using System.Collections;
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
            bullet.GetComponent<Rigidbody2D>().AddForce(
                new Vector2(launchForce * rotation.x, launchForce * rotation.y), ForceMode2D.Impulse);
            nextFireTime = Time.time + cooldown;
        }
    }
}
