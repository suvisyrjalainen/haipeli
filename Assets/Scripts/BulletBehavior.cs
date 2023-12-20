using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public GameObject bullet;

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            //if the tag of collission is enemy, destroy bullet
            col.gameObject.SetActive(false);
            Destroy(bullet);
        }
    }
}
