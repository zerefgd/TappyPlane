using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGRepeat : MonoBehaviour
{

    private Transform player;
    float offset;
    float currentOffset;

    // Start is called before the first frame update
    void Start()
    {
        offset = 12.5f;
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        currentOffset = player.position.x - transform.position.x;
        if(currentOffset >= offset)
        {
            Vector3 temp = transform.position;
            temp.x += offset*2f;
            transform.position = temp;
        }

    }
}
