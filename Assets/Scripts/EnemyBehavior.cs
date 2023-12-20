using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;

    void FixedUpdate()
    {
	    var player = GameObject.Find("Player");
        Vector3 dir = (player.transform.position - this.transform.position).normalized;
        this.GetComponent<Rigidbody2D>().MovePosition(this.transform.position + dir * speed * Time.fixedDeltaTime);
    }
}