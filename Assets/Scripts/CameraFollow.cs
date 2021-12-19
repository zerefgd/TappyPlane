using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    float offset;
    Transform player;
    public bool canFollow;

    // Start is called before the first frame update
    void Start()
    {
        canFollow = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canFollow) return;
        Vector3 temp = transform.position;
        temp.x = player.position.x + offset;
        transform.position = temp;
    }

    public void StartFollowing()
    {
        canFollow = true;
        player = GameObject.Find("Player").transform;
        offset = transform.position.x - player.position.x;
    }
}
