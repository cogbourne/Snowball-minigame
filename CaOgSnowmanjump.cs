using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaOgSnowmanjump : MonoBehaviour
{

    private Rigidbody2D rb2d;
    public float speed;
    public float jumpforce;

    // Use this for initialization
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();

    }

  
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {

            if (Input.GetKey(KeyCode.UpArrow))
            {

                rb2d.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            }

        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy")
        {
            Debug.Log("It is the end");
            Destroy(gameObject);
        }
    }
}
