using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedCameraFollow : MonoBehaviour
{

    private struct PointInSpace //creates a data structure
    {
        public Vector3 Position;
        public float Time;
    }

    [SerializeField]
    private Transform target;

    [SerializeField]
    private Vector3 offset;

    [SerializeField]
    private float delay = 0.5f;

    [SerializeField]
    private float speed = 5;

    private Queue<PointInSpace> pointsInSpace = new Queue <PointInSpace>();
    //makes a queue to gather points of data
    void LateUpdate()
    {
        pointsInSpace.Enqueue(new PointInSpace(){Position = target.position, Time = Time.time}); //saves a point of data
        while(pointsInSpace.Count > 0 && pointsInSpace.Peek().Time <= Time.time - delay + Mathf.Epsilon) //Check if the camera needs to be moved
        {
            transform.position = Vector3.Lerp(transform.position, pointsInSpace.Dequeue().Position + offset, Time.deltaTime * speed); //Moves the camera and removes the used queue
        }
    }
}
