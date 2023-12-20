using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed; //determines how fast the movement is
    public Rigidbody2D rb; //checks for the rigidbody2 in the object

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal"); //checks for horizontal input
        float vertical = Input.GetAxis("Vertical"); //checks for vertical input
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y); //applies sideways momentum
        rb.velocity = new Vector2(rb.velocity.x, vertical * speed); //applies up and down momentum
    }
}
