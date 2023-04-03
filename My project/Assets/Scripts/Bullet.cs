using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;


    // Start is called before the first frame update
    public void SetDirection(Vector2 direction, Vector2 verticalImpulse, Vector2 positionToChange)
    {
        rb.velocity = -direction * speed;
        rb.AddForceAtPosition(verticalImpulse, positionToChange);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    void Update()
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
