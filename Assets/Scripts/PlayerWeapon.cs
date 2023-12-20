using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public GameObject bullet;
    public Transform gun;
    public float bulletSpeed;

    //needed to create the fire rate for the weapon
    public float fireRate = 0.1f;
    private float nextFire = 0.1f;

    void Update()
    {
        Vector3 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Checks the mouse position on screen
        Vector3 lookAt = mouseScreenPosition;
        float AngleRad = Mathf.Atan2(lookAt.y - gun.transform.position.y, lookAt.x - gun.transform.position.x); //Creates a circle around the user that passes through mouse location
        float AngleDeg = (180/Mathf.PI) * AngleRad; //Checks the mouse position in the circle to figure out the guns rotation
        gun.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if (Input.GetMouseButton(0) && Time.time > nextFire || Input.GetKeyDown("space") && Time.time > nextFire) //checks if the user is pressing left click or space and the timer
        {
            nextFire = Time.time + fireRate;
            GameObject bulletClone = Instantiate(bullet);
            bulletClone.transform.position = gun.position;
            bulletClone.transform.rotation = Quaternion.Euler(0, 0, AngleDeg); //applies rotation to the bullet to aim it's velocity
            bulletClone.GetComponent<Rigidbody2D>().velocity = gun.right * bulletSpeed; //applies velocity to the created bullet
            Destroy(bulletClone, 5f);
        }
    }
}
