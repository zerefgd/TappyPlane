using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistancedDestructor : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!player) return;
        if (player.position.x - transform.position.x > 12)
            Destroy(gameObject);
    }
}
