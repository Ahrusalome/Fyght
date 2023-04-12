using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;
    public int bounce = 0;


    // Start is called before the first frame update
    public void Launch(Vector3 direction)
    {
        direction = -transform.right+direction;
        rb.velocity = direction * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (bounce > 0 && collision.gameObject.name == "wallLeft") {
            rb.AddForce(new Vector2(200f,100f));
            bounce--;
        } else if (bounce > 0 && collision.gameObject.name == "wallRight") {
            rb.AddForce(new Vector2(-200f,100f));
            bounce--;
        } else if (bounce > 0 && collision.gameObject.name == "wallUp") {
            rb.AddForce(new Vector2(0,-100f));
            bounce--;
        } else if (collision.gameObject.name == gameObject.name) {
        }
        else {
            Destroy(gameObject);
        }
    }
}
