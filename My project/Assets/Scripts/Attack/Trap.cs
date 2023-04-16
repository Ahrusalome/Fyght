using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float speed = 0.5f;
    public Rigidbody2D rb;
    private bool isGrounded;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity =  -transform.right*speed + new Vector3(0, -0.5f, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "floor") {
            rb.velocity = Vector2.zero;
            isGrounded = true;
        } else if (collision.gameObject.name == gameObject.name ){
        
        } else if (isGrounded) {
            collision.gameObject.GetComponent<PlayerController>().enabled = false;
            StartCoroutine("EnableControls", collision.gameObject.GetComponent<PlayerController>());
        }
    }
    IEnumerator EnableControls(PlayerController controls) {
        gameObject.GetComponent<Collider2D>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(1);
        controls.enabled = true;
        Destroy(gameObject);
        yield return null;
    }
}
