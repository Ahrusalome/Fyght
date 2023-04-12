using UnityEngine;
public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = -transform.right * speed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        string name = collision.gameObject.name.Substring(0, collision.gameObject.name.Length - 7);

        foreach (Character character in GameManager.instance.selectedCharacters)
        {
            if (name == character.prefab.name)
            {
                collision.gameObject.GetComponent<HealthManager>().DamagePlayer(10);
            }
            Debug.Log("Bullet hit something : " + name + " " + character.prefab.name);
        }
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
