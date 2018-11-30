using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaOgSnowballmover : MonoBehaviour
{


    Rigidbody2D enemyRigidBody2D;
    public int UnitsToMove = 5;
    public float EnemySpeed = 500;
    public bool _isFacingRight;
    private float _startPos;
    private float _endPos;

    private AudioSource source;
    public AudioClip deathclip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    public bool _moveRight = true;


    // Use this for initialization
    public void Awake()
    {
        enemyRigidBody2D = GetComponent<Rigidbody2D>();
        _startPos = transform.position.x;
        _endPos = _startPos + UnitsToMove;
        _isFacingRight = transform.localScale.x > 0;
        source = GetComponent<AudioSource>();
    }



    // Update is called once per frame
    public void Update()
    {

        if (_moveRight)
        {
            enemyRigidBody2D.AddForce(Vector2.right * EnemySpeed * Time.deltaTime);
            if (!_isFacingRight)
                Flip();
        }

        if (enemyRigidBody2D.position.x >= _endPos)
            _moveRight = false;

        if (!_moveRight)
        {
            enemyRigidBody2D.AddForce(-Vector2.right * EnemySpeed * Time.deltaTime);
            if (_isFacingRight)
                Flip();
        }
        if (enemyRigidBody2D.position.x <= _startPos)
            _moveRight = true;


    }

   
    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        _isFacingRight = transform.localScale.x > 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(deathclip);
            Debug.Log("It is the end");
            Destroy(gameObject, 0.10f);
        }
    }






}
