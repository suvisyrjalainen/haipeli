using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        var playerPos = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        transform.position = playerPos;
    }
}
