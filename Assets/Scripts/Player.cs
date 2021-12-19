using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D rb;
    bool canJump;

    // Start is called before the first frame update
    void Start()
    {
        canJump = false;
        rb = GetComponent<Rigidbody2D>();
        rb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canJump) return;
        if(Input.GetMouseButton(0))
        {
            rb.velocity = (Vector2.up * 3f) + (Vector2.right * 3f);
        }
    }

    public void PlayerStart()
    {
        StartCoroutine(PlayerInitializeMovement());
    }

    IEnumerator PlayerInitializeMovement()
    {
        Vector3 temp;
        while(transform.position.x < 0 )
        {
            temp = transform.position;
            temp.x += 0.1f;
            transform.position = temp;
            yield return new WaitForSeconds(0.05f);
        }

        rb.simulated = true;
        rb.velocity = Vector2.right * 3f;
        canJump = true;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().StartFollowing();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Death"))
        {
            GameManager.instance.GameEnd();
            rb.velocity = Vector2.zero;
            canJump = false;
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().canFollow = false;
        }

        if(collision.CompareTag("Score"))
        {
            GameManager.instance.UpdateScore();
        }

        if (collision.CompareTag("Diamond"))
        {
            GameManager.instance.UpdateDiamonds();
            Destroy(collision.gameObject);
        }
    }
}
