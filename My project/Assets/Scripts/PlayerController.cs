using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Vector2 movement = Vector2.zero;
    public float speed = 1.0f;
    private Animator animator;
    public bool grounded = false;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rbody.velocity = new Vector2(movement.x*speed*2f,rbody.velocity.y);
        animator.SetBool("Running", movement.x != 0);
    }

    void OnJump() {
        if (grounded) {
            rbody.AddForce(new Vector2(0,5),ForceMode2D.Impulse);
            grounded = false;
            animator.SetBool("InTheAir", true);
        }


    }

    void OnMove(InputValue val) {
        movement = val.Get<Vector2>();
    }

    void OnCollisionEnter2D(Collision2D collision){
        foreach(ContactPoint2D contact in collision.contacts){
            if(contact.normal.y > 0.8f) {
                grounded = true;
                animator.SetBool("InTheAir", false);
            }
        }
    }
    
}
