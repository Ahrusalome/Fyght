using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Vector2 movement = Vector2.zero;
    public float speed = 1.0f;
    private Animator animator;
    public bool grounded = false;

    public Vector3 ennemyPosition;

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
