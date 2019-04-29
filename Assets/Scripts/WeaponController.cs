using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    //public Animator animator;
    public Transform weapon, player, firePoint;
    //public PlayerLifeController playerLife;
    public float rotationSpeed = 3f;
    public Camera cam;
    

	// Update is called once per frame
	void Update ()
    {
        //if (!playerLife.GetDead()) {
        // Calculates direction from object to cursor
        Vector3 theScale = weapon.localScale;
        theScale.x = transform.localScale.x;
        weapon.localScale = theScale;

        Vector3 d = cam.ScreenToWorldPoint(Input.mousePosition) - weapon.position;
        d.Normalize();

        Vector2 direction = new Vector2(d.x, d.y) * transform.localScale.x;
        direction.Normalize();

        // Verify player orientation
        float angle = (player.transform.localScale.x <= -1) ?
            Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg
            : Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Calculates new rotation
        Quaternion newRotation = Quaternion.AngleAxis(angle, Vector3.forward);

        // Spherically sets rotation
        weapon.rotation = Quaternion.Slerp(weapon.rotation, newRotation, rotationSpeed * Time.deltaTime);
        //Debug.Log(weapon.rotation.eulerAngles);

        // Attacks on mouse click
        if (Input.GetMouseButton(0))
        {
        //animator.ResetTrigger("Attacking");
        //animator.SetTrigger("Attacking");
        Quaternion bRotation = weapon.rotation;
        gameObject.GetComponent<Shoot>().SpawnBullet(firePoint.position, bRotation);
        }
        //}
    }
}