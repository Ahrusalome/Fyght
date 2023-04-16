using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rbody;
    private Vector2 movement = Vector2.zero;
    public int speed;
    private Animator animator;
    public bool grounded = false;
    public bool frontSpecialAttack = false;
    public bool isGuarding;

    public Vector3 ennemyPosition;

    void Start()
    {
        speed = GetComponent<Stats>().speed;
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
<<<<<<< HEAD
        transform.localScale = new Vector2(isFlipped() ? -0.3f : 0.3f, 0.3f);
        rbody.velocity = new Vector2(movement.x * speed * 2f, rbody.velocity.y);
=======
        // Player sprite reduce to 0.3f ?
        this.transform.rotation = Quaternion.Euler(new Vector3(0, isFlipped() ? 180 : 0, 0));
        rbody.velocity = new Vector2(movement.x * speed/1.5f, rbody.velocity.y);
>>>>>>> d4714549917a8a9fc5c56b0eb6a0291a71a2ca8d
        animator.SetBool("Running", movement.x != 0);
        frontSpecialAttack = (movement.x != 0);
    }

    void OnJump()
    {
        if (grounded)
        {
            rbody.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            grounded = false;
            animator.SetBool("InTheAir", true);
        }
    }

    void OnMove(InputValue val)
    {
        movement = val.Get<Vector2>();
        if ( (movement.x < 0 && this.GetComponent<RectTransform>().localScale.x > 0) ||
         (movement.x > 0 && this.GetComponent<RectTransform>().localScale.x < 0)){
            isGuarding = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            if (contact.normal.y > 0.8f)
            {
                grounded = true;
                animator.SetBool("InTheAir", false);
            }
        }
    }

    private bool isFlipped()
    {
        Vector3 ennemyPosition = Vector3.zero;
        for (int i = 0; i < LevelManager.instance.characterPositions.Count; i++)
        {
            if (LevelManager.instance.characterPositions[i] != this.transform.position)
            {
                ennemyPosition = LevelManager.instance.characterPositions[i];
            }
        }

        bool isRight = ennemyPosition.x > this.transform.position.x;
        return isRight;
    }
    
}
