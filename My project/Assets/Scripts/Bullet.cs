using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = -transform.right * speed;   
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        if (transform.position.x < -20)
        {
            Destroy(gameObject);
        }
        else if (transform.position.x > 20)
        {
            Destroy(gameObject);
        }
    }
}
