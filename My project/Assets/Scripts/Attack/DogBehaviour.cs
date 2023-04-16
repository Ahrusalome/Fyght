using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogBehaviour : MonoBehaviour
{
    public float speed;
    private Animator animator;
    private Rigidbody2D rb;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
    void Update() {
        rb.AddForce(new Vector2(speed, 0));
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("HasExploded")) {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.layer == 8 || other.gameObject.layer == gameObject.layer) {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            speed = -speed;
        }
        else {
            animator.SetBool("IsWalking", true);
        }
    }
}
